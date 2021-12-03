using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsWpfApp1
{
    class ExternProcess : Papa
    {
        internal static void RefresFromAccessAll()
        {
            string appPath = FileToVec("Config/SharpForPyPath.txt")[0];
            StartProcess(appPath);

            DbOtborMet.RefreshOtborFromFile();
            DbDepMeth.RefreshDepartment();
            DbTermMeth.RefreshTerminal();

            Console.WriteLine("\n\tAll refreshed\n");

            //StartProcess(@"C:\Users\Alex\source\repos\alexeizaigraev\WpfApp3\bin\Release\WpfApp3.exe");
        }

    }
}
