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
            _Hp = 200;
            _Dir = "/Images/Warrior.png";
            _Dmg = 20;
            _Acc = 0.8;
            _Speed = 5;
            _Def = 1.0;
            power = "Full defense";
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
