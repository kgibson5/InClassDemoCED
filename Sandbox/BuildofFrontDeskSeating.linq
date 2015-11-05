<Query Kind="Statements">
  <Connection>
    <ID>1f6a4b30-57f4-4825-8a8c-b4e5c6c67b27</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Step 1 - Get the table info along with any walk-in bills and reservation bills for the specific time slot
var date = Bills.Max(thebill => thebill.BillDate);
var newtime = Bills.Max(thebill => thebill.BillDate).TimeOfDay.Add(new TimeSpan(0,30,0));
var step1 = from eachTableRow in Tables
             select new
             {
                Table = eachTableRow.TableNumber,
                Seating = eachTableRow.Capacity,
                // This sub-query gets the bills for walk-in customers
                WalkIns = from walkIn in eachTableRow.Bills
                        where 
                               walkIn.BillDate.Year == date.Year
                            && walkIn.BillDate.Month == date.Month
                            && walkIn.BillDate.Day == date.Day
                            && walkIn.BillDate.TimeOfDay <= newtime
                            && (!walkIn.OrderPaid.HasValue || walkIn.OrderPaid.Value >= newtime)
                         	&& (!walkIn.PaidStatus || walkIn.OrderPaid >= newtime)
                        select walkIn,
                 // This sub-query gets the bills for reservations
                 Reservations = from booking in eachTableRow.ReservationTables
                        from reservationParty in booking.Reservation.Bills
                        where 
                               reservationParty.BillDate.Year == date.Year
                            && reservationParty.BillDate.Month == date.Month
                            && reservationParty.BillDate.Day == date.Day
                            && reservationParty.BillDate.TimeOfDay <= newtime
                            && (!reservationParty.OrderPaid.HasValue || reservationParty.OrderPaid.Value >= newtime)
                         	&& (!reservationParty.PaidStatus || reservationParty.OrderPaid >= newtime)
                        select reservationParty
             };
//step1.Dump();
var step2 = from dataRow in step1.ToList() // .ToList() forces the first result set to be in memory
            select new
            {
                Table = dataRow.Table,
                Seating = dataRow.Seating,
                CommonBilling = from info in dataRow.WalkIns.Union(dataRow.Reservations)
                                select new // info
                                {
                                    BillID = info.BillID,
                                    BillTotal = info.BillItems.Sum(bi => bi.Quantity * bi.SalePrice),
                                    Waiter = info.Waiter.FirstName,
                                    Reservation = info.Reservation
                                }
            };
step2.Dump();