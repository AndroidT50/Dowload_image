using System;

namespace Dowload_image
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ImageDownloader imageDownloader = new ImageDownloader();
            imageDownloader.ImageStarted += IStarted;
            imageDownloader.ImageCompleted += IsCompleted;
            imageDownloader.Download("https://images.hdqwalls.com/wallpapers/tenet-movie-8k-a1.jpg", "bigimage.jpg");
        }
        static  void IsCompleted(string remoteUri, string fileName)
        {
            Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, remoteUri);
        }
        static void IStarted(string remoteUri, string fileName)
        {
            Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileName, remoteUri);
        }

    }
}
