using System;

namespace Structures
{

    struct Train
    {
        string TrainName;
        public int TrainNumber { get;}
        DateTime Time;

        public Train(string name, int number, DateTime time)
        {
            TrainName = name;
            TrainNumber = number;
            Time = time;
        }

        override public string ToString()
        {
            string result = "Name:" + TrainName + "\nNumber:" + TrainNumber + "\nDeparture time:" + Time;
            return result;
        }
    }

    static class Sort_class
    {
        public static Array Sort(Train[] arr)
        {
            Train temp;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j].TrainNumber < arr[j + 1].TrainNumber)
                    {
                        // меняем элементы местами
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Train[] trains = new Train[3];
            string decision1;
            DateTime decision2;
            int decision3;

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter the name of the train");
                decision1 = Console.ReadLine();
                Console.WriteLine("Enter the name of the train");
                decision3 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the departure time (dd mm yy hh:mm)");
                decision2 = Convert.ToDateTime(Console.ReadLine());

                trains[i] = new Train(decision1, decision3, decision2);
            }

            Sort_class.Sort(trains);

            while(true)
            {
                Console.WriteLine("If you wanna see the information about the train press 1 or press 2 to exit");
                decision3 = Convert.ToInt32(Console.ReadLine());
                if(decision3==1)
                {
                    Console.WriteLine("Enter the number of the train");
                    decision3 = Convert.ToInt32(Console.ReadLine());
                    for(int i=0;i<3;i++)
                    {
                        if (trains[i].TrainNumber == decision3)
                        {
                            Console.WriteLine(trains[i].ToString());
                            break;
                        }
                    }
                }
                else
                    Environment.Exit(0);
            }
        }
    }
}
