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
        delegate string DowImage(string remoteUrl, string fileName);
        public class ImageDownloader
        {
            public string remoteUri;
            public string fileName;

            public event Action<string> ImageStarted;
            public event Action<string> ImageCompleted;
             

            public string Download(string remoteUri, string fileName)
            {
              
                var myWebClient = new WebClient();
                ImageStarted.Invoke("старт");
                myWebClient.DownloadFile(remoteUri, fileName);
                ImageCompleted.Invoke("Конец загрузки");
                return remoteUri;
               
               
            }
            public void IStarted()
            {
                ImageStarted += ImageDownloader_ImageStarted;
               
            }

            private void ImageDownloader_ImageStarted(string obj)
            {
                Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileName, remoteUri);
            }

            public void ImCompleted()
            {
                ImageCompleted += ImageDownloader_ImageCompleted;
            }

            private void ImageDownloader_ImageCompleted(string obj)
            {
                Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, remoteUri);
            }
            


        }
        static void Main(string[] args)
        {
            ImageDownloader imageDownloader = new ImageDownloader();
            ////imageDownloader.Download("https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg", "bigimage.jpg");
            imageDownloader.Download("https://images.hdqwalls.com/wallpapers/vossen-beautiful-wrapped-corvette-c8-8k-ag.jpg", "bigimage.jpg");
            //https://images.hdqwalls.com/wallpapers/tenet-movie-8k-a1.jpg очень тяжелая 27mb
        }
    }
}
