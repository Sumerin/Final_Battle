using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Final_Battle
{
    public class Shark : Boss
    {
        public Shark(List<Character> hero, Action<string> Log)
        {
            this._hp = 1200;
            this._dir = "/Images/shark.png";
            this._dmg = 300;
            this._acc = 0.1;
            this._speed = 1;
            this._def = 1.5;

            this.isFriendly = false;
            this.hero = new List<Character>(hero);
            this.Log = Log;

            isDone = false;
            _characterContextMenu.Items.Add(new Label() { Content = BossClasses.BossDescription.Shark });
        }

        public override void ExecuteTurn()
        {
            foreach (var item in this.hero)
            {

                if (item.isAlive)
                {
                    Attack(item, Log);
                }

            }
        }
    }
}
