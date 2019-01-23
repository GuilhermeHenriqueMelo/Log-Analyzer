using Microsoft.VisualStudio.TestTools.UnitTesting;
using Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.POCO;

namespace Main.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void IncrementKillsTest()
        {
            Game game = new Game();
            Player p1 = new Player();
            p1.IncrementKills();
            p1.IncrementKills();
            p1.IncrementKills();

            Player p2 = new Player();
            p2.IncrementKills();
            p2.IncrementKills();

            Assert.AreEqual(0, game.TotalOfKills);

            game.AddPlayer(p1);
            game.AddPlayer(p2);

            game.SetTotalOfKills();

            Assert.AreEqual(5, game.TotalOfKills);
        }

        [TestMethod()]
        public void IncrementDeathsTest()
        {
            Game game = new Game();
            Player p1 = new Player();
            p1.IncrementDeaths();
            p1.IncrementDeaths();
            p1.IncrementDeaths();

            Player p2 = new Player();
            p2.IncrementDeaths();
            p2.IncrementDeaths();
            p2.IncrementDeaths();

            Assert.AreEqual(0, game.TotalOfDeaths);

            game.AddPlayer(p1);
            game.AddPlayer(p2);

            game.SetTotalOfDeaths();

            Assert.AreEqual(6, game.TotalOfDeaths);
        }

        [TestMethod()]
        public void AddPlayerTest()
        {
            Game game = new Game();

            Assert.AreEqual(0, game.NumberOfPlayers);

            Player p = new Player();
            game.AddPlayer(p);

            Assert.AreEqual(1, game.NumberOfPlayers);
        }
    }
}