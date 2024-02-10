using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSBlazorCharts
{
    /// <summary>
    /// A class representing a single dataset
    /// </summary>
    public sealed class LineChartDataSet<XType, YType>
    {
        /// <summary>
        /// The number of points on the graph.
        /// </summary>
        public LineChartDataPoint<XType, YType>[] Points { get; set; }

        /// <summary>
        /// Constructs a dataset with the given points
        /// </summary>
        /// <param name="points">The points on the graph.</param>
        public LineChartDataSet(params LineChartDataPoint<XType, YType>[] points)
        {
            Points = points;
        }

        public void SortByX()
        {
            var pointList = Points.ToList();
            pointList.Sort((x, y) => (dynamic)x.X < y.X ? -1 : (dynamic)x.X == y.X ? 0 : 1);
            Points = pointList.ToArray();
        }
    }
}
