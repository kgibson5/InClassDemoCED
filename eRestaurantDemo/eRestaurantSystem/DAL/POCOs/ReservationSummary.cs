using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurantSystem.DAL.POCOs
{
    public class ReservationSummary
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int NumberInParty { get; set; }
        public string Status { get; set; }
        public string Event { get; set; }
        public string Contact { get; set; }
    }
}
