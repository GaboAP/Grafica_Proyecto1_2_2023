using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGrafica
{
    class Point
    {
        public Double X, Y, Z;
        public Point(Double x, Double y, Double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Point operator -(Point a, Point b) => new Point(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Point operator *(Point a, Point b) => new Point(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        public static Point operator *(Point a, Matrix3 b) => new Point(
            a.X * b.M11 + a.Y * b.M12 + a.Z * b.M13,
            a.X * b.M21 + a.Y * b.M22 + a.Z * b.M23,
            a.X * b.M31 + a.Y * b.M32 + a.Z * b.M33);
    }
}
