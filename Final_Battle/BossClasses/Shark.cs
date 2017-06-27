using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Final_Battle
{
    public class Shark : Character
    {
        List<Character> hero;
        Action<string> Log;
        public Shark(List<Character> hero, Action<string> Log)
        {
            this._Hp = 1200;
            this._Dir = "/Images/shark.png";
            this._Dmg = 300;
            this._Acc = 0.1;
            this._Speed = 1;
            this._Def = 1.5;

            this.isFriendly = false;
            this.hero = new List<Character>(hero);
            this.Log = Log;

            isDone = false;
            _CharacterContextMenu.Items.Add(new Label() { Content = BossClasses.BossDescription.Shark });
        }

        public override void ExecuteTurn()
        {
            foreach (var item in this.hero)
            {

                if (item.isAlive)
                {
                    if (random.NextDouble() < _Acc)
                    {
                        Log(GetType().Name + " Attacks!!");
                        item.DealDamage(_Dmg, Log);
                    }
                    else
                    {
                        Log(GetType().Name + " Attack " + item.GetType().Name + " and missed :)");
                    }
                    break;
                }

            }
        }
    }
}
