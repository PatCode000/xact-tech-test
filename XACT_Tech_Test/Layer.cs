/// Author: Patryk Stachowiak

using System;
namespace XACT_Tech_Test
{
    /// <summary>
    /// Class <c>Layer</c> models a single layer for the panel.
    /// Layer class contains information about four corners.
    /// </summary>
    public class Layer
    {
        public string m_layerName { get; private set; }
        public Corner[] m_corners { get; private set; }

        /// <summary>
        /// Constructor <c>Layer</c> creates Layer object.
        /// </summary>
        public Layer(string _layerName, Corner _TL, Corner _TR, Corner _BR, Corner _BL)
        {
            m_layerName = _layerName;
            m_corners = new Corner[4];
            m_corners[0] = _TL;
            m_corners[1] = _TR;
            m_corners[2] = _BR;
            m_corners[3] = _BL;
        }
    }
}