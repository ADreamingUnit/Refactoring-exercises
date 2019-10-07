using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterMenu
{
    class Character
    {
        // сделаем так, чтобы статы при создании экземпляра персонажа вообще могли быть любыми, в любом количестве.
        public Stat[] Stats { get; set; }

        private int age; // Т.к. возраст указывается в анкете, конструктор сделаем без него.
        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                    age = value;
            }
        }

        private int points; // сделаем так, чтобы количество максимальных очков задавалось при создании экземпляра.
        public int Points
        {
            get { return points; }
            set
            {
                if (value >= 0 && value <= 30)
                    points = value;
            }
        }

        public Character(Stat[] stats, int maxPoints)
        {
            Stats = stats;
            Points = maxPoints;
        }
    }
}
