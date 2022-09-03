using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyTools;

namespace launchbox_splitter
{

   

    class Program
    {
        static void MoveDirectory(string src, string dest)
        {
            if (Directory.Exists(src))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(dest));
                Directory.Move(src, dest);
            }
        }

        static void Main(string[] args)
        {
            string launchbox_path = ".";
            string platform_path = launchbox_path + "\\Data\\Platforms";
            string splitter_export_path = launchbox_path + "\\SplitterExport";

            if(Directory.Exists(splitter_export_path))
            {
                Console.WriteLine("Exiting Due To Export Path Already Exists: " + splitter_export_path);
                Console.ReadLine();
                return;
            }

            //Scan Data/Platforms for list of platofrms xml files
            Console.WriteLine("Seaching Path for Platform XMLs: " + platform_path);
            FileScanner scanner = new FileScanner();
            scanner.SearchFolder = platform_path;
            scanner.AllowedExtensions = new[] { ".xml" };
            scanner.Recursive = false;
            List<string> platform_xml_list = scanner.Scan();
            Console.WriteLine("Platform XMLs Found: ");
            foreach(string p in platform_xml_list)
            {
                Console.WriteLine(p);
            }

            //Create Launchbox Tree for each Platform 
            foreach (string p in platform_xml_list)
            {
                string platform_name = Path.GetFileNameWithoutExtension(p);
                Console.WriteLine("Exporting: " + splitter_export_path + "\\" + platform_name);
                
                Directory.CreateDirectory(splitter_export_path + "\\" + platform_name +"\\Data\\Platforms");
                File.Move(p, splitter_export_path + "\\" + platform_name + "\\Data\\Platforms\\" + platform_name + ".xml");

                string src_move_path = launchbox_path + "\\Games\\" + platform_name;
                string target_move_path = splitter_export_path + "\\" + platform_name + "\\Games\\" + platform_name;
                MoveDirectory(src_move_path, target_move_path);

                src_move_path = launchbox_path + "\\Images\\" + platform_name;
                target_move_path = splitter_export_path + "\\" + platform_name + "\\Images\\" + platform_name;
                MoveDirectory(src_move_path, target_move_path);

                src_move_path = launchbox_path + "\\Images\\Platforms\\" + platform_name;
                target_move_path = splitter_export_path + "\\" + platform_name + "\\Images\\Platforms\\" + platform_name;
                MoveDirectory(src_move_path, target_move_path);

                src_move_path = launchbox_path + "\\Manuals\\" + platform_name;
                target_move_path = splitter_export_path + "\\" + platform_name + "\\Manuals\\" + platform_name;
                MoveDirectory(src_move_path, target_move_path);

                src_move_path = launchbox_path + "\\Music\\" + platform_name;
                target_move_path = splitter_export_path + "\\" + platform_name + "\\Music\\" + platform_name;
                MoveDirectory(src_move_path, target_move_path);

                src_move_path = launchbox_path + "\\Videos\\" + platform_name;
                target_move_path = splitter_export_path + "\\" + platform_name + "\\Videos\\" + platform_name;
                MoveDirectory(src_move_path, target_move_path);

                src_move_path = launchbox_path + "\\Videos\\Platforms\\" + platform_name;
                target_move_path = splitter_export_path + "\\" + platform_name + "\\Videos\\Platforms\\" + platform_name;
                MoveDirectory(src_move_path, target_move_path);

            }
            

            Console.ReadLine();
        }
    }
}
