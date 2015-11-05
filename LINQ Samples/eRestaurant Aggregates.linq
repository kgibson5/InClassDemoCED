<Query Kind="Expression">
  <Connection>
    <ID>1f6a4b30-57f4-4825-8a8c-b4e5c6c67b27</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

(from theBill in BillItems
where theBill.BillID == 104
select theBill.SalePrice * theBill.Quantity).Sum()

(from customer in Bills
where customer.PaidStatus == true
select customer.BillItems.Sum(theBill => theBill.SalePrice * theBill.Quantity)).Max()

//the average paid bill.

(from customer in Bills
where customer.PaidStatus == true
select customer.BillItems.Sum(theBill => theBill.SalePrice * theBill.Quantity)).Average()

//what is the average number of items per paid bill
//we need to get a list of numbers representing the items per bill
//we take an average of the list
(from customer in Bills
where customer.PaidStatus 
select customer.BillItems.Count()).Average()