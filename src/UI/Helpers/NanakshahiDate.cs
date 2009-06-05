using System;
using System.Linq;

namespace SikhResearchInstitute.UI.Helpers
{
    public class NanakshahiDate
    {
        enum Months
        {
            Chet, Vaisakh, Jeth, Harh, Sawan, Bhadon, Asu, Katik, Maghar, Poh, Magh, Phagan
        };

        public static string Get()
        {
            int s_Date = 0, s_Month = 0, s_Year = 0;

            int yearNow = DateTime.Now.Year;
            int monthNow = DateTime.Now.Month;
            int dateNow = DateTime.Now.Day;
            
            switch (monthNow)
            {
                case (1):
                    if (dateNow < 13)
                    {
                        s_Month = 10;
                        s_Date = 31 - (13 - dateNow);
                    }
                    else
                    {
                        s_Month = 11;
                        s_Date = dateNow - 12;
                    }
                    s_Year = yearNow - 1469;
                    break;

                case (2):
                    if (dateNow < 12)
                    {
                        s_Month = 11;
                        s_Date = 31 - (12 - dateNow);
                    }
                    else
                    {
                        s_Month = 12;
                        s_Date = dateNow - 11;

                    }
                    s_Year = yearNow - 1469;
                    break;

                case (3):
                    if (dateNow < 14)
                    {
                        s_Month = 12;
                        s_Date = 31 - (14 - dateNow);
                        s_Year = yearNow - 1469;
                    }
                    else
                    {
                        s_Month = 1;
                        s_Date = dateNow - 13;
                        s_Year = yearNow - 1468;
                    }
                    break;

                case (4):
                    if (dateNow < 14)
                    {
                        s_Month = 1;
                        s_Date = 32 - (14 - dateNow);
                    }
                    else
                    {
                        s_Month = 2;
                        s_Date = dateNow - 13;
                    }
                    s_Year = yearNow - 1468;
                    break;

                case (5):
                    if (dateNow < 15)
                    {
                        s_Month = 2;
                        s_Date = 32 - (15 - dateNow);
                    }
                    else
                    {
                        s_Month = 3;
                        s_Date = dateNow - 14;
                    }
                    s_Year = yearNow - 1468;
                    break;

                case (6):
                    if (dateNow < 15)
                    {
                        s_Month = 3;
                        s_Date = 32 - (15 - dateNow);
                    }
                    else
                    {
                        s_Month = 4;
                        s_Date = dateNow - 14;
                    }
                    s_Year = yearNow - 1468;
                    break;

                case (7):
                    if (dateNow < 16)
                    {
                        s_Month = 4;
                        s_Date = 32 - (16 - dateNow);
                    }
                    else
                    {
                        s_Month = 5;
                        s_Date = dateNow - 15;
                    }
                    s_Year = yearNow - 1468;
                    break;

                case (8):
                    if (dateNow < 16)
                    {
                        s_Month = 5;
                        s_Date = 32 - (16 - dateNow);
                    }
                    else
                    {
                        s_Month = 6;
                        s_Date = dateNow - 15;
                    }
                    s_Year = yearNow - 1468;
                    break;

                case (9):
                    if (dateNow < 15)
                    {
                        s_Month = 6;
                        s_Date = 31 - (15 - dateNow);
                    }
                    else
                    {
                        s_Month = 7;
                        s_Date = dateNow - 14;
                    }
                    s_Year = yearNow - 1468;
                    break;

                case (10):
                    if (dateNow < 15)
                    {
                        s_Month = 7;
                        s_Date = 31 - (15 - dateNow);
                    }
                    else
                    {
                        s_Month = 8;
                        s_Date = dateNow - 14;
                    }
                    s_Year = yearNow - 1468;
                    break;

                case (11):
                    if (dateNow < 14)
                    {
                        s_Month = 8;
                        s_Date = 31 - (14 - dateNow);
                    }
                    else
                    {
                        s_Month = 9;
                        s_Date = dateNow - 13;
                    }
                    s_Year = yearNow - 1468;
                    break;

                case (12):
                    if (dateNow < 14)
                    {
                        s_Month = 9;
                        s_Date = 31 - (14 - dateNow);
                    }
                    else
                    {
                        s_Month = 10;
                        s_Date = dateNow - 13;
                    }
                    s_Year = yearNow - 1468;
                    break;
            }

            return s_Date + " " + Enum.GetNames(typeof(Months)).ElementAt(s_Month - 1) + ", " + "Samvat " + s_Year + "<br />N&#257;naksh&#257;h&#299;";
        }
    }
}
