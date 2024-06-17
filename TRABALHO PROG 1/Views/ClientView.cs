using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arquivos.Controllers;
using Arquivos.Data;
using Arquivos.Models;

namespace Arquivos.Views
{
  public class ClientView
  {
    private ClientController clientController;

    public ClientView()
    {
      clientController = new ClientController();
      this.Init();
    }

    public void Init()
    {
      Console.WriteLine("************************");
      Console.WriteLine("Você está em Clientes!");
      Console.WriteLine("************************");
      Console.WriteLine("");
      Console.WriteLine("1 - Inserir Cliente");
      Console.WriteLine("2 - Listar Cliente");
      Console.WriteLine("3 - Exportar Cliente");
      Console.WriteLine("4 - Importar Cliente");
      Console.WriteLine("5 - Pesquisar Cliente");
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
      List<Client> listagem = clientController.List();

      for (int i = 0; i < listagem.Count; i++)
      {
        Console.WriteLine(Print(listagem[i]));
      }
    }

    private string Print(Client client)
    {
      string retorno = "";

      retorno += $"ID: {client.Id} \n";
      retorno += $"Nome: {client.FirstName} {client.LastName} \n";
      retorno += "-------------------------------------------";

      return retorno;
    }

    private void Insert()
    {
      Client client = new Client();
      client.Id = clientController.GetNextId();

      Console.WriteLine("Informe o seu primeiro nome:");
      client.FirstName = Console.ReadLine();

      Console.WriteLine("Informe o seu sobrenome:");
      client.LastName = Console.ReadLine();

      Console.WriteLine("Informe o seu CPF:");
      client.CPF = Console.ReadLine();

      Console.WriteLine("Informe o seu email:");
      client.Email = Console.ReadLine();

      bool retorno = clientController.Insert(client);
      if (retorno)
        Console.WriteLine("Cliente inserido com sucesso!");
      else
        Console.WriteLine("Falha ao inserir, verifique seus dados");

    }

    private void Export()
    {
      if (clientController.ExportToTextFile())
        Console.WriteLine("Arquivo gerado com sucesso!");
      else
        Console.WriteLine("Ops, algo deu errado.");
    }

    private void Import()
    {
      if (clientController.ImportFromTxtFile())
        Console.WriteLine("Dados importados com sucesso!");
      else
        Console.WriteLine("Ops, algo deu errado.");
    }

    private void SearchByName()
    {
      Console.WriteLine("Pesquisar cliente pelo nome.");
      Console.WriteLine("Digite o nome:");
      string name = Console.ReadLine();

      foreach (Client c in clientController.SearchByName(name))
      {
        Console.WriteLine(c.ToString());
      }

    }
  }
}