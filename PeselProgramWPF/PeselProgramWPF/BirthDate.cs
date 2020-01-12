using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeselProgramWPF
{
    public class BirthDate
    {
        public int Day { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }

        public BirthDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public BirthDate()
        {

            Day = 1;
            Month = 1;
            Year = 1900;
        }

        override public string ToString()
        {
            if (!IsCorrect())
                return null;
            string day = Day < 10 ? "0" + Day : Day.ToString();
            string month = Month < 10 ? "0" + Month : Month.ToString();
            return day + "." + month + "." + Year;
        }

        public bool IsCorrect()
        {
            bool isMonthCorrect = Month > 0 && Month < 13;
            if (!isMonthCorrect)
                return false;
            bool isDayCorrect = Day > 0 && Day <= DateTime.DaysInMonth(Year, Month);
            if (!isDayCorrect)
                return false;

            return true;
        }
    }
}
