using LiveCharts.Wpf;
using LiveCharts;
using System.Windows.Controls;
using System.Windows.Media;
using System;
using System.Collections.Generic;
using WpfApp_Klimchenya.Model;

namespace WpfApp_Klimchenya
{
    public partial class PointShapeLineExample : UserControl
    {

        public PointShapeLineExample()
        {
            SeriesCollection = new SeriesCollection
            {
                
            };

            Labels = new[]
            {
                "1", "2" , "3" , "4" , "5" , "6" , "7" , "8" , "9" , "10",
                "11", "12" , "13" , "14" , "15" , "16" , "17" , "18" , "19" , "20",
                "21", "22" , "23" , "24" , "25" , "26" , "27" , "28" , "29" , "30"
            };
            YFormatter = value => value.ToString("C");

            //modifying the series collection will animate and update the chart
            //SeriesCollection.Add(new LineSeries
            //{
            //    Title = "Series 4",
            //    Values = new ChartValues<double> { 5, 3, 2, 4 },
            //    LineSmoothness = 0, //0: straight lines, 1: really smooth lines
            //    PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
            //    PointGeometrySize = 50,
            //    PointForeground = Brushes.Gray
            //});

            //modifying any series values will also animate and update the chart
            //SeriesCollection[3].Values.Add(5d);

            DataContext = this;
        }

        public PointShapeLineExample(List<DayStatistics> list)
        {

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Шагов в этот день:",
                    Values = Converter.ListToChartValues(list)
                }
            };

            Labels = new[]
            {
                "1", "2" , "3" , "4" , "5" , "6" , "7" , "8" , "9" , "10",
                "11", "12" , "13" , "14" , "15" , "16" , "17" , "18" , "19" , "20",
                "21", "22" , "23" , "24" , "25" , "26" , "27" , "28" , "29" , "30"
            };
            YFormatter = value => value.ToString("F1");
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }


    }
}

