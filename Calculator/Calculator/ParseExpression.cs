using System;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class ParseExpression
    {
        private const string BracketsRgx = "\\(([1234567890\\.\\+\\-\\*\\/^%]*)\\)";
        private const string NumbsRgx = "[-]?\\d+\\.?\\d*";
        private const string MultDivRgx = "[\\*\\/^%]";
        private const string PlusMinusRgx = "[\\+\\-]";

        private string _expression;
        private static Match _operation;

        public ParseExpression(string expression) => _expression = expression;

        private bool IsHaveBrackets()
        {
            _operation = Regex.Match(_expression.Trim(), BracketsRgx);
            return _operation.Groups.Count > 1;
        }

        private bool IsHaveMultDiv()
        {
            _operation = Regex.Match(_expression, $"({NumbsRgx})\\s?({MultDivRgx})\\s?({NumbsRgx})\\s?");
            return _operation.Value.Length > 0;
        }

        private bool IsHavePlusMinus()
        {
            _operation = Regex.Match(_expression, $"({NumbsRgx})\\s?({PlusMinusRgx})\\s?({NumbsRgx})\\s?");
            return _operation.Value.Length > 0;
        }

        public string Result()
        {
            while (IsHaveBrackets())
            {
                _expression = new BracketsCalculate(_expression).ToString();
            }

            while (IsHaveMultDiv())
            {
                _expression = new MultDivCalculate(_expression).ToString();
            }

            while (IsHavePlusMinus())
            {
                _expression = new PlusMinusCalculate(_expression).ToString();
            }

            try
            {
                _expression = double.Parse(_expression).ToString();
            }
            catch (FormatException)
            {
                _expression = "Ошибка в выражении!";
            }

            return _expression;
        }
    }
}