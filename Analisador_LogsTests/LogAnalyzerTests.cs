using Microsoft.VisualStudio.TestTools.UnitTesting;
using Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Main.Utils;
using Main.Analyzers;

namespace Main.Tests
{
    [TestClass()]
    public class LogAnalyzerTests
    {
        [TestMethod()]
        public void DefineGameSectionsTest()
        {
            string[] arr = Reader.ReadFile(ConfigurationManager.AppSettings["gamesSection"]);

            Assert.IsNotNull(arr);


            LogAnalyzer log = new LogAnalyzer(arr);

            List<string[]> info = log.DefineGameSections();

            Assert.IsNotNull(info);
            Assert.AreNotEqual(1, info.Count);

            Assert.AreEqual(3, info.Count);
        }
    }
}