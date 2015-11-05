using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
#endregion

namespace eRestaurantSystem.DAL.Entities
{
    public class Reservation
    {
        //create a series of constant strings so actual value do not need 
        //to be remembered, instead, a reasonable name will be use
        public const string Booked = "B";
        public const string Arrived = "A";
        public const string Complete = "C";
        public const string NoShow = "N";
        public const string Cancelled = "X";

        [Key]
        public int ReservationID { get; set; }
        [Required]
        [StringLength(30,MinimumLength=5)]
        public string CustomerName { get; set; }
        public DateTime ReservationDate {get;set;}
        [Required, Range(1,16)]
        public int NumberInParty { get; set; }
        [StringLength(15)]
        public string ContactPhone { get; set; }
        [Required]
        [StringLength(1)]
        public string ReservationStatus { get; set; }
        [StringLength(1)]
        public string EventCode { get; set; }

        //Navigation properties
        public virtual SpecialEvent Event { get; set; }

        // the Reservations table (sql) is a many to many
        //relationship to the Tables table (sql)

        //Sql solves this problem by having an associate table
        //that has a compound primary key created from Reservations
        // and Tables.

        //We will NOT be creating an entity for this associate table.
        //Instead we will create on overload map in our DbContext class

        //However, we can still create the virtual navigation property to
        //accomondate this relationship

        public virtual ICollection<Table> Tables { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
      
    }
}
