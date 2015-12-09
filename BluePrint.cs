using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Function_Plotting
{
    partial class BluePrint: System.Windows.Forms.PictureBox
    {
        private void DrawDmap()
        {
            _Dmap = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(_Dmap);
            Pen myPen = new Pen(Brushes.DarkBlue, _gridsize);
            myPen.DashStyle = DashStyle.Dash;

            //Fill Background
            g.FillRectangle(new SolidBrush(_backColor), this.ClientRectangle);

            #region Draw Grid if turned on
            if (_isDrawGrid)
            {
                for (int i = _zPoint.X; i < this.Width; i += _unit)
                    g.DrawLine(myPen, i, 0, i, this.Height);
                for (int i = _zPoint.X; i > 0; i -= _unit)
                    g.DrawLine(myPen, i, 0, i, this.Height);
                for (int i = _zPoint.Y; i < this.Height; i += _unit)
                    g.DrawLine(myPen, 0, i, this.Width, i);
                for (int i = _zPoint.Y; i > 0; i -= _unit)
                    g.DrawLine(myPen, 0, i, this.Width, i);
            }
            #endregion

            #region Draw Zero point's lines
            myPen.DashStyle = DashStyle.Solid;
            g.DrawLine(myPen, _zPoint.X, 0, _zPoint.X, this.Height);
            g.DrawLine(myPen, 0, _zPoint.Y, this.Width, _zPoint.Y);
            #endregion

            myPen.Dispose();
            g.Dispose();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            base.OnPaint(pe);

            DrawDmap();
            _zPoint = new Point(this.Width / 2, this.Height / 2);
            pe.Graphics.DrawImageUnscaled(_Dmap, 0, 0);
        }
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
            //base.OnPaintBackground(pevent);
        }
    }
}
