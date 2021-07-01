using System;

namespace Constructor
{
  // Constructor Overloadind : In C# we can overload constructor by creating another constructor with same name and different parameters

  class Program : Parent
  {
    public string param1, param2;

    // Static Constructor : It is like static block in java. It will be invoked only once for any number of instances of the class and it's during creation of first instance of the class or the first reference to a static member in the class. Static Constructor is used to initialize static fields. It is used to write the code that needs to be  executed only once. 
    static Program()
    {
      Console.WriteLine("Static Constructor Call");
    }

    // Default Constructor 
    Program() : this(2)
    {
      param1 = "Welcome";
      param2 = "Kartik";
      Console.WriteLine("Default Constructor Call");
    }

    //Parameterized Constructor : Constructor with atleast one parameter
    Program(string x, string y)
    {
      this.param1 = x;
      this.param2 = y;
      Console.WriteLine("Paramterized Constructor Call");
    }

    // Copy Constructor: It is a Parameterized Constructor that contains a parameter of same class type. It will copy the values from one instance to another instance
    Program(Program obj)
    {
      param1 = obj.param1;
      param2 = obj.param2;
      Console.WriteLine("Copy Constructor Call");
    }

    Program(int i) : base("parent call")
    {
      Console.WriteLine("this Inherited Constructor Call");
    }

    //Destructor
    ~Program()
    {
      Console.WriteLine("Destructor Call");
    }


    static void Main(string[] args)
    {
      // first static constructor is invoked
      Program p1 = new Program(); //Default constructor called automatically
      Program p2 = new Program("Hello", "World"); //Paramterized constructor called
      Program p3 = new Program(p2); //Copy constructor called


      Console.WriteLine("---------Default Constructor---------");
      Console.WriteLine(p1.param1 + " " + p1.param2);
      Console.WriteLine("--------Paramterized Constructor--------");
      Console.WriteLine(p2.param1 + " " + p2.param2);
      Console.WriteLine("--------Copy Constructor--------");
      Console.WriteLine(p3.param1 + " " + p3.param2);

      Console.ReadLine();
    }
  }

  class Parent
  {
    public Parent()
    {

    }
    public Parent(string i)
    {
      Console.WriteLine("base Parent Parameterized Constructor Call");
    }
  }
}
