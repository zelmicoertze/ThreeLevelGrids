using System;
using System.Collections.Generic;
using DuctingGrids.GridBlock.enums;
using LamedalCore.zz;

namespace DuctingGrids.GridBlock
{
    public sealed class GridBlock_3Macro : IGridBlock
    {
        public string _Frontend_Caption { get; }
        public int Reference_Col { get; }
        public int Reference_Row { get; }
        public double State_Value { get; set; }
        public enBlockState State_Block { get; set; }
        public string _Frontend_Name { get; }
        public IGridblock_Frontend _Parent { get; }

        private readonly Dictionary<string, IGridBlock_State> _gridBlockDictionary = new Dictionary<string, IGridBlock_State>();

        /// <summary>Initializes a new instance of the <see cref="GridBlock_1Micro" /> class.</summary>
        /// <param name="parent">The parent.</param>
        /// <param name="onGridCreate">The on grid create.</param>
        /// <param name="onGridRowCreate">The on grid row create.</param>
        /// <param name="col">The col.</param>
        /// <param name="row">The row.</param>
        /// <param name="subCols">The sub cols.</param>
        /// <param name="subRows">The sub rows.</param>
        /// <param name="microCols">The micro cols.</param>
        /// <param name="microRows">The micro rows.</param>
        public GridBlock_3Macro(IGridblock_Frontend parent, OnGridCreate onGridCreate, OnGridRowCreate onGridRowCreate,
                        int col, int row, 
                        int subCols = 5, int subRows = 5, 
                        int microCols = 5, int microRows = 5)
        {
            _Parent = parent;
            _Frontend_Caption = $"{row}.{col}";
            Reference_Col = col;
            Reference_Row = row;
            State_Value = double.NaN;
            State_Block = enBlockState.Unknown;
            ChildBlockType = enBlockType.SubBlock;
            ChildDisplayType = enBlockDisplayType.Name;
            ChildDecimalPlaces = 1;
            _Frontend_Name = parent._Frontend_Name + $"mac{row}_{col}";
            _Frontend_CurrentRow = GridBlock_Methods.FrontendCurrentRow(parent, row);
            onGridCreate?.Invoke(this, enBlockType.MacroBlock);

            // Create the child objects
            for (int row1 = 1; row1 <= subRows; row1++)
            {
                onGridRowCreate?.Invoke(this, row);

                for (int col1 = 1; col1 <= subCols; col1++)
                {
                    var grid = new GridBlock_2Sub(this, onGridCreate, onGridRowCreate, col1, row1, microCols:microCols, microRows:microRows);
                    _gridBlockDictionary.Add(grid._Frontend_Caption, grid);

                }
            }
            ChildCount = subRows * subCols *microCols*microRows;
        }

        public int ChildCount { get; }

        public IGridBlock_State Child_GridBlockGet(string macroAddress)
        {
            IGridBlock_State grid = null;
            if (_gridBlockDictionary.TryGetValue(macroAddress, out grid) == false)
            {
                throw new ArgumentException($"Error! Unable to find '{macroAddress}'!");
            }
            return grid;
        }

        public string _Frontend_CurrentRow { get; }

        public enBlockType ChildBlockType { get; }
        public enBlockDisplayType ChildDisplayType { get; set; }
        public int ChildDecimalPlaces { get; }
    }
}