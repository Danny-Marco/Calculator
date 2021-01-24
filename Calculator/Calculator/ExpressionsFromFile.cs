using System.Collections.Generic;
using System.IO;

namespace Calculator
{
    public class ExpressionsFromFile
    {
        public List<string> Expressions { get; }
        private string _path;

        public ExpressionsFromFile(string fileName)
        {
            _path = Path.GetFullPath(fileName);
            Expressions = ReadFileDataToList(_path);
        }
        
        private List<string> ReadFileDataToList(string path)
        {
            var lines = new List<string>();
            using var sr = new StreamReader(path, System.Text.Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines;
        }
    }
    
    
}