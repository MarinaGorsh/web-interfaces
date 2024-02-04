using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Code");
            Console.WriteLine("2. File");
            Console.WriteLine("3. List of Files in Directory");
            Console.WriteLine("4. Which even?");
            Console.WriteLine("5. Exit");

            Console.Write("Enter number: ");
            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Err. Try again: ");
            }

            switch (number)
            {
                case 1:
                    await DownloadPageAsync();
                    break;

                case 2:
                    string filePath = "output.html";
                    Console.Write("Enter the text to write to the file: ");
                    string fileContent = Console.ReadLine();

                    File.WriteAllText(filePath, fileContent);
                    Console.WriteLine("Content has been written to the file.");
                    break;

                case 3:
                    string directoryPath = ".";
                    var files = new DirectoryInfo(directoryPath).EnumerateFiles();
                    foreach (var file in files)
                    {
                        Console.WriteLine($"File: {file.Name}");
                    }
                    break;
                case 4:
                    Console.Write("Enter numbers");
                    string inputNumbers = Console.ReadLine();

                    int[] numbers = inputNumbers.Split(' ')
                                                .Select(str => int.TryParse(str, out int num) ? num : 0)
                                                .ToArray();

                    var evenNumbers = numbers.Where(n => n % 2 == 0);

                    Console.WriteLine("Even Numbers:");
                    foreach (var num in evenNumbers)
                    {
                        Console.WriteLine(num);
                    }
                    break;
                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Err. Try again");
                    break;
            }
        }
    }

    static async Task DownloadPageAsync()
    {
        Console.Write("Enter the number of lines to download from the page: ");
        int numberOfLines;

        while (!int.TryParse(Console.ReadLine(), out numberOfLines))
        {
            Console.Write("Err. Try again: ");
        }

        string page = "http://en.wikipedia.org/";

        using (HttpClient client = new HttpClient())
        using (HttpResponseMessage response = await client.GetAsync(page))
        using (HttpContent content = response.Content)
        {
            string result = await content.ReadAsStringAsync();

            if (result != null && result.Length >= numberOfLines)
            {
                Console.WriteLine(result.Substring(0, numberOfLines) + "...");
            }
        }
    }
}
