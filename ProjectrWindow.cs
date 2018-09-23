using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projectr.Projections;

namespace Projectr
{
    public partial class ProjectrWindow : Form
    {
        public ProjectrWindow()
        {
            InitializeComponent();

            this.Projection = new Orthographic();

            this.orthographicToolStripMenuItem.Click += orthographicToolStripMenuItem_Click;

            this.a2PaperButton.CheckedChanged += a2PaperButton_CheckedChanged;
            this.a3PaperButton.CheckedChanged += a3PaperButton_CheckedChanged;
            this.a4PaperButton.CheckedChanged += a4PaperButton_CheckedChanged;
            this.customPaperButton.CheckedChanged += customPaperButton_CheckedChanged;

            this.radioButton0_5.CheckedChanged += radioButton0_5_CheckedChanged;
            this.radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            this.radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            this.radioButton5.CheckedChanged += radioButton5_CheckedChanged;
            this.radioButton10.CheckedChanged += radioButton10_CheckedChanged;

            this.projectButton.Click += projectButton_Click;
        }

        [Bindable(true)]
        public PaperSize PaperSize { get; set; }

        [Bindable(true)]
        public IProjection Projection { get; set; }

        [Bindable(true)]
        public double Interval { get; set; }

        private void orthographicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Projection = new Orthographic();
        }

        private void a2PaperButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.a4PaperButton.Checked)
            {
                this.PaperSize = PaperSize.A2;
            }
        }

        private void a3PaperButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.a4PaperButton.Checked)
            {
                this.PaperSize = PaperSize.A3;
            }
        }

        private void a4PaperButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.a4PaperButton.Checked)
            {
                this.PaperSize = PaperSize.A4;
            }
        }

        private void customPaperButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.customPaperButton.Checked)
            {
                this.PaperSize = PaperSize.Custom;
                customPaperSizeNumericTextBox1.Enabled = true;
                customPaperSizeNumericTextBox2.Enabled = true;
            }
            else
            {
                customPaperSizeNumericTextBox1.Enabled = false;
                customPaperSizeNumericTextBox2.Enabled = false;
            }
        }

        private void radioButton0_5_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton0_5.Checked)
            {
                this.Interval = 0.5;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                this.Interval = 1;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
            {
                this.Interval = 2;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton5.Checked)
            {
                this.Interval = 5;
            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton10.Checked)
            {
                this.Interval = 10;
            }
        }

        private void projectButton_Click(object sender, EventArgs e)
        {
            this.dataSource.Calculate();
        }
    }
}
