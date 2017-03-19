using System;
using System.Drawing;
using System.Windows.Forms;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace DuctingGrids.Frontend.Forms
{
    [Test_IgnoreCoverage(enTestIgnore.FrontendCode)]
    public sealed partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void b11_Click(object sender, EventArgs e)
        {
            Color_Set((Button)sender);
        }

        private void Color_Set(object sender)
        {
            var button = sender as Button;
            if (button != null)
            {
                Color newColor;
                if (button.BackColor == Color.Green) newColor = Color.Red;
                else if (button.BackColor == Color.White) newColor = Color.Green;
                else newColor = Color.White;

                button.BackColor = newColor;
            }
            else
            {
                var group = sender as GroupBox;
                if (group != null)
                {
                    Color newColor;
                    if (group.BackColor == Color.Green) newColor = Color.Red;
                    else if (group.BackColor == Color.White) newColor = Color.Green;
                    else newColor = Color.White;

                    group.BackColor = newColor;
                }
            }

        }

        private void b12_Click(object sender, EventArgs e)
        {
            Color_Set(sender);

        }

        private void b13_Click(object sender, EventArgs e)
        {
            Color_Set(sender);
        }

        private void groupBox_Click(object sender, System.EventArgs e)
        {
            Color_Set(sender);

        }
    }
}
