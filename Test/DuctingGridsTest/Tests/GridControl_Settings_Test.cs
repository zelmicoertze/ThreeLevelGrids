using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuctingGrids.Frontend.GridControl;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.GridBlock;
using LamedalCore.zPublicClass.GridBlock.GridInterface;
using Xunit;

namespace DuctingGridsTest.Tests
{
    public sealed class GridControl_Settings_Test
    {
        [Fact]
        [Test_Method("Address_2RowCol()")]
        [Test_Method("Address_FromRowCol()")]
        public void Address_ToXY_Test()
        {
            int row, col;
            GridControl_Settings.Address_2RowCol("1_1", out row, out col);
            Assert.Equal(1, row);
            Assert.Equal(1, col);

            GridControl_Settings.Address_2RowCol("1_3", out row, out col);
            Assert.Equal(1, row);
            Assert.Equal(3, col);

            GridControl_Settings.Address_2RowCol("7_3", out row, out col);
            Assert.Equal(7, row);
            Assert.Equal(3, col);
            GridControl_Settings.Address_2RowCol("7_3", out row, out col, addressDef: enGrid_AddressDefOrder.ColRow);
            Assert.Equal(3, row);
            Assert.Equal(7, col);
            GridControl_Settings.Address_2RowCol("G_3", out row, out col, addressDef: enGrid_AddressDefOrder.ColRow, addressCol: enGrid_AddressValue.Alfa);
            Assert.Equal(3, row);
            Assert.Equal(7, col);

            // Reverse
            Assert.Equal("1_1", GridControl_Settings.Address_FromRowCol(1, 1));
            Assert.Equal("1_3", GridControl_Settings.Address_FromRowCol(1, 3));
            Assert.Equal("7_3", GridControl_Settings.Address_FromRowCol(7, 3));
            Assert.Equal("7.3", GridControl_Settings.Address_FromRowCol(7, 3, "."));
            Assert.Equal("3_7", GridControl_Settings.Address_FromRowCol(7, 3, addressDef: enGrid_AddressDefOrder.ColRow));
            Assert.Equal("C_7", GridControl_Settings.Address_FromRowCol(7, 3, addressDef: enGrid_AddressDefOrder.ColRow, addressCol: enGrid_AddressValue.Alfa));
            Assert.Equal("C/7", GridControl_Settings.Address_FromRowCol(7, 3, "/", addressDef: enGrid_AddressDefOrder.ColRow, addressCol: enGrid_AddressValue.Alfa));
            Assert.Equal("G_3", GridControl_Settings.Address_FromRowCol(3, 7, addressDef: enGrid_AddressDefOrder.ColRow, addressCol: enGrid_AddressValue.Alfa));
            Assert.Equal("G3", GridControl_Settings.Address_FromRowCol(3, 7, "", addressDef: enGrid_AddressDefOrder.ColRow, addressCol: enGrid_AddressValue.Alfa));
        }

        [Fact]
        [Test_Method("GridControl_Settings.Setup()")]
        public void GridControl_Settings_SizeTest()
        {
            #region Input

            var settings = GridControl_Settings.Setup(2, 2, 2, 2, 5, 5, 32, 30);

            #endregion

            #region Test1: Sizes calc

            Assert.Equal(32, settings.Size_MicroWidth);
            Assert.Equal(30, settings.Size_MicroHeight);
            Assert.Equal(113, settings.Size_SubWidth);
            Assert.Equal(113, settings.Size_SubHeight);
            Assert.Equal(236, settings.Size_MacroWidth);
            Assert.Equal(246, settings.Size_MacroHeight);
            Assert.Equal(482, settings.Size_CuboidWidth);
            Assert.Equal(512, settings.Size_CuboidHeight);

            #endregion

            #region Test2: Sizes calc

            settings.Visible_SubGridZoomFactor = 0.0;
            settings.Visible_MacroGridZoomFactor = 0.0;
            settings.Refresh_Calculations();
            Assert.Equal(32, settings.Size_MicroWidth);
            Assert.Equal(30, settings.Size_MicroHeight);
            Assert.Equal(170, settings.Size_SubWidth);
            Assert.Equal(170, settings.Size_SubHeight);
            Assert.Equal(350, settings.Size_MacroWidth);
            Assert.Equal(360, settings.Size_MacroHeight);
            Assert.Equal(710, settings.Size_CuboidWidth);
            Assert.Equal(740, settings.Size_CuboidHeight);

            #endregion

            #region Test3: Sizes calc

            settings.ResetDefaults();
            Assert.Equal(32, settings.Size_MicroWidth);
            Assert.Equal(30, settings.Size_MicroHeight);
            Assert.Equal(113, settings.Size_SubWidth);
            Assert.Equal(113, settings.Size_SubHeight);
            Assert.Equal(236, settings.Size_MacroWidth);
            Assert.Equal(246, settings.Size_MacroHeight);
            Assert.Equal(482, settings.Size_CuboidWidth);
            Assert.Equal(512, settings.Size_CuboidHeight);

            #endregion

            #region Test4: Add rows and recalc

            settings.Total_SubRows = 3;
            settings.Total_MacroCols = 3;
            settings.Refresh_Calculations();
            Assert.Equal(32, settings.Size_MicroWidth);
            Assert.Equal(30, settings.Size_MicroHeight);
            Assert.Equal(113, settings.Size_SubWidth);
            Assert.Equal(113, settings.Size_SubHeight);
            Assert.Equal(236, settings.Size_MacroWidth);
            Assert.Equal(359, settings.Size_MacroHeight);
            Assert.Equal(718, settings.Size_CuboidWidth);
            Assert.Equal(738, settings.Size_CuboidHeight);

            #endregion
        }

        [Fact]
        [Test_Method("GridBlock_5Setup.Setup()")]
        [Test_Method("GetChild_MicroGridBlock()")]
        [Test_Method("GetChild_SubGridBlock()")]
        [Test_Method("GetChild_GridBlock()")]
        [Test_Method("State_Setup()")]
        [Test_Method("Syncronise()")]
        public void GridBlock_5Setup_Test()
        {

            #region Test5: state settings

            #region Input
            var settings = GridControl_Settings.Setup(2, 3, 2, 3, 2, 4);
            settings.Color_ID.Clear();
            settings.Color_ID.Add(1, Color.Green);
            settings.Color_ID.Add(2, Color.Yellow);
            settings.Color_ID.Add(3, Color.Red);
            var gridCuboid = new GridBlock_5Setup(null, settings);

            // Load data
            // Load data into grids
            // 1.1
            var gridMicro = gridCuboid.GetChild_MicroGridBlock("1_1", "1_1", "1_1");
            gridMicro.State_Setup(1.5, 1, Color.RosyBrown);

            // 1.2
            var gridSub = gridCuboid.GetChild_SubGridBlock("1_1", "1_1");
            gridMicro = gridSub.GetChild_GridBlock("1_2");
            gridMicro.State_Setup(1.52, 2, Color.Blue);

            // 1.3
            gridSub.GetChild_GridBlock("1_3").State_Setup(2.52, 3, Color.Green);

            // 1.4
            var state = gridSub.GetChild_GridBlock("1_4") as IGridBlock_State;
            if (state != null)
            {
                state.State_Id = 9;
                state.State_ValueDouble = 3.3;
                state.State_Color = Color.Aqua;
            }

            // 2.3
            state = gridCuboid.GetChild_MicroGridBlock("1_1", "1_1", "2_3") as IGridBlock_State;
            if (state != null)
            {
                state.State_Id = 1;
                state.State_ValueDouble = 2.333;
                state.State_Color = Color.Black;
            }
            // 2.1
            state = gridCuboid.GetChild_MicroGridBlock("1_1", "1_1", "2_1") as IGridBlock_State;
            if (state != null)
            {
                state.State_Id = 3;
                state.State_ValueDouble = 3.333;
                state.State_Color = Color.BlueViolet;
            }
            GridControlTools.Syncronise(gridCuboid, settings, true, null); // Sync with the front-end controls
            #endregion

            #region Test Grid (1.1),(1.1),(1.1)
            IGridBlock_Base gridMicro1 = gridCuboid.GetChild_MicroGridBlock("1_1", "1_1", "1_1");
            Assert.Equal("1.1",gridMicro1.Name_Caption());
            Assert.Equal("1_1", gridMicro1.Name_Address);
            var gridMicro1_State = gridMicro1 as IGridBlock_State;
            Assert.False(gridMicro1_State == null);
            Assert.Equal(1, gridMicro1_State.State_Row);
            Assert.Equal(1, gridMicro1_State.State_Col);
            Assert.Equal(Color.RosyBrown, gridMicro1_State.State_Color);
            Assert.Equal(1, gridMicro1_State.State_Id);
            Assert.Equal(1.5, gridMicro1_State.State_ValueDouble);
            Assert.Equal(false, gridMicro1_State.State_Selected);

            #endregion
            #region Test Grid (1.1),(1.1),(1.2)
            IGridBlock_Base gridMicro2 = gridCuboid.GetChild_MicroGridBlock("1_1", "1_1", "1_2");
            Assert.Equal("1.2", gridMicro2.Name_Caption());
            Assert.Equal("2.1", gridMicro2.Name_Caption(addressDef: enGrid_AddressDefOrder.ColRow));
            Assert.Equal("1_2", gridMicro2.Name_Address);
            var gridMicro2_State = gridMicro2 as IGridBlock_State;
            Assert.False(gridMicro2_State == null);
            Assert.Equal(1, gridMicro2_State.State_Row);
            Assert.Equal(2, gridMicro2_State.State_Col);
            Assert.Equal(Color.Blue, gridMicro2_State.State_Color);
            Assert.Equal(2, gridMicro2_State.State_Id);
            Assert.Equal(1.52, gridMicro2_State.State_ValueDouble);
            Assert.Equal(false, gridMicro2_State.State_Selected);
            #endregion
            #region Test Grid (1.1),(1.1),(1.3)
            IGridBlock_Base gridMicro3 = gridCuboid.GetChild_MicroGridBlock("1_1", "1_1", "1_3");
            Assert.Equal("1.3", gridMicro3.Name_Caption());
            Assert.Equal("3.1", gridMicro3.Name_Caption(addressDef: enGrid_AddressDefOrder.ColRow));
            Assert.Equal("1_3", gridMicro3.Name_Address);
            var gridMicro3_State = gridMicro3 as IGridBlock_State;
            Assert.False(gridMicro3_State == null);
            Assert.Equal(1, gridMicro3_State.State_Row);
            Assert.Equal(3, gridMicro3_State.State_Col);
            Assert.Equal(Color.Green, gridMicro3_State.State_Color);
            Assert.Equal(3, gridMicro3_State.State_Id);
            Assert.Equal(2.52, gridMicro3_State.State_ValueDouble);
            Assert.Equal(false, gridMicro3_State.State_Selected);
            #endregion
            #region Test Grid (1.1),(1.1),(1.4)
            IGridBlock_Base gridMicro4 = gridCuboid.GetChild_MicroGridBlock("1_1", "1_1", "1_4");
            Assert.Equal("1.4", gridMicro4.Name_Caption());
            Assert.Equal("1_4", gridMicro4.Name_Address);
            var gridMicro4_State = gridMicro4 as IGridBlock_State;
            Assert.False(gridMicro4_State == null);
            Assert.Equal(1, gridMicro4_State.State_Row);
            Assert.Equal(4, gridMicro4_State.State_Col);
            Assert.Equal(Color.Aqua, gridMicro4_State.State_Color);
            Assert.Equal(9, gridMicro4_State.State_Id);
            Assert.Equal(3.3, gridMicro4_State.State_ValueDouble);
            Assert.Equal(false, gridMicro4_State.State_Selected);
            #endregion
            #region Test Grid (1.1),(1.1),(2.3)
            IGridBlock_Base gridMicro5 = gridCuboid.GetChild_MicroGridBlock("1_1", "1_1", "2_3");
            Assert.Equal("2.3", gridMicro5.Name_Caption());
            Assert.Equal("3.2", gridMicro5.Name_Caption(addressDef: enGrid_AddressDefOrder.ColRow));
            Assert.Equal("2_3", gridMicro5.Name_Address);
            var gridMicro5_State = gridMicro5 as IGridBlock_State;
            Assert.False(gridMicro5_State == null);
            Assert.Equal(2, gridMicro5_State.State_Row);
            Assert.Equal(3, gridMicro5_State.State_Col);
            Assert.Equal(Color.Black, gridMicro5_State.State_Color);
            Assert.Equal(1, gridMicro5_State.State_Id);
            Assert.Equal(2.333, gridMicro5_State.State_ValueDouble);
            Assert.Equal(false, gridMicro5_State.State_Selected);
            #endregion
            #region Test Grid (1.1),(1.1),(2.1)
            IGridBlock_Base gridMicro21 = gridCuboid.GetChild_MicroGridBlock("1_1", "1_1", "2_1");
            Assert.Equal("2.1", gridMicro21.Name_Caption());
            Assert.Equal("2_1", gridMicro21.Name_Address);
            var gridMicro21_State = gridMicro21 as IGridBlock_State;
            Assert.False(gridMicro21_State == null);
            Assert.Equal(2, gridMicro21_State.State_Row);
            Assert.Equal(1, gridMicro21_State.State_Col);
            Assert.Equal(Color.BlueViolet, gridMicro21_State.State_Color);
            Assert.Equal(3, gridMicro21_State.State_Id);
            Assert.Equal(3.333, gridMicro21_State.State_ValueDouble);
            Assert.Equal(false, gridMicro21_State.State_Selected);
            #endregion
            #endregion
        }

        #region GridCreate
        [Fact]
        public void GridCreate_Test()
        {
            # region Input
            Frontend_Settings();
            if (_grids == null) GenerateGrids();
            GridControlTools.Syncronise(_grids.Cuboid, _settings, true, null);

            IGridBlock_Base gridBase = _grids.Cuboid.GetChild_MicroGridBlock("1_1", "1_1", "2_3");
            var state = gridBase as IGridBlock_State;
            if (state != null)
            {
                state.State_Id = 1;
                state.State_ValueDouble = 2.333;
                state.State_Color = Color.Violet;
            }
            #endregion

            var gridControl = gridBase.zGridControl as GridControl_BlockMicro;
            Assert.False(gridControl == null);
            Assert.Equal(Color.Silver, gridControl.BackColor);
            Assert.Equal("2.3",gridControl.Text);

            #region Test2: Sync again
            _settings.Address_Order = enGrid_AddressDefOrder.ColRow;
            GridControlTools.Syncronise(_grids.Cuboid, _settings, true, null);
            Assert.Equal(Color.Violet, gridControl.BackColor);
            Assert.Equal("3.2", gridControl.Text);

            #endregion
        }

        private GridControl_Row R1 = null;
        private bool _Ctrl = false;
        private winForms_GridControlsSetup _grids = null;
        private readonly GridControl_Settings _settings = GridControlTools.GridControl_Settings_Setup();
        private Form _form;
        private void GenerateGrids()
        {
            if (_form == null) _form = new Form();
            _form.Controls.Clear();

            // Create area to work in R1
                this.R1 = new GridControl_Row();
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
                _form.Controls.Add(this.R1);
            Frontend_Settings();

            _grids = new winForms_GridControlsSetup(R1, _settings, null);
        }
        private void Frontend_Settings()
        {
            // Get frontend values
            // =====================================
            // Sizes
            //_Settings.Size_MicroHeight = ;
            //_Settings.Size_MicroWidth = ;

            // Macro scope
            _settings.Total_MacroCols = 2;
            _settings.Total_MacroRows = 2;

            // Sub-Grids scope
            _settings.Total_SubCols = 2;
            _settings.Total_SubRows = 2;

            // Micro scope
            _settings.Total_MicroCols = 3;
            _settings.Total_MicroRows = 3;

            // Visible
            _settings.Visible_MacroGrids = true;
            _settings.Visible_SubGrids = true;
            _settings.Visible_MicroGrids = true;
            //// Color
            //_Settings.ColorDefault_MacroGrid = labelColorMacro.BackColor;
            //_Settings.ColorDefault_SubGrid = labelColorSub.BackColor;
            //_Settings.ColorDefault_MicroGrid = labelColorMicro.BackColor;

            _settings.DisplayMode_MicroGrids = enGrid_BlockDisplayType.Address;
            //// Display type
            //if (radioAddress.Checked) _Settings.DisplayMode_MicroGrids = enGrid_BlockDisplayType.Address;
            //if (radioValue.Checked) _Settings.DisplayMode_MicroGrids = enGrid_BlockDisplayType.Value;
            //if (radioName.Checked) _Settings.DisplayMode_MicroGrids = enGrid_BlockDisplayType.Name;

            _settings.Refresh_Calculations();
        }
        #endregion

    }
}
