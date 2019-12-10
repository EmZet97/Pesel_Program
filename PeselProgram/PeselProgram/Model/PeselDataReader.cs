using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeselProgram.Model
{
    class PeselDataReader
    {
        private readonly string pesel;

        public PeselDataReader(string pesel)
        {
            this.pesel = pesel;
        }
        
        public Gender GetGender()
        {
            if (!IsCorrect())
                return Gender.Unknown;


            if (int.Parse(pesel[9].ToString()) % 2 == 0)
                return Gender.Female;
            else
                return Gender.Male;

        }

        public Model.BirthDate GetBirthDate()
        {
            if (!IsCorrect())
                return null;

            int year = 0;
            int day = int.Parse("0" + pesel[4] + pesel[5]);
            int month = int.Parse("0" + pesel[2] + pesel[3]);
            if (month > 80 && month < 93)
            {
                month -= 80;
                year = 1800;
            }
            else if (month > 0 && month < 13)
            {
                month -= 0;
                year = 1900;
            }
            else if (month > 20 && month < 33)
            {
                month -= 20;
                year = 2000;
            }
            else if (month > 40 && month < 53)
            {
                month -= 40;
                year = 2100;
            }
            else if (month > 60 && month < 73)
            {
                month -= 60;
                year = 2200;
            }
            else
            {
                return null;
            }

            year += int.Parse("0" + pesel[0] + pesel[1]);


            Model.BirthDate bd = new Model.BirthDate(day, month, year);
            
            return bd;
        }

        public bool IsCorrect()
        {
            bool isIntString = pesel.All(char.IsDigit);
            bool has11digits = pesel.Length == 11;

            return (isIntString && has11digits);
        }

        public bool IsChecksumCorrect()
        {
            if (!IsCorrect())
                return false;


            int[] wages = new int[] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                int nums = int.Parse(pesel[i].ToString()) * wages[i];
                sum += nums % 10;
            }

            int final_number = 10 - sum % 10;

            if (final_number == int.Parse(pesel[10].ToString()))
                return true;

            return false;
        }

    }
}

