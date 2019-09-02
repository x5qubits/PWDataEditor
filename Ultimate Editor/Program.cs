using System;
using System.Windows.Forms;
using Ultimate_Editor.Clases.AngelicaFileManager;

namespace Ultimate_Editor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new PackHelper(@"E:\PWForsaken_153\element\models.pck");
           // new FileNuller(@"E:\NewBattlePets");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ElementEditor());
        }
    }
}
