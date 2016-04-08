using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sandbox
{
    class Program
    {
        static public void Main(string path)
        {

            var reader = new StreamReader(File.OpenRead(path));
            List<string> dateString = new List<string>();
            List<string> sizeString = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                dateString.Add(values[0]);
                sizeString.Add(values[1]);
            }
            List<DateTime> xvals = dateString.Select(date => DateTime.Parse(date)).ToList();
            List<int> yvals = sizeString.Select(int.Parse).ToList();

            // create the chart
            var chart = new Chart();
            chart.Size = new Size(800, 450);

            var chartArea = new ChartArea();
            chartArea.AxisX.LabelStyle.Format = "dd/MMM\nhh:mm";
            chartArea.AxisY.Title ="Model Size in MB)";
            //chartArea.AxisY.LabelStyle.Format = "{0}MB";
            chartArea.AxisX.MajorGrid.LineColor = Color.White;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 8);
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
            chart.ChartAreas.Add(chartArea);

            var series = new Series();
            series.Name = "Series1";
            series.ChartType = SeriesChartType.FastLine;
            series.XValueType = ChartValueType.DateTime;
            series.BorderWidth = 2;
            chart.Series.Add(series);

            // bind the datapoints
            chart.Series["Series1"].Points.DataBindXY(xvals, yvals);

            // draw!
            chart.Invalidate();

            // write out a file
            chart.SaveImage(@"C:\Temp\chart.png", ChartImageFormat.Png);
        }
    }
}