using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private string[] strings = new string[5] { "one", "two", "three", "four", "five" };
        private List<string> curStrings = new List<string>(new string[5] { "one", "two", "three", "four", "five" });
        
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(strings);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            curStrings = new List<string>(strings);
            listBox1.Items.AddRange(strings);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idx = listBox1.Items.IndexOf(listBox1.SelectedItem);
            curStrings.RemoveAt(idx);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
    }
}
