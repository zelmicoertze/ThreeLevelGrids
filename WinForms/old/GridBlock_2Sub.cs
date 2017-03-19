using System;
using System.Collections.Generic;
using DuctingGrids.GridBlock.enums;

namespace DuctingGrids.GridBlock
{
    public sealed class GridBlock_2Sub : IGridBlock
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
        /// <param name="col">The col.</param>
        /// <param name="row">The row.</param>
        /// <param name="microCols">The micro cols.</param>
        /// <param name="microRows">The micro rows.</param>
        public GridBlock_2Sub(IGridBlock parent, OnGridCreate onGridCreate, OnGridRowCreate onGridRowCreate,
                        int col, int row, int microCols = 5, int microRows = 5)
        {
            _Parent = parent;
            _Frontend_Caption = $"{row}.{col}";
            Reference_Col = col;
            Reference_Row = row;
            State_Value = double.NaN;
            State_Block = enBlockState.Unknown;
            ChildBlockType = enBlockType.MicroBlock;
            ChildDisplayType = enBlockDisplayType.Name;
            ChildDecimalPlaces = 1;
            _Frontend_Name = parent._Frontend_Name + $"sub{row}_{col}";
            _Frontend_CurrentRow = GridBlock_Methods.FrontendCurrentRow(parent, row);

            onGridCreate?.Invoke(this, enBlockType.SubBlock);

            // Create the child objects
            // This can be optimised by only creating a child the momemnt it is neaded in Child_GridBlockGet
            for (int row1 = 1; row1 <= microRows; row1++)
            {
                onGridRowCreate?.Invoke(this, row);

                for (int col1 = 1; col1 <= microCols; col1++)
                {
                    var grid = new GridBlock_1Micro(this, onGridCreate, col1, row1);
                    _gridBlockDictionary.Add(grid._Frontend_Caption, grid);
                }
            }
            ChildCount = microRows*microCols;
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

        public enBlockType ChildBlockType { get;}
        public enBlockDisplayType ChildDisplayType { get; set; }
        public int ChildDecimalPlaces { get;}
    }
}