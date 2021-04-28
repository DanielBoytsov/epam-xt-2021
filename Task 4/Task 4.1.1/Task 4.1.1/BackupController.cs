using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._1._1
{
    class BackupController
    {
        public static void ChooseBackupOperations()
        {
            Console.WriteLine("Please, input here the path to directory which you want to backup");
            var pathFileDir = CheckPath();

            Console.WriteLine("Please, input here the path to directory for logs");
            var pathLogDir = CheckPath();

            while (true)
            {
                Console.WriteLine("What do you want to do?" +
                    "\n1. Directory monitoring" +
                    "\n2. Directory restoration" +
                    "\n0. Exit");

                if (int.TryParse(Console.ReadLine(), out int selection))
                    switch (selection)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Directory monitoring enabled.");
                            var logger = new Logger(pathFileDir, pathLogDir);
                            logger.DirectoryMonitoring();
                            break;
                        case 2:
                            Console.WriteLine("Directory restoration enabled.");
                            var restorer = new Restorer(pathFileDir, pathLogDir);
                            restorer.DirectoryRestoration();
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("You selected non-existent case! Please select other.");
                            break;
                    }
                Console.ReadLine();
            }
        }
        public static string CheckPath()
        {
            while (true)
            {
                var path = Console.ReadLine();
                if (Directory.Exists(path))
                    return path;
                Console.WriteLine("This directory does not exist! Please specify a different path.");
            }
        }
    }
}
