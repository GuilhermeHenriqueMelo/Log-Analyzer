using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Utils
{
    public class Reader
    {
        public static string[] ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("Check if the file is in the correct place");
            }

            string[] arr = File.ReadAllLines(fileName);
            
            if (arr.Length <= 0)
            {
                throw new ArithmeticException("The file doesn't have any line to be read");
            }

            return arr;
        }
    }
}
