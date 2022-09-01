using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    public class Mage : Range
    {
        public Mage(): base(60, 0, 8, 12, 100, 4)
        {
            this.SetStateOfLife(true);
        }
        public void FireBall()
        {

        }
        public void Blizzard()
        {

        }
        public void Heal()
        {

        }


        public override void Move()
        {
            Console.WriteLine("Mage is moving");
        }
    }
}
