using System.Net;
using System;

namespace Dowload_image
{
    public class ImageDownloader
    {
        public string RemoteUri;
        public string FileName;

        public event Action<string, string> ImageStarted;
        public event Action<string, string> ImageCompleted;

        public string Download(string remoteUri, string fileName)
        {
            var myWebClient = new WebClient();
            ImageStarted?.Invoke(remoteUri, fileName);
            myWebClient.DownloadFile(remoteUri, fileName);
            ImageCompleted?.Invoke(remoteUri, fileName);
            return remoteUri;
        }
    }
}