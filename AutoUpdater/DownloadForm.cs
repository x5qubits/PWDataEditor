using ElementEditor;
using JHUI;
using JHUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace NSUpdateManager
{
    public partial class DownloadForm : JForm
    {
        private DownloadManager downloadManager;
        private string downloadFile = "";
        private string extractLocation = "";
        public DownloadForm(string version)
        {
            InitializeComponent();
            string url = "http://licence.jhsoftware.pro/PWTOOL/NewUpdates/"+ version +".zip";
            extractLocation = Path.GetDirectoryName(Application.ExecutablePath);
            downloadFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath) , "update.zip");
            downloadManager = new DownloadManager();
            downloadManager.ProgressChanged += client_DownloadProgressChanged;
            downloadManager.StateChanged += StateChanged;
            downloadManager.DownloadFile(downloadFile, url);
        }

        private void StateChanged(DOWNLOAD_STATE state)
        {
            switch(state)
            {
                case DOWNLOAD_STATE.COMPLEATE:              
                    try
                    {
                        var process = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "DLhelper.exe"
                                //Arguments = string.Join(" ", Environment.GetCommandLineArgs())
                            }
                        };
                        process.Start();
                        process.WaitForInputIdle();
                        
                    }
                    catch
                    {
                        JMessageBox.Show(this, "Unable to find the DLhelper.exe.");
                    }
                    Application.Exit();
                    Environment.Exit(0);
                    break;
                case DOWNLOAD_STATE.CANCELED:
                case DOWNLOAD_STATE.ERROR:
                    JMessageBox.Show(this, "The update information could not be downloaded.");
                    break;
            }
        }

        public void client_DownloadProgressChanged(DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
    }
}
