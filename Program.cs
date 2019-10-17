using System;

namespace ITVDN_1
{
    public class Point
    {

        public int A { get; }
        public int B { get; }
        public Point(int r, int g)
        {
            this.A = r;
            this.B = g;
        }
    }


    public class Figure
    {
        Point[] arr;
        public Figure(params Point[] points)
        {
            if (points.Length < 3 || points.Length > 5)
            {
                Console.WriteLine("Wrong input");
                Environment.Exit(0);
            }
            arr = new Point[points.Length];
            for (int i = 0; i < points.Length; i++)
                arr[i] = points[i];
        }

        public double LenghtSide(Point First, Point Second)
        {
            double result, result1 = 0, result2 = 0;
            result1 = Math.Pow((First.A - Second.A), 2);
            result2 = Math.Pow((First.B - Second.B), 2);
            result = Math.Pow((result1 + result2), 1.0 / 2.0);
            return result;
        }

        public void PerimeterCalculator()
        {
            double result = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                result += LenghtSide(arr[i], arr[i + 1]);
            }
            result += LenghtSide(arr[0], arr[arr.Length - 1]);
            Console.WriteLine("Perimeter is" + result);
        }
    }

    class Run
    {
        static void Main()
        {
            Point first = new Point(0, 0);
            Point second = new Point(0, 7);
            Point third = new Point(7, 0);
            Figure figure = new Figure(first, second, third);
            figure.PerimeterCalculator();
        }
    }
}