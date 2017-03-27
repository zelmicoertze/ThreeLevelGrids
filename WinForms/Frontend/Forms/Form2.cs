using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
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

        public Form2()
        {
            InitializeComponent();
            _Settings = GridControlTools.GridControl_Settings();
            _loading = false;
            Row1();
        }
        private GridControl_Row R1;
        private void Row1()
        {
            this.R1 = new DuctingGrids.Frontend.GridControl.GridControl_Row();
            // 
            // R1
            // 
            this.R1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.R1.Dock = System.Windows.Forms.DockStyle.Top;
            this.R1.GridState = null;
            this.R1.Location = new System.Drawing.Point(3, 16);
            this.R1.Name = "R1";
            this.R1.Size = new System.Drawing.Size(1142, 468);
            this.R1.TabIndex = 0;
            this.groupBox6.Controls.Add(this.R1);
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            GenerateGrids();
        }

        private void GenerateGrids()
        {
            Frontend_Settings();

            _grids = new GridControls_Create(R1, _Settings, onGridClick);
        }

        private void Frontend_Settings()
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
            MessageBox.Show(caption, "GridFeedback");
        }

        private void button_LoadData_Click(object sender, EventArgs e)
        {
            if (_grids == null) return;

            #region Sub1.1
            // 1.1
            var gridMicro = _grids.Cuboid.GetChild_MicroGridBlock("1_1", "1_1", "1_1");
            gridMicro.State_Setup(1.5, 1, Color.Red);

            // 1.2
            var gridSub = _grids.Cuboid.GetChild_SubGridBlock("1_1", "1_1");
            gridMicro = gridSub.GetChild_GridBlock("1_2");
            gridMicro.State_Setup(1.52, 2, Color.Blue);

            // 1.3
            gridSub.GetChild_GridBlock("1_3").State_Setup(2.52, 3, Color.Green);

            // 1.4
            var state = gridSub.GetChild_GridBlock("1_4") as IGridBlock_State;
            if (state != null)
            {
                state.State_ValueDouble = 3.3;
                state.State_Color = Color.Aqua;
            }
            #endregion

            #region Sub1.2
            gridSub = _grids.Cuboid.GetChild_SubGridBlock("1_1", "1_2");
            gridSub.GetChild_GridBlock("1_1").State_Setup(1.1,0);
            gridSub.GetChild_GridBlock("1_2").State_Setup(1.12,0);
            gridSub.GetChild_GridBlock("1_3").State_Setup(1.52,0);
            gridSub.GetChild_GridBlock("1_4").State_Setup(2.12,0);
            gridSub.GetChild_GridBlock("1_5").State_Setup(1.02,1);
            gridSub.GetChild_GridBlock("2_1").State_Setup(1.11,1);
            gridSub.GetChild_GridBlock("2_2").State_Setup(3.12,1);
            gridSub.GetChild_GridBlock("2_2").State_Setup(1.12,1);
            gridSub.GetChild_GridBlock("2_4").State_Setup(1.12,2);
            gridSub.GetChild_GridBlock("2_5").State_Setup(1.12,2);
            gridSub.GetChild_GridBlock("3_1").State_Setup(1.12,2);
            gridSub.GetChild_GridBlock("3_2").State_Setup(1.12,2);
            gridSub.GetChild_GridBlock("3_2").State_Setup(1.12,2);
            gridSub.GetChild_GridBlock("3_3").State_Setup(1.12,1);
            gridSub.GetChild_GridBlock("3_4").State_Setup(1.12,1);
            gridSub.GetChild_GridBlock("3_5").State_Setup(1.12,1);
            gridSub.GetChild_GridBlock("4_1").State_Setup(1.12, 1);
            gridSub.GetChild_GridBlock("4_2").State_Setup(1.12, 1);
            gridSub.GetChild_GridBlock("4_2").State_Setup(1.12, 1);
            gridSub.GetChild_GridBlock("4_3").State_Setup(1.12, 3);
            gridSub.GetChild_GridBlock("4_4").State_Setup(1.12, 3);
            gridSub.GetChild_GridBlock("4_5").State_Setup(1.12, 3);
            gridSub.GetChild_GridBlock("5_1").State_Setup(1.12, 3);
            gridSub.GetChild_GridBlock("5_2").State_Setup(1.12, 3);
            gridSub.GetChild_GridBlock("5_2").State_Setup(1.12, 3);
            gridSub.GetChild_GridBlock("5_3").State_Setup(1.12, 3);
            gridSub.GetChild_GridBlock("5_4").State_Setup(1.12, 3);
            gridSub.GetChild_GridBlock("5_5").State_Setup(1.12, 3);
            #endregion

            // Define colors
            _Settings.Color_ID.Clear();
            _Settings.Color_ID.Add(1, Color.Green);
            _Settings.Color_ID.Add(2, Color.Yellow);
            _Settings.Color_ID.Add(3, Color.Red);

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
