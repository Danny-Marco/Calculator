using System;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class BracketsCalculate
    {
        private string _expression;

        public BracketsCalculate(string expression) => _expression = expression;

        private string Parse()
        {
            const string BracketsRgx = "\\(([1234567890\\.\\+\\-\\*\\/^%]*)\\)";
            Match matchBr = Regex.Match(_expression.Trim(), BracketsRgx);
            return matchBr.ToString();
        }

        private string Calculate()
        {
            var exp = Parse();
            exp = exp.Remove(exp.Length - 1);
            exp = exp.Remove(0, 1);
            var parse = new ParseExpression(exp);
            parse.Result();
            var output = parse.Result();
            return output;
        }
        
        public override string ToString()
        {
            var expression = Parse();
            var value = Calculate();
            _expression = _expression.Replace(expression, value, StringComparison.CurrentCultureIgnoreCase);
            return _expression;
        }
    }
}