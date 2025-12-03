using System;

namespace Geometry
{
    public class Vector
    {
        public double X;
        public double Y;

        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public Vector Add(Vector other)
        {
            return Geometry.Add(this, other);
        }

        public bool Belongs(Segment segment)
        {
            return Geometry.IsVectorInSegment(this, segment);
        }
    }

    public class Segment
    {
        public Vector Begin;
        public Vector End;

        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public bool Contains(Vector vector)
        {
            return Geometry.IsVectorInSegment(vector, this);
        }
    }

    public static class Geometry
    {
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            return new Vector
            {
                X = vector1.X + vector2.X,
                Y = vector1.Y + vector2.Y
            };
        }

        public static double GetLength(Segment segment)
        {
            double deltaX = segment.End.X - segment.Begin.X;
            double deltaY = segment.End.Y - segment.Begin.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {
            double totalLength = GetLength(segment);
            double lengthToBegin = GetLength(new Segment { Begin = segment.Begin, End = vector });
            double lengthToEnd = GetLength(new Segment { Begin = vector, End = segment.End });
            
            return Math.Abs(totalLength - (lengthToBegin + lengthToEnd)) < 1e-10;
        }
    }
}
