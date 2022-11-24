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
            public ImageDownloader(string remoteUri, string fileName)
            {
                this.remoteUri = remoteUri;
                this.fileName = fileName;
            }

            public string Download(string remoteUri, string fileName)
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
            ImageDownloader imageDownloader = new ImageDownloader("https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg", "bigimage.jpg");
            imageDownloader.Download("https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg", "bigimage.jpg");
            
        }
    }
}
