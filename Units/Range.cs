using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public abstract class Range : Military
    {
        private int _range;
        private int _mana;
        public Range(int health, int armor, int attackSpeed, int range, int mana, int damage) 
            : base(health, armor, attackSpeed, damage)
        {
            _range = range;
            _mana = mana;
        }
    }
}
