using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class PlusMinusOperation : IObserver
    {
        private const string NumbsRgx = "[-]?\\d+\\.?\\d*";
        private const string PlusMinusRgx = "[\\+\\-]";
        
        public string Parse(string inExpression)
        {
            
            var expression = Regex.Match(inExpression, $"({NumbsRgx})\\s?({PlusMinusRgx})\\s?({NumbsRgx})\\s?");
            var value = Calculate(expression);
            var findExpression = expression.ToString();
            string outExpression = ReplaceExpression(inExpression, findExpression, value);
            return outExpression;
        }

        public string Calculate(Match expression)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            var a = double.Parse(expression.Groups[1].Value, CultureInfo.InvariantCulture);
            var b = double.Parse(expression.Groups[3].Value, CultureInfo.InvariantCulture);

            switch (expression.Groups[2].Value)
            {
                case "+": return (a + b).ToString();
                case "-": return (a - b).ToString();
                default: throw new FormatException($"Неверная входная строка '{expression.Value}'");
            }
        }

        public string ReplaceExpression(string inExpression, string expression, string value)
        {
            inExpression = inExpression.Replace(expression, value, StringComparison.CurrentCultureIgnoreCase);
            return inExpression;
        }

        public bool IsHaveCurrentOperator(string expression)
        {
            var operation = Regex.Match(expression, $"({NumbsRgx})\\s?({PlusMinusRgx})\\s?({NumbsRgx})\\s?");
            return operation.Value.Length > 0;
        }

        public string ProcessCurrentOperation(string expression)
        {
            while (IsHaveCurrentOperator(expression))
            {
                expression = Parse(expression);
            }

            return expression;
        }
    }
}