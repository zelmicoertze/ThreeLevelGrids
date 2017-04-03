using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using DuctingGrids.Frontend.Forms;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.GridBlock;
using LamedalCore.zPublicClass.GridBlock.GridInterface;

namespace DuctingGrids.Frontend.GridControl
{
    [ToolboxItem(true)]
    [DefaultEvent("")]
    [Description("")]
    public partial class DuctingControl : Control
    {
        private GridControl_Row _panelRow;
        private bool _refreshGrid;
        private GridControl_Settings _Settings = GridControlTools.GridControl_Settings();
        public winForms_GridControlsSetup _grids;

        public DuctingControl()
        {
            InitializeComponent();

            // Assign defaults
            gridWidth = 32;
            gridHeight = 25;
            macroCols = 2;
            macroRows = 2;
            subCols = 2;
            subRows = 2;
            microCols = 2;
            microRows = 2;
            macroGridDefaultColor = System.Drawing.Color.LightGray;
            subGridDefaultColor = System.Drawing.Color.LightGray;
            microGridDefaultColor = System.Drawing.Color.LightGray;
            blockDisplayType = enGrid_BlockDisplayType.Address;
            visibleMacro = true;
            visibleSub = true;
            visibleMicro = true;
            displayName = false;
            displayAddress = true;
            displayValue = false;

            // Create first row
            _panelRow = new GridControl_Row();
            _panelRow.Parent = this;
            _panelRow.BorderStyle = BorderStyle.FixedSingle;
            _panelRow.Dock = DockStyle.Fill;
            _panelRow.GridState = null;
            _panelRow.Location = new Point(3, 16);
            _panelRow.Name = "R1";
            GenerateGrids();
        }

        public DuctingControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region Properties

        [Category("DuctingGrids")]
        [Description("The width of the grid")]
        public int gridWidth { get; set; }

        [Category("DuctingGrids")]
        [Description("The height of the grid")]
        public int gridHeight { get; set; }

        [Category("DuctingGrids")]
        [Description("The number of columns in the macro grid")]
        public int macroCols { get; set; }

        [Category("DuctingGrids")]
        [Description("The number of rows in the macro grid")]
        public int macroRows { get; set; }

        [Category("DuctingGrids")]
        [Description("The number of columns in the sub grid")]
        public int subCols { get; set; }

        [Category("DuctingGrids")]
        [Description("The number of rows in the sub grid")]
        public int subRows { get; set; }

        [Category("DuctingGrids")]
        [Description("The number of columns in the micro grid")]
        public int microCols { get; set; }

        [Category("DuctingGrids")]
        [Description("The number of rows in the micro grid")]
        public int microRows { get; set; }

        [Category("DuctingGrids")]
        [Description("The colour of the macro grid")]
        public System.Drawing.Color macroGridDefaultColor { get; set; }

        [Category("DuctingGrids")]
        [Description("The colour of the sub grid")]
        public System.Drawing.Color subGridDefaultColor { get; set; }

        [Category("DuctingGrids")]
        [Description("The colour of the micro grid")]
        public System.Drawing.Color microGridDefaultColor { get; set; }

        [Category("DuctingGrids")]
        [Description("Display type of the micro blocks")]
        public enGrid_BlockDisplayType blockDisplayType { get; set; }

        [Category("DuctingGrids")]
        [Description("Visibility of the macro grid")]
        public bool visibleMacro { get; set; }

        [Category("DuctingGrids")]
        [Description("Visibility of the sub grid")]
        public bool visibleSub { get; set; }

        [Category("DuctingGrids")]
        [Description("Visibility of the micro grid")]
        public bool visibleMicro { get; set; }

        [Category("DuctingGrids")]
        [Description("Display names in micro blocks")]
        public bool displayName { get; set; }

        [Category("DuctingGrids")]
        [Description("Display addresses in micro blocks")]
        public bool displayAddress { get; set; }

        [Category("DuctingGrids")]
        [Description("Display values in micro blocks")]
        public bool displayValue { get; set; }

        [Category("DuctingGrids")]
        [Description("Refreshes the grid")]
        public bool RefreshGrid
        {
            get { return _refreshGrid; }
            set
            {
                _refreshGrid = value;
                if (value)
                {
                    GenerateGrids();
                }
                _refreshGrid = false;
            }
        }

        #endregion

        public void GenerateGrids()
        {
            _grids = new winForms_GridControlsSetup(_panelRow, _Settings, onGridClick);
        }

        public void Frontend_Settings()
        {
            // Get frontend values

            // =====================================
            // Sizes
            _Settings.Size_MicroHeight = gridHeight;
            _Settings.Size_MicroWidth = gridWidth;

            // Macro scope
            _Settings.Total_MacroCols = macroCols;
            _Settings.Total_MacroRows = macroRows;

            // Sub-grids scope
            _Settings.Total_SubCols = subCols;
            _Settings.Total_SubRows = subRows;

            // Micro scope
            _Settings.Total_MicroCols = microCols;
            _Settings.Total_MicroRows = microRows;

            // Visible
            _Settings.Visible_MacroGrids = visibleMacro;
            _Settings.Visible_SubGrids = visibleSub;
            _Settings.Visible_MicroGrids = visibleMicro;
            // Color
            _Settings.ColorDefault_MacroGrid = macroGridDefaultColor;
            _Settings.ColorDefault_SubGrid = subGridDefaultColor;
            _Settings.ColorDefault_MicroGrid = microGridDefaultColor;

            // Display type
            if (displayAddress) _Settings.DisplayMode_MicroGrids = enGrid_BlockDisplayType.Address;
            if (displayValue) _Settings.DisplayMode_MicroGrids = enGrid_BlockDisplayType.Value;
            if (displayName) _Settings.DisplayMode_MicroGrids = enGrid_BlockDisplayType.Name;

            _Settings.Refresh_Calculations();
        }

        public void Load_Data(string fileName)
        {
            if (_grids == null) return;

            #region Populate From File
            var gridDataSet = new DataSet();
            gridDataSet.ReadXml(fileName);
            DataTable gridData = gridDataSet.Tables[0];
            DuctingTools.ReadGridDataFromFile(_grids, gridData);
            #endregion

            // Define colors
            _Settings.Color_ID.Clear();
            _Settings.Color_ID.Add(1, System.Drawing.Color.Green);
            _Settings.Color_ID.Add(2, System.Drawing.Color.Orange);
            _Settings.Color_ID.Add(3, System.Drawing.Color.DodgerBlue);
            _Settings.Color_ID.Add(4, System.Drawing.Color.Red);
            _Settings.Color_ID.Add(5, System.Drawing.Color.Yellow);

            RefreshGrids();
        }

        public void RefreshGrids()
        {
            Frontend_Settings();
            if (_grids == null) GenerateGrids();
            GridControlTools.Syncronise(_grids.Cuboid, _Settings, true, onGridChange);
        }

        public void onGridChange(IGridControl gridcontrol, enGrid_ChangeType changetype)
        {
            // Fired when something changed.
        }

        private void onGridClick(IGridControl sender)
        {
            // Fired when mouse click on a grid
            var state = sender.GridState;
            var caption = state.Name_Caption;
            if (state._Parent != null)
            {
                caption = state._Parent.Name_Caption + " x " + caption;
                if (state._Parent._Parent != null) caption = state._Parent._Parent.Name_Caption + " x " + caption;
            }
            MessageBox.Show(caption, "Grid Feedback");
        }

        #region Hide
        #region Hide Properties Not Used
        /// <summary>
        /// Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of its visible boundaries.
        /// </summary>
        /// <returns>true if the container enables auto-scrolling; otherwise, false. The default value is false. </returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new bool AutoScroll { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [auto size].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [auto size]; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new bool AutoSize { get; set; }

        /// <summary>
        /// Gets or sets how the control will resize itself.
        /// </summary>
        /// <returns>A value from the <see cref="T:System.Windows.Forms.AutoSizeMode" /> enumeration. The default is <see cref="F:System.Windows.Forms.AutoSizeMode.GrowOnly" />.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new AutoSizeMode AutoSizeMode { get; set; }

        /// <summary>
        /// Gets or sets the border style of the user control.
        /// </summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.BorderStyle" /> values. The default is <see cref="F:System.Windows.Forms.BorderStyle.Fixed3D" />.</returns>
        ///   <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   </PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new BorderStyle BorderStyle { get; set; }

        /// <summary>
        /// Gets or sets the description of the control used by accessibility client applications.
        /// </summary>
        /// <returns>The description of the control used by accessibility client applications. The default is null.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new string AccessibleDescription { get; set; }

        /// <summary>
        /// Gets or sets the name of the control used by accessibility client applications.
        /// </summary>
        /// <returns>The name of the control used by accessibility client applications. The default is null.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new string AccessibleName { get; set; }

        /// <summary>
        /// Gets or sets the accessible role of the control
        /// </summary>
        /// <returns>One of the values of <see cref="T:System.Windows.Forms.AccessibleRole" />. The default is Default.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new AccessibleRole AccessibleRole { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the control can accept data that the user drags onto it.
        /// </summary>
        /// <returns>true if drag-and-drop operations are allowed in the control; otherwise, false. The default is false.</returns>
        ///   <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   </PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new bool AllowDrop { get; set; }

        /// <summary>
        /// Gets or sets the size of the auto-scroll margin.
        /// </summary>
        /// <returns>A <see cref="T:System.Drawing.Size" /> that represents the height and width of the auto-scroll margin in pixels.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new Size AutoScrollMargin { get; set; }

        /// <summary>
        /// Gets or sets the minimum size of the auto-scroll.
        /// </summary>
        /// <returns>A <see cref="T:System.Drawing.Size" /> that determines the minimum size of the virtual area through which the user can scroll.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new Size AutoScrollMinSize { get; set; }

        /// <summary>
        /// Gets or sets how the control performs validation when the user changes focus to another control.
        /// </summary>
        /// <returns>A member of the <see cref="T:System.Windows.Forms.AutoValidate" /> enumeration. The default value for <see cref="T:System.Windows.Forms.UserControl" /> is <see cref="F:System.Windows.Forms.AutoValidate.EnablePreventFocusChange" />.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new virtual AutoValidate AutoValidate { get; set; }

        /// <summary>
        /// Gets or sets the Input Method Editor (IME) mode of the control.
        /// </summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.ImeMode" /> values. The default is <see cref="F:System.Windows.Forms.ImeMode.Inherit" />.</returns>
        ///   <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   </PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new ImeMode ImeMode { get; set; }

        /// <summary>
        /// Gets or sets the space between controls.
        /// </summary>
        /// <returns>A <see cref="T:System.Windows.Forms.Padding" /> representing the space between controls.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new Padding Margin { get; set; }

        /// <summary>
        /// Gets or sets the size that is the upper limit that <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)" /> can specify.
        /// </summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        public new virtual Size MaximumSize { get; set; }

        /// <summary>
        /// Gets or sets the size that is the lower limit that <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)" /> can specify.
        /// </summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        public new virtual Size MinimumSize { get; set; }

        /// <summary>
        /// Gets or sets padding within the control.
        /// </summary>
        /// <returns>A <see cref="T:System.Windows.Forms.Padding" /> representing the control's internal spacing characteristics.</returns>
        ///   <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   </PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new Padding Padding { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
        /// </summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.RightToLeft" /> values. The default is <see cref="F:System.Windows.Forms.RightToLeft.Inherit" />.</returns>
        ///   <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   </PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new virtual RightToLeft RightToLeft { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use the wait cursor for the current control and all child controls.
        /// </summary>
        /// <returns>true to use the wait cursor for the current control and all child controls; otherwise, false. The default is false.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new bool UseWaitCursor { get; set; }
        #endregion

        #region Hide Main Properties
        /// <summary>
        /// Gets or sets the background image displayed in the control.
        /// </summary>
        /// <returns>An <see cref="T:System.Drawing.Image" /> that represents the image to display in the background of the control.</returns>
        ///   <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   </PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        public new virtual Image BackgroundImage { get; set; }

        /// <summary>
        /// Gets or sets the background image layout as defined in the <see cref="T:System.Windows.Forms.ImageLayout" /> enumeration.
        /// </summary>
        /// <returns>One of the values of <see cref="T:System.Windows.Forms.ImageLayout" /> (<see cref="F:System.Windows.Forms.ImageLayout.Center" /> , <see cref="F:System.Windows.Forms.ImageLayout.None" />, <see cref="F:System.Windows.Forms.ImageLayout.Stretch" />, <see cref="F:System.Windows.Forms.ImageLayout.Tile" />, or <see cref="F:System.Windows.Forms.ImageLayout.Zoom" />). <see cref="F:System.Windows.Forms.ImageLayout.Tile" /> is the default value.</returns>
        ///   <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   </PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual ImageLayout BackgroundImageLayout { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the control causes validation to be performed on any controls that require validation when it receives focus.
        /// </summary>
        /// <returns>true if the control causes validation to be performed on any controls requiring validation when it receives focus; otherwise, false. The default is true.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool CausesValidation { get; set; }

        ///// <summary>
        ///// Gets or sets the shortcut menu associated with the control.
        ///// </summary>
        ///// <returns>A <see cref="T:System.Windows.Forms.ContextMenu" /> that represents the shortcut menu associated with the control.</returns>
        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        //public new virtual ContextMenu ContextMenu { get; set; }

        /// <summary>
        /// Gets or sets the cursor that is displayed when the mouse pointer is over the control.
        /// </summary>
        /// <returns>A <see cref="T:System.Windows.Forms.Cursor" /> that represents the cursor to display when the mouse pointer is over the control.</returns>
        ///   <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   </PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new virtual Cursor Cursor { get; set; }

        ///// <summary>
        ///// Gets or sets the foreground color of the control.
        ///// </summary>
        ///// <returns>The foreground <see cref="T:System.Drawing.Color" /> of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultForeColor" /> property.</returns>
        /////   <PermissionSet>
        /////   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /////   </PermissionSet>
        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        ////[Obsolete("just cast me to avoid all this hiding...", true)]
        //public new virtual Color ForeColor { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:System.Windows.Forms.ContextMenuStrip" /> associated with this control.
        /// </summary>
        /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip" /> for this control, or null if there is no <see cref="T:System.Windows.Forms.ContextMenuStrip" />. The default is null.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new virtual ContextMenuStrip ContextMenuStrip { get; set; }

        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]        
        //public new ControlBindingsCollection DataBindings { get; set; }

        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]        
        //public new virtual Color BackColor { get; set; }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <returns>The <see cref="T:System.Drawing.Font" /> to apply to the text displayed by the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultFont" /> property.</returns>
        ///   <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   </PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new virtual Font Font { get; set; }

        #endregion

        #region Hide Events
#pragma warning disable 67
        // ChangeUICues
        /// <summary>
        /// Occurs when [change UI cues].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event UICuesEventHandler ChangeUICues;

        // ControlAdded
        /// <summary>
        /// Occurs when [control added].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event ControlEventHandler ControlAdded;

        // ControlRemoved
        /// <summary>
        /// Occurs when [control removed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event ControlEventHandler ControlRemoved;

        // HelpRequested
        /// <summary>
        /// Occurs when [help requested].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event HelpEventHandler HelpRequested;

        // QueryAccessibilityHelp
        /// <summary>
        /// Occurs when [query accessibility help].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event QueryAccessibilityHelpEventHandler QueryAccessibilityHelp;

        // StyleChanged
        /// <summary>
        /// Occurs when [style changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler StyleChanged;

        // SystemColorsChanged
        /// <summary>
        /// Occurs when [system colors changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler SystemColorsChanged;

        #region DragEvents
        //DragDrop
        /// <summary>
        /// Occurs when [drag drop].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event DragEventHandler DragDrop;

        // DragEnter
        /// <summary>
        /// Occurs when [drag enter].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event DragEventHandler DragEnter;

        // DragLeave
        /// <summary>
        /// Occurs when [drag leave].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler DragLeave;

        //DragOver
        /// <summary>
        /// Occurs when [drag over].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event DragEventHandler DragOver;

        //GiveFeedback
        /// <summary>
        /// Occurs when [give feedback].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event GiveFeedbackEventHandler GiveFeedback;

        //QueryContinueDrag
        /// <summary>
        /// Occurs when [query continue drag].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event QueryContinueDragEventHandler QueryContinueDrag;

        #endregion

        #region FocusEvents
        //Leave
        /// <summary>
        /// Occurs when [leave].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler Leave;

        //Validating
        //    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //    [Obsolete("just cast me to avoid all this hiding...", true)]
        //    public new event CancelEventHandler Validating;

        #endregion

        #region KeyEvents
        //    //KeyDown
        //    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //    [Obsolete("just cast me to avoid all this hiding...", true)]
        //    public new event KeyEventHandler KeyDown;

        //    //KeyUp
        //    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //    [Obsolete("just cast me to avoid all this hiding...", true)]
        //    public new event KeyEventHandler KeyUp;

        //    //PrewiewKeyDown
        //    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //    [Obsolete("just cast me to avoid all this hiding...", true)]
        //    public new event PreviewKeyDownEventHandler PreviewKeyDown;

        #endregion

        #region Layout
        //Layout
        /// <summary>
        /// Occurs when [layout].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event LayoutEventHandler Layout;

        //MarginChanged
        /// <summary>
        /// Occurs when [margin changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler MarginChanged;

        //Move
        /// <summary>
        /// Occurs when [move].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler Move;

        //PaddingChanged
        /// <summary>
        /// Occurs when [padding changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler PaddingChanged;

        //Resize
        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        //public new event EventHandler Resize;

        # endregion

        #region Mouse
        //MouseDown
        /// <summary>
        /// Occurs when [mouse down].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event MouseEventHandler MouseDown;

        //MouseUp
        /// <summary>
        /// Occurs when [mouse up].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event MouseEventHandler MouseUp;

        //MouseHover
        /// <summary>
        /// Occurs when [mouse hover].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler MouseHover;

        //MouseEnter
        /// <summary>
        /// Occurs when [mouse enter].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler MouseEnter;

        //MouseLeave
        /// <summary>
        /// Occurs when [mouse leave].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler MouseLeave;

        #endregion

        #region onPropertyChanged
        //AutoSizeChanged
        /// <summary>
        /// Occurs when [auto size changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler AutoSizeChanged;

        //   //AutoValidateChanged
        //   [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //   [Obsolete("just cast me to avoid all this hiding...", true)] 



        //BackColourChanged
        /// <summary>
        /// Occurs when [back color changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler BackColorChanged;

        //BackgroundImageChange
        /// <summary>
        /// Occurs when [background image changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler BackgroundImageChanged;

        //BackgroundImageLayoutChanged
        /// <summary>
        /// Occurs when [background image layout changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler BackgroundImageLayoutChanged;

        //BindingContextChanged
        /// <summary>
        /// Occurs when [binding context changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler BindingContextChanged;

        //CausesValidationChanged
        /// <summary>
        /// Occurs when [causes validation changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler CausesValidationChanged;

        //ClientSizeChanged
        /// <summary>
        /// Occurs when [client size changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler ClientSizeChanged;

        //ContextMenueStripChanged
        /// <summary>
        /// Occurs when [context menu strip changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler ContextMenuStripChanged;

        //CursorChanged
        /// <summary>
        /// Occurs when [cursor changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler CursorChanged;

        ////DockChanged
        ///// <summary>
        ///// Occurs when [dock changed].
        ///// </summary>
        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        //public new event EventHandler DockChanged;

        //EnabledChanged
        /// <summary>
        /// Occurs when [enabled changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler EnabledChanged;

        //FontChanged
        /// <summary>
        /// Occurs when [font changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler FontChanged;

        //ForeColourChanged
        /// <summary>
        /// Occurs when [fore color changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler ForeColorChanged;

        //LocationChanged
        /// <summary>
        /// Occurs when [location changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler LocationChanged;

        ////ParentChanged
        ///// <summary>
        ///// Occurs when [parent changed].
        ///// </summary>
        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        //public new event EventHandler ParentChanged;

        //RegionChanged
        /// <summary>
        /// Occurs when [region changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler RegionChanged;

        //RighttoLeftChanged
        /// <summary>
        /// Occurs when [right to left changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler RightToLeftChanged;

        //SizeChanged
        /// <summary>
        /// Occurs when [size changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler SizeChanged;

        //TabIndexChanged
        /// <summary>
        /// Occurs when [tab index changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler TabIndexChanged;

        //TabStopChanged
        /// <summary>
        /// Occurs when [tab stop changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler TabStopChanged;

        #endregion


#pragma warning restore 67
        #endregion
        #endregion
    }
}
