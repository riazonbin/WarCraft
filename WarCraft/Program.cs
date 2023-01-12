using Units.ActiveUnits;
using Units.BaseUnits;

Footman f1 = new(80, 100, 100, 15, "Alexander");
Peasant p1 = new(100, "Bulat");
Mage m1 = new(80, 100, 8, 100, 500, 8, "Mage");
Mage m2 = new(80, 100, 10, 100, 100, 4, "UltraMaga");
Footman f2 = new(80, 100, 10, 15, "Magomed");

Blacksmith blacksmith = new(1000, "Blacksmith");
List<Unit> units = new List<Unit>() { f1, p1};
blacksmith.UpgradeWeapon(units);

Random rand = new Random();

Fight(f1, m1);


void Fight(Unit unit1 ,Unit unit2)
{
    List<Unit> units = new List<Unit>(){ unit1, unit2 };

    Task.Run(() =>
    {
        try
        {
            while(units.Count == 2)
            {
                unit1.Attack(unit2);
                Thread.Sleep(((Military)unit1).GetAttackSpeed() * 10);

                if (!unit2.GetStateOfLife())
                {
                    units.Remove(unit2);
                }
            }
        }
        catch { }
    });

    Task.Run(() =>
    {
        try
        {
            while (units.Count == 2)
            {
                unit2.Attack(unit1);
                Thread.Sleep(((Military)unit2).GetAttackSpeed() * 10);

                if (!unit1.GetStateOfLife())
                {
                    units.Remove(unit2);
                }
            }
        }
        catch { }
    });

    while(units.Count == 2)
    {
        Thread.Sleep(1000);
    }

    if(units.Count == 1)
    {
        Console.WriteLine($"Игрок {units[0].Name} победил!");
    }
    else if (units.Count == 0)
    {
        Console.WriteLine("Ничья!");
    }
}