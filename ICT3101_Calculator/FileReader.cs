using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT3101_Calculator
{
    public class FileReader : IFileReader
    {
        public string[] Read(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
