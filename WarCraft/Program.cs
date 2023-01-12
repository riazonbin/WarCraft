using Units.ActiveUnits;
using Units.BaseUnits;

Footman f1 = new(80, 100, 10, 15, "Alexander");
Peasant p1 = new(100, "Bulat");
Mage m1 = new(80, 100, 17, 100, 500, 4, "Mage");
Mage m2 = new(80, 100, 10, 100, 100, 4, "UltraMaga");
Footman f2 = new(80, 100, 10, 15, "Magomed");

Blacksmith blacksmith = new(1000, "Blacksmith");
List<Unit> units = new List<Unit>() { f1, p1};
blacksmith.UpgradeWeapon(units);

Random rand = new Random();


Fight(f1, m1);



void Fight(Unit unit1 ,Unit unit2)
{
    Task.Run(() =>
    {
        try
        {
            while(unit1.GetStateOfLife() && unit2.GetStateOfLife())
            {
                unit1.Attack(unit2);
                Thread.Sleep(((Military)unit1).GetAttackSpeed() * 100);
            }
        }
        catch { }
    });

    Task.Run(() =>
    {
        try
        {
            while (unit2.GetStateOfLife() && unit1.GetStateOfLife())
            {
                unit2.Attack(unit1);
                Thread.Sleep(((Military)unit2).GetAttackSpeed() * 100);
            }
        }
        catch { }
    });

    while(unit1.GetStateOfLife() && unit2.GetStateOfLife())
    {
        Thread.Sleep(1000);
    }
    if(unit1.GetStateOfLife() && !unit2.GetStateOfLife())
    {
        Console.WriteLine($"Игрок {unit1.Name} победил!");
    }
    else if (unit2.GetStateOfLife() && !unit1.GetStateOfLife())
    {
        Console.WriteLine($"Игрок {unit2.Name} победил!");
    }
    else if (!unit2.GetStateOfLife() && !unit1.GetStateOfLife())
    {
        Console.WriteLine("Ничья!");
    }
}