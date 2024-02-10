using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SSBlazorCharts
{
    /// <summary>
    /// Represents the data of a line chart
    /// </summary>
    /// <typeparam name="XType">The type of the x-axis data</typeparam>
    /// <typeparam name="YType">The type of the y-axis data</typeparam>
    /// <remarks>
    /// Both typeparams must support the following operators (&lt; &gt; / * - +)
    /// </remarks>
    public sealed class LineChartData<XType, YType>
    {
        /// <summary>
        /// The data sets contained within this line chart
        /// </summary>
        public LineChartDataSet<XType, YType>[] DataSets { get; private set; }

        public XType? MaxXValue { get; private set; }

        public XType? MinXValue { get; private set; }

        public YType? MaxYValue { get; private set; }

        public YType? MinYValue { get; private set; }

        public LineChartData(params LineChartDataSet<XType, YType>[] dataSets)
        {
            DataSets = dataSets;

            bool hasValue = false;
            MinXValue = default(XType);
            MaxXValue = default(XType);
            MinYValue = default(YType);
            MaxYValue = default(YType);

            // Find first point
            foreach (var dataset in dataSets)
            {
                foreach (var point in dataset.Points)
                {
                    MinXValue = MaxXValue = point.X;
                    MinYValue = MaxYValue = point.Y;
                    break;
                }
            }

            // Find min/max
            foreach (var dataset in dataSets)
            {
                foreach(var point in dataset.Points)
                {
                    if ((dynamic)point.X < MinXValue)
                    {
                        MinXValue = point.X;
                    }

                    if ((dynamic)point.X > MaxXValue)
                    {
                        MaxXValue = point.X;
                    }

                    if ((dynamic)point.Y < MinYValue)
                    {
                        MinYValue = point.Y;
                    }

                    if ((dynamic)point.Y > MaxYValue)
                    {
                        MaxYValue = point.Y;
                    }
                }
            }
        }
    }
}
