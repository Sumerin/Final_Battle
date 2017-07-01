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
        private List<Character> hero;
        private Action<string> Log;

        public Demon(List<Character> hero, Action<string> Log)
        {
            _hp = 2000;
            _dir = "/Images/demon.png";
            _dmg = 50;
            _acc = 0.7;
            _speed = 5;
            _def = 1.7;

            isFriendly = false;
            this.hero = new List<Character>(hero);
            this.Log = Log;

            isDone = false;
            _characterContextMenu.Items.Add(new Label() { Content=BossClasses.BossDescription.Demon});
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
