using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Async_wait
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnExecutar_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            await execute();
            panel1.Visible = false;
            MessageBox.Show("Finalizado.");
        }

        private async Task execute() {

            var path = Environment.GetEnvironmentVariable("temp");
            path = Path.Combine(path, txtDestino.Text);

            if (Directory.Exists(path))
            {
                foreach (string file in Directory.EnumerateFiles(path))
                {
                    var fileInfo = new FileInfo(file);
                    fileInfo.IsReadOnly = false;
                    fileInfo.Delete();
                }
            }
            else {
                Directory.CreateDirectory(path);
            }

            foreach (string  fileName in Directory.EnumerateFiles(txtOrigem.Text))
            {
                using (FileStream SourceStream = File.Open(fileName, FileMode.Open))
                {
                    using(FileStream DestinationStream = File.Create
                        (path+fileName.Substring(fileName.LastIndexOf('\\')))){
                        await SourceStream.CopyToAsync(DestinationStream);
                    }
                }
            }

            var destBkp = Path.Combine(txtOrigem.Text, txtDestino.Text +".zip");

            if (File.Exists(destBkp))
	        {
		            File.Delete(destBkp);
	        }

            System.IO.Compression.ZipFile.CreateFromDirectory(path, destBkp, System.IO.Compression.CompressionLevel.Optimal, false);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtOrigem.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
