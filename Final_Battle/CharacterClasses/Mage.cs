using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Battle
{
    class Mage : Character
    {
        private int powerMultiple = 1;

        public Mage()
        {
            _Hp = 200;
            _Dir = "/Images/mage.png";
            _Dmg = 20;
            _Acc = 0.9;
            _Speed = 5;
            _Def = 20;
            power = "Charged Attak";
            _PowerDescription = CharacterClasses.PowerDescription.ChargedAttack;

        }
        public override void Attack(Character enemy, Action<string> Log)
        {
            int baseDmg = _Dmg;
            _Dmg *= powerMultiple;
            base.Attack(enemy, Log);
            _Dmg = baseDmg;
            powerMultiple = 1;
        }
        public override void Special(List<Character> Characters, Action<string> Log)
        {

            powerMultiple <<= 1;
            Log("CHARGING Power x" + powerMultiple);

            base.Special(Characters, Log);
        }
    }
}
