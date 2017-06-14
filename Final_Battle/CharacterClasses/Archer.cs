using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Battle
{
    class Archer : Character
    {
         public Archer()
        {
            _Hp = 200;
            _Dir = "/Images/archer.png";
            _Dmg = 20;
            _Acc = 0.5;
            _Speed = 5;
            _Def = 20;
           
        }
         
    }
}
