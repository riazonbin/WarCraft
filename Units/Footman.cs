using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public class Footman : Military
    {
        public void Berserker()
        {
            this.SetAttackSpeed(GetAttackSpeed() * 2);
        }
        public void Stun()
        {

        }
        public override void Attack(Unit unit)
        {
            if(!unit.GetStateOfLife())
            {
                throw new Exception("Enemy is destroyed!");
            }

            unit.SetHealth(unit.GetHealth() - this.GetDamage());

            if(unit.GetHealth() <= 0)
            {
                unit.SetStateOfLife(false);
            }
        }
        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
