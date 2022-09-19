/// Author: Patryk Stachowiak

using System;
using Xunit;

namespace XACT_Tech_Test
{
    /// <summary>
    /// Class <c>Program</c> contains all methods to test applications.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Test method <c>ProcessData_10001_8</c> creates tables for file 10001-8.txt.
        /// </summary>
        [Fact]
        private void ProcessData_10001_8()
        {
            string fileName = "10001-8";

            TextLoader textLoader = new TextLoader();
            List<Panel> data = new List<Panel>();
            data = textLoader.LoadData(fileName);

            DataPreparer dataPreparer = new DataPreparer();
            string[] panelTableData = dataPreparer.PreparePanelTable(data);
            string[] layerTableData = dataPreparer.PrepareLayerTable(data);
            string[] cornerTableData = dataPreparer.PrepareCornerTable(data);

            TextWriter m_myTextWriter = new TextWriter();
            m_myTextWriter.WriteToFile("Panel_table_" + fileName, panelTableData);
            m_myTextWriter.WriteToFile("Layer_table_" + fileName, layerTableData);
            m_myTextWriter.WriteToFile("Corner_table_" + fileName, cornerTableData);
        }

        /// <summary>
        /// Test method <c>ProcessData_10002_14</c> creates tables for file 10002-14.txt.
        /// </summary>
        [Fact]
        private void ProcessData_10002_14()
        {
            string fileName = "10002-14";

            TextLoader textLoader = new TextLoader();
            List<Panel> data = new List<Panel>();
            data = textLoader.LoadData(fileName);

            DataPreparer dataPreparer = new DataPreparer();
            string[] panelTableData = dataPreparer.PreparePanelTable(data);
            string[] layerTableData = dataPreparer.PrepareLayerTable(data);
            string[] cornerTableData = dataPreparer.PrepareCornerTable(data);

            TextWriter m_myTextWriter = new TextWriter();
            m_myTextWriter.WriteToFile("Panel_table_" + fileName, panelTableData);
            m_myTextWriter.WriteToFile("Layer_table_" + fileName, layerTableData);
            m_myTextWriter.WriteToFile("Corner_table_" + fileName, cornerTableData);
        }

        /// <summary>
        /// Test method <c>ProcessData_200506_12-01</c> creates tables for file 200506_12-01.txt.
        /// </summary>
        [Fact]
        private void ProcessData_200506_12()
        {
            string fileName = "200506_12-01";

            TextLoader textLoader = new TextLoader();
            List<Panel> data = new List<Panel>();
            data = textLoader.LoadData(fileName);

            DataPreparer dataPreparer = new DataPreparer();
            string[] panelTableData = dataPreparer.PreparePanelTable(data);
            string[] layerTableData = dataPreparer.PrepareLayerTable(data);
            string[] cornerTableData = dataPreparer.PrepareCornerTable(data);

            TextWriter m_myTextWriter = new TextWriter();
            m_myTextWriter.WriteToFile("Panel_table_" + fileName, panelTableData);
            m_myTextWriter.WriteToFile("Layer_table_" + fileName, layerTableData);
            m_myTextWriter.WriteToFile("Corner_table_" + fileName, cornerTableData);
        }

        /// <summary>
        /// Test method <c>ProcessData_200514_14-08/c> creates tables for file 200514_14-08.txt.
        /// </summary>
        [Fact]
        private void ProcessData_200514_08()
        {
            string fileName = "200514_14-08";

            TextLoader textLoader = new TextLoader();
            List<Panel> data = new List<Panel>();
            data = textLoader.LoadData(fileName);

            DataPreparer dataPreparer = new DataPreparer();
            string[] panelTableData = dataPreparer.PreparePanelTable(data);
            string[] layerTableData = dataPreparer.PrepareLayerTable(data);
            string[] cornerTableData = dataPreparer.PrepareCornerTable(data);

            TextWriter m_myTextWriter = new TextWriter();
            m_myTextWriter.WriteToFile("Panel_table_" + fileName, panelTableData);
            m_myTextWriter.WriteToFile("Layer_table_" + fileName, layerTableData);
            m_myTextWriter.WriteToFile("Corner_table_" + fileName, cornerTableData);
        }
    }
}