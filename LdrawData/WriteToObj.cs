using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LdrawData;
using System.IO;

namespace LdrawData
{
    public class WriteToObj
    {

        static String st = "LDrawStep";
        static String lt = "LDrawLine";

        // Writes standard header
        private static void writeobjheader(StreamWriter writefile)
        {
            writefile.WriteLine("# Converted by LdrDat2Obj version 2");
            writefile.WriteLine("mtllib Legocolors.mtl");
        }

        // OBJ format grouping
        private static void writeobjgroup(bool l, bool s, int line, int step, StreamWriter writefile)
        {
            if (l & !s)
                writefile.Write("g " + lt + line.ToString());
            else if (!l & s)
                writefile.Write("g " + st + step.ToString());
            else
                writefile.Write("g " + lt + line.ToString() + " " + st + step.ToString());

            writefile.WriteLine("");

            //writefile.WriteLine("g " + st + step + " " + lt + line);
        }


        static public int writeObj(StreamWriter w, List<Vector3> points, List<PolyShape> polys, bool Line, bool Step)
        {
            int line = 0, step = 0, color = -1;
            bool l = true, s = true;// true to force firsr poly to be in group too
            double y, z;

            writeobjheader(w);

            //vertexes
            foreach (Vector3 v in points)
            {
                // flip Y so obj format is correctly up, then Z to correct handness.
                y = -v.Y;
                z = -v.Z;
                w.WriteLine("v " + v.X.ToString("0.00000") + " " + y.ToString("0.00000") + " " + z.ToString("0.00000"));
            }

            // polys (anf grouping with it)
            foreach (PolyShape p in polys)
            {
                // material (color)
                if(color != p.color)
                {
                    w.WriteLine("usemtl Ldraw" + p.color.ToString());
                    color = p.color;
                }

                // 3 or 4 point polys, check step or line as it progresses for inequality.
                if (Line)
                {
                    if (line != p.line)
                    {
                        l = true;
                        line = p.line;
                    }
                    else
                        l = false;
                }
                if (Step)
                {
                    if (step != p.step)
                    {
                        s = true;
                        step = p.step;
                    }
                    else
                        s = false;
                }
                if(l || s)
                    writeobjgroup(l && Line, s && Step, line, step, w);

                if(p.numpoints == 3)
                    w.WriteLine("f " + p.p1 + " " + p.p2 + " " + p.p3);
                else if (p.numpoints == 4)
                    w.WriteLine("f " + p.p1 + " " + p.p2 + " " + p.p3 + " " + p.p4);

            }

            return 0;
        }
    }
}
