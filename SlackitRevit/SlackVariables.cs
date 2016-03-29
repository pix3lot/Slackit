using System;
using System.Collections.Generic;


namespace SlackitRevit
{
    public class Variables
    {
        /// <summary>
        /// Boolean Slackit Enabled
        /// </summary>
        public static bool slackOn { get; set; }
        /// <summary>
        /// String Slackit Channel Name
        /// </summary>
        public static string slackCh { get; set; } 
        /// <summary>
        /// String Slackit Channel Id
        /// </summary>
        public static string slackChId { get; set; }
        /// <summary>
        /// String Slack Token
        /// </summary>
        public static string slackToken { get; set; }
        ///// <summary>
        ///// List Slack Channel Names
        ///// </summary>
        //public static List<string> slackChannelName { get; set; }
        ///// <summary>
        ///// Dictionary Slack Channel Name & Id
        ///// </summary>
        //public static Dictionary<string, string> slackChannelNameId { get; set; }


        /// <summary>
        /// Link to Revit Icon
        /// </summary>
        public static string icon_revit = "https://s3-us-west-2.amazonaws.com/slack-files2/avatars/2015-02-16/3737857601_ca8f67ca94b70a4b554d_48.jpg";

        private const string dir_temp = "C:/Temp/";
        /// <summary>
        /// String Username
        /// </summary>
        public static string logUsername { get; set; }
        /// <summary>
        /// String Computer Name
        /// </summary>
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
        public static bool giphyOn { get; internal set; }

        public static string defNameSettings = "SlackitSettings";
        public static string spFilePath = dir_temp + "sp.txt";
        public static string groupName = "Slackit";
    }
   
}
