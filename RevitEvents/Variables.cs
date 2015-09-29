using System;


namespace RevitEvents
{
    public class Variables
    {
         private const string dir_temp = "C:/Temp/";

        public static bool slackOn { get; set; } //= true;
        public static string slackCh { get; set; } //= "general";
        public static string slackChId { get; set; } //= "C0BC63KNC"
        public static string slackToken = "xoxp-11410297940-11416830641-11417591522-b23d6b3c8a";//{ get; set; }
        public static string icon_revit_slacker = "https://s3-us-west-2.amazonaws.com/slack-files2/avatars/2015-02-16/3737857601_ca8f67ca94b70a4b554d_48.jpg";

        //Variables to log
        public static string logUsername { get; set; }
        public static string logComputerName { get; set; }

        public static string logFileName { get; set; }
        public static string logFilePath { get; set; }
        public static long logFileSize { get; set; }
        public static string logFileCentral { get; set; }
        public static string logFileCentralName { get; set; }

        public static string logVersionNumber { get; set; }
        public static string logVersionBuild { get; set; }
        public static string logVersionName { get; set; }
        public static bool logCreatedLocal { get; set; }

        public static DateTime logOpenStart { get; set; }
        public static DateTime logOpenEnd { get; set; }
        public static TimeSpan logOpenDuration { get; set; }

        public static DateTime logSyncStart { get; set; }
        public static DateTime logSyncEnd { get; set; }
        public static TimeSpan logSyncDuration { get; set; }

        public static bool logChangesSaved { get; set; }
        public static bool logIsCentral { get; set; }
        public static bool logIsWorkshared { get; set; }

        public static string logSyncComments { get; set; }

        public static string defNameSettings = "SlackerSettings";
        public static string spFilePath = dir_temp + "sp.txt";
        public static string groupName = "Slacker";

    }
}
