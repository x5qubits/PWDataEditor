using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NSUpdateManager;
using PWDataEditorPaied.Forms.SubForms;

namespace ElementEditor
{
    static class Program
    {
        public static bool elementSeditorFirstLoad = true;
        public static bool StandAlone = false;
        /// <summary>
        /// SETTINGS
        /// </summary>
        public static bool SHOWMINIMIZEBUTTON = false;
        public static bool HIDEINTASKBAR = false;
        public static Version productVersion;
        public static string[] ARGS;

        public static string ThreadExceptionLog { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main(string[] args)
        {
            ThreadExceptionLog = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Logs\\");
            
            if (!Directory.Exists(Path.GetDirectoryName(ThreadExceptionLog)))
            {
                Directory.CreateDirectory(ThreadExceptionLog);
            }
            ThreadExceptionLog = Path.Combine(ThreadExceptionLog, "Error.log");
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            ARGS = args;
            productVersion = new Version(FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-Us");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.DoEvents();
            Application.Run(new SplashScreen(Program.ARGS));


        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            File.AppendAllText(ThreadExceptionLog, e.Exception.ToString());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            File.AppendAllText(ThreadExceptionLog, e.ExceptionObject.ToString());
        }
    }
}
