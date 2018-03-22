using System;
using System.IO;

namespace TheFileTroll
{
    public class Program
    {
        //Careful choosing a drive and directory folder
        //This program is a first iteration test for something
        //Much more interesting.
        private static void Main(string[] args)
        {
            GetTheDirectoryFileinfo(@"C:\Users\PCName\Music\Music");
        }

        private static int GetTheDirectoryFileinfo(string folderName)
        {
            //default the count
            var fileCount = 0;
            //get the directory name
            folderName = folderName.TrimEnd(new char[] { '\\' });

            //Add the number of files in the directory for counting
            fileCount += Directory.GetFiles(folderName).Length;

            //Time to get the directory and the files inside
            var subDirectories = Directory.GetDirectories(folderName);

            //Loop through the directory and recursivley count each file found
            foreach (var directory in subDirectories)
                fileCount += GetTheDirectoryFileinfo(directory); 

            //display the folder and file names in a console window for informational gathering purposes
            Console.WriteLine(folderName);
            Console.ReadKey();

            //display how many files each folder/subfolder contains
            Console.WriteLine(fileCount);
            //Console.ReadKey();

            //Later we can get interesting and upload the information to a database

            return fileCount;
        }
    }
}
