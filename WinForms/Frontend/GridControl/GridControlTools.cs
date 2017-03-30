using System;
using System.IO;
using DocumentFormat.OpenXml.Spreadsheet;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.domain.Events;
using LamedalCore.zPublicClass.GridBlock;
using LamedalCore.zPublicClass.GridBlock.GridInterface;
using LamedalCore.zz;
using Color = System.Drawing.Color;

namespace DuctingGrids.Frontend.GridControl
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_Action)]
    public static class GridControlTools
    {

        /// <summary>Return new Grid control settings.</summary>
        /// <returns></returns>
        public static GridControl_Settings GridControl_Settings()
        {
            return new GridControl_Settings();
        }

        /// <summary>Return new Grid control settings.</summary>
        /// <param name="macroRows">The macro rows.</param>
        /// <param name="macroCols">The macro cols.</param>
        /// <param name="subRows">The sub rows.</param>
        /// <param name="subCols">The sub cols.</param>
        /// <param name="microRows">The micro rows.</param>
        /// <param name="microCols">The micro cols.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns></returns>
        public static GridControl_Settings GridControl_Settings(int macroRows, int macroCols, 
                                int subRows, int subCols, 
                                int microRows, int microCols,
                                int width = 0, int height = 0)
        {
            var result = GridControl_Settings();
            result.Setup(macroRows, macroCols, subRows, subCols, microRows, microCols, width, height);
            return result;
        }

        /// <summary>
        /// Syncronise the settings with the frontend controls.
        /// </summary>
        /// <param name="grids">The grids.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="resetColors">if set to <c>true</c> [reset colors].</param>
        /// <param name="onGridChangeEvent">The on grid change.</param>
        /// <param name="onGridCreate">The on grid create.</param>
        public static void Syncronise(GridBlock_5Setup grids, GridControl_Settings settings, bool resetColors = false, 
                    onGrid_ChangeEvent onGridChangeEvent = null)
        {
            settings.Refresh_Calculations();
            var cuboid = grids.GridCuboid as IGridBlock_Base;
            var cuboidControl = cuboid.zGridControl;
            GridSync(cuboid, cuboidControl, settings, resetColors, onGridChangeEvent);

            // Macro Grids
            for (int iRow = 1; iRow <= grids.GridCuboid.Child_Rows; iRow++)
            {
                for (int iCol = 1; iCol <= grids.GridCuboid.Child_Cols; iCol++)
                {
                    IGridBlock_Base macro = grids.GridCuboid.GetChild_GridBlock(String.Format("{0}_{1}", iRow, iCol));
                    IGridControl macroControl = macro.zGridControl;
                    GridSync(macro, macroControl, settings, resetColors, onGridChangeEvent);
                    var macroState = macro as IGridBlock_ChildState;
                    #region Sub Grids
                    for (int rowSub = 1; rowSub <= macroState.Child_Rows; rowSub++)
                    {
                        for (int colSub = 1; colSub <= macroState.Child_Cols; colSub++)
                        {
                            var sub = macro.GetChild_GridBlock(String.Format("{0}_{1}", rowSub, colSub));
                            var subControl = sub.zGridControl;
                            GridSync(sub, subControl, settings, resetColors, onGridChangeEvent);
                            var subState = sub as IGridBlock_ChildState;
                            #region Micro Grids
                            for (int microRow = 1; microRow <= subState.Child_Rows; microRow++)
                            {
                                for (int microCol = 1; microCol <= subState.Child_Cols; microCol++)
                                {
                                    var micro = sub.GetChild_GridBlock(String.Format("{0}_{1}", microRow, microCol));
                                    var microControl = micro.zGridControl;
                                    GridSync(micro, microControl, settings, resetColors, onGridChangeEvent);
                                }
                            }
                            #endregion
                        }
                    }
                    #endregion
                }
            }
        }

        #region Private
        /// <summary>Synchronize grid values.</summary>
        /// <param name="grid">The grid.</param>
        /// <param name="gridControl">The grid control.</param>
        /// <param name="settings"></param>
        /// <param name="resetColors">if set to <c>true</c> [reset colors].</param>
        /// <param name="onGridChangeEvent">The on grid change.</param>
        [Test_IgnoreCoverage(enTestIgnore.FrontendCode)]
        private static void GridSync(IGridBlock_Base grid, IGridControl gridControl, GridControl_Settings settings, bool resetColors, onGrid_ChangeEvent onGridChangeEvent)
        {
            if (gridControl == null) return;  // Testing code  

            var parent = grid._Parent as IGridBlock_ChildState;
            var child = grid as IGridBlock_State;

            if (parent == null)
            {
                // Cuboid
                if (GridSync_Size(child, gridControl, settings.Size_CuboidWidth, settings.Size_CuboidHeight)) onGridChangeEvent(gridControl, enGrid_ChangeType.Size); // Check size
                if (resetColors && GridSync_Color(child, gridControl, settings.ColorDefault_CuboidGrid)) onGridChangeEvent(gridControl, enGrid_ChangeType.Color); // Check size
                //if (GridSync_Visible(gridControl, Visible_CuboidGrids)) onGridChange?.Invoke(gridControl, enGridChangeType.Visible); // Check size
                //if (GridSync_DisplayMode(grid, gridControl, DisplayMode_CuboidGrids)) onGridChange?.Invoke(gridControl, enGridChangeType.DisplayMode); // Check size
            }
            else if (parent.Child_BlockType == enGrid_BlockType.MacroBlock)
            {
                // Macro
                if (GridSync_Size(child, gridControl, settings.Size_MacroWidth, settings.Size_MacroHeight)) onGridChangeEvent(gridControl, enGrid_ChangeType.Size); // Check size
                if (resetColors && GridSync_Color(child, gridControl, settings.ColorDefault_MacroGrid)) onGridChangeEvent(gridControl, enGrid_ChangeType.Color); // Check size
                if (GridSync_Visible(gridControl, settings.Visible_MacroGrids)) onGridChangeEvent(gridControl, enGrid_ChangeType.Visible); // Check size
                //if (GridSync_DisplayMode(grid, gridControl, DisplayMode_MacroGrids)) onGridChange?.Invoke(gridControl, enGridChangeType.DisplayMode); // Check size
            }
            else if (parent.Child_BlockType == enGrid_BlockType.SubBlock)
            {
                // Sub
                if (GridSync_Size(child, gridControl, settings.Size_SubWidth, settings.Size_SubHeight)) onGridChangeEvent(gridControl, enGrid_ChangeType.Size); // Check size
                if (resetColors && GridSync_Color(child, gridControl, settings.ColorDefault_SubGrid)) onGridChangeEvent(gridControl, enGrid_ChangeType.Color); // Check size
                if (GridSync_Visible(gridControl, settings.Visible_SubGrids)) onGridChangeEvent(gridControl, enGrid_ChangeType.Visible); // Check size
                //if (GridSync_DisplayMode(grid, gridControl, DisplayMode_SubGrids)) onGridChange?.Invoke(gridControl, enGridChangeType.DisplayMode); // Check size
            }
            else if (parent.Child_BlockType == enGrid_BlockType.MicroBlock)
            {
                // Micro
                if (GridSync_Size(child, gridControl, settings.Size_MicroWidth, settings.Size_MicroHeight)) onGridChangeEvent(gridControl, enGrid_ChangeType.Size); // Check size
                if (resetColors && GridSync_Color(child, gridControl, settings.ColorDefault_MicroGrid)) onGridChangeEvent(gridControl, enGrid_ChangeType.Color); // Check size
                if (GridSync_Visible(gridControl, settings.Visible_MicroGrids)) onGridChangeEvent(gridControl, enGrid_ChangeType.Visible); // Check size
                if (GridSync_DisplayMode(grid, gridControl, settings.DisplayMode_MicroGrids)) onGridChangeEvent(gridControl, enGrid_ChangeType.DisplayMode); // Check size
            }

            // Color ID is always the same for all grids
            if (settings.Color_ID.Count != 0 && GridSync_StateColor(grid, gridControl, settings)) onGridChangeEvent(gridControl, enGrid_ChangeType.StateColor); // Check size
        }

        [Test_IgnoreCoverage(enTestIgnore.FrontendCode)]
        private static bool GridSync_StateColor(IGridBlock_Base grid, IGridControl gridFrontend, GridControl_Settings settings)
        {
            var state = grid as IGridBlock_State;
            if (state == null) return false;

            var result = false;
            Color color;
            if (settings.Color_ID.TryGetValue(state.State_Id, out color))
            {
                if (gridFrontend.BackColor != color)
                {
                    gridFrontend.BackColor = color;
                    result = true;
                }
            }
            return result;
        }

        [Test_IgnoreCoverage(enTestIgnore.FrontendCode)]
        private static bool GridSync_DisplayMode(IGridBlock_Base grid, IGridControl gridControl, enGrid_BlockDisplayType displayMode)
        {
            var result = false;
            switch (displayMode)
            {
               case enGrid_BlockDisplayType.Address: gridControl.Text = grid.Name_Caption; break;
               case enGrid_BlockDisplayType.Name: gridControl.Text = grid.Name_Control; break;
               case enGrid_BlockDisplayType.Value:
                {
                    var state = grid as IGridBlock_State;
                    if (state == null) return false;
                    if (Double.IsNaN(state.State_ValueDouble))
                         gridControl.Text = "?";
                    else gridControl.Text = state.State_ValueDouble.zObject().AsStr();
                    break;
                }
            }
            return result;
        }

        [Test_IgnoreCoverage(enTestIgnore.FrontendCode)]
        private static bool GridSync_Visible(IGridControl gridControl, bool visible)
        {
            var result = false;
            if (gridControl.Visible != visible)
            {
                gridControl.Visible = visible;
                gridControl._Parent.Visible = visible;
                result = true;
            }
            return result;
        }

        [Test_IgnoreCoverage(enTestIgnore.FrontendCode)]
        private static bool GridSync_Color(IGridBlock_State grid, IGridControl gridControl, Color defaultColor)
        {
            var result = false;
            if (grid == null || grid.State_Color == Color.Black)  // Default color
            {
                if (gridControl.BackColor != defaultColor)
                {
                    gridControl.BackColor = defaultColor;
                    result = true;
                }
            }
            else
            {
                gridControl.BackColor = grid.State_Color;
            }
            return result;
        }

        /// <summary>Sync the grid width and height.</summary>
        /// <param name="grid">The grid.</param>
        /// <param name="gridControl">The grid.</param>
        /// <param name="controlWidth">Width of the control.</param>
        /// <param name="controlHeight">Height of the control.</param>
        /// <returns></returns>
        [Test_IgnoreCoverage(enTestIgnore.FrontendCode)]
        private static bool GridSync_Size(IGridBlock_State grid, IGridControl gridControl, int controlWidth, int controlHeight)
        {
            //return false;
            //if (gridControl.Text == "5.1") gridControl.Text = "5.1";
            var result = false;
            if (gridControl.Width != controlWidth)
            {
                gridControl.Width = controlWidth;
                result = true;
            }
            if (grid != null && grid.State_Col != 1) return result;

            var parent = gridControl._Parent;
            if (parent.Height != controlHeight)
            {
                parent.Height = controlHeight;
                result = true;
            }
            return result;
        }
        #endregion
    }
}