using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projector
{
    public class ProjectrDataSource : Component, INotifyPropertyChanged
    {
        private double customPaperSizeDim1;
        private double customPaperSizeDim2;

        public event PropertyChangedEventHandler PropertyChanged;

        public ProjectrDataSource()
        {
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

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
