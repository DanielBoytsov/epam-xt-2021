using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4._1._1
{
    class Logger
    {
        private FileSystemWatcher _watcher;

        private bool enabled = true;

        private string _sourceDirectory;

        private string _logDirectory;

        public Logger(string sourceDir, string logDir)
        {
            _sourceDirectory = sourceDir;
            _logDirectory = logDir;
        }

        public void DirectoryMonitoring()
        {
            using (_watcher = new FileSystemWatcher(_sourceDirectory, "*.txt"))
            {
                _watcher.NotifyFilter = NotifyFilters.LastAccess
                    | NotifyFilters.LastWrite
                    | NotifyFilters.DirectoryName
                    | NotifyFilters.FileName
                    | NotifyFilters.CreationTime;

                _watcher.IncludeSubdirectories = true;

                _watcher.Deleted += CatchingChanges;

                _watcher.Created += CatchingChanges;

                _watcher.Changed += CatchingChanges;

                _watcher.Renamed += CatchingChanges;

                _watcher.EnableRaisingEvents = true;

                while (enabled)
                    Thread.Sleep(1000);
            }
        }
        private void CatchingChanges(object sender, FileSystemEventArgs eventArgs)
        {
            var date = DateTime.Now.ToString("dd.MM.yyyy_HH.mm.ss");

            var newDir = _logDirectory + date;

            File.AppendAllText(_logDirectory + "Log.txt", "Backup was created successfully. You can restore it by this time :" + date + Environment.NewLine);
            
            File.AppendAllText(_logDirectory + "LogforList.txt", date + Environment.NewLine);
            
            Restorer.DirectoryCopy(_sourceDirectory, newDir, true);
        }

        public static void PrintLogs(string _logDirectory)
        {
            foreach (var item in (File.ReadLines(_logDirectory + "LogforList.txt")))
            {
                Console.WriteLine(item);
            }
        }
    }
}
