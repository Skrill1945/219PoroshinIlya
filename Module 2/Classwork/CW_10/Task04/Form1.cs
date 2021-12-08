using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Random rand = new Random();
        private int hits = 0, misses = 0;

        private void Form1_Click(object sender, EventArgs e)
        {
            missesLabel.Text = $"{++misses}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hitsLabel.Text = $"{++hits}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.Top = rand.Next(50, 450);
            button1.Left = rand.Next(100, 850);
            button1.Visible = !button1.Visible;
        }
    }
}
