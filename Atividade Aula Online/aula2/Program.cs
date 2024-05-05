using System;

namespace Atividade_240304
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculadora de Operações Aritméticas");
            Console.WriteLine("-------------------------------------");

            Console.Write("Digite o primeiro número: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o operador (+, -, *, /): ");
            char operador = Convert.ToChar(Console.ReadLine());

            Console.Write("Digite o segundo número: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double resultado = 0;

            switch (operador)
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        resultado = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Erro: Divisão por zero!");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Operador inválido!");
                    return;
            }

            Console.WriteLine($"Resultado: {resultado}");
        }
    }
}