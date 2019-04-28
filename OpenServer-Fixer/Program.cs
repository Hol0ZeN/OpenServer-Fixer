using System;
using System.IO;
using System.Text;

namespace OpenServer_Fixer
{
    class Program
    {
        private static FileSystemWatcher Watcher = new FileSystemWatcher();

        private static void Main(string[] args)
        {
            string directory = string.Empty;
            do
            {
                Console.Write("Path to database module directory: ");
                directory = Console.ReadLine();
                if (Directory.Exists(directory)) break;
                Console.WriteLine("Wrong directory!");
            } while (!Directory.Exists(directory));

            Watcher.Path = directory;
            Watcher.Filter = "my.ini";
            Watcher.NotifyFilter = NotifyFilters.LastWrite;
            Watcher.EnableRaisingEvents = true;
            Watcher.Changed += Watcher_Changed;
            Console.WriteLine("Ready for OpenServer start!");
            Console.ReadKey();
        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            File.WriteAllText(e.FullPath, File.ReadAllText(e.FullPath), new ASCIIEncoding());
        }
    }
}
