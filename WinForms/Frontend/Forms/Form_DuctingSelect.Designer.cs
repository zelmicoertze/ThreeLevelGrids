using System.ComponentModel;
using System.Windows.Forms;

namespace DuctingGrids.Frontend.Forms
{
    partial class Form_DuctingSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textMacroRows = new System.Windows.Forms.TextBox();
            this.textMacroCols = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textSubRows = new System.Windows.Forms.TextBox();
            this.textSubCols = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textMicroRows = new System.Windows.Forms.TextBox();
            this.textMicroCols = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkMicro = new System.Windows.Forms.CheckBox();
            this.checkSub = new System.Windows.Forms.CheckBox();
            this.checkMacro = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radioSelect = new System.Windows.Forms.RadioButton();
            this.radioClick = new System.Windows.Forms.RadioButton();
            this.radioReadOnly = new System.Windows.Forms.RadioButton();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.labelColorMicro = new System.Windows.Forms.Label();
            this.labelColorSub = new System.Windows.Forms.Label();
            this.labelColorMacro = new System.Windows.Forms.Label();
            this.button_LoadData = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.radioName = new System.Windows.Forms.RadioButton();
            this.radioValue = new System.Windows.Forms.RadioButton();
            this.radioAddress = new System.Windows.Forms.RadioButton();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.textHeight = new System.Windows.Forms.TextBox();
            this.textWidth = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.textGridRows = new System.Windows.Forms.TextBox();
            this.textGridCols = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button_Add = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.AllowDrop = true;
            this.buttonGenerate.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonGenerate.Location = new System.Drawing.Point(467, 22);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerate.TabIndex = 14;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textMacroRows);
            this.groupBox5.Controls.Add(this.textMacroCols);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(113, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(116, 66);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Macro";
            // 
            // textMacroRows
            // 
            this.textMacroRows.Location = new System.Drawing.Point(57, 38);
            this.textMacroRows.Name = "textMacroRows";
            this.textMacroRows.Size = new System.Drawing.Size(53, 20);
            this.textMacroRows.TabIndex = 9;
            this.textMacroRows.Text = "3";
            // 
            // textMacroCols
            // 
            this.textMacroCols.Location = new System.Drawing.Point(57, 13);
            this.textMacroCols.Name = "textMacroCols";
            this.textMacroCols.Size = new System.Drawing.Size(53, 20);
            this.textMacroCols.TabIndex = 8;
            this.textMacroCols.Text = "3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Rows";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Cols";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textSubRows);
            this.groupBox2.Controls.Add(this.textSubCols);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(229, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(116, 66);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sub";
            this.groupBox2.Visible = false;
            // 
            // textSubRows
            // 
            this.textSubRows.Location = new System.Drawing.Point(57, 38);
            this.textSubRows.Name = "textSubRows";
            this.textSubRows.Size = new System.Drawing.Size(53, 20);
            this.textSubRows.TabIndex = 9;
            this.textSubRows.Text = "0";
            // 
            // textSubCols
            // 
            this.textSubCols.Location = new System.Drawing.Point(57, 16);
            this.textSubCols.Name = "textSubCols";
            this.textSubCols.Size = new System.Drawing.Size(53, 20);
            this.textSubCols.TabIndex = 8;
            this.textSubCols.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rows";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cols";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textMicroRows);
            this.groupBox1.Controls.Add(this.textMicroCols);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(345, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(116, 66);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Micro";
            this.groupBox1.Visible = false;
            // 
            // textMicroRows
            // 
            this.textMicroRows.Location = new System.Drawing.Point(57, 38);
            this.textMicroRows.Name = "textMicroRows";
            this.textMicroRows.Size = new System.Drawing.Size(53, 20);
            this.textMicroRows.TabIndex = 9;
            this.textMicroRows.Text = "0";
            // 
            // textMicroCols
            // 
            this.textMicroCols.Location = new System.Drawing.Point(57, 13);
            this.textMicroCols.Name = "textMicroCols";
            this.textMicroCols.Size = new System.Drawing.Size(53, 20);
            this.textMicroCols.TabIndex = 8;
            this.textMicroCols.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Rows";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cols";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkMicro);
            this.groupBox3.Controls.Add(this.checkSub);
            this.groupBox3.Controls.Add(this.checkMacro);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(1053, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(92, 66);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Visible";
            // 
            // checkMicro
            // 
            this.checkMicro.AutoSize = true;
            this.checkMicro.Checked = true;
            this.checkMicro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkMicro.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkMicro.Location = new System.Drawing.Point(3, 50);
            this.checkMicro.Name = "checkMicro";
            this.checkMicro.Size = new System.Drawing.Size(86, 17);
            this.checkMicro.TabIndex = 2;
            this.checkMicro.Text = "Micro Grids";
            this.checkMicro.UseVisualStyleBackColor = true;
            this.checkMicro.Click += new System.EventHandler(this.radioName_Click);
            // 
            // checkSub
            // 
            this.checkSub.AutoSize = true;
            this.checkSub.Checked = true;
            this.checkSub.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkSub.Location = new System.Drawing.Point(3, 33);
            this.checkSub.Name = "checkSub";
            this.checkSub.Size = new System.Drawing.Size(86, 17);
            this.checkSub.TabIndex = 1;
            this.checkSub.Text = "Sub Grids";
            this.checkSub.UseVisualStyleBackColor = true;
            this.checkSub.Click += new System.EventHandler(this.radioName_Click);
            // 
            // checkMacro
            // 
            this.checkMacro.AutoSize = true;
            this.checkMacro.Checked = true;
            this.checkMacro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkMacro.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkMacro.Location = new System.Drawing.Point(3, 16);
            this.checkMacro.Name = "checkMacro";
            this.checkMacro.Size = new System.Drawing.Size(86, 17);
            this.checkMacro.TabIndex = 0;
            this.checkMacro.Text = "Macro Grids";
            this.checkMacro.UseVisualStyleBackColor = true;
            this.checkMacro.Click += new System.EventHandler(this.radioName_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox11);
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.buttonRefresh);
            this.groupBox4.Controls.Add(this.groupBox10);
            this.groupBox4.Controls.Add(this.button_LoadData);
            this.groupBox4.Controls.Add(this.groupBox8);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.buttonGenerate);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.groupBox9);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1148, 85);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Toolbar";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.radioSelect);
            this.groupBox7.Controls.Add(this.radioClick);
            this.groupBox7.Controls.Add(this.radioReadOnly);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox7.Location = new System.Drawing.Point(772, 16);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(92, 66);
            this.groupBox7.TabIndex = 18;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "DisplayMode";
            this.groupBox7.Visible = false;
            // 
            // radioSelect
            // 
            this.radioSelect.AutoSize = true;
            this.radioSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioSelect.Location = new System.Drawing.Point(3, 50);
            this.radioSelect.Name = "radioSelect";
            this.radioSelect.Size = new System.Drawing.Size(86, 17);
            this.radioSelect.TabIndex = 4;
            this.radioSelect.Text = "Select";
            this.radioSelect.UseVisualStyleBackColor = true;
            // 
            // radioClick
            // 
            this.radioClick.AutoSize = true;
            this.radioClick.Checked = true;
            this.radioClick.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioClick.Location = new System.Drawing.Point(3, 33);
            this.radioClick.Name = "radioClick";
            this.radioClick.Size = new System.Drawing.Size(86, 17);
            this.radioClick.TabIndex = 3;
            this.radioClick.TabStop = true;
            this.radioClick.Text = "Click";
            this.radioClick.UseVisualStyleBackColor = true;
            // 
            // radioReadOnly
            // 
            this.radioReadOnly.AutoSize = true;
            this.radioReadOnly.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioReadOnly.Location = new System.Drawing.Point(3, 16);
            this.radioReadOnly.Name = "radioReadOnly";
            this.radioReadOnly.Size = new System.Drawing.Size(86, 17);
            this.radioReadOnly.TabIndex = 2;
            this.radioReadOnly.Text = "Read only";
            this.radioReadOnly.UseVisualStyleBackColor = true;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(548, 23);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 49);
            this.buttonRefresh.TabIndex = 24;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.labelColorMicro);
            this.groupBox10.Controls.Add(this.labelColorSub);
            this.groupBox10.Controls.Add(this.labelColorMacro);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox10.Location = new System.Drawing.Point(864, 16);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(97, 66);
            this.groupBox10.TabIndex = 23;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Color";
            // 
            // labelColorMicro
            // 
            this.labelColorMicro.BackColor = System.Drawing.Color.Silver;
            this.labelColorMicro.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelColorMicro.Location = new System.Drawing.Point(3, 42);
            this.labelColorMicro.Name = "labelColorMicro";
            this.labelColorMicro.Size = new System.Drawing.Size(91, 23);
            this.labelColorMicro.TabIndex = 2;
            this.labelColorMicro.Text = "Micro Grid";
            this.labelColorMicro.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelColorMicro.Click += new System.EventHandler(this.labelColor_Click);
            // 
            // labelColorSub
            // 
            this.labelColorSub.BackColor = System.Drawing.Color.Silver;
            this.labelColorSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelColorSub.Location = new System.Drawing.Point(3, 29);
            this.labelColorSub.Name = "labelColorSub";
            this.labelColorSub.Size = new System.Drawing.Size(91, 13);
            this.labelColorSub.TabIndex = 1;
            this.labelColorSub.Text = "Sub Grid";
            this.labelColorSub.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelColorSub.Click += new System.EventHandler(this.labelColor_Click);
            // 
            // labelColorMacro
            // 
            this.labelColorMacro.BackColor = System.Drawing.Color.Silver;
            this.labelColorMacro.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelColorMacro.Location = new System.Drawing.Point(3, 16);
            this.labelColorMacro.Name = "labelColorMacro";
            this.labelColorMacro.Size = new System.Drawing.Size(91, 13);
            this.labelColorMacro.TabIndex = 0;
            this.labelColorMacro.Text = "Macro Grid";
            this.labelColorMacro.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelColorMacro.Click += new System.EventHandler(this.labelColor_Click);
            // 
            // button_LoadData
            // 
            this.button_LoadData.Location = new System.Drawing.Point(467, 49);
            this.button_LoadData.Name = "button_LoadData";
            this.button_LoadData.Size = new System.Drawing.Size(75, 23);
            this.button_LoadData.TabIndex = 20;
            this.button_LoadData.Text = "Load data";
            this.button_LoadData.UseVisualStyleBackColor = true;
            this.button_LoadData.Click += new System.EventHandler(this.button_LoadData_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.radioName);
            this.groupBox8.Controls.Add(this.radioValue);
            this.groupBox8.Controls.Add(this.radioAddress);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox8.Location = new System.Drawing.Point(961, 16);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(92, 66);
            this.groupBox8.TabIndex = 19;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Display";
            // 
            // radioName
            // 
            this.radioName.AutoSize = true;
            this.radioName.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioName.Location = new System.Drawing.Point(3, 50);
            this.radioName.Name = "radioName";
            this.radioName.Size = new System.Drawing.Size(86, 17);
            this.radioName.TabIndex = 5;
            this.radioName.Text = "Name";
            this.radioName.UseVisualStyleBackColor = true;
            this.radioName.Click += new System.EventHandler(this.radioName_Click);
            // 
            // radioValue
            // 
            this.radioValue.AutoSize = true;
            this.radioValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioValue.Location = new System.Drawing.Point(3, 33);
            this.radioValue.Name = "radioValue";
            this.radioValue.Size = new System.Drawing.Size(86, 17);
            this.radioValue.TabIndex = 4;
            this.radioValue.Text = "Value";
            this.radioValue.UseVisualStyleBackColor = true;
            this.radioValue.Click += new System.EventHandler(this.radioName_Click);
            // 
            // radioAddress
            // 
            this.radioAddress.AutoSize = true;
            this.radioAddress.Checked = true;
            this.radioAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioAddress.Location = new System.Drawing.Point(3, 16);
            this.radioAddress.Name = "radioAddress";
            this.radioAddress.Size = new System.Drawing.Size(86, 17);
            this.radioAddress.TabIndex = 3;
            this.radioAddress.TabStop = true;
            this.radioAddress.Text = "Address";
            this.radioAddress.UseVisualStyleBackColor = true;
            this.radioAddress.Click += new System.EventHandler(this.radioName_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.textHeight);
            this.groupBox9.Controls.Add(this.textWidth);
            this.groupBox9.Controls.Add(this.label8);
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox9.Location = new System.Drawing.Point(3, 16);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(110, 66);
            this.groupBox9.TabIndex = 22;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Size";
            // 
            // textHeight
            // 
            this.textHeight.Location = new System.Drawing.Point(52, 40);
            this.textHeight.Name = "textHeight";
            this.textHeight.Size = new System.Drawing.Size(52, 20);
            this.textHeight.TabIndex = 3;
            this.textHeight.Text = "25";
            // 
            // textWidth
            // 
            this.textWidth.Location = new System.Drawing.Point(52, 20);
            this.textWidth.Name = "textWidth";
            this.textWidth.Size = new System.Drawing.Size(52, 20);
            this.textWidth.TabIndex = 2;
            this.textWidth.Text = "32";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Height";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Width";
            // 
            // groupBox6
            // 
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 85);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1148, 694);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.button_Add);
            this.groupBox11.Controls.Add(this.textGridRows);
            this.groupBox11.Controls.Add(this.textGridCols);
            this.groupBox11.Controls.Add(this.label9);
            this.groupBox11.Controls.Add(this.label10);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox11.Location = new System.Drawing.Point(629, 16);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(143, 66);
            this.groupBox11.TabIndex = 25;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Add Grids";
            this.groupBox11.Visible = false;
            // 
            // textGridRows
            // 
            this.textGridRows.Location = new System.Drawing.Point(57, 38);
            this.textGridRows.Name = "textGridRows";
            this.textGridRows.Size = new System.Drawing.Size(39, 20);
            this.textGridRows.TabIndex = 9;
            this.textGridRows.Text = "1";
            // 
            // textGridCols
            // 
            this.textGridCols.Location = new System.Drawing.Point(57, 13);
            this.textGridCols.Name = "textGridCols";
            this.textGridCols.Size = new System.Drawing.Size(39, 20);
            this.textGridCols.TabIndex = 8;
            this.textGridCols.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Rows";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Cols";
            // 
            // button_Add
            // 
            this.button_Add.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_Add.Location = new System.Drawing.Point(102, 16);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(38, 47);
            this.button_Add.TabIndex = 10;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // Form_DuctingSelect
            // 
            this.ClientSize = new System.Drawing.Size(1148, 779);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.DoubleBuffered = true;
            this.Name = "Form_DuctingSelect";
            this.Text = "Form2";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonGenerate;
        private GroupBox groupBox5;
        private TextBox textMacroRows;
        private TextBox textMacroCols;
        private Label label5;
        private Label label6;
        private GroupBox groupBox2;
        private TextBox textSubRows;
        private TextBox textSubCols;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private TextBox textMicroRows;
        private TextBox textMicroCols;
        private Label label2;
        private Label label1;
        private GroupBox groupBox3;
        private CheckBox checkMicro;
        private CheckBox checkSub;
        private CheckBox checkMacro;
        private GroupBox groupBox4;
        private GroupBox groupBox6;
        private GroupBox groupBox8;
        private RadioButton radioName;
        private RadioButton radioValue;
        private RadioButton radioAddress;
        private GroupBox groupBox7;
        private RadioButton radioSelect;
        private RadioButton radioClick;
        private RadioButton radioReadOnly;
        private Button button_LoadData;
        private GroupBox groupBox9;
        private TextBox textHeight;
        private TextBox textWidth;
        private Label label8;
        private Label label7;
        private GroupBox groupBox10;
        private Label labelColorMicro;
        private Label labelColorSub;
        private Label labelColorMacro;
        private ColorDialog colorDialog1;
        private Button buttonRefresh;
        private GroupBox groupBox11;
        private Button button_Add;
        private TextBox textGridRows;
        private TextBox textGridCols;
        private Label label9;
        private Label label10;
    }
}