using System;
using System.Threading;

namespace BossFight
{
    static class Battle
    {
        static public void Fight(Boss boss, Character character)
        {
            ShowIntroduction(boss.IsRandomAttack);
            while(character.Health > 0)
            {
                VisualizeHealth(character.Health);
                boss.Attack(character);
                Thread.Sleep(4000);
            }
            ShowConclusion();     
        }

        static private void ShowIntroduction(bool isRandomAttack)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Босс может атаковать в двух режимах: все атаки по очереди и случайной атакой.");
            Console.WriteLine("Босс будет атаковать: " + (isRandomAttack ? "случайно!" : "все атаки по очереди!"));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Нажмите enter для начала боя. . .");
            Console.ForegroundColor = oldColor;
            Console.ReadLine();
        }

        static private void VisualizeHealth(int health)
        {
            Console.Clear();
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("У вас здоровья: " + health);
            Console.ForegroundColor = oldColor;
        }

        static private void ShowConclusion()
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Бой закончен, вы погибли!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Нажмите enter чтобы проснуться.");
            Console.ForegroundColor = oldColor;
            Console.ReadLine();

        }
    }
}
