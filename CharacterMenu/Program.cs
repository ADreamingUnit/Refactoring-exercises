using System;

namespace CharacterMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Character somebody = new Character( new Stat[] { new Stat("Сила"), new Stat("Ловкость"), new Stat("Интеллект"), new Stat("Харизма") }, 14);
            Menu.CharacterCreation(somebody);
        }
    }
}
