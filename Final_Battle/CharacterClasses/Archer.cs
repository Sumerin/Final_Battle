using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Battle
{
    class Archer : Character
    {
        private int timer;
        private const int RESET = 3;
        private const int POWERMULTIPLE = 3;
        public Archer()
        {
            _Hp = 200;
            _Dir = "/Images/archer.png";
            _Dmg = 20;
            _Acc = 0.5;
            _Speed = 7;
            _Def = 20;
            power = "Piercing Arrow";

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
                        item.DealDamage(_Dmg * POWERMULTIPLE, Log);
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
