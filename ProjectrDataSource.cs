using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Projectr.Projections;
using System.Windows.Forms;

namespace Projectr
{
    public enum PaperSize
    {
        A2,
        A3,
        A4,
        Custom,
    }

    public enum Orientation
    {
        Landscape,
        Portrait,
    }

    public class ProjectrDataSource : Component, INotifyPropertyChanged
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
        private Point[,] cartCoords;
        private string cartCoordsOutput;

        public event PropertyChangedEventHandler PropertyChanged;

        public ProjectrDataSource()
        {
            this.Interval = 1;
            this.PaperSize = PaperSize.A3;
            this.Orientation = Orientation.Landscape;
        }

        #region Properties

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

        public IProjection Projection { get; set; }

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

        #endregion

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

            int cols = (int)Math.Ceiling((this.east - this.west) / this.interval) + 1;
            int rows = (int)Math.Ceiling((this.north - this.south) / this.interval + 1);

            this.Projection.Origin = new Point((this.west + this.east) / 2, (this.north + this.south) / 2);

            double s = 0;
            double n = 0;
            double w = 0;
            double e = 0;
            Point geoCoord;
            Point cartCoord;

            this.geoCoords = new Point[cols, rows];
            this.cartCoords = new Point[cols, rows];
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    // Start from the bottom left.
                    geoCoord = new Point(this.west + interval * i, this.south + interval * j);
                    cartCoord = this.Projection.ConvertToCart(geoCoord);
                    this.cartCoords[i, j] = cartCoord;

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

            // The transformed, but unscaled, west-east and north-south ranges.
            double we = e - w;
            double sn = n - s;

            // Set paper orientation and get the scaling factor.
            this.Orientation = (sn > we) ? Orientation.Portrait : Orientation.Landscape;
            double scale = GetScaleToPaperSize(we, sn);

            // Scale the grid to fit the paper.
            for (int i = 0; i < cols; i++)
            {
                Point temp;
                for (int j = 0; j < rows; j++)
                {
                    temp = this.cartCoords[i, j];
                    this.cartCoords[i, j] = ScalePoint(temp, scale);
                }
            }
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
            return new Point(scale * point.X, scale * point.Y);
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

        private void Transform()
        {

        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
