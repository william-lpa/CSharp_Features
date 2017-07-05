using CSharp_5;
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

namespace AsyncronousReadWrite
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
        }

        private void IncreaseProgressBar(int value)
        {
            this.Invoke(new Action(() =>
            {
                progressBar1.PerformStep();
                label1.Text = progressBar1.Value + "%";
            }));
        }
        private async Task DownloadFileAsync()
        {
            var request = new WebRequestOperation();
            request.ProgressBarValueChanged += IncreaseProgressBar;
            var fileData = request.DownloadFileAsync();
            var localFile = CreateDownloadingFileOnDisk();
            await fileData;
            MessageBox.Show("Vamos Começar a gravar o download no arquivo!");
            await localFile.WriteDownloadedFileToDiskAsync(fileData.Result);
            MessageBox.Show("Finalizado!");

        }

        private void DownloadFile(object sender, EventArgs e)
        {
            var request = new WebRequestOperation();
            request.ProgressBarValueChanged += IncreaseProgressBar;
            var data = request.DownloadFileAsync().Result;
            var localFile = CreateDownloadingFileOnDisk();            
            MessageBox.Show("Vamos Começar a gravar o download no arquivo!");
            localFile.WriteDownloadedFileToDisk(data);
            MessageBox.Show("Finalizado!");
        }

        private FileOperation CreateDownloadingFileOnDisk()
        {
            return new FileOperation("teste.zip", @"C:\Teste Download");
        }

        private void btnNonAssync_Click(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork+=DownloadFile;
            worker.RunWorkerAsync();
        }

        private void btnAsync_Click(object sender, EventArgs e)
        {
            DownloadFileAsync();
        }
    }
}
