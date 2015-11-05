<Query Kind="Statements">
  <Connection>
    <ID>1f6a4b30-57f4-4825-8a8c-b4e5c6c67b27</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//simpliest form for dumping an entity
Waiters

//simple query syntax
from person in Waiters
select person

//simple method syntax
Waiters.Select(x => x)

//inside our project we will be writting C# statement
var results = from person in Waiters
				select person;
//to display the contents of a variable in LinqPad
//use the .Dump() method
results.Dump();

//implemented inside a VS project's class library BLL method
//[DataObjectMethod(DataObjectMethodType.Select,false)]
//public List<Waiters> SomeMethodName ()
//{
	//you will need to connect to your DAL object
	//this will be done using a new xxxxx() constructor
	//assume your connection variable is called contextvaribale
	
	//do your query
	//var results = from person in contextvariable.Waiters
	//			select person;
	//return your results
	//return results.ToList();
//}