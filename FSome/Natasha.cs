using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SsWpfApp1
{
    class Natasha : Papa
    {
        #region #Fields
        static List<List<string>> accessData;
        static List<string> natasha;
        #endregion


        public static void MainNatasha()
        {
            #region
            outLine = "";
            var header = "Партнёр;Отделения с ЕДРПОУ;ПНФП;Всего\n";
            outText = header;
            natasha = MkNatasha();

            //accessData = AccBase.AccGetNatashaData();
            accessData = GetNatashaData();

            //var partners = AccBase.AccGetPartnersData();
            var partners = GetPartners();
            int sumComon = 0;
            int sumEdrpou = 0;
            int sumPnfp = 0;
            foreach (var partnerItem in partners)
            {
                string partner = partnerItem;
                if ("intime" == partner.ToString()) continue;
                if ("" == partner.ToString()) continue;
                if (0 == CountComon(partner)) continue;
                var outLine = String.Format("{0};{1};{2};{3}\n", partner, CountEdrpou(partner), CountPnfp(partner), CountComon(partner));
                outText += outLine;
                sumComon += CountComon(partner);
                sumEdrpou += CountEdrpou(partner);
                sumPnfp += CountPnfp(partner);
            }

            outText += String.Format("\nВсего с ЕДРПОУ {0}", sumEdrpou);
            outText += String.Format("\nВсего ПНФП {0}", sumPnfp);
            outText += String.Format("\nВсего {0}", sumComon);

            string oFname = dataPath + "Количество отделений/Отделения-" + DateNowLine() + ".csv";
            TextToFile(oFname, outText);
            Say("");
            Say(outText);
            //OpenNote(oFname);
            #endregion
        }



        static int CountPnfp(string partner)
        {
            #region
            int count = 0;
            foreach (var line in accessData)
            {
                if ((line[2].IndexOf(partner) > -1)
                    && (natasha.IndexOf(line[0]) > -1)
                    && (line[1] == ""))
                    count += 1;
            }
            return count;
            #endregion
        }

        static int CountEdrpou(string partner)
        {
            #region
            int count = 0;
            foreach (var line in accessData)
            {
                if ((line[2].IndexOf(partner) > -1)
                    && (natasha.IndexOf(line[0]) > -1)
                    && (line[1] != ""))
                    count += 1;
            }
            return count;
            #endregion
        }

        static int CountComon(string partner)
        {
            #region
            int count = 0;
            foreach (var line in accessData)
            {
                if ((line[2].IndexOf(partner) > -1)
                    && (natasha.IndexOf(line[0]) > -1))
                    count += 1;
            }
            return count;
            #endregion
        }


        
        private static List<List<string>> GetNatashaData()
        {
            #region
            List<List<string>> outList = new List<List<string>>();
            using (var context = new MyDataContext())
            {
                var department = context.departments;
                var w = department.ToList();
                foreach (var line in w)
                {
                    List<string> lineList = new List<string>();
                    lineList.Add(line.DepartmentDep);
                    lineList.Add(line.EdrpouDep);
                    lineList.Add(line.PartnerDep);

                    outList.Add(lineList);
                }

            }
            return outList;
            #endregion
        }

        private static List<string> GetPartners()
        {
            #region
            List<string> partners = new List<string>();
            using (var context = new MyDataContext())
            {
                var department = context.departments;
                //var w = department.ToList();
                foreach (var line in department)
                {
                    if (partners.IndexOf(line.PartnerDep) < 0)
                        partners.Add(line.PartnerDep.ToString());
                }

            }
            return partners;
            #endregion
        }

    }
}
