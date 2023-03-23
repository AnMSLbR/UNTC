using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows.Media;

namespace UNTC.Models
{
    internal class BoreholeChart
    {
        private Borehole _borehole;
        private int _pointCount;
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public BoreholeChart() { }

        public BoreholeChart(Borehole borehole, int pointCount)
        {
            _borehole = borehole;
            _pointCount = pointCount;
            Build(_borehole, _pointCount);
        }

        public void Build(Borehole borehole, int pointCount)
        {
            if (borehole?.Pressure != null)
            {
                SeriesCollection = new SeriesCollection()
                {
                    new LineSeries
                    {
                        //Title = borehole.Title,
                        Values = new ChartValues<double>(borehole.Pressure),
                        Fill = Brushes.Transparent,
                        Stroke = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF73549A"),
                    }
                };

                Labels = CalculateDepthLabels(borehole, pointCount);

                YFormatter = value => value.ToString();
            }
        }

        private string[] CalculateDepthLabels(Borehole borehole, int pointCount)
        {
            var labels = new string[pointCount + 2];
            labels[0] = "0";
            var step = borehole.Depth / pointCount;
            for (int i = 1; i <= pointCount; i++)
            {
                labels[i] = (step * i).ToString();
            }
            labels[pointCount + 1] = borehole.Depth.ToString();

            return labels;
        }
    }
}
