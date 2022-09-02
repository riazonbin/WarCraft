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

        public Military(int health, int armor, int attackSpeed, int damage) : base(health)
        {
            this._armor = armor;
            this._attackSpeed = attackSpeed;
            this._damage = damage;
        }
        public void Attack(Unit unit)
        {

            unit.SetHealth(unit.GetHealth() - this.GetDamage());

            if (unit.GetHealth() <= 0)
            {
                unit.SetStateOfLife(false);
                throw new Exception("Enemy is destroyed!");
            }
        }

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
