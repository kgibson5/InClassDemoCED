<Query Kind="Expression">
  <Connection>
    <ID>1f6a4b30-57f4-4825-8a8c-b4e5c6c67b27</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//orderby

//default is ascending
from food in Items
orderby food.Description
select food

//also available descending
from food in Items
orderby food.CurrentPrice descending
select food

//can use both ascending and  descending
from food in Items
orderby food.CurrentPrice descending, food.Calories ascending
select food

//you can use where and orderby together
from food in Items
where food.MenuCategory.Description.Equals("Entree")
orderby food.CurrentPrice descending, food.Calories ascending

select food