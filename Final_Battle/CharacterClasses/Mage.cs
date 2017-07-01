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
            _hp = 200;
            _dir = "/Images/mage.png";
            _dmg = 20;
            _acc = 0.9;
            _speed = 5;
            _def = 20;
            power = "Charged Attak";
            _powerDescription = CharacterClasses.PowerDescription.ChargedAttack;

        }
        public override void Attack(Character enemy, Action<string> Log)
        {
            int baseDmg = _dmg;
            _dmg *= powerMultiple;
            base.Attack(enemy, Log);
            _dmg = baseDmg;
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
