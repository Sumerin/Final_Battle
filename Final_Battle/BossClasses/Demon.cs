using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Battle
{
    class Demon : Character
    {
        public Demon()
        {
            _Hp = 2000;
            _Dir = "/Images/demon.png";
            _Dmg = 50;
            _Acc = 0.7;
            _Speed = 200;
            _Def = 2;

            isFriendly = false;
            
        }

        public override void ExecuteTurn()
        {
            
        }
      
    }
}
