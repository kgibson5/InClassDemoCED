<Query Kind="Program" />

void Main()
{
	//"hello " + "don" + " world" 
	//5+7
	//string name = "don";
	//string message = "hello " + name + " world"; 
	//message.Dump();
	SayHello("don");
}

// Define other methods and classes here
public void SayHello(string name)
{
	string message = "hello " + name + " world"; 
	message.Dump();
}