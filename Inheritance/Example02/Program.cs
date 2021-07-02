using System;

namespace PolyExample02
{
  class A
  {
    public virtual void display()
    {
      Console.WriteLine("A::display()");
    }
  }

  class B : A
  {
    public override void display()
    {
      Console.WriteLine("B::display()");
    }
  }

  class C : B
  {
    public new void display()
    {
      Console.WriteLine("C::display()");
    }
  }
  class Program
  {
    public static void Main()
    {
      A a1 = new C();
      a1.display();
      // first we have to see chain is formed from where to where (A to C)
      // then we a1.display() is called so compiler goes to class A display method, here virtual keyword is present so it searches for override in subclass B, it's found so the controls comes down in class B now compiler will again search for override keyword (provider control is in chain) in subclass C, it's not found, now compiler see what is there, there is new keyword which tells to go back in class B so the controls comes up in class B display() and prints the output
    }
  }
}
