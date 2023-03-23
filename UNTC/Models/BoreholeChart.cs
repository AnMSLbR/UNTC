using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System;
using System.Windows.Media;

namespace UNTC.Models
{
    internal class BoreholeChart
    {
        public SeriesCollection SeriesCollection { get; set; }

        public BoreholeChart()
        {
            var BoreholeChartPointMapper = Mappers.Xy<BoreholeChartPoint>()
                .X(value => value.Depth)
                .Y(value => value.Pressure);
            Charting.For<BoreholeChartPoint>(BoreholeChartPointMapper);
        }

        public void Build(Borehole borehole)
        {
            if (borehole?.PressureAtStep != null)
            {
                SeriesCollection = new SeriesCollection()
                {
                    new LineSeries
                    {
                        Title = borehole.Title,
                        Values = GetChartValues(borehole),
                        Fill = Brushes.Transparent,
                        Stroke = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF73549A"),
                        PointGeometrySize = 10,
                    }
                };
            }
        }

        private ChartValues<BoreholeChartPoint> GetChartValues(Borehole borehole)
        {
            var count = borehole.PressureAtStep.Length;
            var points = new BoreholeChartPoint[count];
            for (int i = 0; i < count; i++)
            {
                points[i] = new BoreholeChartPoint() { Pressure = borehole.PressureAtStep[i], Depth = borehole.DepthAtStep[i] };
            }
            return new ChartValues<BoreholeChartPoint>(points);
        }
    }
}
