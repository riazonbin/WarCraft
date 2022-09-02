using System.Threading;
using Units;

Mage playerOne = new();
Footman playerTwo = new();


try
{
    while (true)
    {
        playerOne.Attack(playerTwo);
        playerTwo.Attack(playerOne);
    }
}
catch
{
    Console.WriteLine(playerOne.GetStateOfLife() 
        ? $"First player ({playerOne.GetType().Name}) is victorious!" 
        : $"Second player({playerOne.GetType().Name}) is victorious!");
}
