using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Battle
{
    class Cleric  : Character
    {
        private const int HEAL = 3;
        private const int MAXHEAL = 8;
        
        public Cleric()
        {
            _hp = 200;
            _dir = "/Images/cleric.png";
            _dmg = 10;
            _acc = 0.5;
            _speed = 3;
            _def = 0.6;
            power = "Divine Heal";
            _powerDescription = CharacterClasses.PowerDescription.DivineHeal;
        }

        public override void Special(List<Character> Characters, Action<string> Log)
         {
             foreach (var chara in Characters)
             {
                 if (chara.isFriendly && chara.isAlive)
                 {
                     int actualHeal = HEAL + random.Next(MAXHEAL);
                     Log(chara.GetType().Name + "Recivied " + actualHeal + " health");
                     chara.GrantHealth(actualHeal);
                 }
             }
             base.Special(Characters, Log);
         }
    }
}
