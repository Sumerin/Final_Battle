using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Battle
{
    public class Boss : Character
    {
        protected List<Character> hero;
        protected Action<string> Log;
    }
}
