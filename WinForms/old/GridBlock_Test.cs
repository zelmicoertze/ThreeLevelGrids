using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuctingGrids.GridBlock.enums;
using LamedalCore;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;
using Xunit;

namespace DuctingGrids.GridBlock
{
    public sealed class GridBlock_Test : IGridblock_Frontend
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        [Test_IgnoreCoverage(enTestIgnore.CodeIsUsedForTesting)]
        public IGridblock_Frontend _Parent { get; }
        public string _Frontend_Name { get; }
        public string _Frontend_RowParent { get; }
        public string _Frontend_RowChild { get; }
        public string _Frontend_Caption { get; }

        public GridBlock_Test()
        {
            this._Frontend_Name = "";
            this._Frontend_RowParent = "r1";
            _Frontend_RowChild = "";
            _Frontend_Caption = "1.1";
        }

        [Theory]
        [InlineData("1.1", "1.1", "1.1")]
        [InlineData("2.1", "1.2", "1.3")]
        [InlineData("2.1", "2.2", "2.3")]
        [Test_Method("Child_GridBlockGet()")]
        [Test_Method("Child_GridBlockSub()")]
        [Test_Method("Child_GridBlockMicro()")]
        public void GridBlock_4MacroSetup_Test(string addressMacro, string addressSub, string addressMicro)
        {
            int macroY, macroX;
            GridBlock_Methods.Address_ToXY(addressMacro, out macroY, out macroX);
            int subY, subX;
            GridBlock_Methods.Address_ToXY(addressSub, out subY, out subX);
            int microY, microX;
            GridBlock_Methods.Address_ToXY(addressMicro, out microY, out microX);

            
            var gridCuboid = new GridBlock_4MacroSetup(this, null, null, macroCols: 1, macroRows: 5, subCols: 6, subRows: 5, microCols: 6, microRows: 6);

            #region Cuboid
            Assert.Equal(5*6*5*6*6, gridCuboid.ChildCount);
            Assert.Equal(this, gridCuboid._Parent);
            Assert.Equal(enBlockType.MacroBlock, gridCuboid.ChildBlockType);
            Assert.Equal(1, gridCuboid.ChildDecimalPlaces);
            Assert.Equal(enBlockDisplayType.Name, gridCuboid.ChildDisplayType);
            #endregion

            #region Macro block
            var gridMacro = gridCuboid.Child_GridBlockGet(addressMacro) as GridBlock_3Macro;
            Assert.NotEqual(null, gridMacro);
            Assert.Equal(addressMacro, gridMacro._Frontend_Caption);
            Assert.Equal(6*5*6*6, gridMacro.ChildCount);
            Assert.Equal(gridCuboid, gridMacro._Parent);
            Assert.Equal(enBlockType.SubBlock, gridMacro.ChildBlockType);
            Assert.Equal(1, gridMacro.ChildDecimalPlaces);
            Assert.Equal(enBlockDisplayType.Name, gridMacro.ChildDisplayType);
            Assert.Equal(macroY, gridMacro.Reference_Row);
            Assert.Equal(macroX, gridMacro.Reference_Col);
            Assert.Equal(enBlockState.Unknown, gridMacro.State_Block);
            Assert.Equal(double.NaN, gridMacro.State_Value);

            #endregion

            #region Sub block
            var gridSub = gridMacro.Child_GridBlockGet(addressSub) as GridBlock_2Sub;
            Assert.NotEqual(null, gridSub);
            Assert.Equal(addressSub, gridSub._Frontend_Caption);
            Assert.Equal(6 * 6, gridSub.ChildCount);
            Assert.Equal(gridMacro, gridSub._Parent);
            Assert.Equal(enBlockType.MicroBlock, gridSub.ChildBlockType);
            Assert.Equal(1, gridSub.ChildDecimalPlaces);
            Assert.Equal(enBlockDisplayType.Name, gridSub.ChildDisplayType);
            Assert.Equal(subY, gridSub.Reference_Row);
            Assert.Equal(subX, gridSub.Reference_Col);
            Assert.Equal(enBlockState.Unknown, gridSub.State_Block);
            Assert.Equal(double.NaN, gridSub.State_Value);

            // Child_GridBlockSub
            var gridSub2 = gridCuboid.Child_GridBlockSub(addressMacro, addressSub);
            Assert.Equal(gridSub, gridSub2);

            #endregion

            #region Micro block
            var gridMicro = gridSub.Child_GridBlockGet(addressMicro) as GridBlock_1Micro;
            Assert.NotEqual(null, gridMicro);
            Assert.Equal(addressMicro, gridMicro._Frontend_Caption);
            Assert.Equal(gridSub, gridMicro._Parent);
            Assert.Equal(microY, gridMicro.Reference_Row);
            Assert.Equal(microX, gridMicro.Reference_Col);
            Assert.Equal(enBlockState.Unknown,gridMicro.State_Block);
            Assert.Equal(double.NaN,gridMicro.State_Value);
                

            // Child_GridBlockMicro
            var gridMicro2 = gridCuboid.Child_GridBlockMicro(addressMacro, addressSub, addressMicro);
            Assert.Equal(gridMicro, gridMicro2);
            #endregion
        }

        [Theory]
        [InlineData("2.2", "6.2", "2.7")]
        [InlineData("1.6", "3.7", "7.3")]
        [Test_Method("Child_GridBlockGet()")]
        [Test_Method("Child_GridBlockSub()")]
        [Test_Method("Child_GridBlockMicro()")]
        public void GridBlock_4MacroSetup_Fail(string addressMacro, string addressSub, string addressMicro)
        {
            var gridCuboid = new GridBlock_4MacroSetup(this, null, null, macroCols: 1, macroRows: 5, subCols: 6, subRows: 5, microCols: 6, microRows: 6);
            Assert.Throws<ArgumentException>(() =>gridCuboid.Child_GridBlockGet(addressMacro) as GridBlock_3Macro);
            Assert.Throws<ArgumentException>(() => gridCuboid.Child_GridBlockSub("1.1", addressSub));
            Assert.Throws<ArgumentException>(() => gridCuboid.Child_GridBlockMicro("1.1", "1.1", addressMicro));
        }

        private List<string> tree = new List<string>();

        [Fact]
        [Test_Method("GridBlock_4MacroSetup(1.1,1.1,1.1)")]
        public void GridBlock_Frontend_Test1()
        {
            tree.Clear();
            tree.Add(_Frontend_RowParent);
            var gridCuboid = new GridBlock_4MacroSetup(this, onGridCreate, onGridRowCreate, macroCols: 1, macroRows: 1, subCols: 1, subRows: 1, microCols: 1, microRows: 1);

            var treeResult =
@"r1
r1/cub1_1
r1/cub1_1/r1
r1/cub1_1/r1/mac1_1
r1/cub1_1/r1/mac1_1/r1
r1/cub1_1/r1/mac1_1/r1/sub1_1
r1/cub1_1/r1/mac1_1/r1/sub1_1/r1
r1/cub1_1/r1/mac1_1/r1/sub1_1/r1/mic1_1";
            var treeStr = tree.zTo_Str("".NL());
            
            Assert.Equal(treeResult, treeStr);
        }

        private void onGridCreate(IGridblock_Frontend sender, enBlockType blockType)
        {
            tree.Add(sender._Frontend_Name);
        }

        private void onGridRowCreate(IGridblock_Frontend sender, int rowNo)
        {
            tree.Add(sender._Frontend_RowChild);
        }

        [Fact]
        [Test_Method("GridBlock_4MacroSetup(1.1,1.1,5.5)")]
        public void GridBlock_Frontend_Test2()
        {
            tree.Clear();
            tree.Add(_Frontend_RowParent);
            var gridCuboid = new GridBlock_4MacroSetup(this, onGridCreate, onGridRowCreate, macroCols: 1, macroRows: 1, subCols: 1, subRows: 1, microCols: 5, microRows: 5);
            var treeStr = tree.zTo_Str("".NL());

            #region result
            var treeResult =
@"r1
r1/cub1_1
r1/cub1_1/r1
r1/cub1_1/r1/mac1_1
r1/cub1_1/r1/mac1_1/r1
r1/cub1_1/r1/mac1_1/r1/sub1_1
r1/cub1_1/r1/mac1_1/r1/sub1_1/r1
r1/cub1_1/r1/mac1_1/r1/sub1_1/r1/mic1_1
r1/cub1_1/r1/mac1_1/r1/sub1_1/r1/mic1_2
r1/cub1_1/r1/mac1_1/r1/sub1_1/r1/mic1_3
r1/cub1_1/r1/mac1_1/r1/sub1_1/r1/mic1_4
r1/cub1_1/r1/mac1_1/r1/sub1_1/r1/mic1_5
r1/cub1_1/r1/mac1_1/r1/sub1_1/r2
r1/cub1_1/r1/mac1_1/r1/sub1_1/r2/mic2_1
r1/cub1_1/r1/mac1_1/r1/sub1_1/r2/mic2_2
r1/cub1_1/r1/mac1_1/r1/sub1_1/r2/mic2_3
r1/cub1_1/r1/mac1_1/r1/sub1_1/r2/mic2_4
r1/cub1_1/r1/mac1_1/r1/sub1_1/r2/mic2_5
r1/cub1_1/r1/mac1_1/r1/sub1_1/r3
r1/cub1_1/r1/mac1_1/r1/sub1_1/r3/mic3_1
r1/cub1_1/r1/mac1_1/r1/sub1_1/r3/mic3_2
r1/cub1_1/r1/mac1_1/r1/sub1_1/r3/mic3_3
r1/cub1_1/r1/mac1_1/r1/sub1_1/r3/mic3_4
r1/cub1_1/r1/mac1_1/r1/sub1_1/r3/mic3_5
r1/cub1_1/r1/mac1_1/r1/sub1_1/r4
r1/cub1_1/r1/mac1_1/r1/sub1_1/r4/mic4_1
r1/cub1_1/r1/mac1_1/r1/sub1_1/r4/mic4_2
r1/cub1_1/r1/mac1_1/r1/sub1_1/r4/mic4_3
r1/cub1_1/r1/mac1_1/r1/sub1_1/r4/mic4_4
r1/cub1_1/r1/mac1_1/r1/sub1_1/r4/mic4_5
r1/cub1_1/r1/mac1_1/r1/sub1_1/r5
r1/cub1_1/r1/mac1_1/r1/sub1_1/r5/mic5_1
r1/cub1_1/r1/mac1_1/r1/sub1_1/r5/mic5_2
r1/cub1_1/r1/mac1_1/r1/sub1_1/r5/mic5_3
r1/cub1_1/r1/mac1_1/r1/sub1_1/r5/mic5_4
r1/cub1_1/r1/mac1_1/r1/sub1_1/r5/mic5_5";
            #endregion

            Assert.Equal(treeResult, treeStr);
        }

        [Fact]
        [Test_Method("GridBlock_4MacroSetup(2.2,3.3,3.3)")]
        public void GridBlock_Frontend_Test3()
        {
            tree.Clear();
            tree.Add(_Frontend_RowParent);
            var gridCuboid = new GridBlock_4MacroSetup(this, onGridCreate, onGridRowCreate, macroCols: 2, macroRows: 2, subCols: 2, subRows: 2, microCols: 2, microRows: 2);
            var treeStr = tree.zTo_Str("".NL());

            #region result
            var treeResult =
@"r1
r1/cub1_1
r1/cub1_1/r1
r1/cub1_1/r1/mac1_1
r1/cub1_1/r1/mac1_1/r1
r1/cub1_1/r1/mac1_1/r1/sub1_1
r1/cub1_1/r1/mac1_1/r1/sub1_1/r1
r1/cub1_1/r1/mac1_1/r1/sub1_1/r1/mic1_1
r1/cub1_1/r1/mac1_1/r1/sub1_1/r1/mic1_2
r1/cub1_1/r1/mac1_1/r1/sub1_1/r2
r1/cub1_1/r1/mac1_1/r1/sub1_1/r2/mic2_1
r1/cub1_1/r1/mac1_1/r1/sub1_1/r2/mic2_2
r1/cub1_1/r1/mac1_1/r1/sub1_2
r1/cub1_1/r1/mac1_1/r1/sub1_2/r1
r1/cub1_1/r1/mac1_1/r1/sub1_2/r1/mic1_1
r1/cub1_1/r1/mac1_1/r1/sub1_2/r1/mic1_2
r1/cub1_1/r1/mac1_1/r1/sub1_2/r2
r1/cub1_1/r1/mac1_1/r1/sub1_2/r2/mic2_1
r1/cub1_1/r1/mac1_1/r1/sub1_2/r2/mic2_2
r1/cub1_1/r1/mac1_1/r2
r1/cub1_1/r1/mac1_1/r2/sub2_1
r1/cub1_1/r1/mac1_1/r2/sub2_1/r1
r1/cub1_1/r1/mac1_1/r2/sub2_1/r1/mic1_1
r1/cub1_1/r1/mac1_1/r2/sub2_1/r1/mic1_2
r1/cub1_1/r1/mac1_1/r2/sub2_1/r2
r1/cub1_1/r1/mac1_1/r2/sub2_1/r2/mic2_1
r1/cub1_1/r1/mac1_1/r2/sub2_1/r2/mic2_2
r1/cub1_1/r1/mac1_1/r2/sub2_2
r1/cub1_1/r1/mac1_1/r2/sub2_2/r1
r1/cub1_1/r1/mac1_1/r2/sub2_2/r1/mic1_1
r1/cub1_1/r1/mac1_1/r2/sub2_2/r1/mic1_2
r1/cub1_1/r1/mac1_1/r2/sub2_2/r2
r1/cub1_1/r1/mac1_1/r2/sub2_2/r2/mic2_1
r1/cub1_1/r1/mac1_1/r2/sub2_2/r2/mic2_2
r1/cub1_1/r1/mac1_2
r1/cub1_1/r1/mac1_2/r1
r1/cub1_1/r1/mac1_2/r1/sub1_1
r1/cub1_1/r1/mac1_2/r1/sub1_1/r1
r1/cub1_1/r1/mac1_2/r1/sub1_1/r1/mic1_1
r1/cub1_1/r1/mac1_2/r1/sub1_1/r1/mic1_2
r1/cub1_1/r1/mac1_2/r1/sub1_1/r2
r1/cub1_1/r1/mac1_2/r1/sub1_1/r2/mic2_1
r1/cub1_1/r1/mac1_2/r1/sub1_1/r2/mic2_2
r1/cub1_1/r1/mac1_2/r1/sub1_2
r1/cub1_1/r1/mac1_2/r1/sub1_2/r1
r1/cub1_1/r1/mac1_2/r1/sub1_2/r1/mic1_1
r1/cub1_1/r1/mac1_2/r1/sub1_2/r1/mic1_2
r1/cub1_1/r1/mac1_2/r1/sub1_2/r2
r1/cub1_1/r1/mac1_2/r1/sub1_2/r2/mic2_1
r1/cub1_1/r1/mac1_2/r1/sub1_2/r2/mic2_2
r1/cub1_1/r1/mac1_2/r2
r1/cub1_1/r1/mac1_2/r2/sub2_1
r1/cub1_1/r1/mac1_2/r2/sub2_1/r1
r1/cub1_1/r1/mac1_2/r2/sub2_1/r1/mic1_1
r1/cub1_1/r1/mac1_2/r2/sub2_1/r1/mic1_2
r1/cub1_1/r1/mac1_2/r2/sub2_1/r2
r1/cub1_1/r1/mac1_2/r2/sub2_1/r2/mic2_1
r1/cub1_1/r1/mac1_2/r2/sub2_1/r2/mic2_2
r1/cub1_1/r1/mac1_2/r2/sub2_2
r1/cub1_1/r1/mac1_2/r2/sub2_2/r1
r1/cub1_1/r1/mac1_2/r2/sub2_2/r1/mic1_1
r1/cub1_1/r1/mac1_2/r2/sub2_2/r1/mic1_2
r1/cub1_1/r1/mac1_2/r2/sub2_2/r2
r1/cub1_1/r1/mac1_2/r2/sub2_2/r2/mic2_1
r1/cub1_1/r1/mac1_2/r2/sub2_2/r2/mic2_2
r1/cub1_1/r2
r1/cub1_1/r2/mac2_1
r1/cub1_1/r2/mac2_1/r1
r1/cub1_1/r2/mac2_1/r1/sub1_1
r1/cub1_1/r2/mac2_1/r1/sub1_1/r1
r1/cub1_1/r2/mac2_1/r1/sub1_1/r1/mic1_1
r1/cub1_1/r2/mac2_1/r1/sub1_1/r1/mic1_2
r1/cub1_1/r2/mac2_1/r1/sub1_1/r2
r1/cub1_1/r2/mac2_1/r1/sub1_1/r2/mic2_1
r1/cub1_1/r2/mac2_1/r1/sub1_1/r2/mic2_2
r1/cub1_1/r2/mac2_1/r1/sub1_2
r1/cub1_1/r2/mac2_1/r1/sub1_2/r1
r1/cub1_1/r2/mac2_1/r1/sub1_2/r1/mic1_1
r1/cub1_1/r2/mac2_1/r1/sub1_2/r1/mic1_2
r1/cub1_1/r2/mac2_1/r1/sub1_2/r2
r1/cub1_1/r2/mac2_1/r1/sub1_2/r2/mic2_1
r1/cub1_1/r2/mac2_1/r1/sub1_2/r2/mic2_2
r1/cub1_1/r2/mac2_1/r2
r1/cub1_1/r2/mac2_1/r2/sub2_1
r1/cub1_1/r2/mac2_1/r2/sub2_1/r1
r1/cub1_1/r2/mac2_1/r2/sub2_1/r1/mic1_1
r1/cub1_1/r2/mac2_1/r2/sub2_1/r1/mic1_2
r1/cub1_1/r2/mac2_1/r2/sub2_1/r2
r1/cub1_1/r2/mac2_1/r2/sub2_1/r2/mic2_1
r1/cub1_1/r2/mac2_1/r2/sub2_1/r2/mic2_2
r1/cub1_1/r2/mac2_1/r2/sub2_2
r1/cub1_1/r2/mac2_1/r2/sub2_2/r1
r1/cub1_1/r2/mac2_1/r2/sub2_2/r1/mic1_1
r1/cub1_1/r2/mac2_1/r2/sub2_2/r1/mic1_2
r1/cub1_1/r2/mac2_1/r2/sub2_2/r2
r1/cub1_1/r2/mac2_1/r2/sub2_2/r2/mic2_1
r1/cub1_1/r2/mac2_1/r2/sub2_2/r2/mic2_2
r1/cub1_1/r2/mac2_2
r1/cub1_1/r2/mac2_2/r1
r1/cub1_1/r2/mac2_2/r1/sub1_1
r1/cub1_1/r2/mac2_2/r1/sub1_1/r1
r1/cub1_1/r2/mac2_2/r1/sub1_1/r1/mic1_1
r1/cub1_1/r2/mac2_2/r1/sub1_1/r1/mic1_2
r1/cub1_1/r2/mac2_2/r1/sub1_1/r2
r1/cub1_1/r2/mac2_2/r1/sub1_1/r2/mic2_1
r1/cub1_1/r2/mac2_2/r1/sub1_1/r2/mic2_2
r1/cub1_1/r2/mac2_2/r1/sub1_2
r1/cub1_1/r2/mac2_2/r1/sub1_2/r1
r1/cub1_1/r2/mac2_2/r1/sub1_2/r1/mic1_1
r1/cub1_1/r2/mac2_2/r1/sub1_2/r1/mic1_2
r1/cub1_1/r2/mac2_2/r1/sub1_2/r2
r1/cub1_1/r2/mac2_2/r1/sub1_2/r2/mic2_1
r1/cub1_1/r2/mac2_2/r1/sub1_2/r2/mic2_2
r1/cub1_1/r2/mac2_2/r2
r1/cub1_1/r2/mac2_2/r2/sub2_1
r1/cub1_1/r2/mac2_2/r2/sub2_1/r1
r1/cub1_1/r2/mac2_2/r2/sub2_1/r1/mic1_1
r1/cub1_1/r2/mac2_2/r2/sub2_1/r1/mic1_2
r1/cub1_1/r2/mac2_2/r2/sub2_1/r2
r1/cub1_1/r2/mac2_2/r2/sub2_1/r2/mic2_1
r1/cub1_1/r2/mac2_2/r2/sub2_1/r2/mic2_2
r1/cub1_1/r2/mac2_2/r2/sub2_2
r1/cub1_1/r2/mac2_2/r2/sub2_2/r1
r1/cub1_1/r2/mac2_2/r2/sub2_2/r1/mic1_1
r1/cub1_1/r2/mac2_2/r2/sub2_2/r1/mic1_2
r1/cub1_1/r2/mac2_2/r2/sub2_2/r2
r1/cub1_1/r2/mac2_2/r2/sub2_2/r2/mic2_1
r1/cub1_1/r2/mac2_2/r2/sub2_2/r2/mic2_2";
            #endregion

            Assert.Equal(treeResult, treeStr);
        }


        [Fact]
        [Test_Method("Address_ToXY()")]
        public void Address_ToXY_Test()
        {
            int y, x;
            GridBlock_Methods.Address_ToXY("1.1",out y, out x);
            Assert.Equal(1, y);
            Assert.Equal(1, x);

            GridBlock_Methods.Address_ToXY("1.3", out y, out x);
            Assert.Equal(1, y);
            Assert.Equal(3, x);

            GridBlock_Methods.Address_ToXY("7.3", out y, out x);
            Assert.Equal(7, y);
            Assert.Equal(3, x);
        }


        
    }
}
