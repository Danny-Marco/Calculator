using System.Text.RegularExpressions;

namespace Calculator
{
    public interface IObserver
    {
        string Parse(string inExpression);
        string Calculate(Match expression);
        string ReplaceExpression(string inExpression, string expression, string value);
        bool IsHaveCurrentOperator(string expression);
        string ProcessCurrentOperation(string expression);
    }
}