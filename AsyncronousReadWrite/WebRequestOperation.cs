using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_5
{
    class WebRequestOperation
    {
        private readonly Uri uri = new Uri("http://ipv4.download.thinkbroadband.com/100MB.zip");
        internal delegate void ProgressBarChanged(int value);
        internal event ProgressBarChanged ProgressBarValueChanged;
        public long FileLength { get; private set; }
        public long BytesRead { get; private set; }
        public int ProgressPercentage { get; private set; }

        public async Task<byte[]> DownloadFileAsync()
        {
            using (WebClient myWebClient = new WebClient())
            {
                myWebClient.DownloadProgressChanged += DownloadProgressChanged;
                myWebClient.OpenRead(uri);
                FileLength = Convert.ToInt64(myWebClient.ResponseHeaders["Content-Length"]);
                return await myWebClient.DownloadDataTaskAsync(uri); // Thread ficará aguardando até a conclusão da requisão
            }
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            var percentual = (int)Math.Round((e.BytesReceived * 100) / (double)FileLength);
            if (percentual > ProgressPercentage)
            {
                ProgressPercentage = percentual;
                ProgressBarValueChanged(ProgressPercentage);
            }
        }
    }
}
