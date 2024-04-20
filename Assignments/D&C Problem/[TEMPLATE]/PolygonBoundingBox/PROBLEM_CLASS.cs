﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************

    #region Helper structures
    public struct BoundingBox
    {
        public double minX;
        public double minY;
        public double maxX;
        public double maxY;
    }

    public struct Point
    {
        public double X;
        public double Y;
    }
    #endregion

    public static class PROBLEM_CLASS
    {
        #region YOUR CODE IS HERE

        //Your Code is Here:
        //==================
        /// <summary>
        /// This function shall find the bounding box of a given convex polygon in an efficient way (i.e. minX, maxX, minY, maxY)..
        /// </summary>
        /// <param name="Points">Array of the convex polygon points in counterclockwise order</param>
        /// <param name="N">The number of the polygon's points</param>
        /// <returns>BoundingBox object containing the values of the four points of the bounding box</returns>

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

            return GetMaxX(Points, start, mid2 - 1);

        }

        public static double GetMaxY(Point[] Points, int start, int end)
        {

            if (start >= end)
            {
                return Points[start].Y;
            }

            int mid = start + (end - start) / 2;

            if (Points[mid].Y < Points[mid + 1].Y)
            {
                return GetMaxY(Points, mid + 1, end);
            }

            return GetMaxY(Points, start, mid - 1);

        }

        public static double GetMinY(Point[] Points, int start, int end)
        {

            if (start >= end)
            {
                return Points[start].Y;
            }

            int mid = start + (end - start) / 2;

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

            return GetMaxCriticalIndex(Points, start, mid2 - 1);

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

            return GetMinCriticalIndex(Points, start, mid2 - 1);

        }

        public static BoundingBox RequiredFunction(Point[] Points, int N)
        {

            BoundingBox box = new BoundingBox();

            if (N == 1)
            {
                box.minX = Points[0].X;
                box.maxX = Points[0].X;
                box.minY = Points[0].Y;
                box.maxY = Points[0].Y;
                return box;
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

            return box;

            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
        }
        #endregion 
    }
}
