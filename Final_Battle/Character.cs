using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Battle
{
    public abstract class Character
    {
        #region property
        public string Hp
        {
            get
            {
                return "HP: " + _Hp;
            }
            set
            {
                _Hp = Int32.Parse(value);
            }
        }
        public string Damage
        {
            get
            {
                return "Damage: " + _Dmg;
            }
        }
        public string Acc
        {
            get
            {
                return "Acc: " + _Acc;
            }
        }
        public string Speed
        {
            get
            {
                return "Speed: " + _Speed;
            }
        }
        public string Defense
        {
            get
            {
                return "Defense: " + _Def;
            }
        }


        public string Dir
        {
            get
            {
                return this._Dir;
            }
        }

        #endregion


        protected int _Hp;
        protected int _Dmg;
        protected double _Acc;
        protected int _Speed;
        protected int _Def;
        protected string _Dir;

        public Character()
        {

        }




    }
}
