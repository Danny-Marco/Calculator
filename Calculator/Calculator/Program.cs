using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var userInput = "1x+2*(3+2)"; // = 11
            var result = Calculation.Result(userInput);
            Console.WriteLine(result);
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