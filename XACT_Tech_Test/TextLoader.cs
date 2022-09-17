using System;
using System.Diagnostics;
using Newtonsoft.Json.Linq;


namespace XACT_Tech_Test
{
    public class TextLoader
    {
        StreamReader m_streamReader;
        //MathCalculations m_myMathCalculator;

        //decimal[][] m_devotionLines;
        List<List<decimal>> m_panels;
        List<decimal> m_devotionLines;

        public TextLoader()
        {
            Debug.WriteLine("START TEXT LOADER");
            //m_myMathCalculator = new MathCalculations();
            //LoadFile();
        }

        public void LoadFile()
        {
            string l_featureName = "";
            decimal l_actualX = 0.0m;
            decimal l_actualY = 0.0m;
            decimal l_nominalX = 0.0m;
            decimal l_nominalY = 0.0m;

            int l_panelCounter = 0;
            int l_lineCounter = 0;

            m_panels = new List<List<decimal>>();
            m_devotionLines = new List<decimal>();            

            try
            {
                using (m_streamReader = new StreamReader("10001-8.txt"))
                {
                    //Console.WriteLine(m_streamReader.ReadToEnd());

                    bool l_endOfFile = false;
                    while (!l_endOfFile)
                    {
                        string l_dataString = m_streamReader.ReadLine();

                        if (l_dataString == null)
                        {
                            Console.WriteLine("Last panel done");
                            m_panels.Add(m_devotionLines);
                            l_endOfFile = true;
                            return;
                        }

                        string sep = "\t";
                        string[] splitContent = l_dataString.Split(sep.ToCharArray());

                        // Check if next panel
                        if (splitContent[0][0].Equals('F'))
                        {
                            m_devotionLines = new List<decimal>();

                            if (l_panelCounter == 0)
                            {
                                l_panelCounter++;
                                continue; // break out of the loop if this is first line
                            }


                            Debug.WriteLine("Next panel");
                            l_lineCounter = 0;
                            m_panels.Add(m_devotionLines);
                            //m_devotionLines = new List<decimal>();
                            l_panelCounter++;
                        } else
                        {
                            l_featureName = splitContent[0];

                            l_actualX = decimal.Parse(splitContent[1]);
                            l_actualY = decimal.Parse(splitContent[2]);
                            l_nominalX = decimal.Parse(splitContent[3]);
                            l_nominalY = decimal.Parse(splitContent[4]);

                            decimal result = MathCalculations.GetDistanceShort(l_actualX, l_actualY, l_nominalX, l_nominalY);
                            m_devotionLines.Add(result);
                            l_lineCounter++;

                            //Console.WriteLine("Devotion line is: " + result);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void PrintData()
        {
            foreach (List<decimal> panel in m_panels)
            {
                Console.WriteLine("New panel");
                foreach (decimal line in panel)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public void PrintPanelTable()
        {
            int l_panelCounter = 1;

            foreach (List<decimal> panel in m_panels)
            {
                Console.WriteLine("New panel");
                foreach (decimal line in panel)
                {
                    Console.WriteLine(Math.Round(line, 4));
                }

                Console.WriteLine("Minimum panel deviation is: " + Math.Round(MathCalculations.GetMinimum(panel), 4));
                Console.WriteLine("Maximum panel deviation is: " + Math.Round(MathCalculations.GetMaximum(panel), 4));
                Console.WriteLine("Mean devation for panel is: " + Math.Round(MathCalculations.GetMean(panel), 4));
                Console.WriteLine("Mediana devation for panel is: " + Math.Round(MathCalculations.GetMediana(panel), 4));
            }
        }

        //string text = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText.txt");
    }
}