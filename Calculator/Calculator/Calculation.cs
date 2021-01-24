using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class Calculation
    {
        private const string BracketsRgx = "\\(([1234567890\\.\\+\\-\\*\\/^%]*)\\)";
        private const string NumbsRgx = "[-]?\\d+\\.?\\d*";
        private const string MultDevRgx = "[\\*\\/^%]";
        private const string PlusMinusRgx = "[\\+\\-]";

        public static string Result(string expression)
        {
            while (true)
            {
                var matchSk = Regex.Match(expression.Trim(), BracketsRgx);
                if (matchSk.Groups.Count > 1)
                {
                    string inner = matchSk.Groups[0].Value.Substring(1, matchSk.Groups[0].Value.Trim().Length - 2);
                    string left = expression.Substring(0, matchSk.Index);
                    string right = expression.Substring(matchSk.Index + matchSk.Length);

                    expression = left + Result(inner).ToString(CultureInfo.InvariantCulture) + right;
                    continue;
                }

                var matchMulOp = Regex.Match(expression, $"({NumbsRgx})\\s?({MultDevRgx})\\s?({NumbsRgx})\\s?");
                var matchAddOp = Regex.Match(expression, $"({NumbsRgx})\\s?({PlusMinusRgx})\\s?({NumbsRgx})\\s?");
                var match = matchMulOp.Groups.Count > 1 ? matchMulOp : matchAddOp.Groups.Count > 1 ? matchAddOp : null;
                if (match != null)
                {
                    string left = expression.Substring(0, match.Index);
                    string right = expression.Substring(match.Index + match.Length);
                    expression = left + Calculate(match).ToString(CultureInfo.InvariantCulture) + right;
                    continue;
                }

                try
                {
                    return double.Parse(expression, CultureInfo.InvariantCulture).ToString();
                }
                catch (FormatException)
                {
                    return "Ошибка в выражении!";
                }
            }
        }

        private static double Calculate(Match match)
        {
            var a = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
            var b = double.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
            var result = "Ошибка в выражении!";

            switch (match.Groups[2].Value)
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/": return a / b;
                default: throw new FormatException($"Неверная входная строка '{match.Value}'");
            }
        }
    }
}