using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Expression;
using System.Drawing.Drawing2D;

namespace Function_Plotting
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public Point reCoordinate(Point descartesPoint, Point rootPoint)
        {
            return new Point(rootPoint.X + descartesPoint.X, rootPoint.Y - descartesPoint.Y);
        }

        public void PlotFunction(Graphics g, string exp)
        {
            int limit = bluePrint1.Width / 2;
            int x = -limit;
            GraphicsPath path = new GraphicsPath();
            Point rootPoint = new Point(bluePrint1.Width / 2, bluePrint1.Height / 2);


            while (x <= limit)
            {
                string re_exp;

                if (x < 0)
                    re_exp = "(" + "0" + x.ToString() + ")";
                else
                    re_exp = x.ToString();
                ExpressionTree myTree1 = new ExpressionTree(exp.Replace("x", re_exp));
                myTree1.CreateTree();

                if (x + 1 < 0)
                    re_exp = "(" + "0" + (x + 1).ToString() + ")";
                else
                    re_exp = (x + 1).ToString();
                ExpressionTree myTree2 = new ExpressionTree(exp.Replace("x", re_exp));
                myTree2.CreateTree();

                Point current = reCoordinate(new Point(x, (int)(myTree1.Value)), rootPoint);
                Point next = reCoordinate(new Point(x + 1, (int)(myTree2.Value)), rootPoint);
                //current.X /= bluePrint1.Unit; current.Y /= bluePrint1.Unit;
                //next.X /= bluePrint1.Unit; next.Y /= bluePrint1.Unit;
                Point[] points = new Point[2] { current, next };

                path.AddCurve(points);

                x += 1;
            }

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawPath(bluePrint1.DrawPen, path);
        }

        private void butt_Plot_Click(object sender, EventArgs e)
        {
            PlotFunction(bluePrint1.CreateGraphics(), txt_Expression.Text);
        }
    }
}
