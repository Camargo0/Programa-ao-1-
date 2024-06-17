using Arquivos.Controllers;
using Arquivos.Data;
using Arquivos.Models;

namespace Arquivos.Views
{
  public class MedicosView
  {

    private MedicoController medicoController;

    public MedicosView()
    {
      medicoController = new MedicoController();
      this.Init();
    }

    public void Init()
    {
      Console.WriteLine("*********************");
      Console.WriteLine("Você está em médicos!");
      Console.WriteLine("*********************");
      Console.WriteLine("");
      Console.WriteLine("1 - Inserir médicos");
      Console.WriteLine("2 - Listar médicos");
      Console.WriteLine("3 - Exportar médicos");
      Console.WriteLine("4 - Importar médicos");
      Console.WriteLine("5 - Pesquisar médicos");
      Console.WriteLine("");
      Console.WriteLine("0 - Voltar");

      int option = 0;
      option = Convert.ToInt32(Console.ReadLine());

      switch (option)
      {
        case 0:
          break;

        case 1:
          Insert();
          break;

        case 2:
          List();
          break;

        case 3:
          Export();
          break;

        case 4:
          Import();
          break;

        case 5:
          SearchByName();
          break;

        default:
          Console.WriteLine("Opção inválida, tente novamente.");
          break;
      }
    }

    private void List()
    {
      List<Medico> listagem = medicoController.List();

      for (int i = 0; i < listagem.Count; i++)
      {
        Console.WriteLine(Print(listagem[i]));
      }
    }

    private string Print(Medico medico)
    {
      string retorno = "";

      retorno += $"ID: {medico.Id} \n";
      retorno += $"Nome: {medico.FirstName} {medico.LastName} \n";
      retorno += $"CRM: {medico.CRM} \n";
      retorno += "------------------------------------------- \n";

      return retorno;
    }

    private void Insert()
    {
      Medico medico = new Medico();
      medico.Id = medicoController.GetNextId();

      Console.WriteLine("Informe o seu primeiro nome:");
      medico.FirstName = Console.ReadLine();

      Console.WriteLine("Informe o seu sobrenome:");
      medico.LastName = Console.ReadLine();

      Console.WriteLine("Informe o seu CPF:");
      medico.CPF = Console.ReadLine();

      Console.WriteLine("Informe o seu CRM:");
      medico.CRM = Console.ReadLine();

      bool retorno = medicoController.Insert(medico);
      if (retorno)
        Console.WriteLine("Médico inserido com sucesso!");
      else
        Console.WriteLine("Falha ao inserir, verifique seus dados");

    }

    private void Export()
    {
      if (medicoController.ExportToTextFile())
        Console.WriteLine("Arquivo gerado com sucesso!");
      else
        Console.WriteLine("Ops, algo deu errado.");
    }

    private void Import()
    {
      if (medicoController.ImportFromTxtFile())
        Console.WriteLine("Dados importados com sucesso!");
      else
        Console.WriteLine("Ops, algo deu errado.");
    }

    private void SearchByName()
    {
      Console.WriteLine("Pesquisar médico pelo nome.");
      Console.WriteLine("Digite o nome:");
      string name = Console.ReadLine();

      foreach (Medico m in medicoController.SearchByName(name))
      {
        Console.WriteLine(m.ToString());
      }

    }
  }
}