using System;
using System.Windows.Forms;
using MapProjector.Projections;

namespace MapProjector
{
    public partial class MapProjectorWindow : Form
    {
        public MapProjectorWindow()
        {
            InitializeComponent();

            this.intervalGroupBox.DataBindings.Add(new Binding("Selected", this.dataSource, "Interval", true, DataSourceUpdateMode.OnPropertyChanged));
            this.paperGroupBox.DataBindings.Add(new Binding("Selected", this.dataSource, "PaperSize", true, DataSourceUpdateMode.OnPropertyChanged));

            this.orthographicToolStripMenuItem.Click += orthographicToolStripMenuItem_Click;
            this.equirectangularToolStripMenuItem.Click += equirectangularToolStripMenuItem_Click;
            this.projectButton.Click += projectButton_Click;

            SetProjection(new Equirectangular());
            this.equirectangularToolStripMenuItem.Checked = true;
        }

        private void orthographicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.equirectangularToolStripMenuItem.Checked = false;
            this.orthographicToolStripMenuItem.Checked = true;
            SetProjection(new Orthographic());
        }

        private void equirectangularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.equirectangularToolStripMenuItem.Checked = true;
            this.orthographicToolStripMenuItem.Checked = false;
            SetProjection(new Equirectangular());
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
