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

            public event Action <string> ImageStarted;
            public event Action <string> ImageCompleted;
            public string Download(string remoteUri, string fileName)
            {
                var myWebClient = new WebClient();
                ImageStarted += IStarted;
                ImageStarted?.Invoke(fileName);
                Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileName, remoteUri);
                myWebClient.DownloadFile(remoteUri, fileName);
                Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, remoteUri);
                ImageCompleted += IsCompleted;
                ImageCompleted?.Invoke(fileName);
                return remoteUri;
            }
            private void IsCompleted(string fileName)
            {
                Console.WriteLine($"Скачивание файла {fileName} закончилось");
            }
            private void IStarted(string fileName)
            {
                Console.WriteLine($"Скачивание файла {fileName} началось ");
            }
        }
        static void Main(string[] args)
        {
            ImageDownloader imageDownloader = new ImageDownloader();
            imageDownloader.Download("https://images.hdqwalls.com/wallpapers/tenet-movie-8k-a1.jpg", "bigimage.jpg");
        }
    }
}
