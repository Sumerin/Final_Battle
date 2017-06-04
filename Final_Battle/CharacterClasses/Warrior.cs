using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Battle
{
    public class Warrior: Character
    {
        
        
      
       
        public Warrior()
        {
            _Hp = 200;
            _Dir = "/Images/Warrior.png";
            _Dmg = 20;
            _Acc = 0.5;
            _Speed = 5;
            _Def = 20;
           
        }
    }
}
