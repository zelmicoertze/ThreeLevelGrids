namespace DuctingGrids.Frontend.Forms
{
    partial class DuctingControlDebug
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ductingControlButton1 = new DuctingGrids.Frontend.GridControl.DuctingControlButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(14, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 367);
            this.panel1.TabIndex = 1;
            // 
            // ductingControlButton1
            // 
            this.ductingControlButton1.Color1 = System.Drawing.Color.Red;
            this.ductingControlButton1.Color1Transparent = 100;
            this.ductingControlButton1.Color2 = System.Drawing.Color.Green;
            this.ductingControlButton1.Color2Transparent = 100;
            this.ductingControlButton1.Location = new System.Drawing.Point(396, 32);
            this.ductingControlButton1.Name = "ductingControlButton1";
            this.ductingControlButton1.Size = new System.Drawing.Size(75, 23);
            this.ductingControlButton1.TabIndex = 2;
            this.ductingControlButton1.Text = "ductingControlButton1";
            this.ductingControlButton1.UseVisualStyleBackColor = true;
            // 
            // DuctingControlDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 449);
            this.Controls.Add(this.ductingControlButton1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "DuctingControlDebug";
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private GridControl.DuctingControlButton ductingControlButton1;
    }
}