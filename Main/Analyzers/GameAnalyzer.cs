using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.POCO;

namespace Main.Analyzers
{
    public class GameAnalyzer
    {
        private Game _currentGame;
        private string[] _currentGameInfo;

        private static Int32 _GAME_NUMBER = 1;

        public Game CurrentGame { get => this._currentGame; private set => this._currentGame = value; }


        public void GenerateGameResult()
        {
            this._currentGame = ConstructGame();
        }

        public void AnalyseNewGame(string[] gameSectionInfo)
        {
            this._currentGame = new Game();
            this._currentGameInfo = gameSectionInfo;
        }

        private Game ConstructGame()// I need to Fix this!!!
        {
            Game game = new Game();
            Dictionary<string, Player> gameScore = new Dictionary<string, Player>();//I can't use a simple Integer; I need to user the Player class itself!

            CreateGameName(game);

            foreach (string line in this._currentGameInfo)
            {
                if (IsPlayerInfo(line))
                {
                    string name = GetPlayerNameFromClientUser(line);//Problem!

                    if (!gameScore.ContainsKey(name))
                    {
                        gameScore.Add(name, new Player());//Use a Constructor to set the name of the Player automatically.
                        gameScore[name].Name = name;
                    }
                    continue;
                }

                if (IsKillInfo(line))
                {
                    if (IsSuicide(line))
                    {
                        SetSuicidalScore(gameScore, line);
                        continue;
                    }

                    string[] killCount = GetKillCount(line);//Need to find a better name for the Method

                    string killerName = killCount.First();
                    string killedName = killCount.Last();

                    SetPlayersScore(gameScore, killerName, killedName);
                }
            }

            foreach (string key in gameScore.Keys)
            {
                game.AddPlayer(gameScore[key]);
            }

            game.SetTotalOfKills();
            game.SetTotalOfDeaths();

            return game;
        }

        private static void CreateGameName(Game game)
        {
            game.GenerateGameName(GameAnalyzer._GAME_NUMBER);
            _GAME_NUMBER++;   
        }

        private void SetPlayersScore(Dictionary<string, Player> gameScore, string killerName, string killedName)
        {
            if (gameScore.ContainsKey(killerName) && gameScore.ContainsKey(killedName))
            {
                gameScore[killerName].IncrementKills();
                gameScore[killedName].IncrementDeaths();
            }
            else if (gameScore.ContainsKey(killerName) && !gameScore.ContainsKey(killedName))
            {
                gameScore[killerName].IncrementKills();

                gameScore.Add(killedName, new Player());
                gameScore[killedName].Name = killedName;
                gameScore[killedName].IncrementDeaths();
            }
            else if (!gameScore.ContainsKey(killerName) && gameScore.ContainsKey(killedName))
            {
                gameScore[killedName].IncrementDeaths();

                gameScore.Add(killerName, new Player());
                gameScore[killerName].Name = killerName;
                gameScore[killerName].IncrementKills();
            }
        }

        private void SetSuicidalScore(Dictionary<string, Player> gameScore, string line)
        {
            foreach (string name in gameScore.Keys)
            {
                if (IsPlayerNameExistent(line, name))
                {
                    gameScore[name].IncrementDeaths();
                    break;
                }
            }
        }

        private string[] GetKillCount(string line)
        {
            string auxLine1 = line.Substring(line.LastIndexOf(":")+2);
            string killLine = auxLine1.Substring(0, auxLine1.LastIndexOf("by"));

            string[] killCount = killLine.Split(new string[] { "killed" }, StringSplitOptions.None);
            killCount = FixPlayerName(killCount);

            return killCount;// Need's a better name. Too confusing!
        }

        private string[] FixPlayerName(string[] killCount)
        {
            for(int i = 0; i < killCount.Length; i++)
            {
                killCount[i] = killCount[i].Trim(' ');
            }

            return killCount;
        }

        private bool IsPlayerInfo(string line)
        {
            return line.Contains("ClientUserinfoChanged:");
        }

        private bool IsKillInfo(string line)
        {
            return line.Contains("Kill:");
        }

        private bool IsSuicide(string line)
        {
            return line.Contains("<world>");
        }

        private string GetPlayerNameFromClientUser(string line) // I need to do something about the way the NAME of the player is searched!
        {
            string aux = line.Substring(line.IndexOf(@"n\") + 2);
            string name = aux.Substring(0, aux.IndexOf(@"\t"));

            return name.Trim();
        }

        private bool IsPlayerNameExistent(string line, string name)
        {
            return line.Contains(name);
        }
        
    }
}
