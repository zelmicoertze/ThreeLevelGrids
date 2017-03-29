using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using DuctingGrids.Frontend.GridControl;
using LamedalCore;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.GridBlock;
using LamedalCore.zPublicClass.GridBlock.GridInterface;
using LamedalCore.zz;

namespace DuctingGrids.Frontend.Forms
{
    [Test_IgnoreCoverage(enTestIgnore.FrontendCode)]
    public sealed partial class Form2 : Form
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;
        private GridControls_Create _grids = null;
        private bool _loading = true;
        private GridControl_Settings _Settings;
        private DuctingControl _grid;

        public Form2()
        {
            InitializeComponent();
            _Settings = GridControlTools.GridControl_Settings();
            _loading = false;

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
            GenerateGrids();
            //Frontend_Settings();
            //_grid = new DuctingControl();
            //_grid.Parent = R1;
            //_grid.Dock = DockStyle.Fill;
        }

        private void GenerateGrids()
        {
            Frontend_Settings();

            _grids = new GridControls_Create(R1, _Settings, onGridClick);
        }

        public void Load_Data(string fileName)
        {
            if (_grids == null) return;

            #region Populate From File

            var gridDataSet = new DataSet();

            gridDataSet.ReadXml(fileName);

            DataTable gridData = gridDataSet.Tables[0];

            DuctingTools.ReadGridDataFromFile(_grids, gridData);

            #endregion

            // Define colors
            _Settings.Color_ID.Clear();
            _Settings.Color_ID.Add(1, System.Drawing.Color.Green);
            _Settings.Color_ID.Add(2, System.Drawing.Color.Orange);
            _Settings.Color_ID.Add(3, System.Drawing.Color.DodgerBlue);
            _Settings.Color_ID.Add(4, System.Drawing.Color.Red);
            _Settings.Color_ID.Add(5, System.Drawing.Color.Yellow);

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            Frontend_Settings();
            if (_grids == null) GenerateGrids();
            GridControlTools.Syncronise(_grids.Cuboid, _Settings, true, onGridChange);
        }

        private void onGridChange(IGridControl gridcontrol, enGrid_ChangeType changetype)
        {
            // Fired when something changed.
        }

        public void Frontend_Settings()
        {
            // Get frontend values
            // =====================================
            // Sizes
            _Settings.Size_MicroHeight = textHeight.Text.zTo_Int();
            _Settings.Size_MicroWidth = textWidth.Text.zTo_Int();

            // Macro scope
            _Settings.Total_MacroCols = textMacroCols.Text.zTo_Int();
            _Settings.Total_MacroRows = textMacroRows.Text.zTo_Int();

            // Sub-Grids scope
            _Settings.Total_SubCols = textSubCols.Text.zTo_Int();
            _Settings.Total_SubRows = textSubRows.Text.zTo_Int();

            // Micro scope
            _Settings.Total_MicroCols = textMicroCols.Text.zTo_Int();
            _Settings.Total_MicroRows = textMicroRows.Text.zTo_Int();

            // Visible
            _Settings.Visible_MacroGrids = checkMacro.Checked;
            _Settings.Visible_SubGrids = checkSub.Checked;
            _Settings.Visible_MicroGrids = checkMicro.Checked;
            // Color
            _Settings.ColorDefault_MacroGrid = labelColorMacro.BackColor;
            _Settings.ColorDefault_SubGrid = labelColorSub.BackColor;
            _Settings.ColorDefault_MicroGrid = labelColorMicro.BackColor;

            // Display type
            if (radioAddress.Checked) _Settings.DisplayMode_MicroGrids = enGrid_BlockDisplayType.Address;
            if (radioValue.Checked) _Settings.DisplayMode_MicroGrids = enGrid_BlockDisplayType.Value;
            if (radioName.Checked) _Settings.DisplayMode_MicroGrids = enGrid_BlockDisplayType.Name;

            _Settings.Refresh_Calculations();
        }

        private void onGridClick(IGridControl sender)
        {
            // Fired when mouse click on a grid
            var state = sender.GridState;
            var caption = state.Name_Caption;
            if (state._Parent != null)
            {
                caption = state._Parent.Name_Caption + " x "+ caption;
                if (state._Parent._Parent != null) caption = state._Parent._Parent.Name_Caption + " x " + caption;
            }
            MessageBox.Show(caption, "Grid Feedback");
        }

        private void button_LoadData_Click(object sender, EventArgs e)
        {
            Load_Data(@"C:\Users\zcoertze\Desktop\Grid_Test.xml");
        }

        private void labelColor_Click(object sender, EventArgs e)
        {
            // Select the color from a dialog
            var control = sender as Control;
            if (control == null) return;

            colorDialog1.Color = control.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK) control.BackColor = colorDialog1.Color;
            RefreshGrid();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void radioName_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
}
