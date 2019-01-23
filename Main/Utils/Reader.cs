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
                throw new FileNotFoundException();
            }

            string[] arr = File.ReadAllLines(fileName);
            
            if (arr.Length <= 0)
            {
                throw new ArithmeticException();
            }

            return arr;
        }
    }
}
