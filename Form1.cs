using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartCalc
{
    public partial class Form1 : Form
    {

        public List<int> nums = new List<int>();
        public string operat = "";

        int x = 0;
        int y = 0;

        int p = 0;

        Point point = new Point();

        Graphics grapha;

        //List<int> nums = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        public void settext()
        {
            textBox1.Text = "";
            foreach (var item in nums)
            {
                textBox1.Text = textBox1.Text + item.ToString();
            }
        }
        public int setcollection(List<int> e)
        {
            string tmp = "";
            foreach (var item in nums)
            {
                tmp += item.ToString();
            }
            
            return int.Parse(tmp);
        }

        public void zapoln(List<int> e, int num)
        {
            e.Clear();
            foreach (var item in num.ToString())
            {
                e.Add(Convert.ToInt32(Convert.ToString(item).Replace("-","").Replace("+", "").Replace("*", "").Replace("/", "").Replace("^", "")));
            }
            //e.Add(num.ToString()[0]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nums.Add(1);
            settext();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nums.Add(2);
            settext();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nums.Add(3);
            settext();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            nums.Add(4);
            settext();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            nums.Add(5);
            settext();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            nums.Add(6);
            settext();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            nums.Add(7);
            settext();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            nums.Add(8);
            settext();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            nums.Add(9);
            settext();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            nums.Add(0);
            settext();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            nums.Clear();
            settext();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            x = Convert.ToInt32(setcollection(nums));
            textBox1.Text = "x=" + x.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            y = Convert.ToInt32(setcollection(nums));
            textBox1.Text = "y=" + y.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = (x * x).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            p = Convert.ToInt32(setcollection(nums));
            nums.Clear();
            settext();
            operat = "^";
        }

        private void button37_Click(object sender, EventArgs e)
        {
            switch (operat)
            {
                case "^":
                    int a = 0;
                    for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
                    {
                        a = (p * p);
                    }
                    //nums.Clear();
                    p = a;
                    zapoln(nums, a);
                    settext();
                    break;

                case "+":
                    int b = Convert.ToInt32(textBox1.Text) + p;
                    p = b;
                    zapoln(nums, b);
                    settext();
                    break;
                case "-":
                    int c = p - Convert.ToInt32(textBox1.Text);
                    p = c;
                    zapoln(nums, p);
                    settext();
                    break;

                case "*":
                    int d = Convert.ToInt32(textBox1.Text) * p;
                    p = d;
                    zapoln(nums, d);
                    settext();
                    break;

                case "/":
                    int f = p / Convert.ToInt32(textBox1.Text);
                    p = f;
                    zapoln(nums, f);
                    settext();
                    break;
            }
            operat = "";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            p = Convert.ToInt32(setcollection(nums));
            nums.Clear();
            settext();
            operat = "+";
        }

        private void button45_Click(object sender, EventArgs e)
        {
            p = Convert.ToInt32(setcollection(nums));
            nums.Clear();
            settext();
            operat = "-";
        }

        private void button29_Click(object sender, EventArgs e)
        {
            p = Convert.ToInt32(setcollection(nums));
            nums.Clear();
            settext();
            operat = "*";
        }

        private void button28_Click(object sender, EventArgs e)
        {
            p = Convert.ToInt32(setcollection(nums));
            nums.Clear();
            settext();
            operat = "/";
        }

        

        public void graph(Graphics gr, Size panel)
        {
            Pen Pen = new Pen(Color.Aqua, 3);

            gr.DrawLine(Pen, new Point(Convert.ToInt32(panel.Width / 2), 0), new Point(Convert.ToInt32(panel.Width / 2), panel.Height));
            gr.DrawLine(Pen, new Point(0, Convert.ToInt32(panel.Height / 2)), new Point(Convert.ToInt32(panel.Width), Convert.ToInt32(panel.Height / 2)));

            point = new Point(Convert.ToInt32(panel.Width / 2), Convert.ToInt32(panel.Height / 2));

            gr.DrawString("(0;0)", new Font(FontFamily.GenericSerif, 8), Brushes.Black, point);
            //gr.dr
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            grapha = e.Graphics; // получение графического контекста 
            //grapha.Clear(Color.FromArgb(255, 255, 128));
            //gr.PageUnit = GraphicsUnit.Point;
            grapha.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
            graph(grapha, panel1.Size);
            parabola(grapha, 10, point, out p2, out p3);
        }

        public void parabola(Graphics gr, int xmax, Point point, out Point[] left, out Point[] right)
        {
            Point[] p = new Point[0];

            if (xmax > 0)
            {
                p = new Point[xmax];
                p[0] = point;
                for (int i = 0; i < xmax; i++)
                {
                    //gr.DrawLine(Pens.Black, new Point(), new Point());
                    p[i] = new Point(point.X - i, point.Y - (i * i));
                }
            }
            else if (xmax < 0)
            {
                p = new Point[~xmax];
                p[0] = point;
                for (int i = 0; i < ~xmax; i++)
                {
                    //gr.DrawLine(Pens.Black, new Point(), new Point());
                    p[i] = new Point(point.X + (~i), point.Y + (~i * ~i));
                }
            }
            left = p;
            Point[] pa = new Point[0];

            if (xmax > 0)
            {
                pa = new Point[xmax];
                pa[0] = point;
                for (int i = 0; i < xmax; i++)
                {
                    //gr.DrawLine(Pens.Black, new Point(), new Point());
                    pa[i] = new Point(point.X + i, point.Y - (i * i));
                }
            }
            else if (xmax < 0)
            {
                pa = new Point[~xmax];
                pa[0] = point;
                for (int i = 0; i < ~xmax; i++)
                {
                    //gr.DrawLine(Pens.Black, new Point(), new Point());
                    pa[i] = new Point(point.X - ~i, point.Y + (~i * ~i));
                }
            }
            //throw new Exception();
            right = pa;
            gr.DrawString(String.Format("({0};{1})", point.X - p[p.Length - 1].X, point.Y - p[p.Length - 1].Y), new Font(FontFamily.GenericSerif, 8), Brushes.Black, p[p.Length - 1] + new Size(-1,-15));

            gr.DrawLines(Pens.Black, pa);
            gr.DrawLines(Pens.Black, p);

        }

        private void Lines(Graphics gr, int[] ia, int x, int xmax, Point point, out Point[] points)
        {
            // gr.DrawLine(Pens.Blue, new Point(point.X + x[0], point.Y + y[0]), new Point(point.X + x[1], point.Y + y[1]));      
            //gr.DrawLine(Pens.Blue, new Point(point.X + x[0], point.Y + y[0]), new Point(point.X - (~x[1]), point.Y - (y[1])));

            Point[] p = new Point[ia.Length];

            for (int i = 0; i < ia.Length; i++)
            {
                p[i] = new Point(point.X + i, point.Y + ia[i]);
            }

            points = p;

            Point[] pa = new Point[ia.Length];

            for (int iaq = 0; iaq < ia.Length; iaq++)
            {
                pa[iaq] = new Point(point.X + (~iaq), point.Y + ~ia[iaq]);
            }

            gr.DrawLines( Pens.Blue, p);
            //gr.DrawLines(Pens.Blue, pa);
            //gr.DrawString(String.Format("({0};{1})", x[1],y[1]), new Font(FontFamily.GenericSerif, 8), Brushes.Black, point.X + x[1] - 10, point.Y + y[1] + 10);
        }

        private void button53_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(panel1.Handle);

            g.Clear(Color.FromArgb(255, 255, 128));   
           
            graph(g, panel1.Size);
            parabola(g, Convert.ToInt32(textBox1.Text), point, out p2, out p3);
        }

        Point[] p1 = new Point[0];

        Point[] p2 = new Point[0];
        Point[] p3 = new Point[0];

        private bool peres(Point[] p11, Point[] p21, Point[] p22)
        {
            bool tmp = false;
            for (int i = 0; i < p11.Length; i++)
            {
                for (int ia = 0; ia < p21.Length; ia++)
                {
                    if (p11[i].X == p21[ia].X)
                    {
                        if (p11[i].Y == p21[ia].Y)
                        {
                            tmp = true;
                            goto Ex;
                        }
                    }
                }
                for (int bi = 0; bi < p22.Length; bi++)
                {
                    if (p11[i].X == p22[bi].X)
                    {
                        if (p11[i].Y == p22[bi].Y)
                        {
                            tmp = true;
                            goto Ex;
                        }
                    }
                }
            }
        Ex:;
            return tmp;
        }

        private void button61_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(panel1.Handle);

            g.Clear(Color.FromArgb(255, 255, 128));

            graph(g, panel1.Size);
            Lines(g, pars1(textBox2.Text), Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox1.Text) + 5, point, out p1);
        }

        /// <summary>
        /// Решение линейного уравнения с общим x
        /// </summary>
        /// <param name="text">Стройка с линейным уравнением</param>
        /// <param name="colraz">Количесво шагов с прибавлением x+1</param>
        /// <returns>Вернёт решённое линейное уравнение</returns>
        private int[] pars1(string text)
        {
            text = text.Replace("x", textBox1.Text);
            int colraz = int.Parse(text.Split('+')[0].Split('-')[0].Split('*')[0].Split('/')[0]) * 3;

            int[] result = new int[colraz];

            for (int i = 0; i < colraz; i++)
            {              
                if (text.Contains("+"))
                {
                    result[i] = i - int.Parse(text.Split('+')[1]);
                }
                else if (text.Contains("-"))
                {
                    result[i] = i + int.Parse(text.Split('-')[1]);
                }
                else if (text.Contains("*"))
                {
                    result[i] = i / int.Parse(text.Split('*')[1]);
                }
                else if (text.Contains("/"))
                {
                    result[i] = i * int.Parse(text.Split('/')[1]);
                }
            }
            return result;
        }

        private void button69_Click(object sender, EventArgs e)
        {
            if(peres(p1, p3, p2))
            {
                label2.Text = "Ok";
            }
            else
            {
                label2.Text = "No";
            }
        }
    }
}
