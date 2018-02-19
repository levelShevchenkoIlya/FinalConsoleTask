using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemFileReader;
using System.IO;


namespace FinalConsoleTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //DirectoryInfo directoryinfo = new DirectoryInfo();
            GetTree getTree = new GetTree();
            getTree.GettingTree();
        }
    }
}
