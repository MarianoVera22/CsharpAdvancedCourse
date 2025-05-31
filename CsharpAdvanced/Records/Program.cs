using System.Data.Common;
using System.Runtime.InteropServices;

var beer = new Beer("Celebrator", 8.5, new Brand("Ayinger"));
Console.WriteLine(beer.Name);

var beer2 = new Beer("Erdinger", 8, new Brand("Erdinger"));
Console.WriteLine(beer==beer2);

var beer3 = new Beer("Celebrator", 8.5, new Brand("Ayinger"));
Console.WriteLine(beer == beer3);

var (name, acohol, brand ) = beer;
Console.WriteLine(brand.Name);

var (n, _, _) = beer;
Console.WriteLine($"Nombre: {n}");

var mexico = new Country("Mexico") { Population = 1300000000 };
//mexico.Name = ""; No se puede mutar
mexico.Population = 129000000;

var beer4 = beer with { Name = "Larger Hell" };

//beer.Name = "Erdinger"; No se puede ya que los records son inmutables
record Beer(string Name, double Alcohol, Brand brand);
record Brand(string Name); // Si fuera una class toma por referencia y la comparacion es false

record Country(string Name) { 
    public int Population { get; set; } //Elemento mutable de un record
}