using System.Windows.Forms;
using LamedalCore.zPublicClass.GridBlock.GridInterface;

namespace DuctingGrids.Frontend.GridControl
{
    /// <summary>
    /// This control show macro & sub grids. The purpose of this class is to implement IGridControl interfrace
    /// </summary>
    /// <seealso cref="System.Windows.Forms.GroupBox" />
    /// <seealso cref="IGridControl_Frontend" />
    /// <seealso cref="IGridControl" />
    public sealed class GridControl_Block : GroupBox, IGridControl
    {
        /// <summary>This is a property that can be used to save a reference to the backend object.</summary>
        public IGridBlock_Base GridState { get; set; }

        public IGridControl _Parent
        {
            get {  return Parent as IGridControl;}
        }
    }
}