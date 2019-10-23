using System;

namespace Delegates
{
    delegate int RandomDelegate();
    delegate int FinalDelegate(Delegate[] delegates);

    class Anonymous_Methods
    {
        static void Main(string[] args)
        {
            var del_arr = new RandomDelegate[] { Random_Num, Random_Num };

            FinalDelegate del = delegate (Delegate[] delegates)
            {
                var result = 0;
                RandomDelegate temp;
                for (int i = 0; i < delegates.Length - 1; i++)
                {
                    temp = (RandomDelegate)delegates[i];
                    result += temp();
                }
                return result;
            };
            Console.WriteLine(del(del_arr));
        }
        public static int Random_Num()
        {
            int result;
            Random rand = new Random();
            result = rand.Next(1, 100);
            return result;
        }
    }
}
