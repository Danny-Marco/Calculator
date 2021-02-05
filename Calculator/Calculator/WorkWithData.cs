using System;
using System.IO;

namespace Calculator
{
    public class WorkWithData
    {
        private IRepository _repository;

        public void ReadingWriting()
        {
            while (true)
            {
                Console.Write("Введите математическое выражение или путь к файлу: ");
                var path = Console.ReadLine();
                if (File.Exists(path))
                {
                    WritingResult(path);
                    break;
                }

                if (path == "" || path == " ")
                {
                    Console.WriteLine("Вы ничего не ввели!\n");
                }

                else
                {
                    _repository = new ExpressionFromConsole();
                    _repository.Output(path);
                    break;
                }
            }
        }

        private void WritingResult(string path)
        {
            var expressions = new ExpressionsFromFile(path).Expressions;
            if (expressions.Count > 0)
            {
                _repository = new ExpressionFromFile();
                foreach (var expression in expressions)
                {
                    _repository.Output(expression);
                }

                Console.WriteLine("Файл с результатами математических выражений записан!");
                Console.WriteLine($"Путь к файлу: {Directory.GetCurrentDirectory()}");
            }
            else
            {
                Console.WriteLine("Файл пустой!");
            }
        }
    }
}