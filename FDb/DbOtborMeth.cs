using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsWpfApp1
{
    internal class DbOtborMet : Papa
    {

        internal static void RefreshOtborFromFile()
        {
            #region
            DeleteAllOtbor();
            var data = FileToArr(Path.Combine(dataInPath, "otbor.csv"));
            var sum = 0;
            using (var context = new MyDataContext())
            {
                int countLines = -1;
                foreach (var dataLine in data)
                {
                    countLines += 1;
                    if (countLines > 0)
                    {
                        var terminal = dataLine[0];
                        var department = dataLine[1];

                        if (terminal == "" || department == "") continue;

                        var otbor = new T_Otbor
                        {
                            TermOtbor = terminal,
                            DepOtbor = department
                        };
                        context.otbors.Add(otbor);
                        Say($"otbor + {terminal}");
                        sum += 1;
                    }
                }
                context.SaveChanges();
            }
            SayGreen($"\notbor + {sum}\n");
            #endregion
        }


        internal static void AddOtborSome(List<string> terms)
        {
            #region
            DeleteAllOtbor();
            using (var context = new MyDataContext())
            {
                foreach (var term in terms)
                {
                    var otbor = new T_Otbor
                    {
                        TermOtbor = term,
                        DepOtbor = term.Substring(0, 7)
                    };
                    context.otbors.Add(otbor);
                    Say($"+ otbor {otbor.TermOtbor}");
                }
                context.SaveChanges();
            }
            #endregion
        }



        internal static void AddManyOtbor(List<string[]> arr)
        {
            #region
            DeleteAllOtbor();
            using (var context = new MyDataContext())
            {
                //int countLines = -1;
                foreach (var otborLine in arr)
                {
                    //countLines += 1;
                    //if (countLines < 1) continue;
                    var otbor = new T_Otbor
                    {
                        TermOtbor = otborLine[0],
                        DepOtbor = otborLine[1]
                    };
                    context.otbors.Add(otbor);
                }
                context.SaveChanges();
            }
            #endregion
        }


        private static void AddOtbor(string terminal, string department)
        {
            #region
            using (var context = new MyDataContext())
            {

                var otbor = new T_Otbor
                {
                    TermOtbor = terminal,
                    DepOtbor = department
                };

                context.otbors.Add(otbor);
                context.SaveChanges();

            }
            #endregion
        }


        internal static void DeleteAllOtbor()
        {
            #region
            using (var context = new MyDataContext())
            {
                var otbor = context.otbors;

                context.otbors.RemoveRange(otbor);
                context.SaveChanges();
            }
            #endregion
        }

        private static void ShowtKeysOtbor()
        {
            #region
            using (var context = new MyDataContext())
            {

                var otbor = context.otbors;
                var w = otbor.ToList();
                foreach (var line in w)
                {
                    Console.WriteLine(line.Id);
                }

            }
            #endregion
        }

        internal static string ShowtOtbor()
        {
            #region
            var rez = "\n";
            using (var context = new MyDataContext())
            {

                var otbor = context.otbors;
                var w = otbor.ToList();
                foreach (var line in w)
                {
                    //Console.WriteLine(line.DepOtbor + " " + line.TermOtbor);
                    rez += $"{line.DepOtbor} {line.TermOtbor}\n";
                }

            }
            #endregion
            return rez;
        }

        public static List<string[]> GetAllbor()
        {
            #region
            var outList = new List<string[]>();
            using (var context = new MyDataContext())
            {
                var otbor = context.otbors;
                var w = otbor.ToList();
                foreach (var line in w)
                {
                    var lineVec = new string[] { line.TermOtbor, line.DepOtbor };
                    outList.Add(lineVec);
                }

            }
            return outList;
            #endregion
        }

        public static List<string> GetListDepOtbor()
        {
            #region
            var outList = new List<string>();
            using (var context = new MyDataContext())
            {
                var otbor = context.otbors;
                var w = otbor.ToList();
                foreach (var line in w)
                {
                    outList.Add(line.DepOtbor);
                }
            }
            return outList;
            #endregion
        }

    }
}
