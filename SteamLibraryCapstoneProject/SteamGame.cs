using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamLibraryCapstoneProject
{
    public class SteamGame
    {
        public enum GameGenre
        {
            unknown,
            rpg,
            sandbox,
            action,
            fps,
            openworld,
            platformer,
            fighting,
            rts
        }
        #region FIELDS

        private string _name;
        private GameGenre _gamegenre;
        private double _price;
        private int _hours;


        #endregion

        #region PROPERTIES
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public GameGenre CurrentGameGenre
        {
            get { return _gamegenre; }
            set { _gamegenre = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public SteamGame()
        {

        }

        public SteamGame(string name)
        {
            _name = name;
        }

        #endregion

        #region METHODS
        // need to review

        public string SteamGameQuickDescription()
        {
            return _name + " is " + "a " + _gamegenre + ".";

            
        }

        #endregion
    }
}
