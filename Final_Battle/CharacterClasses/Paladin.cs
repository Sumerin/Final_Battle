using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Battle
{
    class Paladin : Character
    {
         public Paladin()
        {
            _Hp = 120;
            _Dir = "/Images/paladin.png";
            _Dmg = 20;
            _Acc = 0.5;
            _Speed = 5;
            _Def = 20;
           
        }
         
    }
}
