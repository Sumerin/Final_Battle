using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Battle
{
    class Archer : Character
    {
        private const int RESET = 3;
        private const int POWERMULTIPLE = 4;

        private int timer;

        public Archer()
        {
            _hp = 200;
            _dir = "/Images/archer.png";
            _dmg = 45;
            _acc = 0.5;
            _speed = 7;
            _def = 0.5;
            power = "Piercing Arrow";
            _powerDescription = CharacterClasses.PowerDescription.PiercingArrow;

        }

        public override void Special(List<Character> Characters, Action<string> Log)
        {
            if (timer == 0)
            {
                Log(power);
                foreach (var item in Characters)
                {
                    if (!item.isFriendly)
                    {
                        item.DealDamage(_dmg * POWERMULTIPLE, Log);
                    }

                }

            }
            else
            {
                Log("Charging left: " + timer);
                timer--;
            }
            timer = RESET;

            base.Special(Characters, Log);
        }
    }
}
