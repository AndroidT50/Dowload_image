using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dowload_image
{
    internal class Program
    {
        public class ImageDownloader
        {

            public string remoteUri;
            public string fileName;

            public ImageDownloader()
            {
                this.remoteUri = remoteUri;
                this.fileName = fileName;
            }

            public string Download()
            {
                var myWebClient = new WebClient();
                Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileName, remoteUri);
                myWebClient.DownloadFile(remoteUri, fileName);
                Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, remoteUri);
                return remoteUri;
            }

        }

        static void Main(string[] args)
        {
            ImageDownloader imageDownloader = new ImageDownloader();
            imageDownloader.Download();
           

        }
    }
}
