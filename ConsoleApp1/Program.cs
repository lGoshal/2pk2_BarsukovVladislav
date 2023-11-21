using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String Line;
            try
            {
                //Pass path and file name to StreamReader class
                StreamWriter streamWriter = new StreamWriter("С:\\Users\\desti\\Desktop\\Text.txt");
                //Writing the line of a text
                streamWriter.WriteLine("Helo world!");
                //Writing the second line of a text
                streamWriter.WriteLine("12345");
                //Closing the file
                streamWriter.Close();
            }
        }
    }
}
