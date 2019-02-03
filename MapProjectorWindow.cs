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

            this.orthographicToolStripMenuItem.Click += projectionToolStripMenuItem_Click;
            this.equirectangularToolStripMenuItem.Click += projectionToolStripMenuItem_Click;
            this.projectButton.Click += projectButton_Click;

            SetProjection(new Equirectangular());
            this.equirectangularToolStripMenuItem.Checked = true;
        }

        private void projectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            foreach(ToolStripMenuItem ddi in this.chooseProjectionToolStripMenuItem.DropDownItems)
            {
                if (ddi.Equals(item))
                {
                    ddi.Checked = true;
                }
                else
                {
                    ddi.Checked = false;
                }
            }

            if (item != null && item.Tag is IProjection projection)
            {
                SetProjection(projection);
            }
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
