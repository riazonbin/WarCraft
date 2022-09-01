using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public class Footman : Military
    {
        public Footman() : base(100, 55, 6, 8) //hp, armor, attackSpeed
        {
            this.SetStateOfLife(true);
        }
        public void Berserker()
        {
            this.SetAttackSpeed(GetAttackSpeed() * 2);
        }
        public void Stun(Military unit)
        {
        }

        public override void Move()
        {
            Console.WriteLine("Footman is moving");
        }
    }
}
