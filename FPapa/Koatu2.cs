using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsWpfApp1
{
    internal class Koatu2 : Papa
    {
        #region #Fields
        static List<string[]> koatuAll = FileToArr(dataInPath + "koatuall.csv");
        //static List<string[]> sprArr;
        static Dictionary<string, List<string[]>> sprDict = new Dictionary<string, List<string[]>>();
        #endregion


        internal static string MkKoatuNew(string sity, string districtSity, string koatuOLd)
        {
            #region
            foreach (var koatuLine in koatuAll)
            {
                if (
                    Str1InStr2Both(koatuLine[1], koatuOLd) &&
                    (Str1InStr2(koatuLine[2], sity) || Str1InStr2(koatuLine[2], districtSity))
                    ) return koatuLine[0];
            }
            return "";
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

        
        static bool Str1InStr2(string str1, string str2)
        {
            #region
            bool flag = false;
            var s1 = WhiteString(str1);
            var s2 = WhiteString(str2);
            //if ((s2.IndexOf(s1) > -1) || (s2.IndexOf(s1) > -1)) flag = true;
            if ((s2.IndexOf(s1) > -1)) flag = true;
            return flag;
            #endregion
        }

        static bool Str1InStr2Both(string str1, string str2)
        {
            #region
            bool flag = false;
            var s1 = WhiteString(str1);
            var s2 = WhiteString(str2);
            if ((s2.IndexOf(s1) > -1) || (s1.IndexOf(s2) > -1)) flag = true;
            return flag;
            #endregion
        }

    }
}
