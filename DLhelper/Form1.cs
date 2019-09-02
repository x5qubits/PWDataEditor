
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLhelper
{
    public partial class Form1 : Form
    {
        private string downloadFile;
        private string extractLocation;

        public Form1()
        {
            InitializeComponent();
            downloadFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "update.zip");
            extractLocation = Path.GetDirectoryName(Application.ExecutablePath);
            startAfter = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Perfect World Data Editor.exe");
        }

        public string startAfter { get; private set; }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                if (File.Exists(downloadFile))
                {
                    try
                    {
                        ZipArchive zip = new ZipArchive(new MemoryStream(File.ReadAllBytes(downloadFile)));
                        ZipArchiveExtensions.ExtractToDirectory(zip, extractLocation, true);
                        File.Delete(downloadFile);
                    }
                    catch(Exception ex)
                    {

                    }
                    var process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = startAfter
                           // Arguments = string.Join(" ", Environment.GetCommandLineArgs())
                        }
                    };
                    process.Start();
                    process.WaitForInputIdle();
                    Application.Exit();
                    Environment.Exit(0);
                }
                else
                {
                    var process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = startAfter
                           // Arguments = string.Join(" ", Environment.GetCommandLineArgs())
                        }
                    };
                    process.Start();
                    process.WaitForInputIdle();
                    Application.Exit();
                    Environment.Exit(0);
                }
            });

        }
    }
}
