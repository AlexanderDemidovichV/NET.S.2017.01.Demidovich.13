using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Represents abstract shape
    /// </summary>
    public abstract class Figure
    {

        /// <summary>
        /// Foursquare of shape
        /// </summary>
        public abstract double Area();

        /// <summary>
        /// Perimeter of shape
        /// </summary>
        public abstract double Perimeter();
    }
}
