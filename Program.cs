using System;
using System.IO;

namespace ConsoleApp2
{
    internal class Program
    {
        static string text;
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Count words in text \"Lorem ipsum\"");
                Console.WriteLine("2. Math expression");
                Console.WriteLine("3. Exit");

                Console.Write("Enter number: ");
                int number;

                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.Write("Err. Try again");
                }
                switch (number)
                {
                    case 1:
                        try
                        {
                            text = File.ReadAllText("C:\\Users\\Marina Gorshevskaya\\source\\repos\\ConsoleApp2\\ConsoleApp2\\LoremIpsum.txt");
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("File 'LoremIpsum.txt' not found.");
                            Environment.Exit(1);
                        }
                        CountWordsInLoremIpsum();
                        break;

                    case 2:
                        PerformMathOperation();
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Err. Try again");
                        break;
                }
            }
        }
        static void CountWordsInLoremIpsum()
        {
            Console.Write("Enter num of words ");
            if (!int.TryParse(Console.ReadLine(), out int numberOfWords))
            {
                Console.WriteLine("Err");
                return;
            }

            string[] words = text.Split(new[] { ' ', '\t', '\n', '\r' });

            Console.WriteLine($"First {numberOfWords} words:\n");
            for (int i = 0; i < numberOfWords; i++)
            {
                Console.Write(words[i] + " ");
            }
            Console.WriteLine();
        }


        static void PerformMathOperation()
        {
            Console.Write("Enter expression: ");
            string expression = Console.ReadLine();
            try
            {
                double result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Err: {ex.Message}");
            }
        }
    }
}
