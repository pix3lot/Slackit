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
        /// <summary>
        /// Int Giphy Setting
        /// </summary>
        public static int giphySet { get; set; }
        /// <summary>
        /// Int CleanUp Setting
        /// </summary>
        public static int tidySet { get; set; }
        /// <summary>
        /// Bool Slack Setting Post Worksharing Warnings
        /// </summary>
        public static bool slackWSWarn { get; set; }
        /// <summary>
        /// Bool Slack Setting Post Model Warnings
        /// </summary>
        public static bool slackModelWarn { get; set; }
        /// <summary>
        /// Bool Slack Setting Post Best Practices Warnings
        /// </summary>
        public static bool slackBPWarn { get; set; }
        /// <summary>
        /// Bool Slack Setting Post Worksharing Info
        /// </summary>
        public static bool slackWSInfo{ get; set; }
        /// <summary>
        /// Bool Slack Setting Post Model Info
        /// </summary>
        public static bool slackModelInfo { get; set; }
        /// <summary>
        /// Bool Slack Setting Post Best Practices Info
        /// </summary>
        public static bool slackBPInfo { get; set; }
        /// <summary>
        /// Bool Slack Setting Post Tracking Info - Pinned Elements
        /// </summary>
        public static bool slackExtraTrackPin { get; set; }
        /// <summary>
        /// String Link to Revit Icon
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
        /// <summary>
        /// String File Name
        /// </summary>
        public static string logFileName { get; set; }
        /// <summary>
        /// String Local File Path
        /// </summary>
        public static string logFilePath { get; set; }
        /// <summary>
        /// Long File Size
        /// </summary>
        public static long logFileSize { get; set; }
        /// <summary>
        /// String Central File Path
        /// </summary>
        public static string logFileCentral { get; set; }
        /// <summary>
        /// String Central File Name
        /// </summary>
        public static string logFileCentralName { get; set; }
        /// <summary>
        /// String Revit Version Number
        /// </summary>
        public static string logVersionNumber { get; set; }
        /// <summary>
        /// String Revit Build Number
        /// </summary>
        public static string logVersionBuild { get; set; }
        /// <summary>
        /// String Revit Version Name
        /// </summary>
        public static string logVersionName { get; set; }
        /// <summary>
        /// Boolean Created Local File
        /// </summary>
        public static bool logCreatedLocal { get; set; }
        /// <summary>
        /// DateTime Open Start
        /// </summary>
        public static DateTime logOpenStart { get; set; }
        /// <summary>
        /// DateTime Open End
        /// </summary>
        public static DateTime logOpenEnd { get; set; }
        /// <summary>
        /// TimeSpan Open Duration
        /// </summary>
        public static TimeSpan logOpenDuration { get; set; }
        /// <summary>
        /// DateTime Sync Start
        /// </summary>
        public static DateTime logSyncStart { get; set; }
        /// <summary>
        /// DateTime Sync End
        /// </summary>
        public static DateTime logSyncEnd { get; set; }
        /// <summary>
        /// TimeSpan Sync Duration
        /// </summary>
        public static TimeSpan logSyncDuration { get; set; }
        /// <summary>
        /// Boolean Changes Saved to Central
        /// </summary>
        public static bool logChangesSaved { get; set; }
        /// <summary>
        /// Boolean File is Central File
        /// </summary>
        public static bool logIsCentral { get; set; }
        /// <summary>
        /// Boolean File is Workshared
        /// </summary>
        public static bool logIsWorkshared { get; set; }
        /// <summary>
        /// String Sync Comments
        /// </summary>
        public static string logSyncComments { get; set; }

        public static string defNameSettings = "SlackitSettings";
    }
   
}
