using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Final_Battle
{
    public class Warrior : Character
    {
        private const double BUFF = 0.2;
        public Warrior()
        {
            _hp = 200;
            _dir = "/Images/Warrior.png";
            _dmg = 20;
            _acc = 0.8;
            _speed = 5;
            _def = 1.0;
            power = "Full defense";
            _powerDescription = CharacterClasses.PowerDescription.FullDefense;
        }

        public override void Special(List<Character> Characters, Action<string> Log)
        {
            foreach (var chara in Characters)
            {
                if (chara.isFriendly)
                {
                    Log(chara.GetType().Name + "Recivied " + BUFF + " Defense");
                    chara.RaiseDefense(BUFF);
                }
            }
            base.Special(Characters, Log);
        }

    }
}
