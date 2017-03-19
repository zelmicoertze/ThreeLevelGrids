using System.Windows.Forms;
using LamedalCore.zPublicClass.GridBlock.GridInterface;

namespace DuctingGrids.Frontend.GridControl
{
    /// <summary>This is a row where grids is displayed. The purpose of this class is to implement IGridControl interfrace</summary>
    /// <seealso cref="IGridControl" />
    /// <seealso cref="System.Windows.Forms.Panel" />
    public sealed class GridControl_Row : Panel, IGridControl
    {
        /// <summary>This is a property that can be used to save a reference to the backend object.</summary>
        public IGridBlock_Base GridState { get; set; }

        public IGridControl _Parent
        {
            get { return Parent as IGridControl; }
        }
    }
}
