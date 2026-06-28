import time
import tkinter as tk
from tkinter import filedialog
import cv2
from PIL import Image, ImageTk
from ultralytics import YOLO

# ==============================================================================
# 1. CONFIGURAÇÕES INICIAIS
# ==============================================================================
modelo = YOLO("yolov8n.pt")

# Dicionário base de tradução
traducao = {"cell phone": "CELULAR", "remote": "CONTROLE DE TV"}

cap = None
rodando_webcam = False

# ==============================================================================
# 2. FUNÇÕES DE PROCESSAMENTO E VISÃO COMPUTACIONAL
# ==============================================================================


def processar_frame(frame):
    """Aplica IA, filtra falsos positivos (pilha) e ajusta os nomes."""
    t_inicio = time.time()

    # Roda a IA apenas para controle (65) e celular (67)
    resultados = modelo(frame, classes=[65, 67], verbose=False)

    t_fim = time.time()
    tempo_ms = (t_fim - t_inicio) * 1000
    lbl_tempo.config(text=f"Tempo da IA: {tempo_ms:.1f} ms")

    frame_ia = frame.copy()
    objeto_detectado = False

    for box in resultados[0].boxes:
        # Coordenadas da caixa
        x1, y1, x2, y2 = map(int, box.xyxy[0])

        # Calcula largura, altura e a área total em pixels da caixa
        largura = x2 - x1
        altura = y2 - y1
        area = largura * altura

        nome_ingles = resultados[0].names[int(box.cls[0])]
        confianca = float(box.conf[0])

        # Tradução padrão
        nome_portugues = traducao.get(nome_ingles, nome_ingles)

        # --- FILTRO PARA A PILHA (FALSO POSITIVO) ---
        # Se a IA achar que é um celular, mas o objeto for muito pequeno na tela (área menor que 12000 pixels),
        # significa que é uma pilha ou um objeto pequeno, e não um celular de verdade.
        if nome_portugues == "CELULAR" and area < 12000:
            nome_portugues = "PILHA"

        # --- TRUQUE BIOMÉTRICO (Xbox vs TV) ---
        elif nome_portugues == "CONTROLE DE TV" and (largura / altura) > 1.1:
            nome_portugues = "CONTROLE DE XBOX"

        # Define as cores de exibição baseado no objeto correto
        if nome_portugues == "CELULAR":
            cor = (255, 0, 0)  # Azul
        elif nome_portugues == "CONTROLE DE XBOX":
            cor = (0, 255, 0)  # Verde
        elif nome_portugues == "PILHA":
            cor = (0, 165, 255)  # Laranja para a Pilha
        else:
            cor = (0, 0, 255)  # Vermelho para controle de TV

        objeto_detectado = True
        texto = f"{nome_portugues} ({confianca*100:.0f}%)"

        # Desenha a caixa e o texto corrigido
        cv2.rectangle(frame_ia, (x1, y1), (x2, y2), cor, 3)
        cv2.putText(
            frame_ia,
            texto,
            (x1, y1 - 10),
            cv2.FONT_HERSHEY_SIMPLEX,
            0.6,
            cor,
            2,
        )

    # --- PROCESSAMENTO DE IMAGEM (FILTRO DE BORDAS CANNY) ---
    frame_cinza = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    frame_bordas = cv2.Canny(frame_cinza, 100, 200)

    if objeto_detectado:
        lbl_resultado.config(text="STATUS: OBJETO DETECTADO", fg="green")
    else:
        lbl_resultado.config(text="STATUS: PROCURANDO...", fg="black")

    return frame_ia, frame_bordas


def atualizar_webcam():
    global cap, rodando_webcam
    if rodando_webcam:
        sucesso, frame = cap.read()
        if sucesso:
            frame_ia, frame_bordas = processar_frame(frame)

            img_rgb = cv2.cvtColor(frame_ia, cv2.COLOR_BGR2RGB)
            img_pil = Image.fromarray(img_rgb).resize((400, 300))
            img_tk = ImageTk.PhotoImage(image=img_pil)
            painel_ia.config(image=img_tk)
            painel_ia.image = img_tk

            img_bordas_pil = Image.fromarray(frame_bordas).resize((400, 300))
            img_bordas_tk = ImageTk.PhotoImage(image=img_bordas_pil)
            painel_proc.config(image=img_bordas_tk)
            painel_proc.image = img_bordas_tk

        janela.after(15, atualizar_webcam)


# ==============================================================================
# 3. CONTROLES DOS BOTÕES
# ==============================================================================


def ligar_desligar_webcam():
    global cap, rodando_webcam
    if not rodando_webcam:
        cap = cv2.VideoCapture(0)
        if cap.isOpened():
            rodando_webcam = True
            btn_webcam.config(text="Parar Câmera", bg="red", fg="white")
            atualizar_webcam()
    else:
        rodando_webcam = False
        if cap:
            cap.release()
        btn_webcam.config(text="Iniciar Câmera", bg="SystemButtonFace", fg="black")
        painel_ia.config(image="", text="Câmera Desligada")
        painel_proc.config(image="", text="Sem Filtro")


def carregar_foto():
    global rodando_webcam
    if rodando_webcam:
        ligar_desligar_webcam()

    caminho = filedialog.askopenfilename(
        filetypes=[("Imagens", "*.jpg *.jpeg *.png")]
    )
    if caminho:
        frame = cv2.imread(caminho)
        frame_ia, frame_bordas = processar_frame(frame)

        img_rgb = cv2.cvtColor(frame_ia, cv2.COLOR_BGR2RGB)
        img_pil = Image.fromarray(img_rgb).resize((400, 300))
        img_tk = ImageTk.PhotoImage(image=img_pil)
        painel_ia.config(image=img_tk)
        painel_ia.image = img_tk

        img_bordas_pil = Image.fromarray(frame_bordas).resize((400, 300))
        img_bordas_tk = ImageTk.PhotoImage(image=img_bordas_pil)
        painel_proc.config(image=img_bordas_tk)
        painel_proc.image = img_bordas_tk


# ==============================================================================
# 4. INTERFACE GRÁFICA NATIVA (TKINTER)
# ==============================================================================
janela = tk.Tk()
janela.title("Trabalho de Visão Computacional")
janela.geometry("850x450")

frame_controles = tk.Frame(janela)
frame_controles.pack(side="top", fill="x", pady=10)

btn_webcam = tk.Button(
    frame_controles, text="Iniciar Câmera", command=ligar_desligar_webcam, padx=10
)
btn_webcam.pack(side="left", padx=10)

btn_foto = tk.Button(
    frame_controles, text="Carregar Foto", command=carregar_foto, padx=10
)
btn_foto.pack(side="left", padx=10)

lbl_tempo = tk.Label(frame_controles, text="Tempo da IA: 0.0 ms", font=("Arial", 10))
lbl_tempo.pack(side="right", padx=20)

lbl_resultado = tk.Label(
    frame_controles, text="STATUS: AGUARDANDO", font=("Arial", 10, "bold")
)
lbl_resultado.pack(side="right", padx=20)

frame_telas = tk.Frame(janela)
frame_telas.pack(side="bottom", fill="both", expand=True, pady=10)

painel_ia = tk.Label(
    frame_telas, text="Câmera Desligada", relief="solid", bd=1, bg="white"
)
painel_ia.pack(side="left", fill="both", expand=True, padx=10, pady=10)

painel_proc = tk.Label(
    frame_telas, text="Sem Filtro", relief="solid", bd=1, bg="white"
)
painel_proc.pack(side="right", fill="both", expand=True, padx=10, pady=10)

janela.mainloop()