using System.Threading;
using Units;

Mage playerOne = new();
Footman playerTwo = new();

Thread myThread1 = new Thread(() => playerOne.Attack(playerTwo));
Thread myThread2 = new Thread(() => playerTwo.Attack(playerOne));


try
{
    while (true)
    {
        myThread1.Start(playerOne);
        Console.WriteLine($"First player's HP is {playerOne.GetHealth()}");
        myThread2.Start(playerOne);
        Console.WriteLine($"Second player's HP is {playerTwo.GetHealth()}");
    }
}
catch(Exception)
{ 
    Console.WriteLine(playerOne.GetStateOfLife() 
        ? $"First player ({playerOne.GetType().Name}) is victorious!" 
        : $"Second player({playerOne.GetType().Name}) is victorious!");
}