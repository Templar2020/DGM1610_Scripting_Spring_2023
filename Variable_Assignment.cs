using System;

namespace HelloWorld
{
  class Program
  {  
    
    static void Main(string[] args)
    {
    	// [data-type] [identifier] [assignment operator] [value]
    	// Variable Declaration
     	int age = 42;
     	float height = 6.25f;
     	double weight = 350.45d;
     	string nameFirst = "George";
      char middleIn = 'M';
     	bool alive = true;
    	
    	weight = 250.67d;
        
      Console.WriteLine(age); 
      Console.WriteLine(height);
      Console.WriteLine(weight);
      Console.WriteLine(nameFirst);
      Console.WriteLine(middleIn);
      Console.WriteLine(alive);
      
    }
  }
}
