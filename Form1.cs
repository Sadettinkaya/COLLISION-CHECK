
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static sakaryaprojedönem2.Form1.Point;

namespace sakaryaprojedönem2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Point
        {
            private int x;
            private int y;

            public int X { get => x; set => x = value; } //kapsülledim
            public int Y { get => y; set => y = value; }

            public Point(int X, int Y)
            {
                this.x = X;
                this.y = Y;
            }

            public Point()
            {
                x = 0; y = 0; //kurucu method burda bir değer atanmadığı sürece varsayılan değerleri yazdırıyor
            }

            public class Point3d : Point //3boyut
            {
                private int z;

                public Point3d()
                {
                }

                public Point3d(int Z)
                {
                    this.z = Z;
                }

                public Point3d(int X, int Y, int Z) : base(X, Y)
                {
                }

                public int Z { get => z; set => z = value; }
            }
            public static class Carpisma //çarpışma satatic sınıfını tanımladım
            {
                public static bool CircleCarp(circle c1, circle c2) //true false döndürmesi için bool tipinde static fonk yazdım
                {
                    float uzaklik = (float)Math.Sqrt(Math.Pow((c1.M.X - c2.M.X), 2) + Math.Pow((c1.M.Y - c2.M.Y), 2));

                    if ((c1.R + c2.R) > uzaklik)
                        return true;
                    else
                        return false;

                }
             
                public static bool KureCarp(Kure k1, Kure k2) //true false döndürmesi için bool tipinde static fonk yazdım
                {
                    float uzaklık = (float)Math.Sqrt(Math.Pow((k1.M.X - k2.M.X), 2) + Math.Pow((k1.M.Y - k2.M.Y), 2) + Math.Pow((k1.M.Z - k2.M.Z), 2));

                    if ((k1.R + k2.R) > uzaklık)
                        return true;
                    else
                        return false;
                }
                public static bool DikdortgenCarp(Dikdortgen d1, Dikdortgen d2)//true false döndürmesi için bool tipinde static fonk yazdım
                {
                    int Xa = d1.M.X + d1.En / 2;
                    int Ya = d1.M.Y + d1.Boy / 2;
                    int Xb = d2.M.X + d2.En / 2;
                    int Yb = d2.M.Y + d2.Boy / 2;
                    if ((Math.Abs(Xa - Xb) < (d1.En / 2 + d2.En / 2) && Math.Abs(Ya - Yb) < (d1.Boy / 2 + d2.Boy / 2)))
                        return true;
                    else
                        return false;
                }
                public static bool SilindirCarp(Silindir s1, Silindir s2)//true false döndürmesi için bool tipinde static fonk yazdım
                {
                    Point3d pa = new Point3d(s1.M.X, s1.M.Y + s1.H / 2, s1.M.Z);
                    Point3d pb = new Point3d(s2.M.X, s2.M.Y + s2.H / 2, s2.M.Z);
                    float uzaklık = (float)Math.Sqrt(Math.Pow((pa.X - pb.X), 2) + Math.Pow((pa.Y - pb.Y), 2) + Math.Pow((pa.Z - pb.Z), 2));
                    if ((s1.R + s2.R) > uzaklık && Math.Abs(pa.Y - pb.Y) < ((s1.H + s2.H) / 2))
                        return true;
                    else
                        return false;
                }

                public static bool silindirNoktaCarp(Silindir s1,Point3d nokta)
                {
                    float x_uzaklik = Math.Abs(nokta.X - s1.M.X);
                    float y_uzaklik = Math.Abs(nokta.Y - s1.M.Y);
                    float z_uzaklik = Math.Abs(nokta.Z - s1.M.Z);
                    if(x_uzaklik <= s1.R &&  y_uzaklik <= s1.H/2 && z_uzaklik<=s1.R)
                        return true;
                    else
                        return false;


                }
                public static bool noktaCemberCarp(circle cmbr1, Point n)
                {
                    float uzaklik = (float)Math.Sqrt(Math.Pow((cmbr1.M.X - n.X), 2) + Math.Pow((cmbr1.M.Y - n.Y), 2));
                    if (uzaklik < cmbr1.R)
                        return true;
                    else
                        return false;
                }

               public static bool cemberDikdortgenCarp (Dikdortgen d1,circle c1)
                {
                    float uzaklık = (float)Math.Sqrt(Math.Pow((c1.M.X - d1.M.X), 2) + Math.Pow((c1.M.Y - d1.M.Y), 2));
                    float kosegen = (float)Math.Sqrt(Math.Pow((d1.Boy), 2) + Math.Pow((d1.En), 2));
                    if(uzaklık<kosegen/2 + c1.R)
                        return true;
                    else
                        return false;
                }
                
                public static bool kureKureCarp(Kure k1,Kure k2)
                {
                    float uzaklık = (float)Math.Sqrt(Math.Pow((k1.M.X - k2.M.X), 2) + Math.Pow((k1.M.Y - k2.M.Y), 2) + Math.Pow((k1.M.Z - k2.M.Z), 2));
                    if(k1.R+k2.R <=uzaklık) 
                        return true;
                        return false;

                }

                public static bool yuzeyKureCarp(Dikdortgenprizma y1,Kure k1)
                {
                    float uzaklik = (float)Math.Sqrt(Math.Pow((y1.M.X - k1.M.X), 2) + Math.Pow((y1.M.Y - k1.M.Y), 2) + Math.Pow((y1.M.Z - k1.M.Z), 2));
                    if (uzaklik <= k1.R + y1.En / 2 && uzaklik <= k1.R + y1.Boy / 2 && uzaklik <= k1.R + y1.Derinlik / 2)
                        return true;
                    else
                        return false;



                }
                public static bool noktaKureCarp(Kure k1,Point3d nokta)
                {
                    float uzaklik = (float)Math.Sqrt(Math.Pow((k1.M.X - nokta.X), 2) + Math.Pow((k1.M.Y - nokta.Y), 2)+ Math.Pow((k1.M.Z - nokta.Z), 2));
                    if(k1.R<=uzaklik)
                        return
                            true;
                    else
                        return 
                            false;

                }
                public static bool dikdortgenprizmalarCarp(Dikdortgenprizma d1, Dikdortgenprizma d2)
                {
                    float x_uzaklik=Math.Abs(d1.M.X-d2.M.X);
                    float y_uzaklik = Math.Abs(d1.M.Y - d2.M.Y);
                    float z_uzaklik = Math.Abs(d1.M.Z - d2.M.Z);

                    if(x_uzaklik<=d1.En/2 + d2.En/2 && y_uzaklik<= d1.Boy/2 + d2.Boy/2 && z_uzaklik<= d1.Derinlik/2+d2.Derinlik/2)
                        return
                            true;
                        return
                           false;

                }

                public static bool yuzeyDikdortgenprizma(Dikdortgenprizma k1, Dikdortgenprizma d2)
                {
                    float x_uzaklik = Math.Abs(k1.M.X - d2.M.X);
                    float y_uzaklik = Math.Abs(k1.M.Y - d2.M.Y);
                    float z_uzaklik = Math.Abs(k1.M.Z - d2.M.Z);

                    if (x_uzaklik <= k1.En / 2 + d2.En / 2 && y_uzaklik <= k1.Boy / 2 + d2.Boy / 2 && z_uzaklik <= k1.Derinlik / 2 + d2.Derinlik / 2)
                        return
                            true;
                    return
                       false;
                }
                public static bool yuzeySilindirCarp(Dikdortgenprizma y1,Silindir s1)
                {

                    float uzaklik = (float)Math.Sqrt(Math.Pow((y1.M.X - s1.M.X), 2) + Math.Pow((y1.M.Y - s1.M.Y), 2) + Math.Pow((y1.M.Z - s1.M.Z), 2));
                    if (uzaklik <= s1.R + y1.En / 2 && uzaklik <= s1.R + y1.Boy / 2 && uzaklik <= s1.R + y1.Derinlik / 2)
                        return true;
                    else
                        return false;

                }
                public static bool noktaDikdortgenprizmaCarp(Dikdortgenprizma d1,Point3d n1)
                {
                    float x_uzaklik = Math.Abs(d1.M.X - n1.X); 
                    float y_uzaklik = Math.Abs(d1.M.Y - n1.Y);
                    float z_uzaklik = Math.Abs(d1.M.Z - n1.Z);

                    if(x_uzaklik<=d1.En && y_uzaklik<= d1.Boy && z_uzaklik<= d1.Derinlik)
                        return true;
                    else
                        return false;

                }
                public static bool kureSilindirCarp(Kure k1, Silindir s1)
                {
                    float x_uzaklik = Math.Abs(k1.M.X - s1.M.X);
                    float y_uzaklik = Math.Abs(k1.M.Y - s1.M.Y);
                    float z_uzaklik = Math.Abs(k1.M.Z - s1.M.Z);

                    if(x_uzaklik <=k1.R+s1.R && y_uzaklik <= k1.R+s1.H/2 && z_uzaklik <=k1.R+s1.R)

                        return true;
                    else 
                        return false;
                }
                
                public static bool kureDikdortgenprizmaCarp(Kure k1,Dikdortgenprizma d1)
                {
                    float uzaklik = (float)Math.Sqrt(Math.Pow((k1.M.X - d1.M.X), 2) + Math.Pow((k1.M.Y - d1.M.Y), 2) + Math.Pow((k1.M.Z - d1.M.Z), 2));
                    if(uzaklik<=k1.R+d1.En/2 && uzaklik<= k1.R+d1.Boy/2 && uzaklik<= k1.R+d1.Derinlik/2)
                        return true;
                    else 
                        return false;
                }
                public static bool noktaDortgenCarp(Dikdortgen d1, Point n1)
                {
                    float uzaklik = (float)Math.Sqrt(Math.Pow((d1.M.X - n1.X), 2) + Math.Pow((d1.M.Y - n1.Y), 2));
                    if (uzaklik < d1.En / 2 && uzaklik < d1.Boy / 2)
                        return true;
                    else
                        return false;

                }
            }

        }

        private void noktaçember_Click(object sender, EventArgs e)
        {
            circle cmbr1 = new circle(new Point(1, 5), 2);
            Point nkt1 = new Point(5, 4);

            if (Carpisma.noktaCemberCarp(cmbr1, nkt1))
                textBox2.Text = "Çemberle nokta çarpışmıştır";
            else
                textBox2.Text = "Çemberle nokta çarpışmamıştır";

            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.DrawEllipse(Pens.Black,100,250,2,2);
            graphics.DrawEllipse(Pens.Black, 500, 200, 100, 100);
           

        }
        

        private void çemberçember_Click(object sender, EventArgs e)
        {
            circle cember1 = new circle(new Point(5, 7), 6);

            circle cember2 = new circle(new Point(7, 8), 1);

            if (Carpisma.CircleCarp(cember1, cember2))
                textBox5.Text = "Çemberler çarpışıyor";
            else
                textBox5.Text = "Çemberler çapışmıyor";

            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.DrawEllipse(Pens.Black, 100, 140, 120, 120);
            graphics.DrawEllipse(Pens.Black, 140, 160, 20, 20);
        }

        private void dikdörtgendikdörtgen_Click(object sender, EventArgs e)
        {

            Dikdortgen dikdortgen = new Dikdortgen(new Point(3, 6), 3, 2);
            Dikdortgen dikdortgen2 = new Dikdortgen(new Point(2, 2), 3, 1);


            if (Carpisma.DikdortgenCarp(dikdortgen, dikdortgen2))
                textBox3.Text = "Dikdörtgenler çarpışıyor";

            else
                textBox3.Text = "Dikdörtgenler çarpışmıyor";

            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.DrawRectangle(Pens.Black, 60, 120, 60, 40);
            graphics.DrawRectangle(Pens.Black, 40, 40, 60, 20);


        }

        private void noktadörtgen_Click(object sender, EventArgs e)
        {
            Dikdortgen dikdörtgen = new Dikdortgen( new Point(1, 2), 2, 4);
            Point n1 = new Point(8, 4);
            if (Carpisma.noktaDortgenCarp(dikdörtgen, n1))
                textBox1.Text = "Dikdörtgen ve nokta çarpışmıştır";
            else
                textBox1.Text = "Dikdörtgen ve nokta çarpışmamıştır";

            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.DrawRectangle(Pens.Black,20,40,40,80);
           
           graphics.DrawEllipse(Pens.Black,320,80,2,2);

        }

        private void silindirsilindir_Click(object sender, EventArgs e)
        {
            Silindir s1 = new Silindir(new Point3d(2, 4, 3), 5,7);


            Silindir s2 = new Silindir(new Point3d(1, 9, 3), 6,5);


            if (Carpisma.SilindirCarp(s1, s2))
                textBox9.Text = "Silindirler çarpışmıştır";
            else
                textBox9.Text = "Silindirler çarpışmamıştır";

            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.DrawLine(Pens.Black, 150, 350, 150, 200);
            graphics.DrawLine(Pens.Black, 350, 350, 350, 200);
            graphics.DrawEllipse(Pens.Black,150,320,200,50);
            graphics.DrawEllipse(Pens.Black,150,179,200,50);

            graphics.DrawLine(Pens.Black, 290, 350, 290, 200);
            graphics.DrawLine(Pens.Black, 490, 350, 490, 200);
            graphics.DrawEllipse(Pens.Black, 290, 320, 200, 50);
            graphics.DrawEllipse(Pens.Black, 290, 179, 200, 50);

            
        }


        private void dikdörtgençember_Click(object sender, EventArgs e)
        {
            Dikdortgen dikdortgen1 = new Dikdortgen(new Point(2, 4),3, 1);
            circle cember = new circle(new Point(1, 6), 2);

            if (Carpisma.cemberDikdortgenCarp(dikdortgen1, cember))
                textBox4.Text = "Dikdörtgen ve çember çarpışmıştır";

            else 
                textBox4.Text = "Dikdörtgen ve çember çarpışmamıştır";

            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.DrawRectangle(Pens.Black, 100, 200, 150, 50);
            graphics.DrawEllipse(Pens.Black, 50, 100, 200, 200);



        }

        private void noktaküre_Click(object sender, EventArgs e)
        {
            Kure kure = new Kure(new Point3d(2,4,5),7);
            Point3d nokta=new Point3d(2,4,6);
            if (Carpisma.noktaKureCarp(kure, nokta))
                textBox6.Text = "Nokta ve küre çarpışmıştır";
            else
                textBox6.Text = "Nokta ve küre çarpışmamıştır";

            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.DrawEllipse(Pens.Black,40,80,140,140);
            graphics.DrawEllipse(Pens.Black,42,129,138,30);
            graphics.DrawRectangle(Pens.Black,40,80,2,1) ;


        }

        private void noktasilindir_Click(object sender, EventArgs e)
        {
            Silindir s1 = new Silindir(new Point3d(4, 3, 3), 5,8);
            Point3d nokta=new Point3d(4, 3,6);
            if (Carpisma.silindirNoktaCarp(s1, nokta))
                textBox8.Text = "Nokta ve silindir çarpışmıştır";
            else
                textBox8.Text = "Nokta ve silindir çarpışmamıştır";

            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.DrawEllipse(Pens.Black, 290, 300, 2, 2);
            graphics.DrawLine(Pens.Black, 150, 350, 150, 200);
            graphics.DrawLine(Pens.Black, 350, 350, 350, 200);
            graphics.DrawEllipse(Pens.Black, 150, 320, 200, 50);
            graphics.DrawEllipse(Pens.Black, 150, 179, 200, 50);

        }

        private void küreküre_Click(object sender, EventArgs e)
        {
            Kure k1=new Kure(new Point3d(4,5,3),5);
            Kure k2=new Kure(new Point3d(1,4,5),5);
            if (Carpisma.kureKureCarp(k1, k2))
                textBox10.Text = "Küreler çarpışıyor";
            else
                textBox10.Text = "Küreler çarpışmıyor";

            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.DrawEllipse(Pens.Black, 40, 80, 140, 140);
            graphics.DrawEllipse(Pens.Black, 42, 129, 138, 30);

            graphics.DrawEllipse(Pens.Black, 200, 150, 140, 140);
            graphics.DrawEllipse(Pens.Black, 202, 199, 138, 30);



        }

        private void küresilindir_Click(object sender, EventArgs e)
        {
            Kure k1=new Kure( new Point3d(2, 3, 3),7);
            Silindir s1 = new Silindir(new Point3d(3, 1, 6), 5, 7);
            if (Carpisma.kureSilindirCarp(k1, s1))
                textBox11.Text = "Küre ve silindir çarpışıyor";
            else
                textBox11.Text = "Küre ve silindir çarpışmıyor";

            Graphics graphics = pictureBox1.CreateGraphics();

            graphics.DrawEllipse(Pens.Black, 200, 150, 140, 140);
            graphics.DrawEllipse(Pens.Black, 202, 199, 138, 30);

            graphics.DrawLine(Pens.Black, 150, 350, 150, 200);
            graphics.DrawLine(Pens.Black, 350, 350, 350, 200);
            graphics.DrawEllipse(Pens.Black, 150, 320, 200, 50);
            graphics.DrawEllipse(Pens.Black, 150, 179, 200, 50);


        }

        private void noktadikdörtgenprizma_Click(object sender, EventArgs e)
        {
            Dikdortgenprizma d1 = new Dikdortgenprizma(new Point3d(2,3,4),3,4,2,3);
            Point3d n1=new Point3d(2,3,5);
            if (Carpisma.noktaDikdortgenprizmaCarp(d1, n1))
                textBox7.Text = "Dikdörtgen prizma ve nokta çarpıştı";
            else
                textBox7.Text = "Dikdörtgen prizma ve nokta çarpışmadı";

            Graphics graphics = pictureBox1.CreateGraphics();

            graphics.DrawRectangle(Pens.Black, 280, 106, 50, 90);
            graphics.DrawRectangle(Pens.Black, 290, 86, 50, 90);
            graphics.DrawLine(Pens.Black,280,104,291, 85);
            graphics.DrawLine(Pens.Black,330,104,341, 85);
            graphics.DrawLine(Pens.Black, 280, 194, 291, 175);
            graphics.DrawLine(Pens.Black, 330, 194, 341, 175);
            graphics.DrawEllipse(Pens.Black, 300, 100, 2, 2);



        }

        private void dikdörtgenprizmadikdörtgenprizma_Click(object sender, EventArgs e)
        {
            Dikdortgenprizma d1=new Dikdortgenprizma(new Point3d(2,4,3),3,4,5,3);
            Dikdortgenprizma d2 = new Dikdortgenprizma(new Point3d(1, 2, 3), 3, 4, 5,5);
            if (Carpisma.dikdortgenprizmalarCarp(d1, d2))
                textBox16.Text = "Dikdörtgen prizmalar çarpışıyor";
            else
                textBox16.Text = "Dikdörtgen prizmalar çarpışmıyor";

            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.DrawRectangle(Pens.Black, 280, 106, 50, 90);
            graphics.DrawRectangle(Pens.Black, 290, 86, 50, 90);
            graphics.DrawLine(Pens.Black, 280, 104, 291, 85);
            graphics.DrawLine(Pens.Black, 330, 104, 341, 85);
            graphics.DrawLine(Pens.Black, 280, 194, 291, 175);
            graphics.DrawLine(Pens.Black, 330, 194, 341, 175);

            graphics.DrawRectangle(Pens.Black, 305, 131, 50, 90);
            graphics.DrawRectangle(Pens.Black, 315, 111, 50, 90);
            graphics.DrawLine(Pens.Black, 305, 130, 314, 110);
            graphics.DrawLine(Pens.Black, 355, 130, 364, 110);
            graphics.DrawLine(Pens.Black, 305, 221, 314, 201);
            graphics.DrawLine(Pens.Black, 355, 221, 364, 201);



        }

        private void küredikdörtgenprizma_Click(object sender, EventArgs e)
        {
            Dikdortgenprizma d1 = new Dikdortgenprizma(new Point3d(1,2,3),5,3,4,5);
            Kure k1=new Kure(new Point3d(3,6,4),5);
            if (Carpisma.kureDikdortgenprizmaCarp(k1, d1))
                textBox15.Text = "Küre ve dikdörtgen prizma çarpışıyor";
            else
                textBox15.Text = "Küre ve dikdörtgen prizma çarpışmıyor";


            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.DrawRectangle(Pens.Black, 280, 106, 50, 90);
            graphics.DrawRectangle(Pens.Black, 290, 86, 50, 90);
            graphics.DrawLine(Pens.Black, 280, 104, 291, 85);
            graphics.DrawLine(Pens.Black, 330, 104, 341, 85);
            graphics.DrawLine(Pens.Black, 280, 194, 291, 175);
            graphics.DrawLine(Pens.Black, 330, 194, 341, 175);

            graphics.DrawEllipse(Pens.Black, 200, 150, 140, 140);
            graphics.DrawEllipse(Pens.Black, 202, 199, 138, 30);


        }

        private void yüzeyküre_Click(object sender, EventArgs e)
        {
            Dikdortgenprizma yuzey=new Dikdortgenprizma(new Point3d(2,4,5),2,5,4,2);
            Kure k1 = new Kure(new Point3d(2,5,3),2);
            if (Carpisma.yuzeyKureCarp(yuzey, k1))
                textBox12.Text = "Yüzey ve küre çarpışıyor";
            else
                textBox12.Text = "Yüzey ve küre çarpışmıyor";


            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.DrawRectangle(Pens.Black, 280, 106, 50, 90);
            graphics.DrawRectangle(Pens.Black, 290, 86, 50, 90);
            graphics.DrawLine(Pens.Black, 280, 104, 291, 85);
            graphics.DrawLine(Pens.Black, 330, 104, 341, 85);
            graphics.DrawLine(Pens.Black, 280, 194, 291, 175);
            graphics.DrawLine(Pens.Black, 330, 194, 341, 175);

            graphics.DrawEllipse(Pens.Black, 200, 150, 140, 140);
            graphics.DrawEllipse(Pens.Black, 202, 199, 138, 30);

            SolidBrush f = new SolidBrush(Color.Black);
            graphics.FillRectangle(f, new Rectangle(280, 106, 50, 90));
            graphics.FillRectangle(f, new Rectangle(290, 86, 50, 90));
          
            


        }

        private void yüzeydikdörtgenprizma_Click(object sender, EventArgs e)
        {

            Dikdortgenprizma yuzey1 = new Dikdortgenprizma(new Point3d(2, 4, 3), 3, 4, 5, 3);
            Dikdortgenprizma d2 = new Dikdortgenprizma(new Point3d(1, 2, 3), 3, 4, 5, 5);
            if (Carpisma.dikdortgenprizmalarCarp(yuzey1, d2))
                textBox13.Text = "Dikdörtgenprizma ve yüzey çarpışıyor";
            else
                textBox13.Text = "Dikdörtgen prizma ve yüzey çarpışmıyor";

            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.DrawRectangle(Pens.Black, 280, 106, 50, 90);
            graphics.DrawRectangle(Pens.Black, 290, 86, 50, 90);
            graphics.DrawLine(Pens.Black, 280, 104, 291, 85);
            graphics.DrawLine(Pens.Black, 330, 104, 341, 85);
            graphics.DrawLine(Pens.Black, 280, 194, 291, 175);
            graphics.DrawLine(Pens.Black, 330, 194, 341, 175);

            SolidBrush f = new SolidBrush(Color.Black);
            graphics.FillRectangle(f, new Rectangle(280, 106, 50, 90));
            graphics.FillRectangle(f, new Rectangle(290, 86, 50, 90));

            graphics.DrawRectangle(Pens.Black, 305, 131, 50, 90);
            graphics.DrawRectangle(Pens.Black, 315, 111, 50, 90);
            graphics.DrawLine(Pens.Black, 305, 130, 314, 110);
            graphics.DrawLine(Pens.Black, 355, 130, 364, 110);
            graphics.DrawLine(Pens.Black, 305, 221, 314, 201);
            graphics.DrawLine(Pens.Black, 355, 221, 364, 201);
        }

        private void yüzeysilindir_Click(object sender, EventArgs e)
        {
            Dikdortgenprizma yuzey1 = new Dikdortgenprizma(new Point3d(2, 4, 3), 3, 4, 5, 3);
            Silindir s1 = new Silindir(new Point3d(1,2,3),2,4);
            if (Carpisma.yuzeySilindirCarp(yuzey1, s1))
                textBox14.Text = "Yüzey ve silindir çarpıştı";
            else
                textBox14.Text = "Yüzey ve silindir çarpışmadı";


            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.DrawRectangle(Pens.Black, 280, 106, 50, 90);
            graphics.DrawRectangle(Pens.Black, 290, 86, 50, 90);
            graphics.DrawLine(Pens.Black, 280, 104, 291, 85);
            graphics.DrawLine(Pens.Black, 330, 104, 341, 85);
            graphics.DrawLine(Pens.Black, 280, 194, 291, 175);
            graphics.DrawLine(Pens.Black, 330, 194, 341, 175);

            SolidBrush f = new SolidBrush(Color.Black);
            graphics.FillRectangle(f, new Rectangle(280, 106, 50, 90));
            graphics.FillRectangle(f, new Rectangle(290, 86, 50, 90));


            graphics.DrawLine(Pens.Black, 150, 350, 150, 200);
            graphics.DrawLine(Pens.Black, 350, 350, 350, 200);
            graphics.DrawEllipse(Pens.Black, 150, 320, 200, 50);
            graphics.DrawEllipse(Pens.Black, 150, 179, 200, 50);



        }

        
    }
}
