﻿using System;
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
            _Hp = 400;
            _Dir = "/Images/paladin.png";
            _Dmg = 20;
            _Acc = 0.7;
            _Speed = 3;
            _Def = 1.5;
           
        }
         public override void ExecuteTurn()
         {
             _Hp += 3;
             Hp = "";
             base.ExecuteTurn();
         }
         
    }
}
