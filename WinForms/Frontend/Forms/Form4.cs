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
using LamedalCore.zPublicClass.GridBlock;

namespace DuctingGrids.Frontend.Forms
{
    public partial class Form4 : Form
    {
        private DuctingControl _ductingControl;
        //private bool _loading = true;
        private GridControl_Settings _Settings;

        public Form4()
        {
            InitializeComponent();
            _Settings = GridControlTools.GridControl_Settings();
            //_loading = false;

            var gridDataSet = new DataSet();

            gridDataSet.ReadXml(@"C:\Users\zcoertze\Desktop\Grid_Test.xml");

            DataTable gridData = gridDataSet.Tables[0];

            int[] arrCounts = DuctingTools.BlockSizes(gridData);

            textMacroRows.Text = arrCounts[0].ToString();
            textMacroCols.Text = arrCounts[1].ToString();
            textSubRows.Text = arrCounts[2].ToString();
            textSubCols.Text = arrCounts[3].ToString();
            textMicroRows.Text = arrCounts[4].ToString();
            textMicroCols.Text = arrCounts[5].ToString();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            if (_ductingControl == null)
            {
                _ductingControl = new DuctingControl();
            }

                _ductingControl.gridWidth = int.Parse(textWidth.Text);
                _ductingControl.gridHeight = int.Parse(textHeight.Text);

                // Macro
                _ductingControl.macroCols = int.Parse(textMacroCols.Text);
                _ductingControl.macroRows = int.Parse(textMacroRows.Text);
                // Sub
                _ductingControl.subCols = int.Parse(textSubCols.Text);
                _ductingControl.subRows = int.Parse(textSubRows.Text);
                // Micro
                _ductingControl.microCols = int.Parse(textMicroCols.Text);
                _ductingControl.microRows = int.Parse(textMicroRows.Text);

                _ductingControl.Frontend_Settings();
                _ductingControl.Parent = panel1;
                _ductingControl.Dock = DockStyle.Fill;

                _ductingControl.GenerateGrids();
        }

        private void button_LoadData_Click(object sender, EventArgs e)
        {
            _ductingControl.Load_Data(@"C:\Users\zcoertze\Desktop\Grid_Test.xml");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            _ductingControl.Refresh();
        }

        private void labelColor_Click(object sender, EventArgs e)
        {
            // Select the color from a dialog
            var control = sender as Control;
            if (control == null) return;

            colorDialog1.Color = control.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK) control.BackColor = colorDialog1.Color;

            _ductingControl.Refresh();
        }

        private void radioAddress_Click(object sender, EventArgs e)
        {
            radioDisplay(false, true, false);
        }

        private void radioName_Click(object sender, EventArgs e)
        {
            radioDisplay(true, false, false);
        }

        private void radioValue_Click(object sender, EventArgs e)
        {
            radioDisplay(false, false, true);
        }

        private void radioDisplay(bool bName, bool bAddress, bool bValue)
        {
            _ductingControl.displayName = bName;
            _ductingControl.displayAddress = bAddress;
            _ductingControl.displayValue = bValue;
            _ductingControl.Frontend_Settings();
            //GridControlTools.Syncronise(_ductingControl._grids.Cuboid, _Settings, true, _ductingControl.onGridChange);
            //_ductingControl.GenerateGrids();
            //_ductingControl.Refresh();
        }
    }
}
