using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_5
{
    class IOOperations
    {
        private const string url = "http://ipv4.download.thinkbroadband.com/100MB.zip";
        private const string filePath = @"C:\Users\leonard.pegler\Desktop\Teste\download\OPDO_WK_201703031729.bak";
        
        public static void Main(string[] args)
        {
            GetWebPage(url);
        }

        public static void GetWebPage(string url)
        {
            using (WebClient myWebClient = new WebClient())
            {
                myWebClient.DownloadFile(url, "teste.zip"); // Thread ficará aguardando até a conclusão da requisão
            }
        }
    }
}
