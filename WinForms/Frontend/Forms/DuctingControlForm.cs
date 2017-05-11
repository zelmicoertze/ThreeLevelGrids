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
    public partial class DuctingControlForm : Form
    {
        private DuctingControl _ductingControl;
        private GridControl_Settings _settings;

        public DuctingControlForm()
        {
            InitializeComponent();
            _settings = GridControlTools.GridControl_Settings_Setup();

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
            ReFreshData();
            _ductingControl.RefreshGrids();
        }

        private void ReFreshData()
        {
            _ductingControl.gridWidth = int.Parse(textWidth.Text);
            _ductingControl.gridHeight = int.Parse(textHeight.Text);

            _ductingControl.macroCols = int.Parse(textMacroCols.Text);
            _ductingControl.macroRows = int.Parse(textMacroRows.Text);

            _ductingControl.subCols = int.Parse(textSubCols.Text);
            _ductingControl.subRows = int.Parse(textSubRows.Text);

            _ductingControl.microCols = int.Parse(textMicroCols.Text);
            _ductingControl.microRows = int.Parse(textMicroRows.Text);
        }

        private void labelColor_Click(object sender, EventArgs e)
        {
            // Select the color from a dialog
            var control = sender as Control;
            if (control == null) return;

            colorDialog1.Color = control.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK) control.BackColor = colorDialog1.Color;

            _ductingControl.macroGridDefaultColor = labelColorMacro.BackColor;
            _ductingControl.subGridDefaultColor = labelColorSub.BackColor;
            _ductingControl.microGridDefaultColor = labelColorMicro.BackColor;

            _ductingControl.RefreshGrids();
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
            _ductingControl.RefreshGrids();
        }

        private void checkDisplay(bool bMicro, bool bSub, bool bMacro)
        {
            _ductingControl.visibleMicro = bMicro;
            _ductingControl.visibleSub = bSub;
            _ductingControl.visibleMacro = bMacro;
            _ductingControl.RefreshGrids();
        }

        private void checkBox_Click(object sender, EventArgs e)
        {
            if (checkMacro.Checked == false)
            {
                checkDisplay(false, false, false);
            }

            if (checkMacro.Checked && checkSub.Checked == false)
            {
                checkDisplay(false, false, true);
            }

            if (checkMacro.Checked && checkSub.Checked && checkMicro.Checked)
            {
                checkDisplay(true, true, true);
            }

            if (checkMacro.Checked && checkSub.Checked && checkMicro.Checked == false)
            {
                checkDisplay(false, true, true);
            }

            if (checkMacro.Checked == false && checkSub.Checked && checkMicro.Checked == false)
            {
                checkDisplay(true, true, false);
            }

            if (checkMacro.Checked == false && checkSub.Checked == false && checkMicro.Checked)
            {
                checkDisplay(true, true, true);
            }
        }
    }
}
