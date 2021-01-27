using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class PlusMinusCalculate
    {
        private string _expression;

        public PlusMinusCalculate(string expression) => _expression = expression;

        private Match Parse(string expression)
        {
            const string NumbsRgx = "[-]?\\d+\\.?\\d*";
            const string PlusMinusRgx = "[\\+\\-]";
            var matchAddOp = Regex.Match(expression, $"({NumbsRgx})\\s?({PlusMinusRgx})\\s?({NumbsRgx})\\s?");
            return matchAddOp;
        }

        private string Calculate()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Match expression = Parse(_expression);
            var a = double.Parse(expression.Groups[1].Value, CultureInfo.InvariantCulture);
            var b = double.Parse(expression.Groups[3].Value, CultureInfo.InvariantCulture);

            switch (expression.Groups[2].Value)
            {
                case "+": return (a + b).ToString();
                case "-": return (a - b).ToString();
                default: throw new FormatException($"Неверная входная строка '{expression.Value}'");
            }
        }

        public override string ToString()
        {
            var expression = Parse(_expression).ToString();
            var value = Calculate();
            _expression = _expression.Replace(expression, value, StringComparison.CurrentCultureIgnoreCase);
            return _expression;
        }
    }
}