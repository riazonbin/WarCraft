using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public abstract class Movable : Unit
    {
        private int _speed;
        public abstract void Move();
    }
}
