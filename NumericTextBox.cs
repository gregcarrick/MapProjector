using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Projectr
{
    public class NumericTextBox : TextBox
    {
        private int maxValue;
        private int minValue = 0;

        public int MaximumValue
        {
            get
            {
                return this.maxValue;
            }
            set
            {
                this.maxValue = value;
                this.MaxLength = this.maxValue.ToString().Length;
            }
        }

        public int MinimumValue
        {
            get
            {
                return this.minValue;
            }
            set
            {
                this.minValue = value;
            }
        }

        /// <summary>
        /// Allows binding to a numeric data field.
        /// </summary>
        public double Value
        {
            get
            {
                double value;
                Double.TryParse(this.Text, out value);
                return value;
            }
            set
            {
                string textValue = value == 0 ? null : value.ToString();
                if (this.Text != textValue)
                {
                    this.Text = textValue;
                }
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            NumberFormatInfo numberFormatInfo = CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;

            string keyInput = e.KeyChar.ToString();

            if ((!string.IsNullOrEmpty(this.Text) || this.Text.Length <= this.MaxLength) && Char.IsDigit(e.KeyChar))
            {
                // Digits are OK up to 3 digits.
            }
            else if (Char.IsControl(e.KeyChar))
            {
                // Controls chars are OK.
            }
            else
            {
                // Swallow this invalid key.
                e.Handled = true;
            }
        }

        /// <inheritdoc/>
        //public override string Text
        //{
        //    get
        //    {
        //        return base.Text;
        //    }
        //    set
        //    {
        //        if (value != base.Text)
        //        {
        //            double doubleValue;
        //            if (Double.TryParse(value, out doubleValue))
        //            {
        //                base.Text = value;
        //                this.Value = doubleValue;
        //            }
        //        }
        //    }
        //}
    }
}

