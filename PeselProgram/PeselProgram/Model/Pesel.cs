using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeselProgram
{
    class Pesel
    {
        private string pesel_number;
        private bool is_valid;
        private bool is_correct;
        private Gender gender;
        private DateTime birth_day;
        private static int[] wages = new int[] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        
        public Pesel(string number)
        {
            pesel_number = number;
            is_correct = CheckIfCorrect(number);
            if (!is_correct)
            {
                is_valid = false;
                birth_day = new DateTime();
                gender = Gender.Unknown;
                return;
            }
            is_valid = ValidateNumber(number);
            birth_day = CheckBirthDate(number);
            gender = CheckGender(number);
        }

        public bool IsCorrect
        {
            get { return is_correct; }
        }
        public bool IsValid
        {
            get { return is_valid; }
        }

        public Gender GetGender() => gender;

        public DateTime GetBirthDate() => birth_day;

        private Gender CheckGender(string pesel)
        {
            // Check length if correct
            if(pesel.Length == 1)
            {
                if ((int)pesel[9] % 2 == 0)
                    return Gender.Female;
                else
                    return Gender.Male;
            }

            return Gender.Unknown;
        }

        private DateTime CheckBirthDate(string pesel)
        {
            int day = (int)(pesel[4] + pesel[5]);
            int month = (int)(pesel[2] + pesel[3]);
            int year = (int)(pesel[0] + pesel[1]);
            DateTime bd = new DateTime(day: day, month: month, year: year);
            return bd;
        }

        private bool CheckIfCorrect(string pesel)
        {
            bool isIntString = pesel.All(char.IsDigit);
            bool has11digits = pesel.Length == 11;

            return (isIntString && has11digits);
        }
        private bool ValidateNumber(string pesel)
        {
            int sum = 0;
            for(int i = 0; i<10; i++)
            {
                string nums = ((int)pesel[i] * wages[i]).ToString();
                sum += (int)(nums[nums.Length - 1]);
            }

            int final_number = 10 - (int)(sum.ToString()[sum.ToString().Length - 1]);

            if (final_number == (int)pesel[10])
                return true;

            return false;
        }

    }
}
