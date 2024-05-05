using System;

namespace Tabuada
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tabuada Dinâmica");
            Console.WriteLine("----------------");

            Console.Write("Digite o operador aritmético (+, -, * ou /): ");
            char operador = Convert.ToChar(Console.ReadLine());

            Console.WriteLine($"Tabuada do operador {operador}:");
            Console.WriteLine();

            switch (operador)
            {
                case '+':
                    for (int i = 1; i <= 9; i++)
                    {
                        Console.WriteLine($"1 + {i} = {1 + i}");
                    }
                    break;
                case '-':
                    for (int i = 1; i <= 9; i++)
                    {
                        Console.WriteLine($"1 - {i} = {1 - i}");
                    }
                    break;
                case '*':
                    for (int i = 1; i <= 9; i++)
                    {
                        Console.WriteLine($"1 * {i} = {1 * i}");
                    }
                    break;
                case '/':
                    for (int i = 1; i <= 9; i++)
                    {
                        if (i != 0)
                        {
                            Console.WriteLine($"1 / {i} = {1.0 / i}");
                        }
                        else
                        {
                            Console.WriteLine($"1 / {i} = Indefinido");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Operador inválido!");
                    break;
            }
        }
    }
}