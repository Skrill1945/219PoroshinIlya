using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private long num1 = 1, num2 = 2, num3 = 5;
        private int curId = 1;

        private void generateNextNumBtn_Click(object sender, EventArgs e)
        {
            if (curId == 1)
            {
                numLabel.Text = $"{num1}";
                curId++;
            }
            else if (curId == 2)
            {
                numLabel.Text = $"{num2}";
                curId++;
            }
            else
            {
                numLabel.Text = $"{num1 + 2 * num2}";
                num3 = num1 + 2 * num2;
                num1 = num2;
                num2 = num3;
            }
        }
    }
}
