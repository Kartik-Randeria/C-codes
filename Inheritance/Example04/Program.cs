﻿using System;

namespace PolyExample04
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
    public new void display()
    {
      Console.WriteLine("B::display()");
    }
  }

  class C : B
  {
    public override void display()
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
      // then we a1.display() is called so compiler goes to class A display method, here virtual keyword is present so it searches for override in subclass B, it's not found, now the compiler will see what is present, there is new keyword in class B display() so the controls goes back in class A (parent class) 
      // Now we have to check syntax if override is present in subclass then parent class must have either virtual or override if either of it is not there then compiler throws error
      // in this case class C display() is override and its parent class B display() does not have either virtual or override so compiler throws error: 'C.display()': cannot override inherited member 'B.display()' because it is not marked virtual, abstract, or override
    }
  }
}
