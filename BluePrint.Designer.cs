using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Function_Plotting
{
    partial class BluePrint : System.Windows.Forms.PictureBox
    {
        #region Initialize fields
        private int _unit;
        private int _gridsize;
        private Point _zPoint;
        private Bitmap _Dmap = null;
        private bool _isDrawGrid = true;
        private Color _backColor = Color.White;
        private Pen _pen = new Pen(Brushes.Black, 2);
        #endregion

        #region Initialize properties
        public int Unit
        {
            get { return _unit; }
            set { this._unit = value; }
        }
        public int LinesWidth
        {
            get { return _gridsize; }
            set { this._gridsize = value; }
        }
        public Point RootPoint
        {
            get { return _zPoint; }
            set { this._zPoint = value; }
        }
        public bool isDrawGrid
        {
            get { return _isDrawGrid; }
            set { this._isDrawGrid = value; }
        }
        public Color BackgroundColor
        {
            get { return _backColor; }
            set { this._backColor = value; }
        }
        public Pen DrawPen
        {
            get { return _pen; }
            set { this._pen = value; }
        }
        #endregion

        #region Constructor
        public BluePrint()
        {
            this.Width = this.Height = 300;
            _unit = 20;
            _gridsize = 1;
            _zPoint = new Point(this.Width / 2, this.Height / 2);

            Graphics myGraphics = this.CreateGraphics();
            DrawDmap();
            myGraphics.DrawImageUnscaled(_Dmap, 0, 0);
            myGraphics.Dispose();
        }
        #endregion
    }
}
