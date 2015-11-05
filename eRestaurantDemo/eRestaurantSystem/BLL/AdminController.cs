using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eRestaurantSystem.DAL;
using eRestaurantSystem.DAL.Entities;
using eRestaurantSystem.DAL.DTOs;
using eRestaurantSystem.DAL.POCOs;
using System.ComponentModel; //Object Data Source

#endregion

namespace eRestaurantSystem.BLL
{
    [DataObject]
    public class AdminController
    {

        #region Queries

        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<SpecialEvent> SpecialEvents_List()
        {
            //connect to our DbContext class in the DAL
            //create an instance of the class
            //we will use a transaction to hold our query
            using (var context = new eRestaurantContext())
            {
                //method syntax
                //return context.SpecialEvents.OrderBy(x => x.Description).ToList();

                //query syntax
                var results = from item in context.SpecialEvents
                              orderby item.Description
                              select item;
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Waiter> Waiters_List()
        {
            using (var context = new eRestaurantContext())
            {
                var results = from item in context.Waiters
                              orderby item.LastName, item.FirstName
                              select item;
                return results.ToList();  //none, 1 or more rows
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Waiter GetWaiterByID(int waiterid)
        {
            using (var context = new eRestaurantContext())
            {
                var results = from item in context.Waiters
                              where item.WaiterID == waiterid
                              select item;
                return results.FirstOrDefault();  //one row at most
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Reservation> GetReservationsByEventCode(string eventcode)
        {
            using (var context = new eRestaurantContext())
            {
                //query syntax
                var results = from item in context.Reservations
                              where item.EventCode.Equals(eventcode)
                              orderby item.CustomerName, item.ReservationDate
                              select item;
                return results.ToList();



            }
        }

    [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<ReservationsByDate> GetReservationsByDate(string reservationdate)
        {
            using (var context = new eRestaurantContext())
            {
                //Linq is not very playful or cooperative with
                //DateTime

                //extract the year, month and day ourselves out
                //of the passed parameter value
                int theYear = (DateTime.Parse(reservationdate)).Year;
                int theMonth = (DateTime.Parse(reservationdate)).Month;
                int theDay = (DateTime.Parse(reservationdate)).Day;

                var results = from eventitem in context.SpecialEvents
                              orderby eventitem.Description
                              select new ReservationsByDate() //a new instance for each specialevent row on the table
                              {
                                  Description = eventitem.Description,
                                  Reservations = from row in eventitem.Reservations
                                                 where row.ReservationDate.Year == theYear
                                                   && row.ReservationDate.Month == theMonth
                                                   && row.ReservationDate.Day == theDay
                                                 select new ReservationDetail() // a new for each reservation of a particular specialevent code
                                                 {
                                                     CustomerName = row.CustomerName,
                                                     ReservationDate = row.ReservationDate,
                                                     NumberInParty = row.NumberInParty,
                                                     ContactPhone = row.ContactPhone,
                                                     ReservationStatus = row.ReservationStatus
                                                 }

                              };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<MenuCategoryItems> MenuCategoryItems_List()
        {
            using (var context = new eRestaurantContext())
            {
                var results = from menuitem in context.MenuCategories
                              orderby menuitem.Description
                              select new MenuCategoryItems() 
                              {
                                  Description = menuitem.Description,
                                  MenuItems = from row in menuitem.MenuItems
                                              select new MenuItem() 
                                                 {
                                                     Description = row.Description,
                                                     Price = row.CurrentPrice,
                                                     Calories = row.Calories,
                                                     Comment = row.Comment
                                                 }
                              };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<CategoryMenuItems> GetReportCategoryMenuItems()
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var results = from cat in context.Items
                              orderby cat.Category.Description, cat.Description
                              select new CategoryMenuItems
                              {
                                  CategoryDescription = cat.Category.Description,
                                  ItemDescription = cat.Description,
                                  Price = cat.CurrentPrice,
                                  Calories = cat.Calories,
                                  Comment = cat.Comment
                              };

                return results.ToList(); // this was .Dump() in Linqpad
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<WaiterBilling> GetWaiterBillingReport()
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var results = from abillrow in context.Bills
                              where abillrow.BillDate.Month == 5
                              orderby abillrow.BillDate,
                                      abillrow.Waiter.LastName,
                                      abillrow.Waiter.FirstName
                              select new WaiterBilling()
                              {
                                  BillDate = abillrow.BillDate.Year + "/" +
                                             abillrow.BillDate.Month + "/" +
                                             abillrow.BillDate.Day,
                                  WaiterName = abillrow.Waiter.LastName + ", " +
                                               abillrow.Waiter.FirstName,
                                  BillID = abillrow.BillID,
                                  BillTotal = abillrow.Items.Sum(eachbillitemrow =>
                                          eachbillitemrow.Quantity * eachbillitemrow.SalePrice),
                                  PartySize = abillrow.NumberInParty,
                                  Contact = abillrow.Reservation.CustomerName
                              };

                return results.ToList();
            }
        }

        #endregion

        #region Add, Update, Delete of CRUD for CQRS
        [DataObjectMethod(DataObjectMethodType.Insert,false)]
        public void SpecialEvents_Add(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //these methods are execute using an instance level item
                //set up a instance pointer and initialize to null
                SpecialEvent added = null;
                //setup the command to execute the add
                added = context.SpecialEvents.Add(item);
                //command is not executed until it is actually saved.
                context.SaveChanges();
            }
        }
         [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void SpecialEvents_Update(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //indicate the updating item instance
                //alter the Modified Status flag for this instanc
                context.Entry<SpecialEvent>(context.SpecialEvents.Attach(item)).State =
                    System.Data.Entity.EntityState.Modified;
                //command is not executed until it is actually saved.
                context.SaveChanges();
            }
        }
         [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void SpecialEvents_Delete(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                
                //lookup the instance and record if found (set pointer to instance)
                SpecialEvent existing = context.SpecialEvents.Find(item.EventCode);

                //setup the command to execute the delete
                context.SpecialEvents.Remove(existing);
                //command is not executed until it is actually saved.
                context.SaveChanges();
            }
        }

         [DataObjectMethod(DataObjectMethodType.Insert, false)]
         public int Waiters_Add(Waiter item)
         {
             using (eRestaurantContext context = new eRestaurantContext())
             {
                 //these methods are execute using an instance level item
                 //set up a instance pointer and initialize to null
                 Waiter added = null;
                 //setup the command to execute the add
                 added = context.Waiters.Add(item);
                 //command is not executed until it is actually saved.
                 context.SaveChanges();
                 //the Waiter instance added contains the newly inserted
                 //record to sql including the generated pkey value
                 return added.WaiterID;
             }
         }
         [DataObjectMethod(DataObjectMethodType.Update, false)]
         public void Waiters_Update(Waiter item)
         {
             using (eRestaurantContext context = new eRestaurantContext())
             {
                 //indicate the updating item instance
                 //alter the Modified Status flag for this instanc
                 context.Entry<Waiter>(context.Waiters.Attach(item)).State =
                     System.Data.Entity.EntityState.Modified;
                 //command is not executed until it is actually saved.
                 context.SaveChanges();
             }
         }
         [DataObjectMethod(DataObjectMethodType.Delete, false)]
         public void Waiters_Delete(Waiter item)
         {
             using (eRestaurantContext context = new eRestaurantContext())
             {

                 //lookup the instance and record if found (set pointer to instance)
                 Waiter existing = context.Waiters.Find(item.WaiterID);

                 //setup the command to execute the delete
                 context.Waiters.Remove(existing);
                 //command is not executed until it is actually saved.
                 context.SaveChanges();
             }
         }
        #endregion

        #region FrontDesk
         [DataObjectMethod(DataObjectMethodType.Select,false)]
         public DateTime GetLastBillDateTime()
         {
             using (eRestaurantContext context = new eRestaurantContext())
             {
                 var result = 
                     context.Bills.Max(eachBillrow => eachBillrow.BillDate);
                 return result;
             }
         }
         [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ReservationCollection> ReservationsByTime(DateTime date)
         {
             using (eRestaurantContext context = new eRestaurantContext())
             {
                 var result = (from data in context.Reservations
                               where data.ReservationDate.Year == date.Year
                               && data.ReservationDate.Month == date.Month
                               && data.ReservationDate.Day == date.Day
                                   // && data.ReservationDate.Hour == timeSlot.Hours
                               && data.ReservationStatus == Reservation.Booked
                               select new ReservationSummary()
                               {
                                   ID = data.ReservationID,
                                   Name = data.CustomerName,
                                   Date = data.ReservationDate,
                                   NumberInParty = data.NumberInParty,
                                   Status = data.ReservationStatus,
                                   Event = data.Event.Description,
                                   Contact = data.ContactPhone
                               }).ToList();  //causes execution of the query so
                                            //that the retrieved data is in memory
                 
                 var finalResult = from item in result
                                   orderby item.NumberInParty
                                   group item by item.Date.Hour into itemGroup //temporary data collection
                                   select new ReservationCollection() //DTO
                                   {
                                       Hour = itemGroup.Key,
                                       Reservations = itemGroup.ToList()
                                   };
                 return finalResult.OrderBy(x => x.Hour).ToList();  //method syntax
             }
         }
        #endregion
    }//eof class
}//eof namespace


