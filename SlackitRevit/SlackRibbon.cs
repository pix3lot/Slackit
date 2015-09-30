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
    [Transaction(TransactionMode.Automatic)]

    public class SlackRibbon : IExternalApplication
    {
        const string assemblyDir = @"C:\ProgramData\Autodesk\Revit\Addins\2015\";
        const string imageDir = @"C:\ProgramData\Autodesk\Revit\Addins\2015\";

        public Result OnStartup(UIControlledApplication app)
        {
            RibbonPanel ribbonPanelTools = app.CreateRibbonPanel("Slacker");

            PushButton pushBtnSlackSettings = ribbonPanelTools.AddItem(new PushButtonData("SlackSettings", "Slacker\nSettings", assemblyDir + "SlackitRevit.dll", "SlackitRevit.SlackCommand")) as PushButton;
            pushBtnSlackSettings.LargeImage = new BitmapImage(new Uri(imageDir + "SlackPost_32.png"));

            PushButton pushBtnSlackCapture = ribbonPanelTools.AddItem(new PushButtonData("SlackPost", "Send\nScreenShot", assemblyDir + "SlackitRevit.dll", "SlackitRevitk.CaptureCommand")) as PushButton;
            pushBtnSlackCapture.LargeImage = new BitmapImage(new Uri(imageDir + "SlackPost_32.png"));

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication app)
        {
            return Result.Succeeded;
        }

    }

}