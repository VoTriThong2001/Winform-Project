using System;
using System.IO;
using System.Collections;
class Program
{
    public static void Main()
    {

        //Getting drive names
        DriveInfo[] Drives = DriveInfo.GetDrives();
        System.Console.WriteLine("Drive names: ");
        foreach (DriveInfo d in Drives)
        {
            Console.WriteLine("Drive {0}", d.Name);
        }

        //Reading a txt file
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\ACER\Documents\TextFile.txt");
        System.Console.WriteLine("\nContents of TextFile.txt: ");
        foreach (string line in lines)
        {
          
            Console.WriteLine(line);
        }

        //Listing file names in My document
        try
        {
            string[] dirs = Directory.GetFiles(@"C:\Users\ACER\Documents\");
            Console.WriteLine("\nFiles in documents: ");
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
}