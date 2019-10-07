using System;
using System.Threading;

namespace BossFight
{
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
}
