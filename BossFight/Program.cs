using System;
using System.Threading;

namespace BossFight
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryDice cruelFate = new BinaryDice();
            Character smolHumie = new Character(800, 20);
            Boss daBiggestGit = new Boss(cruelFate.RollTheDice());

            Battle.Fight(daBiggestGit, smolHumie);
        }
    }
}
