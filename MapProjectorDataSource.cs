using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using MapProjector.Projections;

namespace MapProjector
{
    /// <summary>
    /// Allows the user to choose from pre-set paper sizes or set custom side lengths.
    /// </summary>
    public enum PaperSize
    {
        /// <summary>
        /// Standard size A2.
        /// </summary>
        A2,

        /// <summary>
        /// Standard size A3.
        /// </summary>
        A3,

        /// <summary>
        /// Standard size A4.
        /// </summary>
        A4,

        /// <summary>
        /// Custom width and length.
        /// </summary>
        Custom,
    }

    /// <summary>
    /// Paper orientation: Landscape or Portrait.
    /// </summary>
    public enum Orientation
    {
        /// <summary>
        /// Landscape.
        /// </summary>
        Landscape,

        /// <summary>
        /// Portrait.
        /// </summary>
        Portrait,
    }

    /// <summary>
    /// The data source bound to the <see cref="MapProjectorWindow"/>.
    /// </summary>
    public class MapProjectorDataSource : Component, INotifyPropertyChanged
    {
        private double north;
        private double south;
        private double east;
        private double west;
        private double interval;
        private PaperSize paperSize;
        private Orientation orientation;
        private int customPaperSizeDim1;
        private int customPaperSizeDim2;
        private Point[,] geoCoords;
        Dictionary<double, List<Point>> cartCoords;
        private int cols;
        private int rows;
        private string cartCoordsOutput;

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Constructs a new instance of <see cref="MapProjectorDataSource"/>.
        /// </summary>
        public MapProjectorDataSource()
        {
            this.Interval = 1;
            this.PaperSize = PaperSize.A3;
            this.Orientation = Orientation.Landscape;
        }

        #region Properties

        /// <summary>
        /// Northernmost geographical coordinate.
        /// </summary>
        public double North
        {
            get
            {
                return this.north;
            }
            set
            {
                if (value != this.north)
                {
                    this.north = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Southernmost geographical coordinate.
        /// </summary>
        public double South
        {
            get
            {
                return this.south;
            }
            set
            {
                if (value != this.south)
                {
                    this.south = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Easternmost geographical coordinate.
        /// </summary>
        public double East
        {
            get
            {
                return this.east;
            }
            set
            {
                if (value != this.east)
                {
                    this.east = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Westernmost geographical coordinate.
        /// </summary>
        public double West
        {
            get
            {
                return this.west;
            }
            set
            {
                if (value != this.west)
                {
                    this.west = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Interval of the coordinate gridlines.
        /// </summary>
        public double Interval
        {
            get
            {
                return this.interval;
            }
            set
            {
                if (value != this.interval)
                {
                    this.interval = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// One parameter for the custom paper size, the other being <see cref="CustomPaperSizeDim2"/>.
        /// </summary>
        public double CustomPaperSizeDim1
        {
            get
            {
                return this.customPaperSizeDim1;
            }
            set
            {
                if (value != this.CustomPaperSizeDim1)
                {
                    this.customPaperSizeDim1 = (int)value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// One parameter for the custom paper size, the other being <see cref="CustomPaperSizeDim1"/>.
        /// </summary>
        public double CustomPaperSizeDim2
        {
            get
            {
                return this.customPaperSizeDim2;
            }
            set
            {
                if (value != this.CustomPaperSizeDim2)
                {
                    this.customPaperSizeDim2 = (int)value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The chosen paper size.
        /// </summary>
        public PaperSize PaperSize
        {
            get
            {
                return this.paperSize;
            }
            set
            {
                if (value != this.paperSize)
                {
                    this.paperSize = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The orientation of the paper.
        /// </summary>
        public Orientation Orientation
        {
            get
            {
                return this.orientation;
            }
            set
            {
                if (value != this.orientation)
                {
                    this.orientation = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The projection in use.
        /// </summary>
        public IProjection Projection { get; set; }

        /// <summary>
        /// Text output displaying the projected coordinates.
        /// </summary>
        public string CartCoordsOutput
        {
            get
            {
                return this.cartCoordsOutput;
            }
            set
            {
                this.cartCoordsOutput = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The meridian through centre of the map. Assumes that the projection
        /// results in west-east symmetry.
        /// </summary>
        public double Meridian { get; set; }

        #endregion

        /// <summary>
        /// Called when the Calculate button is clicked to project the coordinates.
        /// </summary>
        public void Calculate()
        {
            if (!CanCalculate())
            {
                MessageBox.Show(
                    "Invalid inputs.\r\n\r\nThe north-south and west-east ranges must be integer multiples of the selected interval. Please edit your bounds and try again.",
                    "Error", 
                    MessageBoxButtons.OK);

                return;
            }

            this.cols = (int)Math.Ceiling((this.east - this.west) / this.interval) + 1;
            this.rows = (int)Math.Ceiling((this.north - this.south) / this.interval + 1);

            this.Meridian = (this.west + this.east) / 2;
            this.Projection.Origin = new Point(this.Meridian, (this.north + this.south) / 2);

            double s = 0;
            double n = 0;
            double w = 0;
            double e = 0;
            Point geoCoord;
            Point cartCoord;

            this.geoCoords = new Point[this.cols, this.rows];
            this.cartCoords = new Dictionary<double, List<Point>>();
            double rowLat;

            for (int j = 0; j < this.rows; j++)
            {
                // Start at the top.
                List<Point> row = new List<Point>();
                rowLat = this.north - interval * j;
                this.cartCoords.Add(rowLat, row);

                for (int i = 0; i < this.cols; i++)
                {
                    // Go from left to right.
                    geoCoord = new Point(this.west + interval * i, this.north - interval * j);
                    cartCoord = this.Projection.ConvertToCart(geoCoord);
                    row.Add(cartCoord);

                    // Keep track of the extremes in each cardinal direction.
                    if ((i == 0 && j == 0) || cartCoord.Y < s)
                    {
                        s = cartCoord.Y;
                    }
                    if ((i == 0 && j == 0) || cartCoord.Y > n)
                    {
                        n = cartCoord.Y;
                    }
                    if ((i == 0 && j == 0) || cartCoord.X < w)
                    {
                        w = cartCoord.X;
                    }
                    if ((i == 0 && j == 0) || cartCoord.X > e)
                    {
                        e = cartCoord.X;
                    }
                }
            }

            // The converted, but unscaled, west-east and north-south ranges.
            double we = e - w;
            double sn = n - s;

            // Set paper orientation and get the scaling factor.
            this.Orientation = (sn > we) ? Orientation.Portrait : Orientation.Landscape;
            double scale = GetScaleToPaperSize(we, sn);

            // Scale the grid to fit the paper.
            foreach (List<Point> row in this.cartCoords.Values)
            {
                for (int i = 0; i < row.Count; i++)
                {
                    Point point = row[i];
                    row[i] = ScalePoint(point, scale);
                }
            }

            DumpOutput();
        }

        private bool CanCalculate()
        {
            bool result = true;

            double vertSpan = this.north - this.south;
            double horiSpan = this.east - this.west;
            result &= vertSpan > 0 && vertSpan % this.interval == 0;
            result &= horiSpan > 0 && horiSpan % this.interval == 0;

            return result;
        }

        private double GetScaleToPaperSize(double we, double sn)
        {
            int paperLongSide = (this.PaperSize == PaperSize.Custom)
                ? Math.Max(this.customPaperSizeDim1, this.customPaperSizeDim2)
                : this.PaperSize.LongSide();
            int paperShortSide = (this.PaperSize == PaperSize.Custom)
                ? Math.Min(this.customPaperSizeDim1, this.customPaperSizeDim2)
                : this.PaperSize.ShortSide();

            // Set paper orientation
            return (this.Orientation == Orientation.Portrait)
                ? Math.Min((paperLongSide / sn), (paperShortSide / we))
                : Math.Min((paperShortSide / sn), (paperLongSide / we));
        }

        private Point ScalePoint(Point point, double scale)
        {
            int paperWidth = 0, paperHeight = 0;
            switch (this.Orientation)
            {
                case Orientation.Landscape:
                    paperWidth = this.PaperSize.LongSide();
                    paperHeight = this.PaperSize.ShortSide();
                    break;
                case Orientation.Portrait:
                    paperWidth = this.PaperSize.ShortSide();
                    paperHeight = this.PaperSize.LongSide();
                    break;
            }

            return new Point(
                scale * point.X + paperWidth / 2, // left to right
                paperHeight / 2 - scale * point.Y // top to bottom
                );
        }

        private Point[,] Transform(Point[,] input)
        {
            Point[,] result = new Point[input.GetLength(1), input.GetLength(0)];

            for(int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    result[j, i] = input[i, j];
                }
            }

            return result;
        }

        private void DumpOutput()
        {
            StringBuilder output = new StringBuilder();

            if (this.cartCoords != null)
            {
                this.cartCoords = this.cartCoords.SortDictionaryByKeyDescending();

                foreach (List<Point> row in this.cartCoords.Values)
                {
                    output.AppendLine(GetOutputLine(row));
                }
            }

            this.CartCoordsOutput = output.ToString();
        }

        private string GetOutputLine(List<Point> row)
        {
            string[] outputLine = new string[this.cols];

            for(int i = 0; i < row.Count; i++)
            {
                outputLine[i] = row[i].ToString();
            }

            return string.Join(", ", outputLine);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
