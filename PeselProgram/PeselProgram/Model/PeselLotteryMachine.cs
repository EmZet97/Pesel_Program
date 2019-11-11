using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeselProgram.Model
{
    class PeselLotteryMachine
    {
        private Pesel pesel;

        private Gender gender;
        private DateTime birth_day;
        
        public void SetGender(Gender gender)
        {
            this.gender = gender;
        }

        public void SetBirthDay(DateTime date)
        {
            birth_day = date;
        }

        public void GeneratePesel()
        {


        }
    }
}
