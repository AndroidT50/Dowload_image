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
            //public ImageDownloader() { }
            //public ImageDownloader(string url) { }
            public string remoteUri;
            public string fileName;

                

        }

        static void Main(string[] args)
        {
            
            string remoteUri = "https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg";
           
            string fileName = "bigimage.jpg";

            // Качаем картинку в текущую директорию
            var myWebClient = new WebClient();
            Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileName, remoteUri);
            myWebClient.DownloadFile(remoteUri, fileName);
            Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, remoteUri);

        }
    }
}
