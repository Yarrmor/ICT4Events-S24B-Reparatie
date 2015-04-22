using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class Groepslid : Account
    {
        public Groepshoofd Groepshoofd { get; set; }

        public Groepslid(string rfid, int accountID, string email, string roepnaam, AccountType type, Groepshoofd groepshoofd, bool verbannen)
            : base(rfid, accountID, email, roepnaam, type, verbannen)
        {
            this.Groepshoofd = groepshoofd;
        }

        public Groepslid(Groepshoofd groepshoofd, string email)
            : base(email)
        {
            this.Groepshoofd = groepshoofd;
        }
    }
}
