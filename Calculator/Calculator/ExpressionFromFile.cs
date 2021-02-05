
namespace Calculator
{
    public class ExpressionFromFile : IRepository
    {
        public void Output(string expression)
        {
            var result = new Calculate(expression).Calculation();
            var writeExp = new WriteExpressionToFile(expression, result);
            writeExp.WriteToFile();
        }
    }
}