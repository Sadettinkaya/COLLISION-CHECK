using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static sakaryaprojedönem2.Form1.Point;

namespace sakaryaprojedönem2
{
    public class Silindir:Form1
    {
        Point3d m;
        int r;
        int h;

        public Silindir()
        {
            m = new Point3d();
            r = 0;
            h = 0;
        }

        public Silindir(Point3d point3d, int v)
        {
        }

        public Silindir(Point3d p, int R, int H)
        {
            this.m = p;
            this.r = R;
            this.h = H;
        }

        public Point3d M { get => m; set => m = value; }
        public int R { get => r; set => r = value; }
        public int H { get => h; set => h = value; }

    }
}
