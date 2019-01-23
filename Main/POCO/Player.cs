using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.POCO
{
    public class Player
    {
        private Int32 _numberOfKills;
        //private string _weaponName;
        private Int32 _numberOfDeaths;

        public string Name { get; set; }
        public Int32 NumberOfKills { get => this._numberOfKills; private set => this._numberOfKills = value; }
        //public string WeaponName { get; set; }
        public Int32 NumberOfDeaths { get => this._numberOfDeaths; private set => this._numberOfDeaths = value; }

        public Player()
        {

        }

        public Player(string name)
        {
            this.Name = name;
        }

        public void IncrementKills()
        {
            this._numberOfKills++;
        }

        //public void DecrementKills()
        //{
        //    this._numberOfKills--;
        //}

        public void IncrementDeaths()
        {
            this._numberOfDeaths++;
        }
    }
}