#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace SlackitRevit
{
    public class SlackRibbon : IExternalApplication
    {
        #if RELEASE2015
                        const string assemblyDir = @"C:\ProgramData\Autodesk\Revit\Addins\2015\";
                        const string imageDir = @"C:\ProgramData\Autodesk\Revit\Addins\2015\";
        #elif RELEASE2016
                        const string assemblyDir = @"C:\ProgramData\Autodesk\Revit\Addins\2016\";
                        const string imageDir = @"C:\ProgramData\Autodesk\Revit\Addins\2016\";
        #elif RELEASE2017
                        const string assemblyDir = @"C:\ProgramData\Autodesk\Revit\Addins\2017\";
                        const string imageDir = @"C:\ProgramData\Autodesk\Revit\Addins\2017\";
        #else
                const string assemblyDir = @"C:\ProgramData\Autodesk\Revit\Addins\2018\";
                const string imageDir = @"C:\ProgramData\Autodesk\Revit\Addins\2018\";
        #endif

        public Result OnStartup(UIControlledApplication app)
        {
            RibbonPanel ribbonPanelTools = app.CreateRibbonPanel("Slackit");

            PushButton pushBtnSlackSettings = ribbonPanelTools.AddItem(new PushButtonData("SlackitSettings", "Settings", assemblyDir + "SlackitRevit.dll", "SlackitRevit.SlackCommand")) as PushButton;
            pushBtnSlackSettings.LargeImage = new BitmapImage(new Uri(imageDir + "SlackitLogo_32.png"));

            PushButton pushBtnSlackCapture = ribbonPanelTools.AddItem(new PushButtonData("SlackitCapture", "Screenshot", assemblyDir + "SlackitRevit.dll", "SlackitRevit.CaptureCommand")) as PushButton;
            pushBtnSlackCapture.LargeImage = new BitmapImage(new Uri(imageDir + "SlackitLogo_32.png"));

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication app)
        {
            return Result.Succeeded;
        }

    }

}