using System;
namespace XACT_Tech_Test
{
    public class TextWriter
    {


        public TextWriter()
        {
            Console.WriteLine("TEXT WRITER IN PROGRESS");
        }

        public void WriteToFile(string _fileName, string[] _textLines)
        {
            string fileName = _fileName;
            using (StreamWriter writer = new StreamWriter(fileName + ".txt"))
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

