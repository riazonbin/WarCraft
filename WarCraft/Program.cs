using System.Threading.Tasks;
using Units.ActiveUnits;
using Units.BaseUnits;

Footman f1 = new(80, 100, 15, 15, "Alexander");
Peasant p1 = new(100, "Bulat");
Mage m1 = new(80, 100, 8, 100, 500, 12, "Mage");
Mage m2 = new(80, 100, 10, 100, 100, 4, "UltraMaga");
Footman f2 = new(80, 100, 10, 15, "Magomed");

Blacksmith blacksmith = new(1000, "Blacksmith");
List<Unit> units = new List<Unit>() { f1, p1};
blacksmith.UpgradeWeapon(units);

Random rand = new Random();

Fight(f1, m1);


void Fight(Unit unit1 ,Unit unit2)
{
    List<Unit> units = new List<Unit>() { unit1, unit2 };

    var task1 = Task.Run((Action)(() =>
    {
        UnitAttack(unit1, unit2, units);
    }));

    var task2 = Task.Run(() =>
    {
        UnitAttack(unit2, unit1, units);
    });

    Task.WaitAll(task1, task2);
    AttackResult(units, task1, task2);
}

static void UnitAttack(Unit attacker, Unit defender, List<Unit> units)
{
    try
    {
        while (units.Count == 2)
        {
            attacker.Attack(defender);
            Thread.Sleep(((Military)attacker).GetAttackSpeed() * 10);

            if (!defender.GetStateOfLife())
            {
                units.Remove(defender);
            }
        }
    }
    catch { }
}

static void AttackResult(List<Unit> units, Task task1, Task task2)
{
    if (units.Count == 1)
    {
        Console.WriteLine($"Игрок {units[0].Name} победил!");
    }
    else if (units.Count == 0)
    {
        Console.WriteLine("Ничья!");
    }
    Task.WaitAll(task1, task2);
}