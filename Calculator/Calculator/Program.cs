using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var oper = GetOperation();
            Console.WriteLine(oper);
        }

        private static string GetOperation()
        {
            while (true)
            {
                Console.Write("Ввудите операцию: ");
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
            var rgx = new Regex(@"^[0-9+\-*%\/\(\)]*$");
            return rgx.IsMatch(userInput) && userInput.Length > 0 && !StartsWithMathSymbol(userInput);
        }

        private static bool StartsWithMathSymbol(string userInput)
        {
            var firstElement = userInput.First();
            var lastElement = userInput.Last();
            var firstElementIsSymbol =
                firstElement == '+'
                || firstElement == '/'
                || firstElement == '%'
                || firstElement == '*';
            var lastElementIsSymbol =
                lastElement == '+'
                || lastElement == '-'
                || lastElement == '/'
                || lastElement == '%'
                || lastElement == '*';
            
            return firstElementIsSymbol || lastElementIsSymbol;
        }
    }
}