<Query Kind="Expression">
  <Connection>
    <ID>1f6a4b30-57f4-4825-8a8c-b4e5c6c67b27</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//groupby

from food in Items
group food by food.MenuCategory.Description

//this creates a key with a value and the row collection for that key value

//more than one field
from food in Items
group food by new {food.MenuCategory.Description, food.CurrentPrice}