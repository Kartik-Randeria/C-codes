using System;

namespace Polymorphism
{
  // Concepts:

  // Method Overriding: It means redefining same method in child class. In method Overriding, by default base class (parent) method is called.

  // Method Hiding (new keyword): C# supports method hiding. For hiding the base class method from derived class simply declare the derive class method with new keyword

  //virtual and override keyword: In C# for overriding the base class method in derived class, we have to declare base class method as virtual and derived class method as override. If we use override then we don't need to use new keyword to declare method.

  //Mixing Method Overriding and Method Hiding: It is done by using new and virtual keyword since the method of derived class can be virtual and new at the same time. This is required when we want to further override the derived class method into next level, here I am overriding Class B, Test3() method in Class C as shown below :
  class A
  {
    public void Test()
    {
      Console.WriteLine("A::Test()");
    }

    public virtual void Test2()
    {
      Console.WriteLine("A::Test2()");
    }
    public void Test3()
    {
      Console.WriteLine("A::Test3()");
    }
  }

  class B : A
  {
    // If this overriden method is not declared using new keyword then compiler gives warning as C# supports method hiding
    public new void Test()
    {
      Console.WriteLine("B::Test()");
    }
    public override void Test2()
    {
      Console.WriteLine("B::Test2()");
    }
    public new virtual void Test3()
    {
      Console.WriteLine("B::Test3()");
    }
  }

  class C : B
  {
    public new void Test()
    {
      Console.WriteLine("C::Test()");
    }
    public override void Test2()
    {
      Console.WriteLine("C::Test2()");
    }
    public override void Test3()
    {
      Console.WriteLine("C::Test3()");
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      A a1 = new A();
      B b1 = new B();
      C c1 = new C();

      Console.WriteLine("--------------------------Simple-------------------------------");
      a1.Test(); //output=> A::Test()
      b1.Test(); //output=> B::Test()
      c1.Test(); //output=> C::Test()
      Console.WriteLine("----------------override and virtual keyword-------------------");

      //If LHS and RHS is different then new keyword hides the subclass method (only PC format allowed Parent-Child)
      a1 = new B();
      a1.Test2(); //output=> B::Test2()

      b1 = new C();
      b1.Test2(); //output=> C::Test2()

      Console.WriteLine("--------------Mixing Overriding and Hiding----------------------");

      a1 = new B();
      a1.Test3(); //output=> A::Test3()

      a1 = new C();
      a1.Test3(); //output=> A::Test3()

      b1 = new C();
      b1.Test3(); //output=> C::Test3()



      Console.ReadKey();
    }
  }
}
