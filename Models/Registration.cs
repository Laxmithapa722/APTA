using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APTA.Models
{
    public class Registration
    {
        public int RegistrationID { get; set; }
        public int ConferenceID { get; set; }
        public int MemberID { get; set; }

        public Conference Conference { get; set; }
        public Member Member { get; set; }

    }
}
