using System.Threading;
using Units;

Mage playerOne = new();
Footman playerTwo = new();

Thread myThread1 = new Thread(() => playerOne.Attack(playerTwo));
Thread myThread2 = new Thread(() => playerTwo.Attack(playerOne));

myThread1.Start(playerOne);

try
{
    while (true)
    {
        playerOne.Attack(playerTwo);
        Console.WriteLine($"First player's HP is {playerOne.GetHealth()}");
        playerTwo.Attack(playerOne);
        Console.WriteLine($"Second player's HP is {playerTwo.GetHealth()}");
    }
}
catch(Exception)
{ 
    Console.WriteLine(playerOne.GetStateOfLife() 
        ? $"First player ({playerOne.GetType().Name}) is victorious!" 
        : $"Second player({playerOne.GetType().Name}) is victorious!");
}