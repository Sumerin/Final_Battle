using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Final_Battle
{
    class Rabbit : Boss
    {
        public Rabbit(List<Character> hero, Action<string> Log)
        {
            this._hp = 1200;
            this._dir = "/Images/rabbit.png";
            this._dmg = 100;
            this._acc = 1.0;
            this._speed = 100;
            this._def = 1.1;

            this.isFriendly = false;
            this.hero = new List<Character>(hero);
            this.Log = Log;
            this.hero.Sort();
            this.hero.Reverse();

            isDone = false;
            _characterContextMenu.Items.Add(new Label() { Content = BossClasses.BossDescription.Rabbit });
        }

        public override void ExecuteTurn()
        {
            foreach (var item in this.hero)
            {

                if (item.isAlive)
                {
                    Attack(item, Log);
                    break;
                }
            }
        }
    }
}
