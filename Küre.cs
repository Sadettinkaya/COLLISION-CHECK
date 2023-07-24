using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static sakaryaprojedönem2.Form1.Point;

namespace sakaryaprojedönem2
{
    public class Kure:Form1
    {
        Point3d m;
        int r;
        public Kure()
        {
            m = new Point3d();
            r = 0;
        }

        public Kure(Point3d P, int R)
        {
            this.m = P;
            this.r = R;
        }

        public Point3d M { get => m; set => m = value; }
        public int R { get => r; set => r = value; }
    }
}
