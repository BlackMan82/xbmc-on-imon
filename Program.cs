using System;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace iMon.XBMC
{
    
    class MyMessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            return false;
        }
    }


    static class Program
    {
        static Mutex mutex = new Mutex(true, Application.ProductName);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                if (mutex.WaitOne(TimeSpan.Zero, true))
                {
                    Logging.initialize();

                    try
                    {

                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new XBMC());
                    }
                    catch (Exception ex)
                    {
                        Logging.Error("Unhandled exception", ex);
                        MessageBox.Show("An unhandled exception has occured." + Environment.NewLine +
                                        "Please check the debug/error log for more details", 
                                        "Unhandled Exception",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    Logging.deinitialize();

                    mutex.ReleaseMutex();
                }
                else
                {
                    // send our Win32 message to make the currently running instance
                    // jump on top of all the other windows

                    NativeMethods.PostMessage((IntPtr) NativeMethods.HWND_BROADCAST, NativeMethods.WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
                    //MessageBox.Show("Another instance is running." + Environment.NewLine + 
                    //                "Current process: " + Process.GetCurrentProcess().ToString() + Environment.NewLine +
                    //                "Process by name length: " + Process.GetProcessesByName("XbmcOniMon").Length + Environment.NewLine +
                    //                "1st process: " + (Process.GetProcessesByName("XbmcOniMon")[0].ToString()) + Environment.NewLine +
                    //                "2nd process: " + (Process.GetProcessesByName("XbmcOniMon")[1].ToString()));
                    //Process[] processes = Process.GetProcessesByName("XbmcOniMon");
                    //foreach (Process proc in processes)
                    //      NativeMethods.PostMessage((IntPtr) proc.MainWindowHandle, NativeMethods.WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
                    //NativeMethods.PostMessage((IntPtr) Process.GetProcessesByName("XbmcOniMon")[1].MainWindowHandle, NativeMethods.WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
                }
            }
            catch (Exception ex)
            {
                //Logging.Error("Unhandled exception", ex);

                MessageBox.Show("An unhandled exception has occured." + Environment.NewLine +
                                ex.ToString(),
                                //"Please check the debug/error log for more details", 
                                "Unhandled Exception",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    internal class NativeMethods
    {
        public const int HWND_BROADCAST = 0xffff;

        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
        //public static readonly int WM_SHOWME = 0xc201;

        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }
}
