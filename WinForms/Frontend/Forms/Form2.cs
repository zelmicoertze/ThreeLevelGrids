using System;
using System.Collections.Generic;
using System.Configuration;
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

        public Form2()
        {
            InitializeComponent();
            _Settings = _lamed.lib.MultiGrids.GridControl_Settings();
            _loading = false;

            int iMacroXCount = 0;
            int iMacroYCount = 0;
            int iSubXCount = 0;
            int iSubYCount = 0;
            int iMicroXCount = 0;
            int iMicroYCount = 0;

            using (StreamReader sr = new StreamReader(@"C:\Users\zcoertze\Desktop\Grid_Test.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string sLine;
                    string[] sArrData;
                    sLine = sr.ReadLine();

                    sArrData = sLine.Split(',');

                    int iMacroX = int.Parse(sArrData[0].Substring(1, sArrData[0].Length - 1));
                    int iMacroY = int.Parse(sArrData[1].Substring(0, sArrData[1].LastIndexOf('"')));

                    if (iMacroX > iMacroXCount)
                    {
                        iMacroXCount = iMacroX;
                    }
                    if (iMacroY > iMacroYCount)
                    {
                        iMacroYCount = iMacroY;
                    }

                    int iSubX = int.Parse(sArrData[2].Substring(1, sArrData[2].Length - 1));
                    int iSubY = int.Parse(sArrData[3].Substring(0, sArrData[3].LastIndexOf('"')));

                    if (iSubX > iSubXCount)
                    {
                        iSubXCount = iSubX;
                    }
                    if (iSubY > iSubYCount)
                    {
                        iSubYCount = iSubY;
                    }

                    int iMicroX = int.Parse(sArrData[4].Substring(1, sArrData[4].Length - 1));
                    int iMicroY = int.Parse(sArrData[5].Substring(0, sArrData[5].LastIndexOf('"')));

                    if (iMicroX > iMicroXCount)
                    {
                        iMicroXCount = iMicroX;
                    }
                    if (iMicroY > iMicroYCount)
                    {
                        iMicroYCount = iMicroY;
                    }

                    textMacroRows.Text = iMacroXCount.ToString();
                    textMacroCols.Text = iMacroYCount.ToString();
                    textSubRows.Text = iSubXCount.ToString();
                    textSubCols.Text = iSubYCount.ToString();
                    textMicroRows.Text = iMicroXCount.ToString();
                    textMicroCols.Text = iMicroYCount.ToString();
                }
            }
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
            MessageBox.Show(caption, "Grid Feedback");
        }

        private void button_LoadData_Click(object sender, EventArgs e)
        {
            if (_grids == null) return;

            //#region Sub1.1
            //// 1.1
            //var gridMicro = _grids.Cuboid.GetChild_MicroGridBlock("1_1", "1_1", "1_1");
            //gridMicro.State_Setup(1.5, 1, Color.Red);

            //// 1.2
            //var gridSub = _grids.Cuboid.GetChild_SubGridBlock("1_1", "1_1");
            //gridMicro = gridSub.GetChild_GridBlock("1_2");
            //gridMicro.State_Setup(1.52, 2, Color.Blue);

            //// 1.3
            //gridSub.GetChild_GridBlock("1_3").State_Setup(2.52, 3, Color.Green);

            //// 1.4
            //var state = gridSub.GetChild_GridBlock("1_4") as IGridBlock_State;
            //if (state != null)
            //{
            //    state.State_ValueDouble = 3.3;
            //    state.State_Color = Color.Aqua;
            //}
            //#endregion

            #region Populate from text file

            using (StreamReader sr = new StreamReader(@"C:\Users\zcoertze\Desktop\Grid_Test.txt"))
            {
                    while (sr.Peek() >= 0)
                    {
                        string sLine;
                        string[] sArrData;
                        sLine = sr.ReadLine();

                        sArrData = sLine.Split(',');

                        string sMacroX = sArrData[0];
                        string sMacroY = sArrData[1];
                        string sMacro = sMacroX.Substring(1, sMacroX.Length - 1) + "_" + sMacroY.Substring(0, sMacroY.LastIndexOf('"'));

                        string sSubX = sArrData[2];
                        string sSubY = sArrData[3];
                        string sSub = sSubX.Substring(1, sSubX.Length - 1) + "_" + sSubY.Substring(0, sSubY.LastIndexOf('"'));

                        string sMicroX = sArrData[4];
                        string sMicroY = sArrData[5];
                        string sMicro = sMicroX.Substring(1, sMicroX.Length - 1) + "_" + sMicroY.Substring(0, sMicroY.LastIndexOf('"'));

                        string sFloatValue = sArrData[6];
                        double dFloatData;

                        if (sFloatValue == "")
                        {
                            dFloatData = 0;
                        }
                        else
                        {
                            dFloatData = double.Parse(sFloatValue);                
                        }

                        string sState = sArrData[7];

                        switch (sState)
                        {
                            case "Scheduled":
                                sState = "1";
                                break;
                            case "In Progress":
                                sState = "2";
                                break;
                            case "Complete":
                                sState = "3";
                                break;
                            case "Cancelled":
                                sState = "4";
                                break;
                            case "Inspected":
                                sState = "5";
                                break;
                        }

                        var gridSub = _grids.Cuboid.GetChild_SubGridBlock(sMacro, sSub);

                        gridSub.GetChild_GridBlock(sMicro).State_Setup(dFloatData, int.Parse(sState));
                    }
                }
            
            #endregion

            // Define colors
            _Settings.Color_ID.Clear();
            _Settings.Color_ID.Add(1, Color.Green);
            _Settings.Color_ID.Add(2, Color.Orange);
            _Settings.Color_ID.Add(3, Color.DodgerBlue);
            _Settings.Color_ID.Add(4, Color.Red);
            _Settings.Color_ID.Add(5, Color.Yellow);

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            Frontend_Settings();
            if (_grids == null) GenerateGrids();
            _lamed.lib.MultiGrids.Syncronise(_grids.Cuboid, _Settings, true, onGridChange);
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

        private void checkMicro_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkMicro.Checked == false)
            {
                MessageBox.Show("Zoom out.");
            }
        }
    }
}
