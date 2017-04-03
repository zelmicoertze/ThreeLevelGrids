using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DuctingGrids.Frontend.GridControl;
using LamedalCore.domain.Enumerals;
using LamedalCore.domain.Events;
using LamedalCore.zPublicClass.GridBlock;
using LamedalCore.zPublicClass.GridBlock.GridInterface;

namespace DuctingGrids.Frontend.GridControl
{
    public sealed class winForms_GridControlsSetup
    {
        /// <summary>Store a quick reference to all the grid controls.</summary>
        private static readonly Dictionary<string, IGridControl> _gridControls = new Dictionary<string, IGridControl>();   // rows

        public readonly GridBlock_5Setup Cuboid;
        private readonly onGrid_Click _onClickEvent;
        private GridControl_Settings _Settings;


        /// <summary>Creates the Grid control with macro, sub and micro grids.</summary>
        /// <param name="rootRow">The root row. This is the top most row</param>
        /// <param name="settings">The settings.</param>
        /// <param name="onClick">The on click.</param>
        /// <returns></returns>
        public winForms_GridControlsSetup(GridControl_Row rootRow, GridControl_Settings settings, onGrid_Click onClick)        // Starting row                                        
        {
            _Settings = settings;
            if (onClick != null)
            {
                _onClickEvent -= onClick;
                _onClickEvent += onClick;
            }

            // Setup cuboid row
            Layout_Reset(rootRow);
            Cuboid = new GridBlock_5Setup(onCreateGridControl, settings);
            Layout_Resume(rootRow);
        }

        /// <summary>
        /// Creates the child grids.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        public void CreateChildGrids(GridControl_Row rootRow, IGridControl grid, int rows, int cols)
        {
            Cuboid.CreateNewChildGrids(grid, onCreateGridControl, rows, cols);
            Layout_Resume(rootRow);
        }

        #region Private
        private void onCreateGridControl(IGridBlock_Base sender, enGrid_ControlType gridcontroltype, string parentname, string childname, 
            enGrid_BlockType blocktype, ref IGridControl gridcontrol)
        {
            if (gridcontrol != null) throw new ArgumentException(gridcontrol.ToString(), "Error!. Grid control must be null in order to be created.");
            #region Sample of a simple 1x1,1x1,1x1 grid
            // R1
            // R1cub1_1
            // R1cub1_1R1
            // R1cub1_1R1mac1_1
            // R1cub1_1R1mac1_1R1
            // R1cub1_1R1mac1_1R1sub1_1
            // R1cub1_1R1mac1_1R1sub1_1R1
            // R1cub1_1R1mac1_1R1sub1_1R1mic1_1

            // Row//?//R1//CuboidGrid
            // Grid//R1//R1cub1_1//CuboidGrid
            // Row//R1cub1_1//R1cub1_1R1//MacroBlock
            // Grid//R1cub1_1R1//R1cub1_1R1mac1_1//MacroBlock
            // Row//R1cub1_1R1mac1_1//R1cub1_1R1mac1_1R1//SubBlock
            // Grid//R1cub1_1R1mac1_1R1//R1cub1_1R1mac1_1R1sub1_1//SubBlock
            // Row//R1cub1_1R1mac1_1R1sub1_1//R1cub1_1R1mac1_1R1sub1_1R1//MicroBlock
            // Grid//R1cub1_1R1mac1_1R1sub1_1R1//R1cub1_1R1mac1_1R1sub1_1R1mic1_1//MicroBlock
            #endregion

            // Find the grid control 
            bool created;
            gridcontrol = GridControl_Get(gridcontroltype, childname, blocktype, out created);
            if (created == false) return;   // The control exists, we do not need to do anything.

            // Find the parent
            IGridControl parent;
            if (GridControl_Get(parentname, out parent) == false) throw new InvalidOperationException("Error! Parent " + parentname + " does not exist.");

            // Setup the row / grid properties
            gridcontrol.GridState = sender;
            gridcontrol.Text = sender.Name_Caption;   // Set the caption of the control
            if (gridcontroltype == enGrid_ControlType.Row)
            {
                #region Row setup
                // ==================
                int height = 100;
                if (blocktype == enGrid_BlockType.CuboidGrid) height = _Settings.Size_CuboidHeight;  // These settings need to be calculated 
                else if (blocktype == enGrid_BlockType.MacroBlock) height = _Settings.Size_MacroHeight;  // These settings need to be calculated 
                else if (blocktype == enGrid_BlockType.SubBlock) height = _Settings.Size_SubHeight;
                else if (blocktype == enGrid_BlockType.MicroBlock) height = _Settings.Size_MicroHeight;

                GridControl_SetupRow(parent, gridcontrol, height);
                #endregion
            }
            else
            {
                #region Grid setup
                // ===================
                var color = Color.Gray;
                int width = 30;
                if (blocktype == enGrid_BlockType.CuboidGrid)
                {
                    color = _Settings.ColorDefault_CuboidGrid;
                    width = _Settings.Size_CuboidWidth; // These settings need to be calculated 
                } else if (blocktype == enGrid_BlockType.MacroBlock)
                {
                    width = _Settings.Size_MacroWidth; // These settings need to be calculated 
                    color = _Settings.ColorDefault_MacroGrid;
                }
                else if (blocktype == enGrid_BlockType.SubBlock)
                {
                    width = _Settings.Size_SubWidth;
                    color = _Settings.ColorDefault_SubGrid;
                }
                else if (blocktype == enGrid_BlockType.MicroBlock)
                {
                    var display = _Settings.DisplayMode_MicroGrids;
                    if (display == enGrid_BlockDisplayType.Address) gridcontrol.Text = sender.Name_Caption;   // Set the caption of the control
                    if (display == enGrid_BlockDisplayType.Name) gridcontrol.Text = sender.Name_Control;   // Set the caption of the control
                    if (display == enGrid_BlockDisplayType.Value) gridcontrol.Text = "?";   //There is no value yet

                    width = _Settings.Size_MicroWidth;
                    color = _Settings.ColorDefault_MicroGrid;
                }
                GridControl_SetupBlock(parent, gridcontrol, width, color);

                #endregion
            }
        }

        /// <summary>Resets the grid control dictionary.</summary>
        /// <param name="rootRow">The root row.</param>
        private void Layout_Reset(GridControl_Row rootRow)
        {
            rootRow.SuspendLayout();
            rootRow.Visible = false;
            if (_gridControls.Count != 0)
            {
                // Remove all controls
                rootRow.Controls.Clear();
                _gridControls.Clear();
            }
            // Setup the root row
            _gridControls.Add(rootRow.Name, rootRow);
            rootRow.Height = _Settings.Size_CuboidHeight;
        }

        /// <summary>Resume layout on all controls.</summary>
        private void Layout_Resume(GridControl_Row rootRow)
        {
            var gridControls = _gridControls.Values.ToList();
            foreach (IGridControl gridControl in gridControls) gridControl.ResumeLayout(true);
            Application.DoEvents();
            rootRow.Visible = true;
        }

        /// <summary>Setup a new row control.</summary>
        /// <param name="parentControl">The parent control.</param>
        /// <param name="rowControl">The row control.</param>
        /// <param name="height">The height.</param>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        private void GridControl_SetupRow(IGridControl parentControl, IGridControl rowControl, int height)
        {
            #region Check input parameters
            // Check row
            if (rowControl == null) throw new ArgumentNullException(rowControl.ToString());
            var row = rowControl as GridControl_Row;
            if (row == null) throw new ArgumentNullException(row.ToString());

            // Check parent
            if (parentControl == null) throw new ArgumentNullException(parentControl.ToString());
            var parent = parentControl as GridControl_Block;
            if (parent == null) throw new ArgumentNullException(parent.ToString());
            #endregion

            if (row.Parent != parent) parent.Controls.Add(row);
            row.BringToFront();

            row.BorderStyle = BorderStyle.FixedSingle;
            row.Dock = DockStyle.Top;
            row.Location = new Point(3, 16);
            //rowPanel.Name = name;
            row.Height = height;
            //panel.TabIndex = 2;
            //row.Click -= ClickEvent;
            //row.Click += ClickEvent;
        }

        /// <summary>Setup a new grids control (micro, sub or macro).</summary>
        /// <param name="parentRowControl">The parent control.</param>
        /// <param name="gridControl">The grid control.</param>
        /// <param name="width">The width.</param>
        /// <param name="color"></param>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        private void GridControl_SetupBlock(IGridControl parentRowControl, IGridControl gridControl, int width, Color color)
        {
            #region Check input parameters
            // Check the control
            if (gridControl == null) throw new ArgumentNullException(gridControl.ToString());

            // Check parent
            if (parentRowControl == null) throw new ArgumentNullException(parentRowControl.ToString());
            var parent = parentRowControl as GridControl_Row;
            if (parent == null) throw new ArgumentNullException(parent.ToString());
            #endregion

            // Set the parent & add events
            var control = gridControl as Control;
            if (control != null)
            {
                if (control.Parent != parent) parent.Controls.Add(control);
                control.Click -= ClickEvent;
                control.Click += ClickEvent;
                control.BringToFront();
                control.Dock = DockStyle.Left;
                control.Top = 0;
                control.Left = 0;
                control.Width = width;
                control.BackColor = color;
            }

            #region These properties are not used

            //gridBlock.Height = 20;   // The height does not matter
            //gridBlock.BackColor = System.Drawing.Color.White;
            //button.UseVisualStyleBackColor = false;

            #endregion
        }

        /// <summary>Try to find the specific grid control.</summary>
        /// <param name="childname">The name of the control to find.</param>
        /// <param name="gridControl">The grid control.</param>
        /// <returns></returns>
        private bool GridControl_Get(string childname, out IGridControl gridControl)
        {
            if (_gridControls.TryGetValue(childname, out gridControl)) return true;
            else return false;
        }

        /// <summary>Try to find the specific grid control. If the control is not found it will be created.</summary>
        /// <param name="gridcontroltype">The gridcontroltype.</param>
        /// <param name="childname">The childname.</param>
        /// <param name="blocktype">The blocktype.</param>
        /// <param name="created">if set to <c>true</c> [created].</param>
        /// <returns></returns>
        private IGridControl GridControl_Get(enGrid_ControlType gridcontroltype, string childname, enGrid_BlockType blocktype, out bool created)
        {
            created = false;
            IGridControl gridControl;
            if (GridControl_Get(childname, out gridControl)) return gridControl;  // The control was found -> work is done.

            // We need to create the control
            if (gridcontroltype == enGrid_ControlType.Row)
            {
                #region Create a new row
                var row = new GridControl_Row();
                _gridControls.Add(childname, row);
                gridControl = row;
                #endregion
            }
            else
            {
                if (blocktype == enGrid_BlockType.MicroBlock)
                {
                    #region Create micro grid
                    var micro = new GridControl_BlockMicro();
                    _gridControls.Add(childname, micro);
                    gridControl = micro;
                    #endregion
                }
                else
                {
                    #region Create sub or macro grid block
                    var grid = new GridControl_Block();
                    _gridControls.Add(childname, grid);
                    gridControl = grid;
                    #endregion
                }
            }
            gridControl.Name = childname;   // Set the name
            gridControl.SuspendLayout();    // Optimise performance
            created = true;                 // Set flag
            return gridControl;
        }

        private void ClickEvent(object sender, EventArgs e)
        {
            var control = sender as IGridControl;
            if (_onClickEvent != null) _onClickEvent(control);
        }
        #endregion
    }
}