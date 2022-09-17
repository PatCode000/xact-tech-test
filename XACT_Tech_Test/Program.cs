using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;


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

        [Fact]
        private void LoadTextFile()
        {
            TextLoader textLoader = new TextLoader();
            Console.WriteLine("TEXT FILE LOADED");
            textLoader.LoadFile();
            textLoader.PrintData();
        }

        [Fact]
        private void PrintPanelTable()
        {
            TextLoader textLoader = new TextLoader();
            Console.WriteLine("TEXT FILE LOADED");
            textLoader.LoadFile();
            textLoader.PrintPanelTable();
        }


        [Fact]
        private void TestDistance()
        {
            decimal result;
            decimal result2;
            //result = MathCalculations.GetDistance(5,5,0,0);
            result2 = MathCalculations.GetDistanceShort(5,5,0,0);

            //Console.WriteLine(result);
            Console.WriteLine(result2);
        }
    }
}