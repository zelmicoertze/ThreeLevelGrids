using DuctingGrids.Frontend.GridControl;

namespace DuctingGrids.Frontend.Forms
{
    sealed partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.labelColorMicro = new System.Windows.Forms.Label();
            this.labelColorSub = new System.Windows.Forms.Label();
            this.labelColorMacro = new System.Windows.Forms.Label();
            this.button_LoadData = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.radioName = new System.Windows.Forms.RadioButton();
            this.radioValue = new System.Windows.Forms.RadioButton();
            this.radioAddress = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radioSelect = new System.Windows.Forms.RadioButton();
            this.radioClick = new System.Windows.Forms.RadioButton();
            this.radioReadOnly = new System.Windows.Forms.RadioButton();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.textHeight = new System.Windows.Forms.TextBox();
            this.textWidth = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.R1 = new DuctingGrids.Frontend.GridControl.GridControl_Row();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.textMacroRows.Text = "2";
            // 
            // textMacroCols
            // 
            this.textMacroCols.Location = new System.Drawing.Point(57, 13);
            this.textMacroCols.Name = "textMacroCols";
            this.textMacroCols.Size = new System.Drawing.Size(53, 20);
            this.textMacroCols.TabIndex = 8;
            this.textMacroCols.Text = "2";
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
            // 
            // textSubRows
            // 
            this.textSubRows.Location = new System.Drawing.Point(57, 38);
            this.textSubRows.Name = "textSubRows";
            this.textSubRows.Size = new System.Drawing.Size(53, 20);
            this.textSubRows.TabIndex = 9;
            this.textSubRows.Text = "2";
            // 
            // textSubCols
            // 
            this.textSubCols.Location = new System.Drawing.Point(57, 16);
            this.textSubCols.Name = "textSubCols";
            this.textSubCols.Size = new System.Drawing.Size(53, 20);
            this.textSubCols.TabIndex = 8;
            this.textSubCols.Text = "3";
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
            // 
            // textMicroRows
            // 
            this.textMicroRows.Location = new System.Drawing.Point(57, 38);
            this.textMicroRows.Name = "textMicroRows";
            this.textMicroRows.Size = new System.Drawing.Size(53, 20);
            this.textMicroRows.TabIndex = 9;
            this.textMicroRows.Text = "5";
            // 
            // textMicroCols
            // 
            this.textMicroCols.Location = new System.Drawing.Point(57, 13);
            this.textMicroCols.Name = "textMicroCols";
            this.textMicroCols.Size = new System.Drawing.Size(53, 20);
            this.textMicroCols.TabIndex = 8;
            this.textMicroCols.Text = "5";
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
            this.groupBox6.Controls.Add(this.R1);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 85);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1148, 694);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(548, 20);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 49);
            this.buttonRefresh.TabIndex = 24;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // R1
            // 
            this.R1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.R1.Dock = System.Windows.Forms.DockStyle.Top;
            this.R1.GridState = null;
            this.R1.Location = new System.Drawing.Point(3, 16);
            this.R1.Name = "R1";
            this.R1.Size = new System.Drawing.Size(1142, 468);
            this.R1.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 779);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.DoubleBuffered = true;
            this.Name = "Form2";
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
            this.groupBox10.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textMacroRows;
        private System.Windows.Forms.TextBox textMacroCols;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textSubRows;
        private System.Windows.Forms.TextBox textSubCols;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textMicroRows;
        private System.Windows.Forms.TextBox textMicroCols;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkMicro;
        private System.Windows.Forms.CheckBox checkSub;
        private System.Windows.Forms.CheckBox checkMacro;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private GridControl_Row R1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton radioName;
        private System.Windows.Forms.RadioButton radioValue;
        private System.Windows.Forms.RadioButton radioAddress;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton radioSelect;
        private System.Windows.Forms.RadioButton radioClick;
        private System.Windows.Forms.RadioButton radioReadOnly;
        private System.Windows.Forms.Button button_LoadData;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox textHeight;
        private System.Windows.Forms.TextBox textWidth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label labelColorMicro;
        private System.Windows.Forms.Label labelColorSub;
        private System.Windows.Forms.Label labelColorMacro;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonRefresh;
    }
}