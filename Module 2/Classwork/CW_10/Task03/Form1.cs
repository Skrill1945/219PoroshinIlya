using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool IsShrinking = true;

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsShrinking)
            {
                if (Size.Width >= 100 && Size.Height >= 100)
                {
                    Size = new Size(Size.Width / 2, Size.Width / 2);
                    if (Size.Width <= 200 || Size.Height <= 100)
                    {
                        IsShrinking = false;
                        button1.Text = "Make form big";
                    }
                } else
                {
                    Size = new Size(Size.Width * 2, Size.Width * 2);
                }
            }
            else
            {
                if (Size.Width <= 1000 && Size.Height <= 1000)
                {
                    Size = new Size(Size.Width * 2, Size.Width * 2);
                    if (Size.Width >= 1000 || Size.Height >= 1000)
                    {
                        button1.Text = "Make form smol";
                        IsShrinking = true;
                    }
                }
                else
                {
                    Size = new Size(Size.Width / 2, Size.Width / 2);
                }
            }
        }
    }
}
