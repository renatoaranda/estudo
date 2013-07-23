using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileImageSln
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPasta.Text))
            {
                string[] filePaths = Directory.GetFiles(@txtPasta.Text);
                Array.Sort<string>(filePaths);
                foreach (var item in filePaths)
                {
                    //string[] x = item.Split('\\');
                    //txtResultado.Text += x[6] + "\r\n";
                    txtResultado.Text += item + "\r\n";
                }
            }
        }
    }
}
