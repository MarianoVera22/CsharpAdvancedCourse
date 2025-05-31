using System.Runtime.InteropServices;

var calculator = new Calculator(15);
Console.WriteLine(Calculator.Pi);

List<string> beers = new List<string>() {
    "Weizen", "Pils"
};

var brand = new Brand("Krombacher",beers);
var brandName = brand.Name;
var brand2 = brand.With("Erdinger");
var brand3 = brand.With(beers: new List<string>() { "Light" });
var people = new
{
    Name = "Juan",
    Age = "29",
    Country = "Argentina"
};

//people.Name = "Pedro"; No me deja modificar por que es anonimo


//brand.Name = "Erinder"; No se puede por que no tiene SET
//brand.Beers = new List<string>(); Tampoco en las listas 

// Pero si puedo agregar, por eso tengo que agregar IREADONLY para que sea inmutable
//brand.Beers.Add("Dark");

public class Brand { 
    public string Name { get; }
    //public List<string> Beers { get; }
    public IReadOnlyList<string> Beers { get; }

    public Brand(string name, List<string> beers) {
        Name = name;
        Beers = beers;
    }

    public Brand With(string? name = null, List<string> beers = null) {
        return new Brand(name?? this.Name, beers ?? this.Beers.ToList());
    }
}
public class Calculator {
    public const double Pi = 3.1416;
    public readonly int Value;

    public Calculator(int value)
    {
        Value = value;
    }
}