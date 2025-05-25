using System.Runtime.CompilerServices;
using ExtensionsMethods;

int number = 10;
int number2 = number.X2();
//Console.WriteLine(number2);

var sale = new Sale(15);
//Console.WriteLine(sale.GetInfo());

int num = 20;
//Console.WriteLine(num.Mul(15));

List<int> numbers = new List<int>() {
    15, 20, 30, 46
};

//Console.WriteLine(num.Exists(numbers));

string name = "Mariano";
List<string> names = new List<string>() {
    "Laura", "Pedro", "Yolanda"
};

//Console.WriteLine(name.Exists(names));
//Console.WriteLine(name.IsOn(names));


var beer = new Beer() { Quantity = 500 };
var wine = new Wine() { Quantity = 1000 };
Console.WriteLine(beer.GetDescription());
Console.WriteLine(wine.GetDescription());

beer.SetBrand("Fullers").SetName("London Porter").SetQuantity(550);


#region Class
public static class IntOperations {
    public static int X2(this int number) {
        return number * 2;
    }

    public static int Mul(this int number, int multiplier) {
        return number * multiplier;
    }
}

public static class SaleExtensions
{
    public static string GetInfo(this Sale sale)
    {
        return "El monto es $" + sale.Amount;
    }
}

public static class ListExtensions { 
    public static bool Exists<T> (this T element, List<T> list){
        foreach (T item in list) {
            if (item.Equals(element)) {
                return true;
            }
        }
        return false;
    }

    public static bool IsOn<T>(this T element, List<T> list) where T : class {
    
        foreach (T item in list)
        {
            if (item.Equals(element))
            {
                return true;
            }
        }
        return false;
    }
}
#endregion

public interface IDrink { 
    public decimal Quantity { get; set; }
}


public static class DrinkExtensions {
    public static string GetDescription(this IDrink drink) {
        return $"La bebida tiene {drink.Quantity} ml";
    }
}

public class Beer : IDrink {
    public decimal Quantity { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
}

public class Wine : IDrink
{
    public decimal Quantity { get; set; }
}

public static class BeerExtensions {
    public static Beer SetQuantity(this Beer beer, decimal quantity) {
        beer.Quantity = quantity;
        return beer;
    }

    public static Beer SetName(this Beer beer, string name) {
        beer.Name = name;
        return beer;
    }

    public static Beer SetBrand(this Beer beer, string brand) { 
        beer.Brand = brand.ToUpper();
        return beer;
    }
}