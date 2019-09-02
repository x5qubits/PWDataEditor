using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharkShield.classes
{
    static class NativeMethods
    {
        public static int PROCESS_ALL_ACCESS = (0x0010);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);


        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);
        public delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("msvcrt.dll")]
        public static extern int memcmp(byte[] b1, byte[] b2, int count);

        [DllImport("User32.dll")]
        public static extern int GetWindow(int hwndSibling, int wFlag);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "GetWindowText", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int _GetWindowText(IntPtr hWnd, StringBuilder lpWindowText, int nMaxCount);
    }
}
