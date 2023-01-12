using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Units.BaseUnits;

namespace Units.ActiveUnits
{
    public class Mage : BaseUnits.Range
    {
        private int healthHealth = 15;
        private int manaForHeal = 20;
        private int manaForBlizzard = 25;

        public delegate void OnHealAbilityDelegate(Unit currentMage, Unit unit, double healedHP);
        public event OnHealAbilityDelegate OnHealEvent;

        public Mage(double health, double armor, int attackSpeed,
            double range, double mana, double damage, string name)
            : base(health, armor, attackSpeed, range, mana, damage, name)
        {
            OnHealEvent += (currentMage, unit, healedHP) =>
            Console.WriteLine($"{currentMage.Name} have healed {unit.Name} for {healedHP}");
        }

        public void FireBall(Unit unit)
        {
            if (GetMana() < 35)
            {
                return;
            }

            this.SetMana(GetMana() - 35);
            SetDamage(9);
            Attack(unit);
            SetDamage(GetMaxDamage());
            Console.WriteLine($"Mage {this.Name} fireballed {unit.Name}");
        }

        public void Blizzard(Unit unit)
        {
            if (GetMana() < manaForBlizzard)
            {
                return;
            }

            this.SetMana(GetMana() - manaForBlizzard);
            SetDamage(14);
            ((Military)unit).SetAttackSpeed(0);
            Attack(unit);
            SetDamage(GetMaxDamage());
            Console.WriteLine($"Mage {this.Name} blizzarded {unit.Name}");
        }

        public void Heal(Unit unit)
        {
            if (GetMana() < manaForHeal)
            {
                return;
            }

            double oldHP = unit.GetHealth();
            double newHP = oldHP + healthHealth;
            this.SetMana(GetMana() - manaForHeal);

            if (newHP > GetMaxHealth())
            {
                OnHealEvent(this, unit, GetMaxHealth() - oldHP);
                unit.SetHealth(GetMaxHealth());
                return;
            }
            else
            {
                OnHealEvent(this, unit, healthHealth);
                unit.SetHealth(newHP);
            }
            Console.WriteLine($"Mage {this.Name} healed himself!");
        }

        public override void Move()
        {
            Console.WriteLine($"Mage {this.Name} is moving");
        }

        public override void Attack(Unit unit)
        {
            Random random = new Random();

            if(random.Next(5) == 1)
            {
                FireBall(unit);
                return;
            }
            if (random.Next(5) == 1)
            {
                Heal(this);
                return;
            }

            base.Attack(unit);
        }
    }
}
