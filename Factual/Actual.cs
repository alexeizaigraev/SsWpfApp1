using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsWpfApp1
{
    internal class Actual : Papa
    {
        internal static void OtborToActua()
        {
            #region
            var otbor = DbOtborMet.GetAllbor();

            foreach (var line in otbor)
            {
                var dep = line[1];
                try
                {
                    DbDepNewMeth.DeleteOneDepartment(dep);
                    //Say($"- actual {dep}");
                }
                catch { }
                var data = DbDepMeth.GetOneDep(dep);
                try
                {
                    DbDepNewMeth.AddOneDepartment(data);
                    //Say($"+ actual {dep}");
                }
                catch (Exception ex) { SayRed(ex.Message); }

            }


            #endregion
        }




        internal static void ClearActualOtbor()
        {
            #region
            var otbor = DbOtborMet.GetAllbor();
            foreach (var line in otbor)
            {
                var dep = line[1];
                try
                {
                    DbDepNewMeth.DeleteOneDepartment(dep);
                    //Say($"- actual {dep}");
                }
                catch { }
            }

            #endregion
        }

    }
}
