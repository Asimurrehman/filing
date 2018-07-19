using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "FileRead";
            this.label1.Text = "fname";
            this.label2.Text = "fileaddress";
            this.label3.Text = "fileExtension";
            this.button1.Text = "FileStreamread";
            this.button2.Text = "StreamReader";
            this.button3.Text = "Streamwrite";
            this.button4.Text = "FileStreamWrite";

            string[] a = { ".txt", ".doc" };
            comboBox1.Items.AddRange(a);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = this.textBox2.Text + this.textBox1.Text + this.comboBox1.Text;

            FileStream fs = new FileStream(fname, FileMode.OpenOrCreate);
            byte[] bb = new byte[100];
            char[] ch = new char[100];

            fs.Read(bb,0,100);
            Decoder de = Encoding.UTF8.GetDecoder();
            de.GetChars(bb, 0, bb.Length, ch, 0);


            foreach (char c in ch)
            {
               textBox3.Text +=c;
            
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fname = this.textBox2.Text + this.textBox1.Text + this.comboBox1.Text;

            StreamReader sr = new StreamReader(fname);
            textBox3.Text = sr.ReadToEnd();
            sr.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fname = this.textBox2.Text + this.textBox1.Text + this.comboBox1.Text;
          
            StreamWriter sr = new StreamWriter(fname);
            sr.Write(this.textBox3.Text);
            sr.Close();
            MessageBox.Show("done");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fname = this.textBox2.Text + this.textBox1.Text + this.comboBox1.Text;

            FileStream fs = new FileStream(fname, FileMode.OpenOrCreate);
            byte[] bb = new byte[100];
            char[] ch = new char[100];

          
            ch = textBox3.Text.ToCharArray();
            Encoder de = Encoding.UTF8.GetEncoder();
            de.GetBytes(ch, 0, ch.Length, bb, 0,true);
            fs.Write(bb, 0, bb.Length);
            fs.Close();

            //foreach (char c in ch)
            //{
            //    textBox3.Text += c;

            //}
           
           
            
        }
    }
}
