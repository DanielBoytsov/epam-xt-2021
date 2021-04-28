using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._1._1
{
    class Restorer
    {
        private string _sourceDirectory;

        private string _logDirectory;

        public Restorer(string sourceDir, string logDir)
        {
            _sourceDirectory = sourceDir;
            _logDirectory = logDir;
        }

        public void DirectoryRestoration()
        {
            Console.WriteLine("Indicate to what point you want to rollback" +
                              "\nWrite in format dd.MM.yyyy_HH:mm:ss" +
                              "\n(like a 28.04.2021_12.34.45)" +
                              "\nYou can check the available restorations in the Log.txt at Logs Directory");
            var logTargetDirectory = new DirectoryInfo(_logDirectory + Console.ReadLine());

            if (logTargetDirectory.Exists)
            {
                var sourceTargetDirectory = new DirectoryInfo(_sourceDirectory);

                foreach (var file in sourceTargetDirectory.GetFiles())
                {
                    file.Delete();
                }

                foreach (var dir in sourceTargetDirectory.GetDirectories())
                {
                    dir.Delete(true);
                }

                DirectoryCopy(logTargetDirectory.ToString(), _sourceDirectory, true);
            }
            else
                Console.WriteLine("No backups found for this time!");
        }
        public static void DirectoryCopy(string sourceDir, string targetDir, bool copySubDirs)
        {
            var dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
                throw new DirectoryNotFoundException("Directories not found");
            var dirs = dir.GetDirectories();

            if (!Directory.Exists(targetDir))
                Directory.CreateDirectory(targetDir);
            var files = dir.GetFiles();

            foreach (var file in files)
            {
                var tempPath = Path.Combine(targetDir, file.Name);

                file.CopyTo(tempPath, true);
            }

            if (copySubDirs)
            {
                foreach (var subDir in dirs)
                {
                    var tempPath = Path.Combine(targetDir, subDir.Name);

                    DirectoryCopy(subDir.FullName, tempPath, copySubDirs);
                }
            }
        }
    }
}
