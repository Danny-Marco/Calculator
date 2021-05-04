using System.IO;

namespace Calculator
{
    public class WriteExpressionToFile
    {
        private readonly string _lineForWrite;

        public WriteExpressionToFile(string inExpression, string expressionResult)
        {
            _lineForWrite = $"{inExpression} = {expressionResult}";
        }

        public void WriteToFile()
        {
            var fileName = "Result.txt";
            var aFile = new FileStream(fileName, FileMode.OpenOrCreate);
            var sw = new StreamWriter(aFile);
            aFile.Seek(0, SeekOrigin.End);
            sw.WriteLine(_lineForWrite);
            sw.Close();
        }
    }
}