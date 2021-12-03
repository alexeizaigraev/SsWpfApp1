using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsWpfApp1
{
    class DbDepMeth : Papa
    {
        internal static void RefreshDepartment()
        {
            #region
            Say("# RefreshDepartment");
            int countOk = 0;
            int countLines = -1;
            try
            {
                DeleteAllDepartment();
            }
            catch (Exception ex) { SayRed(ex.Message); }
            var data = FileToArr(Path.Combine(dataInPath, "departments.csv"));
            using (var context = new MyDataContext())
            {


                foreach (var dataLine in data)
                {
                    countLines += 1;
                    if (countLines > 0)
                    {
                        if (dataLine[0] == "") continue;

                        try
                        {
                            var department = new T_Department
                            {
                                DepartmentDep = dataLine[0],
                                RegionDep = dataLine[1],
                                DistrictRegionDep = dataLine[2],
                                DistrictCityDep = dataLine[3],
                                CityTypeDep = dataLine[4],
                                CityDep = dataLine[5],
                                StreetDep = dataLine[6],
                                StreetTypeDep = dataLine[7],
                                HousDep = dataLine[8],
                                PostIndexDep = dataLine[9],
                                PartnerDep = dataLine[10],
                                StatusDep = dataLine[11],
                                RegisterDep = dataLine[12],
                                EdrpouDep = dataLine[13],
                                AddressDep = dataLine[14],
                                PartnerNameDep = dataLine[15],
                                IdTerminalDep = dataLine[16],
                                KoatuDep = dataLine[17],
                                TaxIdDep = dataLine[18],
                                Koatu2Dep = ""
                            };

                            context.departments.Add(department);
                            //Say($"+ dep new {department.DepartmentDep}");
                            countOk += 1;
                        }
                        catch (Exception ex) { SayRed($"{dataLine[0]} {ex.Message}"); }
                    }
                }
                context.SaveChanges();
            }
            SayGreen($"\nadd {countOk} from {countLines}\n {countLines - countOk} erroros\n");
            #endregion
        }

        internal static void DeleteAllDepartment()
        {
            try
            {
                #region
                using (var context = new MyDataContext())
                {
                    var department = context.departments;

                    context.departments.RemoveRange(department);
                    context.SaveChanges();
                }
                #endregion
                Say("DeleteAllDepartment");
            }
            catch (Exception ex) { SayRed($"DeleteAllDepartment {ex.Message}"); }
        }

        internal static void DeleteOneDepartment(string dep)
        {
            #region
            try
            {
                using (var context = new MyDataContext())
                {
                    var singleRec = context.departments.FirstOrDefault(x => x.DepartmentDep == dep);// object your want to delete
                    context.departments.Remove(singleRec);
                    context.SaveChanges();
                    Say($"del {dep}");
                }
            }
            catch (Exception ex) { SayRed($"{dep} {ex.Message}"); }
            #endregion
        }


        public static List<List<string>> GetAllDep()
        {
            #region
            var outList = new List<List<string>>();
            using (var context = new MyDataContext())
            {
                var department = context.departments;
                var w = department.ToList();
                foreach (var line in w)
                {
                    var lineVec = new List<string> {
                                line.DepartmentDep,
                                line.RegionDep,
                                line.DistrictRegionDep,
                                line.DistrictCityDep,
                                line.CityTypeDep,
                                line.CityDep,
                                line.StreetDep,
                                line.StreetTypeDep,
                                line.HousDep,
                                line.PostIndexDep,
                                line.PartnerDep,
                                line.StatusDep,
                                line.RegisterDep,
                                line.EdrpouDep,
                                line.AddressDep,
                                line.PartnerNameDep,
                                line.IdTerminalDep,
                                line.KoatuDep,
                                line.TaxIdDep,
                                line.Koatu2Dep};

                    outList.Add(lineVec);
                }

            }
            return outList;
            #endregion
        }

        internal static List<string> GetOneDep(string myDep)
        {
            #region
            List<List<string>> outList = new List<List<string>>();
            using (var context = new MyDataContext())
            {
                var department = context.departments;
                //var w = department.ToList();

                var lingVar = from dep in department
                              where dep.DepartmentDep == myDep
                              select
                              new
                              {
                                  dep.DepartmentDep,
                                  dep.RegionDep,
                                  dep.DistrictRegionDep,
                                  dep.DistrictCityDep,
                                  dep.CityTypeDep,
                                  dep.CityDep,
                                  dep.StreetDep,
                                  dep.StreetTypeDep,
                                  dep.HousDep,
                                  dep.PostIndexDep,
                                  dep.PartnerDep,
                                  dep.StatusDep,
                                  dep.RegisterDep,
                                  dep.EdrpouDep,
                                  dep.AddressDep,
                                  dep.PartnerNameDep,
                                  dep.IdTerminalDep,
                                  dep.KoatuDep,
                                  dep.TaxIdDep,
                                  dep.Koatu2Dep
                              };
                foreach (var dep in lingVar)
                {
                    List<string> vec = new List<string>();

                    vec.Add(dep.DepartmentDep);
                    vec.Add(dep.RegionDep);
                    vec.Add(dep.DistrictRegionDep);
                    vec.Add(dep.DistrictCityDep);
                    vec.Add(dep.CityTypeDep);
                    vec.Add(dep.CityDep);
                    vec.Add(dep.StreetDep);
                    vec.Add(dep.StreetTypeDep);
                    vec.Add(dep.HousDep);
                    vec.Add(dep.PostIndexDep);
                    vec.Add(dep.PartnerDep);
                    vec.Add(dep.StatusDep);
                    vec.Add(dep.RegisterDep);
                    vec.Add(dep.EdrpouDep);
                    vec.Add(dep.AddressDep);
                    vec.Add(dep.PartnerNameDep);
                    vec.Add(dep.IdTerminalDep);
                    vec.Add(dep.KoatuDep);
                    vec.Add(dep.TaxIdDep);
                    vec.Add(dep.Koatu2Dep);

                    outList.Add(vec);
                }
            };
            return outList[0];
            #endregion
        }


        internal static void AddOneDepartment(List<string> vec)
        {
            #region
            string dep = vec[0];
            Say("# AddOneDepartment");
            DeleteOneDepartment(dep);
            using (var context = new MyDataContext())
            {
                var department = new T_Department
                {
                    DepartmentDep = vec[0],
                    RegionDep = vec[1],
                    DistrictRegionDep = vec[2],
                    DistrictCityDep = vec[3],
                    CityTypeDep = vec[4],
                    CityDep = vec[5],
                    StreetDep = vec[6],
                    StreetTypeDep = vec[7],
                    HousDep = vec[8],
                    PostIndexDep = vec[9],
                    PartnerDep = vec[10],
                    StatusDep = vec[11],
                    RegisterDep = vec[12],
                    EdrpouDep = vec[13],
                    AddressDep = vec[14],
                    PartnerNameDep = vec[15],
                    IdTerminalDep = vec[16],
                    KoatuDep = vec[17],
                    TaxIdDep = vec[18],
                    Koatu2Dep = ""
                };

                context.departments.Add(department);
                context.SaveChanges();
                Say($"+ dep new {department.DepartmentDep}");
            }
            #endregion
        }

        internal static List<string> GetListDep()
        {
            #region
            var outList = new List<string>();
            using (var context = new MyDataContext())
            {
                var department = context.departments;
                var w = department.ToList();
                foreach (var line in w)
                {
                    outList.Add(line.DepartmentDep);
                }

            }
            return outList;
            #endregion
        }

        internal static List<string> GetLisPartner()
        {
            #region
            var outList = new List<string>();
            using (var context = new MyDataContext())
            {
                var department = context.departments;
                var w = department.ToList();
                foreach (var line in w)
                {
                    if ( outList.IndexOf(line.PartnerDep) < 0 ) outList.Add(line.PartnerDep);
                }

            }
            return outList;
            #endregion
        }

    }
}
