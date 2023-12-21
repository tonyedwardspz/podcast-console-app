using System;
using System.Collections.Generic;
using System.Linq;

namespace podcast_console_app
{
    internal class Program
    {
        // A dictionary to store the paths the user initially selects from
        internal static Dictionary<string, string> libraries = new Dictionary<string, string>()
        {
            {"Tony's Podcasts", @"D:\Podcasts\tonys-podcasts"},
            {"Wellbeing Podcasts", @"D:\Podcasts\tony-meditation"},
            {"Archive Podcasts", @"D:\Podcasts\tonys-archive"},
            {"Sleep Podcasts", @"D:\Podcasts\sleep-meditation-podcasts"}
        };

        internal static string filePath;
        internal static string folderNumber;
        internal static string fileNumber;
        static void Main(string[] args)
        {
            Console.WriteLine("Please select a library: ");
            ListLibraries();

            ListFolders(filePath);
            Console.WriteLine("Please select a folder number: ");
            folderNumber = Console.ReadLine();

            ListFiles(filePath, folderNumber);
            Console.WriteLine("Please select a file number: ");
            fileNumber = Console.ReadLine();

            PlayFile(filePath, folderNumber, fileNumber);
        }

        public static void ListLibraries()
        {
            foreach (KeyValuePair<string, string> library in libraries)
            {
                int i = Array.IndexOf(libraries.ToArray(), library);
                Console.WriteLine($"[{i}] - {library.Key}");
            }
            string libraryNumber = Console.ReadLine();
            filePath = libraries.ElementAt(int.Parse(libraryNumber)).Value;
            return;
        }

        public static void ListFolders(string path)
        {
            string[] folders = System.IO.Directory.GetDirectories(path);

            foreach (string folder in folders)
            {
                int i = Array.IndexOf(folders, folder);
                Console.WriteLine($"[{i}] - {folder}");
            }
        }

        public static void ListFiles(string path, string folderNumber)
        {
            string[] folders = System.IO.Directory.GetDirectories(path);
            string folderPath = folders[int.Parse(folderNumber)];
            string[] files = System.IO.Directory.GetFiles(folderPath);

            foreach (string file in files)
            {
                int i = Array.IndexOf(files, file);
                string fileName = System.IO.Path.GetFileName(file);
                Console.WriteLine($"[{i}] - {fileName}");
            }
        }

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
