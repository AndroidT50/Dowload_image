using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace Dowload_image
{
    internal class Program
    {
        delegate string DowImage(string remoteUrl, string fileName);
        public class ImageDownloader
        {
            public string remoteUri;
            public string fileName;

            public event Action<string,string> ImageStarted;
            public event Action<string,string> ImageCompleted;
             

            public string Download(string remoteUri, string fileName)
            {
                
                var myWebClient = new WebClient();
                ImageStarted += IStarted;
                ImageStarted?.Invoke(remoteUri, fileName);
                myWebClient.DownloadFile(remoteUri, fileName);
                ImageCompleted += IsCompleted;
                ImageCompleted?.Invoke(remoteUri, fileName);
                return remoteUri;
                

            }

            private void IsCompleted(string remoteUri, string fileName)
            {
                Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, remoteUri);
            }

            private void IStarted(string remoteUri, string fileName)
            {
                Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileName, remoteUri);
            }

        }
        static void Main(string[] args)
        {
            ImageDownloader imageDownloader = new ImageDownloader();
            imageDownloader.Download("https://images.hdqwalls.com/wallpapers/tenet-movie-8k-a1.jpg", "bigimage.jpg");
            
            
        }

       
    }
}
