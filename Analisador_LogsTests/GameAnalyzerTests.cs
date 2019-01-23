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
using Main.POCO;

namespace Main.Tests
{
    [TestClass()] // Do more test to generate more games!
    public class GameAnalyzerTests
    {
        [TestMethod()]
        public void GenerateGameResultTest()
        {
            string[] logInfo = Reader.ReadFile(ConfigurationManager.AppSettings["gamesSection"]);
            LogAnalyzer log = new LogAnalyzer(logInfo);

            Game game = null;

            GameAnalyzer gA = new GameAnalyzer();
            Assert.IsNotNull(gA);


            Game g = gA.CurrentGame;
            Assert.IsNull(g);


            List<string[]> list = log.DefineGameSections();
            Assert.IsNotNull(list);
            Assert.AreNotEqual(0, list.Count);


            foreach(string[] arr in list)
            {
                gA.AnalyseNewGame(arr);
                Assert.IsNotNull(gA.CurrentGame);

                gA.GenerateGameResult();
                game = gA.CurrentGame;
                Assert.IsNotNull(game);
            }
        }
    }
}