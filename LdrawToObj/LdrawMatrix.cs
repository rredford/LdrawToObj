using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Point3DData;
using ldrawToObj;

namespace LdrawMatrixData
{
    public class LdrawMatrix
    {
        public int color { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public double d { get; set; }
        public double e { get; set; }
        public double f { get; set; }
        public double g { get; set; }
        public double h { get; set; }
        public double i { get; set; }
        public LdrawMatrix(int color = 0, double x = 0.0, double y = 0.0, double z = 0.0, double a = 1.0,
               double b = 0.0, double c = 0.0, double d = 0.0, double e = 1.0, double f = 0.0,
               double g = 0.0, double h = 0.0, double i = 1.0)
        {
            this.color = color;
            this.x = x;
            this.y = y;
            this.z = z;
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            this.f = f;
            this.g = g;
            this.h = h;
            this.i = i;
        }//default I3 matrix.

        // Transforms a point into this coordite system...
        public void transformPoint(Vector3 p)//Point3D p)
        {
            Vector3 z = new Vector3(0.0, 0.0, 0.0);

            // Matrix math - transformation
            z.X = (this.a * p.X) + (this.b * p.Y) + (this.c * p.Z) + this.x;
            z.Y = (this.d * p.X) + (this.e * p.Y) + (this.f * p.Z) + this.y;
            z.Z = (this.g * p.X) + (this.h * p.Y) + (this.i * p.Z) + this.z;
            p.X = z.X;
            p.Y = z.Y;
            p.Z = z.Z;
            //return new Point3D(p.x, p.y, p.z);
        }
    }
}
