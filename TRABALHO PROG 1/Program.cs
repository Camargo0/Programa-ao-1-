using Arquivos.Views;
using Arquivos.Utils;
// Programa para leitura de dados de pessoas e exportação em arquivo .txt

Bootstrapper.ChargeClients();
Bootstrapper.ChargeDoctors();
Bootstrapper.ChargeAnimals();

int option = 0;
do
{
  Console.WriteLine("**********************************");
  Console.WriteLine("Programa para leitura e exportação de dados");
  Console.WriteLine("**********************************");
  Console.WriteLine("");
  Console.WriteLine("1 - Clientes");
  Console.WriteLine("2 - Animais");
  Console.WriteLine("3 - Médicos");
  Console.WriteLine("");
  Console.WriteLine("0 - Sair");

  option = Convert.ToInt32(Console.ReadLine());

  switch (option)
  {
    case 1:
      Console.WriteLine("OPÇÃO CLIENTES");
      ClientView clientView = new ClientView();
      break;

    case 2:
      Console.WriteLine("OPÇÃO ANIMAIS");
      AnimalView animalView = new AnimalView();
      break;

    case 3:
      Console.WriteLine("OPÇÃO MÉDICOS");
      MedicosView medicosView = new MedicosView();
      break;

  }
}

while (option > 0);