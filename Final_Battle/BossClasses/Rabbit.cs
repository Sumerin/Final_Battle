using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Battle
{
    class Rabbit : Character
    {
        List<Character> hero;
        Action<string> Log;
        public Rabbit(List<Character> hero, Action<string> Log)
        {
            this._Hp = 1200;
            this._Dir = "/Images/rabbit.png";
            this._Dmg = 100;
            this._Acc = 1.0;
            this._Speed = 100;
            this._Def = 1.1;

            this.isFriendly = false;
            this.hero = new List<Character>(hero);
            this.Log = Log;
            this.hero.Sort();
            this.hero.Reverse();
        }

        public override void ExecuteTurn()
        {
            foreach (var item in this.hero)
            {

                if (item.isAlive)
                {
                    Log(GetType().Name + " Attacks!!");
                    item.DealDamage(_Dmg, Log);
                    break;
                }
            }
        }
    }
}
