using System;

namespace setup
{
    public class GuessTheNum
    {
        public int min;
        public int max;

        public GuessTheNum(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public int RandomNum()
        {
            Random random = new Random();
            int num = random.Next(min, max);
            return num;
        }
    }
    
}