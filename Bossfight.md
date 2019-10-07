# Refactoring-exercises
==================== Код задания одним файлом: ====================

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
    
    class BinaryDice
    {
        private readonly bool value;

        public BinaryDice()
        {
            value = (DateTime.Now.Millisecond % 2) == 0;
        }

        public bool RollTheDice()
        {
            return value;
        }
    }
    
    class Character
    {       
        public int Health { get; set; }
        public int Armor { get; private set; }

        public Character(int health, int armor)
        {
            Health = health;
            Armor = armor;
        }
    }
    
    class Boss
    {
        public bool IsRandomAttack { get; private set; }

        private int currentAttackNumber = 0;

        public Boss(bool isRandom)
        {
            IsRandomAttack = isRandom;
        }

        // в зависимости от значения поля IsRandomAttack атакует в соответственном порядке.
        public void Attack(Character character)
        {
            if(IsRandomAttack)
            {
                int randomAttackNumber = DateTime.Now.Millisecond % 3;
                ExecuteAttack(randomAttackNumber, character);
            }
            else
            {
                ExecuteAttack(currentAttackNumber, character);
                currentAttackNumber++;
                if (currentAttackNumber > 2)
                {
                    currentAttackNumber = 0;
                }
            }
        }

        private void ExecuteAttack(int attackNumber, Character character)
        {
            switch(attackNumber)
            {
                case 0:
                    FuriousAttack(character);
                    break;
                case 1:
                    MusicalSadismAttack(character);
                    break;
                case 2:
                    BossTiredAttack(character);
                    break;
            }
        }

        private void BossTiredAttack(Character character)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Босс поник и рассказал вам о своём долгом пути, попутно дав пару советов. И немедленно выпил.");
            Console.ForegroundColor = oldColor;
            character.Health = character.Health - (80 - character.Armor);
        }

        private void MusicalSadismAttack(Character character)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Босс исполнил новый альбом Ольги Бузовой!");
            Console.ForegroundColor = oldColor;
            character.Health = character.Health - (140 - character.Armor);
        }

        private void FuriousAttack(Character character)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Босс атаковал с немыслимой яростью своими руками!");
            Console.ForegroundColor = oldColor;
            character.Health = character.Health - (100 - character.Armor);
        }
    }
    
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
