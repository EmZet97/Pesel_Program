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
        private Gender gender;
        private DateTime birth_day;
        
        public Pesel(string number)
        {
            pesel_number = number;
        }

        public bool IsValid
        {
            get { return is_valid; }
        }

        public Gender GetGender() => gender;

        public DateTime GetBirthDate() => birth_day;


    }
}
