using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FWWCode;
using System.IO;

namespace WW1Code
{
    public partial class Form1 : Form
    {
        private Cipher Coder;
        private Cezar.Cezar Cezar;

        public Form1()
        {
            InitializeComponent();
            Coder = new Cipher();
            Cezar = new Cezar.Cezar();
            listBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.ResetText();
            if (listBox1.SelectedIndex == 0)
            {
                textBox2.Text = Coder.Decipher(textBox1.Text);
            }
            if (listBox1.SelectedIndex == 1)
            {
                textBox2.Text = Cezar.Decipher(textBox1.Text, Convert.ToInt32(textBox3.Text));
            }
            else
                return;
            using (StreamWriter sw = new StreamWriter("Logs.txt", true))
            {
                sw.WriteLine("begin------------------------{0} Encoding : {1}  Deciph", DateTime.Now.ToString(), label5.Text);
                sw.WriteLine("{0}", textBox1.Text);
                sw.WriteLine("-------->");
                sw.WriteLine("{0}", textBox2.Text);
                sw.WriteLine("end------------------------");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.ResetText();
            if (listBox1.SelectedIndex == 0)
            {
                textBox2.Text = Coder.Encrypt(textBox1.Text);
            }
            if (listBox1.SelectedIndex == 1)
            {
                textBox2.Text = Cezar.Encrypt(textBox1.Text, Convert.ToInt32(textBox3.Text));
            }
            else
                return;
            using (StreamWriter sw = new StreamWriter("Logs.txt", true))
            {
                sw.WriteLine("begin------------------------{0} Encoding : {1}  Encrypt", DateTime.Now.ToString(), label5.Text);
                sw.WriteLine("{0}", textBox1.Text);
                sw.WriteLine("-------->");
                sw.WriteLine("{0}", textBox2.Text);
                sw.WriteLine("end------------------------");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() == "First world war")
            {
                label5.Text = "First world war code";
                textBox3.Text = "Key";
            }
            if (listBox1.SelectedItem.ToString() == "Cezar code")
            {
                label5.Text = "Cezar code";
                textBox3.Text = "0";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            var tmp = textBox2.Text;
            textBox2.Text = textBox1.Text;
            textBox1.Text = tmp;
        }
    }
}