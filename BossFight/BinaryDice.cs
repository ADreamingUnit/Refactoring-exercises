using System;
using System.Threading;

namespace BossFight
{
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
}
