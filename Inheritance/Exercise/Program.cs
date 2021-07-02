using System;

namespace PolymorphismExercise
{
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
    // If this Test() method is not declared using new keyword then compiler gives warning as C# supports method hiding
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

      // (only PC format allowed Parent-Child)
      // new keyword means go back


      a1 = new C();
      a1.Test2(); //output=> C::Test2()
      // first we have to see chain is formed from where to where (in this case from A to C)
      // Now we go to a1.Test2() (it will go in class A and calls Test2()), here whenever compiler sees virtual keyword it searches for override in subclass (class B) and if it is found then it comes down to that overriden method
      // Now compiler will search in subclass(in class C) for override provided its in the given chain (A to C), if override is present it will print the output of subclass (class C) else it will go back. 

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


