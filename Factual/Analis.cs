using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsWpfApp1
{
    internal class Analis : Papa
    {

        public static bool flag = true;

        private static List<List<string>> futur = DbDepMeth.GetAllDep();
        private static List<List<string>> actual = DbDepNewMeth.GetAllDep();

        private static List<string> futurList = DbDepMeth.GetListDep();
        private static List<string> actualList = DbDepNewMeth.GetListDep();

        public static void AnalisMain()
        {
            info = "";
            foreach (var fut in futur)
            {
                var depFut = fut[0];
                foreach (var act in actual)
                {
                    var depAct = act[0];
                    if (depFut == depAct)
                    {
                        //Say($"{depFut} {depAct}");
                        FindDifrent(fut, act);
                    }
                }
            }

            info += "\n\n";
            FindAbcentDeps();
            //info += "\n\n";

            //if (flag) info = "Всё совпало\n";
            info += "\n\t Анализ завершён";
            //string fname = "info.txt";
            //TextToFile(fname, info);
            //Say(info);
            //OpenNote(fname);
        }

        private static void FindDifrent(List<string> fut, List<string> act)
        {
            //int colNum = 16;
            for (int i = 0; i < fut.Count; i++)
            {
                bool equalFlag = true;
                if (!fut[i].Equals(act[i]))
                {
                    info += $"Отделение {fut[0]}\ndep {fut[i]}\ndepNew {act[i]}\n";
                    equalFlag = false;
                    flag = false;
                    //break;
                }
                if (!equalFlag) info += "\n";
            }
        }

        private static void FindAbcentDeps()
        {
            foreach (var act in actualList)
            {
                int ind = futurList.IndexOf(act);
                if (ind < 0)
                {
                    info += $"not in dep {act}\n";
                    flag = false;
                }
            }
            info += "\n\n";
            foreach (var fufu in futurList)
            {
                int ind = actualList.IndexOf(fufu);
                if (ind < 0)
                {
                    info += $"not in depNew {fufu}\n";
                    flag = false;
                }
            }

        }
    }
}
