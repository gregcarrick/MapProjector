using System;
using System.IO;
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

            this.saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            this.orthographicToolStripMenuItem.Click += projectionToolStripMenuItem_Click;
            this.plateCarreeToolStripMenuItem.Click += projectionToolStripMenuItem_Click;
            this.projectButton.Click += projectButton_Click;

            SetProjection(new Equirectangular());
            this.plateCarreeToolStripMenuItem.Checked = true;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text fies|*.txt";
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(dialog.FileName))
                {
                    string projFullName = this.dataSource.Projection.Description;
                    string[] names = projFullName.Split('.');
                    string projShortName = names[names.Length - 1];
                    sw.WriteLine("Projection: {0}", projShortName);
                    sw.WriteLine(
                        "Range: {0}{1} to {2}{3} lat, {4}{5} to {6}{7} lon",
                        Math.Abs(this.dataSource.North), (this.dataSource.North >= 0 ? "N" : "S"),
                        Math.Abs(this.dataSource.South), (this.dataSource.South >= 0 ? "N" : "S"),
                        Math.Abs(this.dataSource.West), (this.dataSource.West >= 0 ? "W" : "E"),
                        Math.Abs(this.dataSource.East), (this.dataSource.East >= 0 ? "W" : "E")
                        );
                    sw.WriteLine(this.dataSource.GetPaperDimensionsText());
                    sw.WriteLine();
                    sw.Write(this.dataSource.CartCoordsOutput);
                }
            }
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
