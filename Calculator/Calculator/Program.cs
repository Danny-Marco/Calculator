using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var path = GetPathFromUser();
            ReadExpressionsWriteResult(path);
        }

        private static void ReadExpressionsWriteResult(string fileName)
        {
            string path = Directory.GetCurrentDirectory();
            var expsFromFiles = new ExpressionsFromFile(fileName).Expressions;

            foreach (var exp in expsFromFiles)
            {
                var result = new Calculate(exp).Calculation();
                var writeExp = new WriteExpressionToFile(exp, result);
                writeExp.WriteToFile();
            }

            Console.WriteLine("Файл записан!");
            Console.WriteLine($"Текущий путь к файлу: {path}");
        }

        private static string GetOperation()
        {
            while (true)
            {
                Console.Write("Введите операцию: ");
                var userInput = Console.ReadLine();
                if (!CheckOperation(userInput))
                {
                    Console.WriteLine("Операция не валидна!\n");
                }
                else
                {
                    return userInput;
                }
            }
        }

        public static bool CheckOperation(string userInput)
        {
            userInput = userInput.Replace(" ", "");
            // var rgx = new Regex(@"^-[0\.-9+\-*%\/\(\)]*$");
            var rgx = new Regex(@"^(?:\d+|\(\d+\s*[-+/*]\s*\d+\))(?:\s*[-+/*]\s*(?:\d+|\(\d+\s*[-+/*]\s*\d+\)))*$");
            return rgx.IsMatch(userInput) && userInput.Length > 0;
        }

        private static string GetPathFromUser()
        {
            while (true)
            {
                Console.WriteLine("Введите путь к файлу");
                var path = Console.ReadLine();
                try
                {
                    string content = File.ReadAllText(path);
                    if (string.IsNullOrEmpty(content))
                    {
                        throw new ApplicationException($"файл пустой");
                    }

                    return path;
                }

                catch (FileNotFoundException)
                {
                    Console.WriteLine("По указанному пути файл не найден!\n");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Вы ничего не ввели!\n");
                }
                catch (ApplicationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}