using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.BL
{
    class PROGRAM
    {
        public string dTitle;
        public string duration;
        public int seats;
        public int remSeats;
        public List<SUBJECT> subjDetails;
        public PROGRAM(string dTitle, string duration, int seats, List<SUBJECT> subjDetails)
        {
            this.dTitle = dTitle;
            this.duration = duration;
            this.seats = seats;
            this.subjDetails = subjDetails;
        }
    }
}
