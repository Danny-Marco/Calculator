using System;
using System.Collections.Generic;

namespace Calculator
{
    public class ExpressionFromConsole : IRepository
    {
        public void Output(string expression)
        {
            var calc = new Calculate(expression);
            var calculate = calc.Calculation();
            var result = $"{expression} = {calculate}";
            Console.WriteLine(result);
        }
    }
}