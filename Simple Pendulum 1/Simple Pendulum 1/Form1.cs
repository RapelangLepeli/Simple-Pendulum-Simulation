using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Pendulum_1
{
    public partial class Form1 : Form
    {
        static Point Origin;
        static Point Bob;
        static float Length;
        static Graphics G;
        static Pen pen;
        static float Angle;
        static float AnglularVelocity;
        static float AngularAcceleration;
        static List<Color> lstColours;
        static Random random;
        public Form1()
        {
            InitializeComponent();
            Origin = new Point(panel1.Width/ 2,200);
            Length = 300;
           // Bob = new Point(Origin.X,(int)Length);
            G = panel1.CreateGraphics();
           
            Angle = (float)Math.PI/2;

            lstColours = new List<Color>();
            lstColours.Add(Color.Blue);
            lstColours.Add(Color.Green);
          
            lstColours.Add(Color.Bisque);
            random = new Random((int)DateTime.Now.Ticks);

            AnglularVelocity = 0.01f;
            AngularAcceleration = 0.00f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10000000000; i++)
            {
                int ColourNumber = random.Next(lstColours.Count);
                pen = new Pen(lstColours[ColourNumber], 5);
                Thread.Sleep(50);
                G.Clear(Color.White);
                Bob.X = (int)(Length * Math.Sin(Angle) + Origin.X);
                Bob.Y = (int)(Length * Math.Cos(Angle) + Origin.Y);
                G.DrawLine(pen, Origin.X, Origin.Y, Bob.X, Bob.Y);
                G.DrawEllipse(pen, Bob.X - 17, Bob.Y, 40, 40);

                AngularAcceleration = (float)(-0.01 * Math.Sin(Angle));
                Angle += AnglularVelocity;
                AnglularVelocity += AngularAcceleration;

               AnglularVelocity *= (float)0.99;
            }
        }
    }
}
