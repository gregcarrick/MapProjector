using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Projectr.Projections;
using System.Windows.Forms;

namespace Projectr
{
    public enum PaperSize
    {
        A2,
        A3,
        A4,
        Custom
    }

    public class ProjectrDataSource : Component, INotifyPropertyChanged
    {
        private double north;
        private double south;
        private double east;
        private double west;
        private double interval;
        private PaperSize paperSize;
        private double customPaperSizeDim1;
        private double customPaperSizeDim2;
        private IProjection projection;

        public event PropertyChangedEventHandler PropertyChanged;

        public ProjectrDataSource()
        {
            this.PaperSize = PaperSize.A3;
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
                    this.customPaperSizeDim1 = value;
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
                    this.customPaperSizeDim2 = value;
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

        public IProjection Projection
        {
            get
            {
                return this.projection;
            }
            set
            {
                if (value != this.projection)
                {
                    this.projection = value;
                    OnPropertyChanged();
                }
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

            int cols = (int)Math.Ceiling((this.east - this.west) / this.interval);
            int rows = (int)Math.Ceiling((this.north - this.south) / this.interval);

            double? southernmost = null;
            double? northernmost = null;
            double? westernmost = null;
            double? easternmost = null;
            Point geoCoord;
            Point cartCoord;

            Point[,] geoCoords = new Point[cols, rows];
            Point[,] cartCoords = new Point[cols, rows];
            for (int i = 0; i <= cols; i++)
            {
                for (int j = 0; j <= rows; j++)
                {
                    geoCoord = new Point(this.west + interval * i, this.south + interval * j);
                    cartCoord = projection.ConvertToCart(geoCoord);
                    cartCoords[i, j] = cartCoord;

                    if (!southernmost.HasValue || cartCoord.Y < southernmost.Value)
                    {
                        southernmost = cartCoord.Y;
                    }
                    if (!northernmost.HasValue || cartCoord.Y > northernmost.Value)
                    {
                        northernmost = cartCoord.Y;
                    }
                    if (!westernmost.HasValue || cartCoord.X < westernmost.Value)
                    {
                        westernmost = cartCoord.X;
                    }
                    if (!easternmost.HasValue || cartCoord.X > easternmost.Value)
                    {
                        easternmost = cartCoord.X;
                    }
                }
            }

            if ((northernmost.Value - southernmost.Value) > (easternmost.Value - westernmost.Value))
            {

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

        private Point[,] Transform(Point[,] input)
        {
            Point[,] result = new Projectr.Point[input.GetLength(1), input.GetLength(0)];

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
