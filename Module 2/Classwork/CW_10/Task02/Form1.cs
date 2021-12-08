using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string[] lines = new string[4] { "asdasd", "vubih8njomp", "iuyrnvtr", "idfjvdov," };

        private void btn1_Click(object sender, EventArgs e)
        {
            textBox1.Lines = lines;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = string.Join(' ', textBox1.Lines);
            MessageBox.Show(s);
        }
    }
}
