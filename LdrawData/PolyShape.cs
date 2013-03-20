using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LdrawData
{
    public class PolyShape
    {
        public int numpoints { get; set; }
        public int color { get; set; }
        public int line { get; set; }
        public int step { get; set; }

        public int p1 { get; set; }
        public int p2 { get; set; }
        public int p3 { get; set; }
        public int p4 { get; set; }

        public PolyShape() { }
        public PolyShape(int numpoints, int color, int line, int step, int i1, int i2, int i3, int i4) 
        {
            this.numpoints = numpoints;
            this.color = color;
            this.line = line;
            this.step = step;
            p1 = i1;
            p2 = i2;
            p3 = i3;
            p4 = i4;
        }
    }
}
