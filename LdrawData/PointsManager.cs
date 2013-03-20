using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LdrawData
{
    public class PointsManager
    {
        private KDTree kd;
        public List<Vector3> points = new List<Vector3>();

        public PointsManager()
        {
        }

        public int addOrNearest(Vector3 v)
        {
            int n;
            Vector3 N;

            if (points.Count > 0)
            {
                n = kd.FindNearest(v); // get nearest
                N = points.ElementAt(n);
                if (N.Distance(v) > 0.00001) // nearest one is too far.
                {
                    // add and rebuild kd
                    points.Add(new Vector3(v));
                    kd = KDTree.MakeFromPoints(points.ToArray());
                    return points.Count;
                }
                else
                    return n + 1; // good near one is found.
            }
            else // No other point, add 
            {
                // add and rebuild kd
                points.Add(new Vector3(v));
                kd = KDTree.MakeFromPoints(points.ToArray());
                return points.Count - 1;
            }

        }

        public void clear()
        {
            points.Clear();
            kd = null;
        }

    }
}
