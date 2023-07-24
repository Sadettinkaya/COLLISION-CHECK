using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sakaryaprojedönem2
{
    public class Dikdortgen:Form1
    {
        Point m;
        int en;
        int boy;

        public Dikdortgen()
        {
            m = new Point();
            en = 0;
            boy = 0;

        }

        public Dikdortgen(Point p, int En, int Boy)
        {
            this.m = p;
            this.en = En;
            this.boy = Boy;
        }

        public Point M { get => m; set => m = value; }
        public int En { get => en; set => en = value; }
        public int Boy { get => boy; set => boy = value; }
    }
}
