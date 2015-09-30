using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.ExtensibleStorage;
using System.Windows;
using System.Windows.Forms;
using Slack;
using SlackitRevit;


namespace SlackitRevit
{
    [Transaction(TransactionMode.Manual)]

    public class CaptureCommand : IExternalCommand
    {
        public static List<string> chlist { get; set; }
        public static Dictionary<string, string> chdict { get; set; }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            System.Drawing.Rectangle bounds = Screen.GetBounds(System.Drawing.Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(System.Drawing.Point.Empty, System.Drawing.Point.Empty, bounds.Size);
                }
                bitmap.Save("C://SceenCapture.jpg", ImageFormat.Jpeg);
            }

            FileStream str = File.OpenRead("C://SceenCapture.jpg");
            byte[] fBytes = new byte[str.Length];
            str.Read(fBytes, 0, fBytes.Length);
            str.Close();

            var webClient = new WebClient();
            string boundary = "------------------------" + DateTime.Now.Ticks.ToString("x");
            webClient.Headers.Add("Content-Type", "multipart/form-data; boundary=" + boundary);
            var fileData = webClient.Encoding.GetString(fBytes);
            var package = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"file\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n{3}\r\n--{0}--\r\n", boundary, "Testing.txt", "multipart/form-data", fileData);

            var nfile = webClient.Encoding.GetBytes(package);
            string url = "https://slack.com/api/files.upload?token=" + Variables.slackToken + "&content=" + nfile + "&channels=[" + Variables.slackChId + "]";

            byte[] resp = webClient.UploadData(url, "POST", nfile);

            var k = System.Text.Encoding.Default.GetString(resp);
            Console.WriteLine(k);
            Console.ReadKey();

            return Result.Succeeded;
        }

}
    }
