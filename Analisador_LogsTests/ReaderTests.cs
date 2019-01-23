using Microsoft.VisualStudio.TestTools.UnitTesting;
using Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace Main.Tests
{
    [TestClass()]
    public class ReaderTests
    {
        [TestMethod()]
        public void FindFileTest()
        {
            string filePath = ConfigurationManager.AppSettings["testFile"];

            Assert.IsNotNull(filePath);
        }

        [TestMethod()]
        public void ReadFileTest()
        {
            string filePath = ConfigurationManager.AppSettings["testFile"];

            FileStream fs = File.OpenRead(filePath);

            Assert.IsNotNull(fs);
        }
    }
}