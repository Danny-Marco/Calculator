using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class ParenthesesOperation : IObserver
    {
        const string BracketsRgx = "\\(([1234567890\\.\\+\\-\\*\\/^%]*)\\)";
        private readonly List<IObserver> _observers;

        public ParenthesesOperation()
        {
            _observers = new List<IObserver>
            {
                new MultDivOperation(),
                new PlusMinusOperation(),
            };
        }

        public string Parse(string inExpression)
        {
            var matchBr = Regex.Match(inExpression.Trim(), BracketsRgx);
            var value = Calculate(matchBr);
            var findExpression = matchBr.ToString();
            string outExpression = ReplaceExpression(inExpression, findExpression, value);
            return outExpression;
        }

        public string Calculate(Match expression)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            var brackExp = expression.ToString();
            brackExp = brackExp.Remove(brackExp.Length - 1);
            brackExp = brackExp.Remove(0, 1);

            foreach (var observer in _observers)
            {
                brackExp = observer.ProcessCurrentOperation(brackExp);
            }

            return brackExp;
        }

        public string ReplaceExpression(string inExpression, string expression, string value)
        {
            inExpression = inExpression.Replace(expression, value, StringComparison.CurrentCultureIgnoreCase);
            return inExpression;
        }

        public bool IsHaveCurrentOperator(string expression)
        {
            var operation = Regex.Match(expression.Trim(), BracketsRgx);
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