using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static sakaryaprojedönem2.Form1.Point;

namespace sakaryaprojedönem2
{
   
    public class Dikdortgenprizma:Form1
    {
        Point3d m;
        private int h;
        private int en;
        private int boy;
        private int derinlik;

        public Dikdortgenprizma(Point3d M, int H, int En, int Boy, int Derinlik)
        {
            this.m = M;
            this.h = H;
            this.en = En;
            this.boy = Boy;
            this.derinlik = Derinlik;
        }
        public Dikdortgenprizma()
        {
            m = new Point3d();
            this.h = 0;
            this.boy = 0;
            this.derinlik = 0;
            this.en = 0;
        }

        public Point3d M { get => m; set => m = value; }
        public int H { get => h; set => h = value; }
        public int En { get => en; set => en = value; }
        public int Boy { get => boy; set => boy = value; }
        public int Derinlik { get => derinlik; set => derinlik = value; }


    }

}
