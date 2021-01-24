using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            ReadExpressionsWriteResult();
        }

        private static void ReadExpressionsWriteResult()
        {
            string path = Directory.GetCurrentDirectory();
            var fileName = "Expressions.txt";
            var expsFromFiles = new ExpressionsFromFile(fileName).Expressions;

            foreach (var exp in expsFromFiles)
            {
                var result = new Calculation().Result(exp);
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
            var rgx = new Regex(@"^[0\.-9+\-*%\/\(\)]*$");
            return rgx.IsMatch(userInput) && userInput.Length > 0 && !StartsWithMathSymbol(userInput);
        }

        private static bool StartsWithMathSymbol(string userInput)
        {
            var firstElement = userInput.First();
            var lastElement = userInput.Last();
            const string mathSymbolsForEnd = "+-*/";
            const string mathSymbolsForStart = "+*/";
            var firstElementIsSymbol = mathSymbolsForStart.Contains(firstElement);
            var lastElementIsSymbol = mathSymbolsForEnd.Contains(lastElement);

            return firstElementIsSymbol || lastElementIsSymbol;
        }
    }
}