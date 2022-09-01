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
        public Movable(int health)
        {
            this.SetHealth(health);
            this.SetMaxHealth(health);
        }
        public abstract void Move();
    }
}
