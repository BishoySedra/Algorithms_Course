using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;

class Program
{
    public struct Point
    {
        public double X;
        public double Y;
    }

    public struct BoundingBox
    {
        public double minX;
        public double minY;
        public double maxX;
        public double maxY;
    }

    public static double GetMaxX(Point[] Points, int start, int end)
    {

        if (start >= end)
        {
            return Points[start].X;
        }

        int mid1 = start + (end - start) / 3;
        int mid2 = end - (end - start) / 3;

        if (Points[mid1].X < Points[mid2].X)
        {
            return GetMaxX(Points, mid1 + 1, end);
        }
        else
        {
            return GetMaxX(Points, start, mid2 - 1);
        }

    }

    public static double GetMaxY(Point[] Points, int start, int end)
    {

        int mid = start + (end - start) / 2;

        if (start >= end)
        {
            return Points[start].Y;
        }

        if (Points[mid].Y < Points[mid + 1].Y)
        {
            return GetMaxY(Points, mid + 1, end);
        }

        return GetMaxY(Points, start, mid - 1);
    }

    public static double GetMinY(Point[] Points, int start, int end)
    {

        int mid = start + (end - start) / 2;

        if (start >= end)
        {
            return Points[start].Y;
        }

        if (Points[mid].Y > Points[mid + 1].Y)
        {
            return GetMinY(Points, mid + 1, end);
        }

        return GetMinY(Points, start, mid - 1);
    }

    public static int GetMaxCriticalIndex(Point[] Points, int start, int end)
    {

        if (start >= end)
        {
            return start;
        }

        int mid1 = start + (end - start) / 3;
        int mid2 = end - (end - start) / 3;

        if (Points[mid1].Y < Points[mid2].Y)
        {
            return GetMaxCriticalIndex(Points, mid1 + 1, end);
        }
        else
        {
            return GetMaxCriticalIndex(Points, start, mid2 - 1);
        }

    }

    public static int GetMinCriticalIndex(Point[] Points, int start, int end)
    {
        if (start >= end)
        {
            return start;
        }

        int mid1 = start + (end - start) / 3;
        int mid2 = end - (end - start) / 3;

        if (Points[mid1].Y > Points[mid2].Y)
        {
            return GetMinCriticalIndex(Points, mid1 + 1, end);
        }
        else
        {
            return GetMinCriticalIndex(Points, start, mid2 - 1);
        }
    }

    static void Main(string[] args)
    {
        do
        {

            // create an array of points with input size
            Console.WriteLine("Enter the number of points");
            int N = Convert.ToInt32(Console.ReadLine());
            Point[] Points = new Point[N];

            // read the points
            // ask to press enter to generate random points
            
            //Console.WriteLine("Press Enter to generate random points");
            //Console.ReadLine();

            for (int i = 0; i < Points.Length; i++)
            {
                Console.WriteLine("Enter X and Y for point " + (i + 1));
                string coordinates = Console.ReadLine();
                string[] coordinatesArray = coordinates.Split(' ');
                double X = Convert.ToDouble(coordinatesArray[0]);
                double Y = Convert.ToDouble(coordinatesArray[1]);
                // generate some random double points
                //Random random = new Random();
                //double X = random.Next(0, 1000000);
                //double Y = random.Next(0, 1000000);
                //Console.WriteLine("X = " + X + " Y = " + Y);
                Points[i].X = X;
                Points[i].Y = Y;
            }

            BoundingBox box = new BoundingBox();

            if (N == 1)
            {
                box.minX = Points[0].X;
                box.maxX = Points[0].X;
                box.minY = Points[0].Y;
                box.maxY = Points[0].Y;
                
                Console.WriteLine("Min X = " + box.minX);
                Console.WriteLine("Max X = " + box.maxX);
                Console.WriteLine("Min Y = " + box.minY);
                Console.WriteLine("Max Y = " + box.maxY);
                Console.WriteLine("=============================");
                continue;
            }

            // Guranteed that first point has the minimum X
            box.minX = Points[0].X;

            // getting the maximum X by getting the critical point splitting increasing and decreasing
            box.maxX = GetMaxX(Points, 0, N - 1);

            // getting the critical point splitting increasing and decreasing
            int critical_index = 0;
            if (Points[0].Y < Points[1].Y)
            {
                critical_index = GetMaxCriticalIndex(Points, 0, N - 1);
            }
            else
            {
                critical_index = GetMinCriticalIndex(Points, 0, N - 1);
            }

            // getting the minimum Y starting from the first point to the critical point
            double min1 = GetMinY(Points, 0, critical_index);
            // getting the minimum Y starting from the critical point to the last point
            double min2 = GetMinY(Points, critical_index, N - 1);

            if (min1 < min2)
            {
                box.minY = min1;
            }
            else
            {
                box.minY = min2;
            }

            // getting the maximum Y starting from the first point to the critical point
            double max1 = GetMaxY(Points, 0, critical_index);
            // getting the maximum Y starting from the critical point to the last point
            double max2 = GetMaxY(Points, critical_index, N - 1);

            if (max1 > max2)
            {
                box.maxY = max1;
            }
            else
            {
                box.maxY = max2;
            }

            Console.WriteLine("Min X = " + box.minX);
            Console.WriteLine("Max X = " + box.maxX);
            Console.WriteLine("Min Y = " + box.minY);
            Console.WriteLine("Max Y = " + box.maxY);
            Console.WriteLine("=============================");


        } while (true);
    }
}