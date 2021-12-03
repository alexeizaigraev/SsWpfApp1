using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsWpfApp1
{
    class HrDepAb : Papa
    {
        static SortedDictionary<string, int> dictSum = new SortedDictionary<string, int>();
        static List<string[]> koatuAll;
        static Dictionary<string, List<string[]>> sprDict = new Dictionary<string, List<string[]>>();
        public static void MainHrDepAb()
        {
            #region
            var natasha = MkNatasha();
            //string myKey = "partner";
            //string outText = "№ п/п;\"№ Відділення ТОВ \"\"ЕПС\"\"\";Адреса;koatu1;koatu2;Партнер\n";
            string outText = "№ п/п;\"№ Відділення ТОВ \"\"ЕПС\"\"\";Адреса;Партнер\n";
            var data = GetSummuryData();
            var sizeLine = data[0].Count;


            int count = 0;
            foreach (var u in data)
            {
                try
                {
                    if (u[0] == "" || natasha.IndexOf(u[0]) < 0) continue;

                    count++;
                    string outLine = String.Format("{0}", count) + ";"
                            + u[0] + ";" + u[1] + ";" + u[2];

                    outText += outLine + "\n";
                }
                //catch (Exception ex) { pMagenta(ex.Message); }
                catch (Exception ex) { info += ex.Message + "\n"; }
                //catch { }
            }

            string oFname = dataOutPath + "summury_ab.csv";
            SayGreen($"\n\n\tsumm {count}\n\n");
            TextToFile(oFname, outText);
            //OpenNote(oFname);
            #endregion
        }

        static List<List<string>> GetSummuryData()
        {
            #region
            List<List<string>> outList = new List<List<string>>();
            using (var context = new MyDataContext())
            {
                var department = context.departmentnews;
                var terminal = context.terminals;
                var otbor = context.otbors;
                var w = department.ToList();

                var lingVar = from dep in department
                              select
                              new
                              {
                                  dep = dep.DepartmentDep,
                                  //region = dep.RegionDep,
                                  //disrictRegion = dep.DistrictRegionDep,
                                  //potIndex = dep.PostIndexDep,
                                  //cityType = dep.CityTypeDep,
                                  //city = dep.CityDep,
                                  //districtCity = dep.DistrictCityDep,
                                  //streetType = dep.StreetTypeDep,
                                  //street = dep.StreetDep,
                                  //hous = dep.HousDep,
                                  adres = dep.AddressDep,
                                  //koatu = dep.KoatuDep,
                                  partner = dep.PartnerDep
                              };

                foreach (var line in lingVar)
                {

                    List<string> lineList = new List<string>();
                    lineList.Add(line.dep);
                    lineList.Add(line.adres);
                    lineList.Add(line.partner);

                    outList.Add(lineList);
                }

            }
            return outList;
            #endregion
        }



        static string WhiteString(string inString)
        {
            #region #MkFioWhite
            string white = "";
            foreach (char cha in inString)
            {
                if (char.IsLetter(cha))
                {
                    char[] c = { cha };
                    string ss = new string(c);
                    white += ss;
                }
            }
            return white.ToLower();
            #endregion
        }

        



    }
}
