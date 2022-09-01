using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public class Dragon : Range
    {
        public Dragon() : base(100, 100, 4, 25, 100, 20)
        {
            this.SetStateOfLife(true);
        }

        public void FireBreath(Unit unit)
        {
            if (!unit.GetStateOfLife())
            {
                throw new Exception("Enemy is destroyed!");
            }

            unit.SetHealth(unit.GetHealth() - 25);

            if (unit.GetHealth() <= 0)
            {
                unit.SetStateOfLife(false);
            }
        }

        public override void Move()
        {
            Console.WriteLine("Dragon is moving");
        }
    }
}
