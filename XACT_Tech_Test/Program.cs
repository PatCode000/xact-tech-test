using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using static System.Net.Mime.MediaTypeNames;


namespace XACT_Tech_Test
{


    public class Program
    {
        /*
        static void Main(string[] args)
        {
            // Display the number of command line arguments.

        }        
        */
        List<Panel> data;

        [Fact]
        private void PrintPanelTable()
        {
            data = new List<Panel>();
            TextLoader textLoader = new TextLoader();
            data = textLoader.LoadData();
            DataPreparer dataPreparer = new DataPreparer();
            //dataPreparer.PreparePanelTable(data);
            //dataPreparer.PrepareLayerTable(data);
            dataPreparer.PrepareCornerTable(data);
        }


    }
}