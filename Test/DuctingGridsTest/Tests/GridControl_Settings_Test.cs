using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        [Test_Method("GridControl_Settings")]
        public void GridControl_Settings_SizeTest()
        {
            #region Input
            var settings = new GridControl_Settings(2, 2, 2, 2, 5, 5, 32, 30);
            #endregion

            #region Test1: Sizes calc
            Assert.Equal(32, settings.Size_MicroWidth);
            Assert.Equal(30, settings.Size_MicroHeight);
            Assert.Equal(170, settings.Size_SubWidth);
            Assert.Equal(170, settings.Size_SubHeight);
            Assert.Equal(350, settings.Size_MacroWidth);
            Assert.Equal(360, settings.Size_MacroHeight);
            Assert.Equal(710, settings.Size_CuboidWidth);
            Assert.Equal(740, settings.Size_CuboidHeight);
            #endregion

            #region Test2: Add rows and recalc
            settings.Total_SubRows = 3;
            settings.Total_MacroCols = 3;
            settings.Refresh_Calculations();
            Assert.Equal(32, settings.Size_MicroWidth);
            Assert.Equal(30, settings.Size_MicroHeight);
            Assert.Equal(170, settings.Size_SubWidth);
            Assert.Equal(170, settings.Size_SubHeight);
            Assert.Equal(350, settings.Size_MacroWidth);
            Assert.Equal(530, settings.Size_MacroHeight);
            Assert.Equal(1060, settings.Size_CuboidWidth);
            Assert.Equal(1080, settings.Size_CuboidHeight);
            #endregion

            settings.Color_ID.Clear();
            settings.Color_ID.Add(1, Color.Green);
            settings.Color_ID.Add(2, Color.Yellow);
            settings.Color_ID.Add(3, Color.Red);

            settings.Setup(1, 1, 1, 1, 1, 4);
            var gridCuboid = new GridBlock_5Setup(null, settings);

            // Load data
            // Load data into grids
            // 1.1
            var gridMicro = gridCuboid.GetChild_MicroGridBlock("1_1", "1_1", "1_1");
            gridMicro.State_Setup(1.5, 1, Color.Red);

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
                state.State_ValueDouble = 3.3;
                state.State_Color = Color.Aqua;
            }

            GridControlTools.Syncronise(gridCuboid, settings, true, OnGridChangeEvent);
        }

        private void OnGridChangeEvent(IGridControl gridcontrol, enGrid_ChangeType changetype)
        {
            // Fire when change happened
        }
    }
}
