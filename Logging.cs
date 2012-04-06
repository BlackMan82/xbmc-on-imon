using System;
using System.Text;
using System.IO;
using System.Diagnostics;

using iMon.XBMC.Properties;

namespace iMon.XBMC
{
    internal static class Logging
    {
        #region Private variables

        //internal const string ErrorLog = "error.log";
        //internal const string DebugLog = "debug.log";
        //internal const string OldLog = ".old";
        //internal const string ErrorLog = Settings.Default.ErrorLogFilename;
        internal static string DebugLog = Settings.Default.DebugLogFilename;
        internal static string OldLog = Settings.Default.OldLogExtension;
        // For testing purposes only - should be set to true in final releases
        internal const bool iMonNotRespondingLog = false;

        #endregion

        #region Public functions

        public static void initialize(string logPath)
        {
            initialize(logPath, FileMode.Create);
        }

        public static void initialize(string logPath, FileMode mode)
        {
            TextWriterTraceListener traceListener;
            FileStream logFile;

            logFile = File.Open(Path.Combine(logPath, DebugLog), mode, FileAccess.Write, FileShare.Read);
            traceListener = new TextWriterTraceListener(logFile, "XbmcOniMonLogger");
            Trace.Listeners.Add(traceListener);
            Trace.AutoFlush = true;
        }

        public static void deinitialize()
        {
            Trace.Close();
        }

        public static void Error(string message)
        {
            Error("GUI", message, null);
        }

        public static void Error(string area, string message)
        {
            Error(area, message, null);
        }

        public static void Error(string message, Exception exception)
        {
            Error("GUI", message, exception);
        }

        public static void Error(string area, string message, Exception exception)
        {
            // Do not log "iMonNotResponding" messages when forbidden
            if (iMonNotRespondingLog == false && message.Contains("iMonNotResponding"))
            {
                return;
            }

            //if (Settings.Default.GeneralDebugEnable)
            //{
            //    Log(area, "ERROR " + message, exception);
            //    return;
            //}

            // New logging mechanism
            Trace.TraceError("{0} [{1}] {2}", DateTime.Now, area, message);
            if (exception != null)
            {
                Trace.TraceError("    {0}: {1}" + Environment.NewLine +
                                 "         {2}", exception.GetType().Name, exception.Message, exception.StackTrace);
            }

            //try 
            //{
            //    using (StreamWriter file = new StreamWriter(ErrorLog, true, Encoding.UTF8))
            //    {
            //        file.WriteLine("{0} [{1}] {2}", DateTime.Now, area, message);
            //        if (exception != null)
            //        {
            //            file.WriteLine("    {0}: {1}" + Environment.NewLine +
            //                           "         {2}", exception.GetType().Name, exception.Message, exception.StackTrace);
            //        }
            //    }
            //}
            //catch (Exception)
            //{ }
        }

        public static void Log(string message)
        {
            Log("GUI", message, null);
        }

        public static void Log(string area, string message)
        {
            Log(area, message, null);
        }

        public static void Log(string message, Exception exception)
        {
            Log("GUI", message, exception);
        }

        public static void Log(string area, string message, Exception exception)
        {
            if (!Settings.Default.GeneralDebugEnable)
            {
                return;
            }

            // Do not log "iMonNotResponding" messages when forbidden
            if (iMonNotRespondingLog == false && message.Contains("iMonNotResponding"))
            {
                return;
            }

            // New logging mechanism
            Trace.TraceInformation("{0} [{1}] {2}", DateTime.Now, area, message);
            if (exception != null)
            {
                Trace.TraceInformation("    {0}: {1}" + Environment.NewLine +
                                       "         {2}", exception.GetType().Name, exception.Message, exception.StackTrace);
            }

            //try
            //{
            //    using (StreamWriter file = new StreamWriter(DebugLog, true, Encoding.UTF8))
            //    {
            //        file.WriteLine("{0} [{1}] {2}", DateTime.Now, area, message);
            //        if (exception != null)
            //        {
            //            file.WriteLine("    {0}: {1}" + Environment.NewLine +
            //                           "         {2}", exception.GetType().Name, exception.Message, exception.StackTrace);
            //        }
            //    }
            //}
            //catch (Exception)
            //{ }
        }

        #endregion
    }
}
