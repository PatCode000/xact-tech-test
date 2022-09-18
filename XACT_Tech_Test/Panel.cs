using System;
namespace XACT_Tech_Test
{
    /// <summary>
    /// Class <c>Panel</c> contains information about all layers in this panel.
    /// </summary>
    public class Panel
    {
        public List<Layer> m_layers;

        /// <summary>
        /// Constructor <c>Panel</c> creates panel object.
        /// </summary>
        public Panel()
        {
            m_layers = new List<Layer>();
        }
    }
}