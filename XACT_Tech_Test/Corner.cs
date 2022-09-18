using System;
using System.Diagnostics.Metrics;

namespace XACT_Tech_Test
{
    /// <summary>
    /// Class <c>Corner</c> models a corner in a two-dimensional plane.
    /// Storing nominal values for coordinates.
    /// </summary>
    public class Corner
    {
        public decimal m_actualX { get; private set; }
        public decimal m_actualY { get; private set; }
        public decimal m_nominalX { get; private set; }
        public decimal m_nominalY { get; private set; }
        public decimal m_deviationLine { get; private set; }

        /// <summary>
        /// Constructor <c>Corner</c> creates corner object.
        /// </summary>
        /// <param name="_actualX">the actual x-coordinate.</param>
        /// <param name="_actualY">the actual y-coordinate.</param>
        /// <param name="_nominalX">the nominal x-coordinate.</param>
        /// <param name="_nominalY">the nominal y-coordinate.</param>
        public Corner(decimal _actualX, decimal _actualY, decimal _nominalX, decimal _nominalY)
        {
            m_actualX = _actualX;
            m_actualY = _actualY;
            m_nominalX = _nominalX;
            m_nominalY = _nominalY;
            m_deviationLine = MathCalculations.GetDistance(m_actualX, m_actualY, m_nominalX, m_nominalY);
        }
    }
}