using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KDTreeDLL;

namespace LdrawData
{
    public class PointsManager
    {
        private KDTree kd;
        public List<Vector3> points = new List<Vector3>();

        public PointsManager()
        {
            kd = new KDTree(3);
        }

        public int addOrNearest(Vector3 v)
        {
            int n;
            Vector3 N;

            if (points.Count > 0)
            {
                n = (int) kd.nearest( v.Array ); // get nearest
                N = points.ElementAt(n);

                if (N.Distance(v) > 0.00001) // nearest one is too far.
                {
                    // add poinbt to Points list and KD insert.
                    kd.insert(v.Array, points.Count);
                    points.Add(new Vector3(v));
                    //kd = KDTree.MakeFromPoints(points.ToArray());
                    return points.Count;
                }
                else
                    return n + 1; // good near one is found.
            }
            else // No other point, add 
            {
                // add both points and kd tree item
                kd.insert(v.Array, 0);
                points.Add(new Vector3(v));
                //kd = KDTree.MakeFromPoints(points.ToArray());
                return points.Count;
            }

        }

        public void clear()
        {
            points.Clear();
            //kd = null;
            //kd = new KDTree();
        }

    }
}
