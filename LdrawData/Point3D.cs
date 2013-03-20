using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point3DData
{
    public class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Point3D() { this.X = 0.0; this.Y = 0.0; this.Z = 0.0; }
        public Point3D(double x, double y, double z) { this.X = x; this.Y = y; this.Z = z; }
        public static Boolean operator ==(Point3D a, Point3D b)
        {
            if (a == null || b == null)
                return false;
            if ((a.X == b.X) && (a.Y == b.Y) && (a.Z == b.Z)) return true; else return false;
        }
        public static Boolean operator !=(Point3D a, Point3D b) { return !(a == b); }
        public override int GetHashCode() { return (X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode()); }
        public override bool Equals(Object a) { Point3D b = (Point3D)a; return X == b.X && Y == b.Y && Z == b.Z; }
    }
}
