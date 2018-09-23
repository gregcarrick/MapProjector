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
using System.Globalization;

namespace Projectr
{
    public partial class ProjectrWindow : Form
    {
        private IProjection projection;

        public ProjectrWindow()
        {
            InitializeComponent();

            this.orthographicToolStripMenuItem.Click += orthographicToolStripMenuItem_Click;
            this.customPaperButton.CheckedChanged += customPaperButton_CheckedChanged;
        }

        private void customPaperButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.customPaperButton.Checked)
            {
                customPaperSizeNumericTextBox1.Enabled = true;
                customPaperSizeNumericTextBox2.Enabled = true;
            }
            else
            {
                customPaperSizeNumericTextBox1.Enabled = false;
                customPaperSizeNumericTextBox1.Text = null;
                customPaperSizeNumericTextBox2.Enabled = false;
            }
        }

        private void orthographicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.projection = new Orthographic();
        }
    }
}
