using System;
using System.ComponentModel;
using System.Net;

namespace NSUpdateManager
{
    public class DownloadManager
    {
        public Action<DOWNLOAD_STATE> StateChanged = null;
        public Action<DownloadProgressChangedEventArgs> ProgressChanged = null;
        private string DownloadURL = "";

        public void DownloadFile(string downloadFile, string url)
        {
            DownloadURL = url;
            WebClient client = new WebClient();
            Uri Uri = new Uri(DownloadURL);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);

            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgress);
            client.DownloadFileAsync(Uri, downloadFile);
            if (StateChanged != null)
                StateChanged.Invoke(DOWNLOAD_STATE.DOWNLOADING);

        }
        private void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            if (ProgressChanged != null)
            {
                ProgressChanged.Invoke(e);
            }
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                if (StateChanged != null)
                    StateChanged.Invoke(DOWNLOAD_STATE.CANCELED);
            }
            else
            {
                if (StateChanged != null)
                    StateChanged.Invoke(DOWNLOAD_STATE.COMPLEATE);
            }
        }
    }

}
