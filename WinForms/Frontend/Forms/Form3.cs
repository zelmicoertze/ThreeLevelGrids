using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuctingGrids.Frontend.GridControl;

namespace DuctingGrids.Frontend.Forms
{
    public partial class Form3 : Form
    {
        private DuctingControl _grid;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _grid = new DuctingControl();
            _grid.Parent = panel1;
            _grid.Dock = DockStyle.Fill;
        }
    }
}
