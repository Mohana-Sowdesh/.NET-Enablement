using System;
using System.Collections.Generic;

class Dog
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class demo{
    static void Main()
    {
        List<Dog> dogs = new List<Dog>() {
            new Dog { Name = "Rex", Age = 4 },
            new Dog { Name = "Sean", Age = 0 },
            new Dog { Name = "Stacy", Age = 3 }
         };
         var names = dogs.Select(x => x.Name);
         foreach (var name in names)
         {
             Console.WriteLine(name);

         }
    }
}
