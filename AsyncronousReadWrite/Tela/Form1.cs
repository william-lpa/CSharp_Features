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
        private async Task DownloadFile5Async()
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

        private void DownloadFile4Async(object sender, EventArgs e)
        {
            var request = new WebRequestOperation();
            request.ProgressBarValueChanged += IncreaseProgressBar;
            var data = request.DownloadFileOldAsync();
            MessageBox.Show("Vamos Começar a gravar o download no arquivo!");
            CreateDownloadingFileOnDisk().WriteDownloadedFileToDiskOldAsync(data);
            MessageBox.Show("Finalizado!");
        }
        private void DownloadFileNonAsync(object sender, EventArgs e)
        {
            var request = new WebRequestOperation();
            var data = request.DownloadFile();
            MessageBox.Show("Vamos Começar a gravar o download no arquivo!");
            CreateDownloadingFileOnDisk().WriteDownloadedFileToDisk(data);
            MessageBox.Show("Finalizado!");
        }

        private FileOperation CreateDownloadingFileOnDisk()
        {
            return new FileOperation("teste.zip", @"C:\Teste Download");
        }

        private void btnAsync4_Click(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += DownloadFile4Async;
            worker.RunWorkerAsync();
        }

        private void btnAsync5_Click(object sender, EventArgs e)
        {//wpf supports assync calls
            DownloadFile5Async();
        }

        private void btn_NonAsync_Click(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += DownloadFileNonAsync;
            worker.RunWorkerAsync();
        }
    }
}
