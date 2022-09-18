using System;
namespace XACT_Tech_Test
{
    /// <summary>
    /// Class <c>TextWriter</c> is responsible for writing a text to the file.
    /// </summary>
    public class TextWriter
    {
        /// <summary>
        /// Constructor <c>TextWriter</c> creates TextWriter object.
        /// </summary>
        public TextWriter()
        {
            Console.WriteLine("TEXT WRITER IN PROGRESS");
        }

        /// <summary>
        /// Method <c>WriteToFile</c> creates txt file, and writes data into the this file.
        /// </summary>
        /// <param name="_fileName"> name of the new file.</param>
        /// <param name="_textLines"> data to write to the text file.</param>
        public void WriteToFile(string _fileName, string[] _textLines)
        {
            string fileName = _fileName;
            using (StreamWriter writer = new StreamWriter("test-data-results/" + fileName + ".txt"))
            {
                foreach (string text in _textLines)
                {
                    writer.WriteLine(text);
                    Console.WriteLine(text);
                }
            }
        }
    }
}

