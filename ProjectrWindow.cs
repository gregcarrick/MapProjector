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

            this.intervalGroupBox.DataBindings.Add(new Binding("Selected", this.dataSource, "Interval", true, DataSourceUpdateMode.OnPropertyChanged));
            this.paperGroupBox.DataBindings.Add(new Binding("Selected", this.dataSource, "PaperSize", true, DataSourceUpdateMode.OnPropertyChanged));

            this.orthographicToolStripMenuItem.Click += orthographicToolStripMenuItem_Click;
            this.projectButton.Click += projectButton_Click;

            SetProjection(new Orthographic());
        }

        private void orthographicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetProjection(new Orthographic());
        }

        private void projectButton_Click(object sender, EventArgs e)
        {
            this.dataSource.Calculate();
        }

        private void SetProjection(IProjection projection)
        {
            if (this.dataSource != null)
            {
                this.dataSource.Projection = projection;
            }
        }
    }
}
