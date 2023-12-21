using System;

namespace podcast_console_app
{
    internal class Program
    {
        internal static string filePath = @"D:\Podcasts\tonys-podcasts";
        internal static string folderNumber;
        internal static string fileNumber;
        static void Main(string[] args)
        {
            ListFolders(filePath);
            Console.WriteLine("Please select a folder number: ");
            folderNumber = Console.ReadLine();

            ListFiles(filePath, folderNumber);
            Console.WriteLine("Please select a file number: ");
            fileNumber = Console.ReadLine();

            PlayFile(filePath, folderNumber, fileNumber);
        }

        // A function that lists all of the folders in the passed directory
        public static void ListFolders(string path)
        {
            string[] folders = System.IO.Directory.GetDirectories(path);

            foreach (string folder in folders)
            {
               
                int i = Array.IndexOf(folders, folder);
                Console.WriteLine($"[{i}] - {folder}");
            }
        }

        // A function that lists all of the files in the selected folder
        public static void ListFiles(string path, string folderNumber)
        {
            string[] folders = System.IO.Directory.GetDirectories(path);
            string folderPath = folders[int.Parse(folderNumber)];
            string[] files = System.IO.Directory.GetFiles(folderPath);

            foreach (string file in files)
            {
                int i = Array.IndexOf(files, file);
                Console.WriteLine($"[{i}] - {file}");
            }
        }

        // a Function that plays the selected audio file in the default player
        public static void PlayFile(string path, string folderNumber, string fileNumber)
        {
            string[] folders = System.IO.Directory.GetDirectories(path);
            string folderPath = folders[int.Parse(folderNumber)];

            string[] files = System.IO.Directory.GetFiles(folderPath);
            string filePath = files[int.Parse(fileNumber)];
            
            System.Diagnostics.Process.Start(filePath);
        }
    }
}
