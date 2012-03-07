using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace iMon.XBMC
{
    internal static class Updating
    {
        # region Constants

        private const string ChangelogFile = "CHANGELOG";
        private const string ChangelogUrl = "https://raw.github.com/BlackMan82/xbmc-on-imon/master/";
        private const string UpdateBaseUrl = "https://github.com/downloads/BlackMan82/";
        private const string ProjectName = "xbmc-on-imon";
        //private const string VersionNumberIndicator = "*";
        private const string VersionNumberIndicator = "v";
        //private const int VersionNumberPosition = 1;
        private const int VersionNumberPosition = 0;

        private const string LoggingArea = "Update";

        # endregion

        # region Private variables

        private static Version currentVersion;
        private static Version newestVersion;

        # endregion

        # region Constructor

        static Updating()
        {
            Updating.currentVersion = new Version(Assembly.GetExecutingAssembly().GetName().Version.ToString());
            
            // For testing purposes only
            //Updating.currentVersion = new Version("0.1.8.0");
        }

        # endregion

        # region Private functions

        private static string getDownloadUrl()
        {
            return UpdateBaseUrl + ProjectName + "/" + ProjectName + "-v" + newestVersion.ToString() + ".zip";
        }

        private static bool getNewestVersionNumber()
        {
            WebResponse response;
            string sourceUrl = ChangelogUrl + ChangelogFile;
            string line;
            bool result = false;
            WebRequest request = WebRequest.Create(sourceUrl);

            Logging.Log(LoggingArea, "Source for updates: " + sourceUrl);
            
            try
            {
                response = request.GetResponse();
            }
            catch (WebException ex)
            {
                Logging.Error(LoggingArea, ex.Message);
                return result;
            }

            Logging.Log(LoggingArea, "CHANGELOG found");
            
            StreamReader reader = new StreamReader(response.GetResponseStream());
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                if (line.StartsWith(VersionNumberIndicator))
                {
                    Logging.Log(LoggingArea, "Version number found, trying to parse: " + line);
                    try
                    {
                        string versionNumber = line.Split(' ')[VersionNumberPosition].Substring(1);
                        Updating.newestVersion = new Version(versionNumber);
                        //Version.TryParse(versionNumber, out Updating.newestVersion);
                    }
                    catch (Exception)
                    {
                        result = false;
                        Logging.Error(LoggingArea, "Version number parsing failed");
                        continue;
                    }
                    
                    result = true;
                    Logging.Log(LoggingArea, "Latest version number parsed: " + newestVersion);
                    break;
                }
            }

            if (!result)
                Logging.Error(LoggingArea, "Version number not found!");
            
            return result;

            //Updating.newestVersion = new Version(reader.ReadLine()); // the first line in the file is a version number
            //Updating.dNewestVersion = double.Parse(Updating.sNewestVersion, CultureInfo.InvariantCulture);
            //string Link = reader.ReadLine(); // the second line in the file is a link to the latest update
        }

        # endregion

        # region Public functions

        public static bool update(bool automaticUpdate)
        {
            bool updateIsAvailable = false;

            Logging.Log(LoggingArea, "Checking for update");

            if (!getNewestVersionNumber())
                return false;

            if (Updating.newestVersion > Updating.currentVersion)
            {
                updateIsAvailable = true;
                Logging.Log(LoggingArea, "Update available");
                if (MessageBox.Show("An update is available! (" + Updating.newestVersion.ToString() + ")\nDo you wish to download it?", Assembly.GetExecutingAssembly().GetName().Name + ": Update available", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    Process.Start(Updating.getDownloadUrl());
                }

            }
            else
            {
                updateIsAvailable = false;
                Logging.Log(LoggingArea, "Update not available");
                if (!automaticUpdate)
                    MessageBox.Show("You are using the most up to date version!", Assembly.GetExecutingAssembly().GetName().Name + ": Update not available");
            }

            return updateIsAvailable;
        }

        # endregion
    }
}
