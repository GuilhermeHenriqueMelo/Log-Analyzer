using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Main.Utils;
using Main.POCO;
using Main.Analyzers;

namespace Main
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            //string s = @"ClientUserinfoChanged: 2 n\Isgalamido\t\0\model\xian/default\hmodel\xian/default\g_redteam\\g_blueteam\\c1\4\c2\5\hc\100\w\0\l\0\tt\0\tl\0";
            //string aux1 = s.Substring(s.IndexOf(@"n\"));

            //Console.WriteLine(aux1.Substring(2, aux1.IndexOf(@"\t")-2));

            //Player p = new Player();
            //p.Name = "Teste";
            //p.IncrementKills();
            //p.IncrementKills();
            //p.IncrementKills();

            //p.IncrementDeaths();
            //p.IncrementDeaths();

            //Game g = new Game();
            //g.AddPlayer(p);

            //string s = JsonConvert.SerializeObject(g, Formatting.Indented);

            //Console.WriteLine(s);#Test
            try
            {
                var path = ConfigurationManager.AppSettings["logFile"];
                var log = Reader.ReadFile(path);

                var list = BeginAnalysis(log);

                PrintGameSection(list);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press any key to close the program...");
            Console.ReadLine();
        }

        private static void PrintGameSection(List<Game> list)
        {
            foreach(var g in list)
            {
                string obj = JsonConvert.SerializeObject(g, Formatting.Indented);

                Console.WriteLine(obj + "\n");
            }
        }

        public static List<Game> BeginAnalysis(string[] log)
        {
            LogAnalyzer logAnalyzer = new LogAnalyzer(log);

            var list = logAnalyzer.DefineGameSections();

            var games = CreateGamesSections(list);

            return games;
        }

        private static List<Game> CreateGamesSections(List<string[]> list)
        {
            GameAnalyzer gameAnalyzer = new GameAnalyzer();
            List<Game> gamesList = new List<Game>();

            foreach(var arr in list)
            {
                gameAnalyzer.AnalyseNewGame(arr);
                gameAnalyzer.GenerateGameResult();
                var game = gameAnalyzer.CurrentGame;

                gamesList.Add(game);
            }

            return gamesList;
        }
    }
}
