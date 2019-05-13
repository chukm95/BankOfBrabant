using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfBrabant.Controllers
{
    public class Class
    {
        public static bool IsSofiNummer(string sofinummer)
        {
            if (sofinummer.Length != 9) return false;
            int i = 9;
            int total = 0;
            for (int j = 0; j < 8; j++)
            {
                char t = sofinummer[j];
                total += int.Parse(t.ToString()) * i; i--;
            }
            int rest = int.Parse(sofinummer[8].ToString());
            return ((total % 11) == rest);
        }

        public static string GetNextSofiNummer(string highestSofinummer)
        {
            string sofinummer = "";
            int s = System.Convert.ToInt32(highestSofinummer);

            while (sofinummer == "")
            {
                s++;
                if (IsSofiNummer(System.Convert.ToString(s)))
                {
                    sofinummer = System.Convert.ToString(s);
                }
            }


            return "";
        }
    }
}
