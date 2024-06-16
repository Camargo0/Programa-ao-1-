CREATE DATABASE SistemaTransporteAereo;

USE SistemaTransporteAereo;

-- Tabela de Aeronaves
CREATE TABLE Aeronaves (
    id_aeronave INT PRIMARY KEY AUTO_INCREMENT,
    tipo VARCHAR(50) NOT NULL,
    numero_poltronas INT NOT NULL
);

-- Tabela de Clientes Preferenciais
CREATE TABLE ClientesPreferenciais (
    id_cliente INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    telefone VARCHAR(15)
);

-- Tabela de Aeroportos
CREATE TABLE Aeroportos (
    id_aeroporto INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    cidade VARCHAR(100) NOT NULL,
    pais VARCHAR(100) NOT NULL
);

-- Tabela de Voos
CREATE TABLE Voos (
    id_voo INT PRIMARY KEY AUTO_INCREMENT,
    id_aeronave INT,
    aeroporto_origem INT,
    aeroporto_destino INT,
    horario_saida DATETIME NOT NULL,
    horario_chegada DATETIME NOT NULL,
    FOREIGN KEY (id_aeronave) REFERENCES Aeronaves(id_aeronave),
    FOREIGN KEY (aeroporto_origem) REFERENCES Aeroportos(id_aeroporto),
    FOREIGN KEY (aeroporto_destino) REFERENCES Aeroportos(id_aeroporto)
);

-- Tabela de Escalas
CREATE TABLE Escalas (
    id_escala INT PRIMARY KEY AUTO_INCREMENT,
    id_voo INT,
    aeroporto_escala INT,
    horario_saida DATETIME NOT NULL,
    FOREIGN KEY (id_voo) REFERENCES Voos(id_voo),
    FOREIGN KEY (aeroporto_escala) REFERENCES Aeroportos(id_aeroporto)
);

-- Tabela de Poltronas
CREATE TABLE Poltronas (
    id_poltrona INT PRIMARY KEY AUTO_INCREMENT,
    id_aeronave INT,
    localizacao ENUM('janela', 'corredor', 'direita', 'esquerda') NOT NULL,
    disponivel BOOLEAN DEFAULT TRUE,
    FOREIGN KEY (id_aeronave) REFERENCES Aeronaves(id_aeronave)
);

