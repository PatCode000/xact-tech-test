using System;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace XACT_Tech_Test
{
    public class TextLoader
    {
        StreamReader m_streamReader;

        public TextLoader()
        {
            Debug.WriteLine("START TEXT LOADER");
        }

        public List<Panel> LoadData()
        {
            List<Panel> m_panelList = new List<Panel>();

            int l_panelCounter = 0;
            int l_cornerCounter = 0;

            try
            {
                using (m_streamReader = new StreamReader("10001-8.txt"))
                {
                    Panel t_panel = new Panel();
                    Corner[] t_corners = new Corner[4];

                    bool l_endOfFile = false;

                    while (!l_endOfFile)
                    {
                        string l_dataString = m_streamReader.ReadLine();

                        if (l_dataString == null)
                        {
                            m_panelList.Add(t_panel);
                            l_endOfFile = true;
                            return m_panelList;
                        }

                        string sep = "\t";
                        string[] splitContent = l_dataString.Split(sep.ToCharArray());

                        // Check if next panel
                        if (splitContent[0][0].Equals('F'))
                        {
                            l_panelCounter++;

                            if (l_panelCounter == 1)
                            {
                                continue; // skip the first line
                            } else
                            {
                                m_panelList.Add(t_panel);
                                t_panel = new Panel(); // Create new panel
                            }
                        } else
                        {
                            string[] t_layerInfo = splitContent[0].Split("_");
                            string t_layerNo = "";
                            decimal t_actualX = 0.0m;
                            decimal t_actualY = 0.0m;
                            decimal t_nominalX = 0.0m;
                            decimal t_nominalY = 0.0m;

                            t_layerNo = t_layerInfo[1];
                            t_actualX = decimal.Parse(splitContent[1]);
                            t_actualY = decimal.Parse(splitContent[2]);
                            t_nominalX = decimal.Parse(splitContent[3]);
                            t_nominalY = decimal.Parse(splitContent[4]);

                            // Create new corner
                            Corner t_corner = new Corner(t_actualX, t_actualY, t_nominalX, t_nominalY);
                            t_corners[l_cornerCounter] = t_corner;

                            if (l_cornerCounter == 3) // Create new layer
                            {
                                Layer t_layer = new Layer(t_layerNo, t_corners[0], t_corners[1], t_corners[2], t_corners[3]);
                                t_panel.m_layers.Add(t_layer);
                                l_cornerCounter = 0;
                            } else
                            {
                                l_cornerCounter++;
                            }
                        }
                    }
                }

                return m_panelList;
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                throw new ArgumentNullException(e.Message);
            }
        }        
    }
}