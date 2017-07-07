using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Battle
{
    class Paladin : Character
    {
        private const int HP_REGEN = 10;
         public Paladin()
        {
            _hp = 400;
            _dir = "/Images/paladin.png";
            _dmg = 20;
            _acc = 0.7;
            _speed = 3;
            _def = 1.5;
            power = "HealthRegen";
            _powerDescription = CharacterClasses.PowerDescription.HealthRegen;
           
        }
         public override void ExecuteTurn()
         {
             _hp += HP_REGEN;
             NotifyPropertyChanged("Hp");
             base.ExecuteTurn();
         }
         
    }
}
