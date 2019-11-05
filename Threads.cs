using System;
using System.Threading;


namespace Threads
{
    class Threads
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix();

            matrix.Start();
        }
    }

    class Matrix
    {
        private char[,] window;
        private const int windowWidth = 120;
        private const int windowHeight = 30;
        private const int track = 8;


        public Matrix()
        {
            window = new char[windowWidth, windowHeight];
            for (int i = 0; i < windowWidth; i++)
                for (int j = 0; j < windowHeight; j++)
                    window[i, j] = ' ';
        }

        public void Start()
        {
            Random rand = new Random();

            Thread myThread = new Thread(Show);
            myThread.Name = "Show Thread";
            myThread.Start();

            while (true)
            {
                Thread myNewThread = new Thread(CharsInColumn);
                myNewThread.Start(rand.Next(0, windowWidth));
                Thread.Sleep(rand.Next(50, 500));

            }



        }

        public void Show()
        {
            char[] arr = new char[windowWidth];

            while (true)
            {
                Console.Clear();
                for (int i = 0; i < windowHeight; i++)
                {
                    for (int j = 0; j < windowWidth; j++)
                    {
                        arr[j] = window[j, i];
                    }
                    Console.WriteLine(arr);

                }
                Thread.Sleep(300);
            }
        }

        public void CharsInColumn(object i)
        {
            int iteration = 0;
            int[] values = new int[52];         //массив для выбора значений
            for (int g = 65; g <= 90; g++)
            {
                values[iteration] = g;
                iteration++;
            }
            for (int g = 97; g <= 122; g++)
            {
                values[iteration] = g;
                iteration++;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Random rand = new Random();
            iteration = 0;
            int temp = 0;

            while (iteration <= windowHeight + track - 1)
            {
                temp = 0;
                //if (iteration == 20)
                //{
                //    window[(int)i, iteration - track - trackIter] = ' ';
                //    trackIter++;
                //}
                if (iteration - track >= 0)
                {
                    window[(int)i, iteration - track] = ' ';
                    //while (iteration - track <= windowHeight)
                    //{
                    //    window[(int)i, iteration - track] = (char)values[rand.Next(0, 51)];
                    //}
                }

                while (temp < track && iteration - temp >= 0 && iteration < windowHeight)
                {

                    window[(int)i, iteration - temp] = (char)values[rand.Next(0, 51)];
                    temp++;
                }

                iteration++;
                Thread.Sleep(300);
            }
        }

    }

}
