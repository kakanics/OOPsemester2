using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessAppComplete
{
    internal class genericFunctions
    {
        public static bool validateStringAsInt(string pages)
        {
            bool flag = true;
            int length = pages.Length;
            for (int i = 0; i < length; i++)
            {
                if (!(pages[i] >= '0') || !(pages[i] <= '9'))
                    flag = false;
            }
            if (pages == "") return false;
            return flag;
        }
        public static string parseData(string record, int field)
        {
            int commaCount = 1;
            string item = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    item += record[i];
                }
            }
            return item;
        }
    }
}
