using System;

namespace FichaCadastral
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("== FICHA CADASTRAL ==");

            // Coletando os dados do usuário
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("E-mail: ");
            string email = Console.ReadLine();

            Console.Write("Data de nascimento (DD/MM/AAAA): ");
            DateTime dataNascimento;
            while (!DateTime.TryParse(Console.ReadLine(), out dataNascimento))
            {
                Console.WriteLine("Formato inválido! Use o formato DD/MM/AAAA.");
                Console.Write("Data de nascimento (DD/MM/AAAA): ");
            }

            Console.Write("Sexo ou gênero: ");
            string genero = Console.ReadLine();

            Console.Write("CEP: ");
            string cep = Console.ReadLine();

            Console.Write("Rua: ");
            string rua = Console.ReadLine();

            Console.Write("Número: ");
            string numero = Console.ReadLine();

            Console.Write("Bairro: ");
            string bairro = Console.ReadLine();

            Console.Write("Cidade: ");
            string cidade = Console.ReadLine();

            Console.Write("UF: ");
            string uf = Console.ReadLine();

            Console.Write("País: ");
            string pais = Console.ReadLine();

            // Exibindo os dados cadastrados
            Console.WriteLine("\n== DADOS CADASTRADOS ==\n");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"E-mail: {email}");
            Console.WriteLine($"Data de nascimento: {dataNascimento.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Sexo ou gênero: {genero}");
            Console.WriteLine($"CEP: {cep}");
            Console.WriteLine($"Rua: {rua}");
            Console.WriteLine($"Número: {numero}");
            Console.WriteLine($"Bairro: {bairro}");
            Console.WriteLine($"Cidade: {cidade}");
            Console.WriteLine($"UF: {uf}");
            Console.WriteLine($"País: {pais}");

            Console.WriteLine("\nObrigado por se cadastrar!");
        }
    }
