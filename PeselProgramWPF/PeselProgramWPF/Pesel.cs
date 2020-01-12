using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeselProgramWPF
{
    public class Pesel
    {
        private string pesel_number;
        private PeselDataReader reader;

        private bool is_checksum_correct;
        private bool is_birthdate_correct;
        private bool is_correct;
        private Gender gender;
        private BirthDate birth_date;

        public Pesel(string number)
        {
            pesel_number = number;
            reader = new PeselDataReader(pesel_number);

            is_correct = reader.IsCorrect();
            if (!is_correct)
            {
                is_checksum_correct = false;
                is_birthdate_correct = false;
                birth_date = new BirthDate();
                gender = Gender.Unknown;
                return;
            }

            is_checksum_correct = reader.IsChecksumCorrect();
            if (reader.GetBirthDate() != null && reader.GetBirthDate().IsCorrect())
            {
                is_birthdate_correct = true;
            }
            else
            {
                is_birthdate_correct = false;
            }
            birth_date = reader.GetBirthDate();
            gender = reader.GetGender();
        }

        public bool IsCorrect
        {
            get { return is_correct; }
        }
        public bool IsChecksumCorrect
        {
            get { return is_checksum_correct; }
        }
        public bool IsBirthdateCorrect
        {
            get { return is_birthdate_correct; }
        }

        public Gender GetGender() => gender;

        public string GetBirthDate() => birth_date.ToString();



    }
}
