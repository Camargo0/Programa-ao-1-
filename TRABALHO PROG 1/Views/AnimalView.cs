using Arquivos.Controllers;
using Arquivos.Models;
using Arquivos.Data;

namespace Arquivos.Views
{
  public class AnimalView
  {

    private AnimalController animalController;

    public AnimalView()
    {
      animalController = new AnimalController();
      this.Init();
    }

    public void Init()
    {
      Console.WriteLine("------------------------");
      Console.WriteLine("Você está em Animais!");
      Console.WriteLine("------------------------");
      Console.WriteLine("");
      Console.WriteLine("1 - Inserir Animais");
      Console.WriteLine("2 - Listar Animais");
      Console.WriteLine("3 - Exportar Animais");
      Console.WriteLine("4 - Importar Animais");
      Console.WriteLine("5 - Pesquisar Animais");
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
      List<Animal> listagem = animalController.List();

      for (int i = 0; i < listagem.Count; i++)
      {
        Console.WriteLine(Print(listagem[i]));
      }
    }

    private string Print(Animal animal)
    {
      string retorno = "";

      retorno += $"ID: {animal.Id} \n";
      retorno += $"Nome: {animal.Name} \n";
      retorno += $"Raça: {animal.Raca} \n";
      retorno += "------------------------------------------- \n";

      return retorno;
    }

    private void Insert()
    {
      Animal animal = new Animal();
      animal.Id = animalController.GetNextId();

      Console.WriteLine("Informe o nome do seu animal:");
      animal.Name = Console.ReadLine();

      Console.WriteLine("Informe o tipo do seu animal(cachorro, gato, etc..):");
      animal.Tipo = Console.ReadLine();

      Console.WriteLine("Informe a raça do seu animal:");
      animal.Raca = Console.ReadLine();

      bool retorno = animalController.Insert(animal);
      if (retorno)
        Console.WriteLine("Animal inserido com sucesso!");
      else
        Console.WriteLine("Falha ao inserir, verifique os dados");

    }

    private void Export()
    {
      if (animalController.ExportToTextFile())
        Console.WriteLine("Arquivo gerado com sucesso!");
      else
        Console.WriteLine("Ops, algo deu errado.");
    }

    private void Import()
    {
      if (animalController.ImportFromTxtFile())
        Console.WriteLine("Dados importados com sucesso!");
      else
        Console.WriteLine("Ops, algo deu errado.");
    }

    private void SearchByName()
    {
      Console.WriteLine("Pesquisar animal pelo nome.");
      Console.WriteLine("Digite o nome:");
      string name = Console.ReadLine();

      foreach (Animal a in animalController.SearchByName(name))
      {
        Console.WriteLine(a.ToString());
      }

    }
  }
}