using System;



namespace XACT_Tech_Test
{
    public class DataPreparer
    {
        TextWriter m_myTextWriter = new TextWriter();

        public DataPreparer()
        {
            Console.WriteLine("RUN DATA PREPARER");
        }

        public void PreparePanelTable(List<Panel> _data)
        {
            List<List<decimal>> m_panels = new List<List<decimal>>();

            foreach (Panel panel in _data)
            {
                List<decimal> m_panelDeviationLines = new List<decimal>();
                foreach (Layer layer in panel.m_layers)
                {
                    foreach (Corner corner in layer.m_corners)
                    {
                        m_panelDeviationLines.Add(corner.m_deviationLine);
                    }
                }
                m_panels.Add(m_panelDeviationLines);
            }

            // WRITE DATA TO FILE
            string[] textLines = new string[m_panels.Count + 1];

            string header = "Panel No: | Minimum | Maximum | Mean | Median";
            textLines[0] = header;

            for (int i = 0; i < m_panels.Count; i++)
            {
                decimal t_minimum = Math.Round(MathCalculations.GetMinimum(m_panels[i]), 4);
                decimal t_maximum = Math.Round(MathCalculations.GetMaximum(m_panels[i]), 4);
                decimal t_mean = Math.Round(MathCalculations.GetMean(m_panels[i]), 4);
                decimal t_mediana = Math.Round(MathCalculations.GetMediana(m_panels[i]), 4);

                string panelText = "Panel " + i + " | " + t_minimum + " | " + t_maximum + " | " + t_mean + " | " + t_mediana;
                textLines[i + 1] = panelText;
            }

            m_myTextWriter.WriteToFile("Panel_table",textLines);
        }

        public void PrepareLayerTable(List<Panel> _data)
        {
            // Get layers type
            
            List<string> l_layersType = new List<string>();

            for (int i=0; i<_data[0].m_layers.Count;i++)
            {
                l_layersType.Add(_data[0].m_layers[i].m_layerName);
            }

            List<decimal>[] layersTable = new List<decimal>[_data[0].m_layers.Count];
            for (int i=0; i< layersTable.Length;i++)
            {
                layersTable[i] = new List<decimal>();
            }            

            foreach (Panel panel in _data)
            {
                for (int i=0; i< panel.m_layers.Count;i++)
                {
                    foreach (Corner corner in panel.m_layers[i].m_corners)
                    {
                        layersTable[i].Add(corner.m_deviationLine);
                    }
                }
            }

            // WRITE DATA TO FILE
            string[] textLines = new string[layersTable.Length + 1];

            string header = "Layer No: | Minimum | Maximum | Mean | Median";
            textLines[0] = header;

            for (int i = 0; i < layersTable.Length; i++)
            {
                decimal t_minimum = Math.Round(MathCalculations.GetMinimum(layersTable[i]), 4);
                decimal t_maximum = Math.Round(MathCalculations.GetMaximum(layersTable[i]), 4);
                decimal t_mean = Math.Round(MathCalculations.GetMean(layersTable[i]), 4);
                decimal t_mediana = Math.Round(MathCalculations.GetMediana(layersTable[i]), 4);

                string panelText = "Layer " + l_layersType[i] + " | " + t_minimum + " | " + t_maximum + " | " + t_mean + " | " + t_mediana;
                textLines[i + 1] = panelText;
            }

            m_myTextWriter.WriteToFile("Layer_table", textLines);
        }

        public void PrepareCornerTable(List<Panel> _data)
        {
            // Get layers type

            string[] l_cornersType = new string[] { "TL", "TR", "BR", "BL" };

            List<decimal>[] cornersTable = new List<decimal>[_data[0].m_layers[0].m_corners.Length];

            for (int i = 0; i < cornersTable.Length; i++)
            {
                cornersTable[i] = new List<decimal>();
            }

            foreach (Panel panel in _data)
            {
                //for (int i = 0; i < panel.m_layers.Count; i++)
                foreach (Layer layer in panel.m_layers)
                {
                    //foreach (Corner corner in panel.m_layers[i].m_corners)
                    for (int i=0; i<layer.m_corners.Length;i++)
                    {
                        cornersTable[i].Add(layer.m_corners[i].m_deviationLine);
                    }
                }
            }

            // WRITE DATA TO FILE
            string[] textLines = new string[cornersTable.Length + 1];

            string header = "Corner: | Minimum | Maximum | Mean | Median";
            textLines[0] = header;

            for (int i = 0; i < cornersTable.Length; i++)
            {
                decimal t_minimum = Math.Round(MathCalculations.GetMinimum(cornersTable[i]), 4);
                decimal t_maximum = Math.Round(MathCalculations.GetMaximum(cornersTable[i]), 4);
                decimal t_mean = Math.Round(MathCalculations.GetMean(cornersTable[i]), 4);
                decimal t_mediana = Math.Round(MathCalculations.GetMediana(cornersTable[i]), 4);

                string panelText = "Corner " + l_cornersType[i] + " | " + t_minimum + " | " + t_maximum + " | " + t_mean + " | " + t_mediana;
                textLines[i + 1] = panelText;
            }

            m_myTextWriter.WriteToFile("Corner_table", textLines);
        }
    }
}

