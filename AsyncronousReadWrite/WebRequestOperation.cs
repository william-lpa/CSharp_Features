using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp_5
{
    class WebRequestOperation
    {
        private readonly Uri uri = new Uri("http://ipv4.download.thinkbroadband.com/5MB.zip");
        internal delegate void ProgressBarChanged(int value);
        internal event ProgressBarChanged ProgressBarValueChanged;
        public long FileLength { get; private set; }
        public long BytesRead { get; private set; }
        public int ProgressPercentage { get; private set; }

        public byte[] DownloadFile()
        {
            using (WebClient myWebClient = new WebClient())
            {
                myWebClient.OpenRead(uri);
                FileLength = Convert.ToInt64(myWebClient.ResponseHeaders["Content-Length"]);
                return myWebClient.DownloadData(uri); // Thread retornrá para o invocador até a conclusão
            }
        }

        public async Task<byte[]> DownloadFileAsync()
        {
            using (WebClient myWebClient = new WebClient())
            {
                myWebClient.DownloadProgressChanged += DownloadProgressChanged;
                myWebClient.OpenRead(uri);
                FileLength = Convert.ToInt64(myWebClient.ResponseHeaders["Content-Length"]);
                return await myWebClient.DownloadDataTaskAsync(uri); // Thread retornrá para o invocador até a conclusão
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

        private HttpWebRequest _request;
        private IAsyncResult _responseAsyncResult;
        private byte[] data;
        public byte[] DownloadFileOldAsync()
        {
            _request = WebRequest.Create(uri) as HttpWebRequest;
            _responseAsyncResult = _request.BeginGetResponse(ResponseCallback, _responseAsyncResult);

            while (data == null)
            {
                Thread.Sleep(3000);
            }
            return data;
        }
        private void ResponseCallback(object state)
        {
            var response = _request.EndGetResponse(state as IAsyncResult);
            long contentLength = response.ContentLength;

            Stream responseStream = response.GetResponseStream();

            data = GetContentWithProgressReporting(responseStream, contentLength);

            response.Close();
        }
        private byte[] GetContentWithProgressReporting(Stream responseStream, long contentLength)
        {
            // Allocate space for the content
            var data = new byte[contentLength];
            int bytesRead = 0;
            int bytesReceived = 0;
            var buffer = new byte[256];
            do
            {
                bytesReceived = responseStream.Read(buffer, 0, 256);
                Array.Copy(buffer, 0, data, bytesRead, bytesReceived);
                bytesRead += bytesReceived;

                // Report percentage
                var percentage = (int)Math.Round(((double)bytesRead * 100) / contentLength);
                if (percentage > ProgressPercentage)
                {
                    ProgressPercentage = percentage;
                    ProgressBarValueChanged((int)ProgressPercentage);
                }
            } while (bytesRead < contentLength);

            return data;
        }
    }
}
