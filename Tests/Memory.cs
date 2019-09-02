using PWnpcEditor.classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PWDataEditorPaied.Classes
{
    public class PWMemory
    {
        //import kernel32 and create OpenProcess and ReadProcess functions
        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Boolean bInheritHandle, UInt32 dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        //Create handle
        public int Handle;
        public Process nProcess;
        public int baseAddress;
        private Offset offset = null;
        //constructor
        public PWMemory(string sprocess, Offset Config)
        {
            offset = Config;
            //Get the specific process
            Process[] Processes = Process.GetProcessesByName(sprocess);
            nProcess = Processes[0];
            //access to the process
            Handle = (int)OpenProcess(0x10, false, (uint)nProcess.Id);
            baseAddress = (int)nProcess.MainModule.BaseAddress;
        }

    }
}
