using System;
using System.Threading;

namespace BossFight
{
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
}
