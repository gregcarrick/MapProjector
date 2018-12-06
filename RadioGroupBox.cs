using System;
using System.Linq;
using System.Windows.Forms;

namespace Projectr
{
    public class RadioGroupBox<T> : GroupBox where T : struct
    {
        public event EventHandler SelectedChanged;

        private T selected;

        public T Selected
        {
            get
            {
                return this.selected;
            }
            set
            {
                if (this.Controls != null)
                {
                    RadioButton rb = this.Controls.OfType<RadioButton>().
                        FirstOrDefault(radio =>
                        radio.Tag != null && ((T)radio.Tag).Equals(value));

                    if (rb != null)
                    {
                        rb.Checked = true;
                        this.selected = value;
                    }
                }
            }
        }

        private void OnSelectedChanged()
        {
            this.SelectedChanged?.Invoke(this, new EventArgs());
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            RadioButton rb = e.Control as RadioButton;
            if (rb != null)
            {
                rb.CheckedChanged += rb_CheckedChanged;
            }
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked && rb.Tag != null)
            {
                this.selected = (T)rb.Tag;
                OnSelectedChanged();
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (this.Controls != null)
                {
                    foreach (RadioButton rb in this.Controls.OfType<RadioButton>())
                    {
                        if (rb != null)
                        {
                            rb.CheckedChanged -= rb_CheckedChanged;
                        }
                    }
                }
            }
        }
    }
}
