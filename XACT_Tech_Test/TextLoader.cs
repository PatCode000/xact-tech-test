/// Author: Patryk Stachowiak

using System;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace XACT_Tech_Test
{
    /// <summary>
    /// Class <c>TextLoader</c> is responsible for reading a text from the file.
    /// </summary>
    public class TextLoader
    {
        StreamReader? m_streamReader;

        /// <summary>
        /// Constructor <c>TextLoader</c> creates TextLoader object.
        /// </summary>
        public TextLoader()
        {
            Debug.WriteLine("TEXT LOADER IN PROGRESS");
        }

        /// <summary>
        /// Method <c>LoadData</c> loads and creates data from the text file.
        /// </summary>
        /// <param name="_fileName"> name of the new file to load.</param>
        public List<Panel> LoadData(string _fileName)
        {
            List<Panel> m_panelList = new List<Panel>();

            int l_panelCounter = 0;
            int l_cornerCounter = 0;

            try
            {
                using (m_streamReader = new StreamReader("test-data/" + _fileName + ".txt"))
                {
                    Panel t_panel = new Panel();
                    Corner[] t_corners = new Corner[4];

                    bool l_endOfFile = false;

                    while (!l_endOfFile)
                    {
                        // Warning below was prevented with nullable value. It wasn't necessary as the lines below prevents from code from using null, but it looks much better now when there is no error. 
                        string? l_dataString = m_streamReader.ReadLine();

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
                                continue; // Skip the first line
                            } else
                            {
                                m_panelList.Add(t_panel);
                                t_panel = new Panel(); // Create new panel
                            }
                        } else
                        {
                            string[] t_layerInfo = splitContent[0].Split("_");
                            string t_layerNo = t_layerInfo[1]; // Take the name of the layer
                            decimal t_actualX = decimal.Parse(splitContent[1]);
                            decimal t_actualY = decimal.Parse(splitContent[2]);
                            decimal t_nominalX = decimal.Parse(splitContent[3]);
                            decimal t_nominalY = decimal.Parse(splitContent[4]);

                            // Create new corner
                            Corner t_corner = new Corner(t_actualX, t_actualY, t_nominalX, t_nominalY);
                            t_corners[l_cornerCounter] = t_corner;

                            if (l_cornerCounter == 3) // Create new layer, and add all corners
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