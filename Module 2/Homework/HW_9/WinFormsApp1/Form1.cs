using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int state = 0;
        private int textSlowCounter = 0;
        public Form1()
        {
            InitializeComponent();
            Text = "Растаявшая надпись";
            CenterToScreen();
            label1.Text = "Чеширский кот";
            label1.Font = new Font(label1.Font.FontFamily, 40);
            label1.ForeColor = Color.DeepPink;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (state == 0)
            {
                textSlowCounter++;
                if (textSlowCounter == 5)
                {
                    textSlowCounter = 0;
                    label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
                }
                if (label1.Text == "")
                {
                    state = 1;
                }
            }
            else if (state == 1)
            {
                Opacity -= 0.01;
                if (Opacity <= 0)
                {
                    state = 2;
                    label1.Text = "Кот уже ушел!";
                }
            }
            else if (state == 2)
            {
                Opacity += 0.01;
                if (Opacity >= 1)
                {
                    state = 3;
                }
            }
        }
    }
}
