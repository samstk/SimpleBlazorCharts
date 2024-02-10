using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSBlazorCharts
{
    /// <summary>
    /// Represents a single data point on the graph.
    /// </summary>
    public struct LineChartDataPoint<XType, YType>
    {
        /// <summary>
        /// The X-axis value for this point
        /// </summary>
        public XType X { get; set; }

        public YType Y { get; set; }

        public LineChartDataPoint(XType x, YType y)
        {
            X = x;
            Y = y;
        }
    }
}
