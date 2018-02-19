using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Threading;
using System.Net.Sockets;

namespace SystemFileReader
{
    public class GetTree
    {
        private object locker = new object();
        //public string treeAdress;
        //public GetTree()
        //{
        //    treeAdress = "C:\\";
        //}
        //public GetTree(string TA)
        //{
        //    treeAdress = TA;
        //}

        //DirectoryInfo dir = new DirectoryInfo(Console.ReadLine());
        //foreach ( var item in dir.)
        public void Threads()
        {
            //ManualResetEvent stopPause = new ManualResetEvent(true);
            //int flag = 3;
            //var key = Console.ReadKey().Key;
            string adress = Console.ReadLine();
            DirectoryInfo diTop = new DirectoryInfo(adress);
            try
            {
                

                foreach (var fi in diTop.EnumerateFiles())
                {
                    try
                    {

                        Console.WriteLine(fi.FullName);

                    }
                    catch (UnauthorizedAccessException UnAuthTop)
                    {
                        Console.WriteLine("{0}", UnAuthTop.Message);
                    }
                }

                foreach (var di in diTop.EnumerateDirectories("*"))
                {

                   // Console.WriteLine(di.FullName);
                    try
                    {

                        foreach (var fi in di.EnumerateFiles("*", SearchOption.AllDirectories))
                        {
                            
                            try
                            {
                                
                                lock (locker)
                                {
                                    
                                    Console.Write(fi.Directory);
                                    Console.Write("  ");
                                    Console.WriteLine(fi.Name);
                                    
                                }
                            }
                            catch (UnauthorizedAccessException UnAuthFile)
                            {
                                Console.WriteLine("UnAuthFile: {0}", UnAuthFile.Message);
                            }
                        }
                    }
                    catch (UnauthorizedAccessException UnAuthSubDir)
                    {
                        Console.WriteLine("UnAuthSubDir: {0}", UnAuthSubDir.Message);
                    }
                }
            }
            catch (DirectoryNotFoundException DirNotFound)
            {
                Console.WriteLine("{0}", DirNotFound.Message);
            }
            catch (UnauthorizedAccessException UnAuthDir)
            {
                Console.WriteLine("UnAuthDir: {0}", UnAuthDir.Message);
            }
            catch (PathTooLongException LongPath)
            {
                Console.WriteLine("{0}", LongPath.Message);
            }
        }
        public void GettingTree()
        {
            //int flag = 3;
            //ManualResetEvent stopPause = new ManualResetEvent(true);
            Console.WriteLine("Write folder adress:");
            //var key = Console.ReadKey().Key;
            //Console.WriteLine("{0}",Console.ReadKey().Key);
            
            for (int i = 0; i < 3; i++)
            {

                Thread myThread = new Thread(Threads);
                //myThread.Name = "Поток " + i.ToString();
                myThread.Start();
                

            }
            

            Console.ReadLine();
        }
        public void StartStop()
        {
            int flag = 3;
            ManualResetEvent stopPause = new ManualResetEvent(true);
            //Console.WriteLine("Write folder adress:");
            var key = Console.ReadKey().Key;
            if (flag % 2 != 0)
            {
                Console.WriteLine("Stop");
                stopPause.Reset();
                Console.ReadKey();
            }
            if (flag % 2 == 0)
            {
                Console.WriteLine("start");
                stopPause.Set();
                Console.ReadKey();
            }
            if (key == ConsoleKey.Spacebar)
            {
                flag++;
            }
        }
    }
}
