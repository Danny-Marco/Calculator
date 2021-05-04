using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Calculate
    {
        private string _expression;
        private readonly List<IObserver> _observers;

        public Calculate(string expression)
        {
            _expression = expression;
            _observers = new List<IObserver>
            {
                new ParenthesesOperation(),
                new MultDivOperation(),
                new PlusMinusOperation()
            };
        }

        public string Calculation()
        {
            foreach (var observer in _observers)
            {
                _expression = observer.ProcessCurrentOperation(_expression);
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