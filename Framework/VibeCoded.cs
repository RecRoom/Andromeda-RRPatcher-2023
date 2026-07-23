using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

public static class NativeConsoleFilter
{
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool CreatePipe(out IntPtr hReadPipe, out IntPtr hWritePipe, IntPtr lpPipeAttributes, uint nSize);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool SetStdHandle(int nStdHandle, IntPtr hHandle);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr GetStdHandle(int nStdHandle);

    const int STD_OUTPUT_HANDLE = -11;
    const int STD_ERROR_HANDLE = -12;

    public static void Install(string filterString)
    {
        IntPtr realStdOut = GetStdHandle(STD_OUTPUT_HANDLE);

        CreatePipe(out IntPtr readPipe, out IntPtr writePipe, IntPtr.Zero, 0);
        SetStdHandle(STD_OUTPUT_HANDLE, writePipe);
        SetStdHandle(STD_ERROR_HANDLE, writePipe);

        var safeHandle = new Microsoft.Win32.SafeHandles.SafeFileHandle(readPipe, true);
        var reader = new StreamReader(new FileStream(safeHandle, FileAccess.Read));

        var realOutHandle = new Microsoft.Win32.SafeHandles.SafeFileHandle(realStdOut, false);
        var realWriter = new StreamWriter(new FileStream(realOutHandle, FileAccess.Write)) { AutoFlush = true };

        var thread = new Thread(() =>
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains(filterString))
                    continue;
                realWriter.WriteLine(line);
            }
        });
        thread.IsBackground = true;
        thread.Start();
    }
}