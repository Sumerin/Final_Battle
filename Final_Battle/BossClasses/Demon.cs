using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Controls;

namespace Final_Battle
{
    class Demon : Character
    {
        List<Character> hero;
        Action<string> Log;
        public Demon(List<Character> hero, Action<string> Log)
        {
            _Hp = 2000;
            _Dir = "/Images/demon.png";
            _Dmg = 50;
            _Acc = 0.7;
            _Speed = 5;
            _Def = 1.7;

            isFriendly = false;
            this.hero = new List<Character>(hero);
            this.Log = Log;

            isDone = false;
            _CharacterContextMenu.Items.Add(new Label() { Content=BossClasses.BossDescription.Demon});
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
                }
            }
        }

    }
}
