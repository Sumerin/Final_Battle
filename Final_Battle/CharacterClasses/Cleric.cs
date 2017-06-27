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
            _Hp = 200;
            _Dir = "/Images/cleric.png";
            _Dmg = 20;
            _Acc = 0.5;
            _Speed = 5;
            _Def = 20;
            power = "Divine Heal";
            _PowerDescription = CharacterClasses.PowerDescription.DivineHeal;
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
