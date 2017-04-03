using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            int addWidth = 10;
            int addHeight = 26;

            int widthTotal = 0;
            int heightTotal = 0;
            int widthMacro = 0;
            int widthMacroMax = 0;
            int heightMacro = 0;

            // Calculate the sizes
            List<IGridBlock_Base> macroGrids = cuboid.GridBlocksDictionary.Values.ToList();
            foreach (IGridBlock_Base macro in macroGrids)
            {
                // Sub Grids
                List<IGridBlock_Base> subGrids = macro.GridBlocksDictionary.Values.ToList();
                int widthSub = 0;
                int widthSubMax = 0;
                int heightSub = 0;
                foreach (IGridBlock_Base sub in subGrids)
                {
                    // Micro Grids
                    var microGrids = sub.GridBlocksDictionary.Values.ToList();
                    int widthMicro = 0;
                    int widthMicroMax = 0;
                    int heightMicro = 0;
                    foreach (IGridBlock_Base micro in microGrids)
                    {
                        micro.zGridControl.Width = settings.Size_MicroWidth;
                        micro.zGridControl._Parent.Width = settings.Size_MicroHeight;  // Row height
                        GridSync_CalcSize(micro, ref widthMicro, ref heightMicro);   // update the grid settings
                        widthMicroMax = Math.Max(widthMicroMax, widthMicro);
                    }
                    // Sub
                    var subControl = sub.zGridControl;
                    var subRow = subControl._Parent;
                    subControl.Width = Math.Max(widthMicroMax + addWidth, settings.Min_SubSize);
                    if (subControl.Left + subControl.Width > macro.zGridControl.Width) macro.zGridControl.Width = subControl.Left + subControl.Width + addWidth;   // Make sure children fit
                    subRow.Height = Math.Max(subRow.Height, Math.Max(heightMicro + addHeight, settings.Min_SubSize));
                    GridSync_CalcSize(sub, ref widthSub, ref heightSub);    // update the grid settings
                    widthSubMax = Math.Max(widthSubMax, widthSub);
                    //heightTotal += subRow.Height;
                }
                var macroControl = macro.zGridControl;
                var macroRow = macroControl._Parent;
                macroControl.Width = Math.Max(macroControl.Width, Math.Max(widthSubMax + addWidth, settings.Min_MacroSize));
                if (macroControl.Left +macroControl.Width > cuboid.zGridControl.Width) cuboid.zGridControl.Width = macroControl.Left + macroControl.Width +addWidth;  // Make sure children fit
                macroRow.Height = Math.Max(macroRow.Height, Math.Max(heightSub + addHeight, settings.Min_MacroSize));
                GridSync_CalcSize(macro, ref widthMacro, ref heightMacro);   // update the grid settings
                widthMacroMax = Math.Max(widthMacroMax, widthMacro);
            }
            var cuboidControl = cuboid.zGridControl;
            var cuboidRow = cuboidControl._Parent;
            //cuboidControl.Width = widthMacroMax + addWidth;
            cuboidRow.Height = heightMacro + addHeight;

            // Macro Grids
            foreach (IGridBlock_Base macro in macroGrids)
            {
                // Sub Grids
                List<IGridBlock_Base> subGrids = macro.GridBlocksDictionary.Values.ToList();
                foreach (IGridBlock_Base sub in subGrids)
                {
                    // Micro Grids
                    var microGrids = sub.GridBlocksDictionary.Values.ToList();
                    foreach (IGridBlock_Base micro in microGrids)
                    {
                        GridSync(micro, settings, resetColors, onGridChangeEvent);   // update the grid settings
                    }
                    GridSync(sub, settings, resetColors, onGridChangeEvent);    // update the grid settings
                }
                GridSync(macro, settings, resetColors, onGridChangeEvent);   // update the grid settings
            }
            GridSync(cuboid, settings, resetColors, onGridChangeEvent);  // update the grid settings
        }

        static int rowMax = 0;
        private static void GridSync_CalcSize(IGridBlock_Base grid, ref int width, ref int height)
        {
            
            IGridControl gridControl = grid.zGridControl;
            var child = grid as IGridBlock_State;
            if (child != null)
            {
                // Recalc sizes
                if (child.State_Row != rowMax)
                {
                    // reset the row
                    width = 0;
                    rowMax = child.State_Row;
                }
                width += gridControl.Width; // Only increase width on first row

                if (child.State_Col == 1) height += gridControl._Parent.Height; // Only increase height on first col
            }
        }

        #region Private
        /// <summary>
        /// Synchronize grid values.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="resetColors">if set to <c>true</c> [reset colors].</param>
        /// <param name="onGridChangeEvent">The on grid change.</param>
        [Test_IgnoreCoverage(enTestIgnore.FrontendCode)]
        private static void GridSync(IGridBlock_Base grid, GridControl_Settings settings, bool resetColors, onGrid_ChangeEvent onGridChangeEvent)
        {
            IGridControl gridControl = grid.zGridControl;
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
            return false;
            ////if (gridControl.Text == "5.1") gridControl.Text = "5.1";
            //var result = false;
            //if (gridControl.Width != controlWidth)
            //{
            //    gridControl.Width = controlWidth;
            //    result = true;
            //}
            //if (grid != null && grid.State_Col != 1) return result;

            //var parent = gridControl._Parent;
            //if (parent.Height != controlHeight)
            //{
            //    parent.Height = controlHeight;
            //    result = true;
            //}
            //return result;
        }
        #endregion
    }
}