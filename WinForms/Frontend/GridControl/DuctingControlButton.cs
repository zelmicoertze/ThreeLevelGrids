using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Drawing.Helpers;

namespace DuctingGrids.Frontend.GridControl
{
    public partial class DuctingControlButton : Button
    {
        private Color color1 = Color.Red;
        private Color color2 = Color.Green;
        private int color1Transparent = 100;
        private int color2Transparent = 100;

        public Color Color1
        {
            get { return color1; }
            set { color1 = value; Invalidate(); }
        }

        public Color Color2
        {
            get { return color2; }
            set { color2 = value; Invalidate(); }
        }

        public int Color1Transparent
        {
            get { return color1Transparent; }
            set { color1Transparent = value; Invalidate(); }
        }

        public int Color2Transparent
        {
            get { return color2Transparent; }
            set { color2Transparent = value; Invalidate(); }
        }

        public DuctingControlButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Color c1 = Color.FromArgb(color1Transparent, color1);
            Color c2 = Color.FromArgb(color2Transparent, color2);
            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, c1, c2, 10);
            pe.Graphics.FillRectangle(b, ClientRectangle);
            b.Dispose();
        }
    }
}
