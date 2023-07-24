using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sakaryaprojedönem2
{
    public class circle:Form1 //çember sınıfı
    {
        Point m; //m(x,y) diye bir merkez noktası tanımladım
        int r; //yarı çap tanımladım

        public circle()
        {
            Point m = new Point(); // point sınıfından bir nesne oluşturduk new point() diyerek
                                   //o nesnenin referansını m değişkenine atadık m burda merkez noktasu gibi oldu
            r = 0;
        }

        public circle(Point P, int R)
        {
            this.m = P;
            this.r = R;

        }

        public int R { get => r; set => r = value; }
        public Point M { get => m; set => m = value; }

    }
}
