using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public abstract class Military : Movable
    {
        private int _damage;
        private int _attackSpeed;
        private int _armor;
        public abstract void Attack(Unit unit);

        public int GetDamage()
        {
            return _damage;
        }

        public int GetAttackSpeed()
        {
            return _attackSpeed;
        }

        public int SetAttackSpeed(int newAttackSpeed)
        {
            return _attackSpeed = newAttackSpeed;
        }


    }
}
