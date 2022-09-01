using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public abstract class Unit
    {
        private int _health;
        private string _name;
        private int _cost;
        private int _lvl;
        private bool _isDestroyed;
        private int _maxhealth;

        public int GetHealth()
        {
            return _health;
        }
        public int SetHealth(int newHealth)
        {
            return _health = newHealth;
        }
        public bool GetStateOfLife()
        {
            return _isDestroyed;
        }
        public bool SetStateOfLife(bool newState)
        {
            return _isDestroyed = newState;
        }
        public int SetMaxHealth(int health)
        {
            return _maxhealth = health;
        }
    }
}
