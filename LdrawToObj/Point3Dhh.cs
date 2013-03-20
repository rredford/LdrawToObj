using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point3DData
{
    public class Point3D
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public Point3D() { this.x = 0.0; this.y = 0.0; this.z = 0.0; }
        public Point3D(double x, double y, double z) { this.x = x; this.y = y; this.z = z; }
        public static Boolean operator ==(Point3D a, Point3D b)
        {
            if (a == null || b == null)
                return false;
            if ((a.x == b.x) && (a.y == b.y) && (a.z == b.z)) return true; else return false;
        }
        public static Boolean operator !=(Point3D a, Point3D b) { return !(a == b); }
    }
}
