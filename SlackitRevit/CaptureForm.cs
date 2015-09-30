using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using RevitEvents;

namespace RevitSlack
{
    public partial class CaptureForm : Form
    {
        public CaptureForm()
        {
            this.InitializeComponent();
//Hide the Form
this.Hide();
//Create the Bitmap
Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, 
                         Screen.PrimaryScreen.Bounds.Height);
//Create the Graphic Variable with screen Dimensions
Graphics graphics = Graphics.FromImage(printscreen as Image);
//Copy Image from the screen
graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
//Create a temporal memory stream for the image
using (MemoryStream s = new MemoryStream())
{
    //save graphic variable into memory
    printscreen.Save(s, ImageFormat.Bmp);                
    pictureBox1.Size = new System.Drawing.Size(this.Width, this.Height);
    //set the picture box with temporary stream
    pictureBox1.Image = Image.FromStream(s);
}
//Show Form
this.Show();
//Cross Cursor
Cursor = Cursors.Cross;
        }

            int selectX;
            int selectY;
            int selectWidth;
            int selectHeight;            
            public Pen selectPen;        

            //This variable control when you start the right click
            bool start = false;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //validate if there is an image
            if (pictureBox1.Image == null)
                return;            
            //validate if right-click was trigger
            if(start)
            {
                //refresh picture box
                pictureBox1.Refresh();
                //set corner square to mouse coordinates
                selectWidth = e.X - selectX;
                selectHeight = e.Y - selectY;
                //draw dotted rectangle
                pictureBox1.CreateGraphics().DrawRectangle(selectPen, selectX, selectY, selectWidth, selectHeight);
            }
        }

private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
{
    //validate when user right-click
    if (!start)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            //starts coordinates for rectangle
            selectX = e.X;
            selectY = e.Y;
            selectPen = new Pen(Color.Red, 1);
            selectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
        }
        //refresh picture box
        pictureBox1.Refresh();
        //start control variable for draw rectangle
        start = true;
    }
    else
    {
        //validate if there is image
        if (pictureBox1.Image == null)
            return;
        //same functionality when mouse is over
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            pictureBox1.Refresh();
            selectWidth = e.X - selectX;
            selectHeight = e.Y - selectY;
            pictureBox1.CreateGraphics().DrawRectangle(selectPen, selectX, 
                     selectY, selectWidth, selectHeight);

        }
        start = false;
        //function save image to clipboard
        SaveToClipboard();            
    }
}

private void SaveToClipboard()
{
    //validate if something selected
    if (selectWidth > 0)
    {

        Rectangle rect = new Rectangle(selectX, selectY, selectWidth, selectHeight);
        //create bitmap with original dimensions
        Bitmap OriginalImage = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
        //create bitmap with selected dimensions
        Bitmap _img = new Bitmap(selectWidth, selectHeight);
        _img.Save(@"C:\SceenCapture.png", System.Drawing.Imaging.ImageFormat.Png);
        //create graphic variable
        Graphics g = Graphics.FromImage(_img);
        //set graphic attributes
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);                
        //insert image stream into clipboard
        Clipboard.SetImage(_img);
                    FileStream str = File.OpenRead(@"C:\SceenCapture.png");
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
    } 
    //End application
    Application.Exit();
}
        }
    }

