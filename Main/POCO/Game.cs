using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.POCO
{
    public class Game
    {
        private string _name;
        private List<Player> _listOfPlayers;
        private Int32 _totalOfKills;
        private Int32 _totalOfDeaths;

        public string Name { get => this._name; private set => this._name = value; }
        public List<Player> ListOfPlayers { get => this._listOfPlayers; private set => this._listOfPlayers = value; }


        public int NumberOfPlayers
        {
            get
            {
                return this._listOfPlayers.Count;
            }

            private set
            {

            }
        }

        public Int32 TotalOfKills
        {
            get
            {
                return this._totalOfKills;
            }

            private set
            {
                //this._totalOfKills = this._listOfPlayers.Sum(p => p.NumberOfKills);//Need to test this functionality to see if it's working.
            }
        }
        public Int32 TotalOfDeaths
        {
            get
            {
                return this._totalOfDeaths;
            }

            private set
            {
                //this._totalOfDeaths = this._listOfPlayers.Sum(p => p.NumberOfDeaths);//Need to test this functionality to see if it's working.
            }
        }

        public Game()
        {
            this._listOfPlayers = new List<Player>();
        }

        //public void IncrementKills()
        //{
        //    this._totalOfKills++;
        //}

        //public void IncrementDeaths()
        //{
        //    this._totalOfDeaths++;
        //}

        public void AddPlayer(Player p)
        {
            if (p == null)
            {
                throw new NullReferenceException();
            }

            if (!this._listOfPlayers.Contains(p))
            {
                this._listOfPlayers.Add(p);
            }
        }

        public void GenerateGameName(int number)
        {
            if (this._name == null)
            {
                Name = "game_" + number;
            } else
            {
                throw new ArgumentException();
            }
        }

        public void SetTotalOfKills()
        {
            int aux = 0;

            foreach(Player p in this._listOfPlayers)
            {
                aux += p.NumberOfKills;
            }

            this._totalOfKills = aux;
        }

        public void SetTotalOfDeaths()
        {
            int aux = 0;

            foreach (Player p in this._listOfPlayers)
            {
                aux += p.NumberOfDeaths;
            }

            this._totalOfDeaths = aux;
        }
    }
}
