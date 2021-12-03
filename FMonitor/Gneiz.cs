using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SsWpfApp1
{
    internal class Gnetz : Papa
    {

        private static string[] priznaks = { "foto", "photo", "фото" };
        private static string outPath = Path.Combine(dataPath, "gnetz");

        private static SortedDictionary<string, int> rezDict = new SortedDictionary<string, int>();
        private static List<string> allDeps = DbDepMeth.GetListDep();

        private static List<string> senDeps = new List<string>();

        private static List<string> agFolders = MkGdriveFolders();

        internal static void MainGnetz()
        {
            try
            {
                //Papa.info = "";
                info = gnetzKind + "\n\n";
                foreach (var agFolger in agFolders)
                {
                    var agPath = Path.Combine(gDrivePath, agFolger);
                    WalkDirectoryTree(new DirectoryInfo(agPath));
                }

                var resived = GetFilesFromFolder(outPath);
                //info += $"\nsend {send.Count} departments\n\n";
                List<string> bed = new List<string>();
                List<string> good = new List<string>();

                foreach (var dep in allDeps)
                {
                    if (dep == "1") continue;
                    foreach (var fName in resived)
                    {
                        if (fName.IndexOf(dep) > -1)
                        {
                            if (rezDict.ContainsKey(dep)) { rezDict[dep] += 1; }
                            else { rezDict[dep] = 1; }
                        }
                    }

                }
                info += "\nОтделение Количество_файлов\n\n";
                int summ = 0;
                foreach (var dep in rezDict.Keys)
                {
                    info += $"{dep} {rezDict[dep]}\n";
                    summ += rezDict[dep];
                }
                info += $"\nфайлов {summ }\n";
                info += $"\nОтделений {rezDict.Count }\n";
                info += "\n\nwell";
            }
            catch (Exception ex)
            { info += ex.Message + "\n"; }

        }


        private static bool PriznacInName(string fName)
        {
            fName = fName.ToLower();
            bool flag = false;
            foreach (var priznak in priznaks)
            {
                if (fName.IndexOf(priznak) > -1)
                    flag = true;
                break;
            }
            return flag;
        }

        public static void WalkDirectoryTree(DirectoryInfo root)
        {
            FileInfo[] files = null;

            try
            {
                files = root.GetFiles();
                foreach (var file in files)
                {
                    var fName = Convert.ToString(file);
                    if (PriznacInName(fName))
                    {
                        try
                        {
                            var fInfoOLld = new FileInfo(fName);
                            var sOldName = fInfoOLld.ToString().Split('\\');
                            var dep = sOldName[sOldName.Length - 2];
                            var agFolder = sOldName[sOldName.Length - 3];
                            if (sOldName.Length > 3 && agFolders.IndexOf(agFolder) > -1)
                            {
                                var fNameNew = Path.Combine(outPath, dep + "_" + Convert.ToString(fInfoOLld.Name));
                                FileInfo fInfoFnameNew = new FileInfo(fNameNew);
                                if (gnetzKind == "copy") fInfoOLld.CopyTo(fInfoFnameNew.ToString(), true);
                                else fInfoOLld.CopyTo(fInfoFnameNew.ToString(), true);
                                //info += fNameNew + "\n";
                            }

                        }
                        catch (Exception ex) { info += ex.Message + "\n"; }

                    }

                }
            }
            catch (UnauthorizedAccessException)
            { }
            catch (DirectoryNotFoundException)
            { }
            catch (NullReferenceException)
            { }

            if (files == null) return;

            foreach (var dirInfo in root.GetDirectories()) WalkDirectoryTree(dirInfo);
        }
    }
}
