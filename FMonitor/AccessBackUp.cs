using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SsWpfApp1
{
    internal class AccessBackUp : Papa
    {
        internal static void MainAccessBackUp()
        {
            string accessConfigDir = Path.Combine(dataPath, "ConfigDir");
            string dirOut = "";
            try { dirOut = File.ReadAllLines(Path.Combine(accessConfigDir, "PathBackUpAccessOut.txt"))[0]; }
            catch { Sos("Не могу прочитать", dataConfigDirPath + "PathBackUpAccessOut.txt"); }
            string[] storedDirs = File.ReadAllLines(Path.Combine(accessConfigDir, "PathBackUpAccessDirList.txt"));

            foreach (string dir in storedDirs)
            {
                Coper(dir, dirOut);
            }
        }
    }
}
