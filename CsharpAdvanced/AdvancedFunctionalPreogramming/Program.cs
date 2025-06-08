using System.Text.RegularExpressions;
using AdvancedFunctionalPreogramming;

// Closure

var sum = Closure.SumClosure();
var sum2 = Closure.SumClosure();
//sum(1, 2);
//sum(2, 3);

//sum2(4, 5);
//sum(5, 6);

var fn = Closure.DelayExecutor(1000,
    () => Console.WriteLine("Ejecucion de funcion"));
//fn();


// Map

List<int> numbers = new List<int>() {
    1,2,3,4,5,6,7,8,9,10,11,12,13
};

var stringNumbers = numbers.Map<int, string>(
    (item) => $"El numero es: {item}"
    );

foreach (var item in stringNumbers) {
    //Console.WriteLine(item);
}

// Filter

var max5Numbers = numbers.Filter((item) => item > 5);

//foreach (var item in max5Numbers) {
//    Console.WriteLine(item);
//}


// Reduce

int total = numbers.Reduce((acum, item) => acum + item, 0);
//Console.WriteLine(total);

// Composition

Func<double, double, double> add = (a,b) => a + b;
Func<double, double> mulx2 = (a) => a * 2;
Func<double, double, double> mul = (a, b) => a * b;

Func<double, double, double> addAndMulx2 = (a, b) => mulx2(add(a,b));

var result = addAndMulx2(5, 10);
//Console.WriteLine(result);

Func<double, double, double, double> addAndMul = (a,b,c) => mul(add(a,b),c);
var result2 = addAndMul(5, 10, 3);
//Console.WriteLine(result2);

Func<int, string> toString = (x) => $"Number: {x}";
Func<int, bool> max5 = (x) => x > 5;

Func<List<int>, List<string>> numbersMax5AndString = (lst) => ListExtensions.Map(ListExtensions.Filter(lst, max5), toString);

var numberResult = numbersMax5AndString(numbers);
//numberResult.ForEach(Console.WriteLine);

// Pipe

Func<string, string> removeSpace = (s) => s.Replace(" ", "");
Func<string, string> firstCapitalLetter = (s) => char.ToUpper(s[0]) +s.Substring(1);
Func<string, string> removeNumbers = (s) => Regex.Replace(s, @"\d","");

string text = "lau2381467 7327154 ra182478ma0819274 r2198i1234na";
var cleanText= Functions.PipeStrings(text, removeSpace, firstCapitalLetter, removeNumbers);
var cleanText2 = Functions.Pipe(text, removeSpace, firstCapitalLetter, removeNumbers);
var numbersxPipe = Functions.Pipe(numbers,
    lst => lst.Map(e => e * 2),
    lst => lst.Map(e => e - 1)
    //lst => lst.Reduce((ac, item) => ac + item,0) No se puede por que retorna solo un entero
    );

var numberxPipe = numbers.P(lst => lst.Map(e => e * 2))
    .P(lst => lst.Map(e => e - 1))
    .P(lst => lst.Reduce((ac, item) => ac + item, 0)); //Funciones con distinto cuerpo

//Console.WriteLine(cleanText);
//Console.WriteLine(cleanText2);
//numbersxPipe.ForEach(Console.WriteLine);
//Console.WriteLine(numberxPipe);


// Currying

Func<string, Func<string, string>> Concat() {
    return a => b => a +" "+ b;
}

var concat = Concat();
var concatWithHi = concat("Hola");
//Console.WriteLine(concatWithHi("Hector"));
//Console.WriteLine(concatWithHi("Mariano"));

Func<decimal, Func<decimal, Func<decimal, decimal>>> calculateTotal =
    basePrice => tax => discount => (basePrice + (basePrice * tax) - discount);

var basePrice = 100;
var tax = 0.1m;
var discount = 20;

var calculateWithBasePrice = calculateTotal(basePrice);
var calculateWithTax = calculateWithBasePrice(tax);
var amount = calculateWithTax(discount);
var amountWithoutTax = calculateWithBasePrice(0)(discount);
var amountWithoutTaxAndDiscount = calculateWithBasePrice(0)(0);

//Console.WriteLine($"El total es: {amount}");
//Console.WriteLine($"El total sin impuestos es: {amountWithoutTax}");
//Console.WriteLine($"El total sin impuestos ni descuento es: {amountWithoutTaxAndDiscount}");

// Memoization

var pow = Memoization.Pow(2);
//Console.WriteLine(pow(2));
//Console.WriteLine(pow(2)); // ya existe
//Console.WriteLine(pow(2)); // ya existe
//Console.WriteLine(pow(3));
//Console.WriteLine(pow(3)); // ya existe

var requestAsync = Memoization.GetUrl("https://jsonplaceholder.typicode.com/posts");
//Console.WriteLine(await requestAsync(1));
//Console.WriteLine(await requestAsync(1));// ya existe
//Console.WriteLine(await requestAsync(1));// ya existe
//Console.WriteLine(await requestAsync(2));
//Console.WriteLine(await requestAsync(2));// ya existe

var mulx5 = (double x) => x * 5;
var mem = Memoization.Mem(mulx5); //<double, double> es una redundacia por que el programa ya lo sabe

//Console.WriteLine(mem(2));
//Console.WriteLine(mem(2));

var getUrl = async (string url) =>
{
    using (var client = new HttpClient())
    {
        var response = await client.GetAsync(url);
        var responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }
};

var memAsync =  Memoization.MemAsync(getUrl);
//Console.WriteLine(await memAsync("https://jsonplaceholder.typicode.com/posts/1"));
//Console.WriteLine(await memAsync("https://jsonplaceholder.typicode.com/posts/1"));

// Functor

var identitiy = new Identity<int>(55);
var newIdentity = identitiy.Map<string>(x=> "Es un numero envuelto: "+x.ToString());
//Console.WriteLine(newIdentity.GetValue());

var beerPrice = new Identity<double>(100);
var beerTax = 0.1;
var beerDiscount = 15;

var totalBeerPrice = beerPrice
    .Map(x => x + (x * beerTax))
    .Map(x => x - beerDiscount)
    .Map(x => "El resultado es: " + x.ToString());

//Console.WriteLine(totalBeerPrice.GetValue());
//Console.WriteLine(beerPrice.GetValue());

var numberMFString = MaybeFunctore<int>
    .Some(8)
    .Map(x => x * 2)
    //.Map(x => x / 0) // Ocasiona error y no lo considera, el Monad si
    .Map(x => $"El maybe Number es {x}");

//Console.WriteLine(numberMFString.GetValue());


// Monad

MaybeMonad<int> Div(int num, int div)
{
    if (div == 0)
    {
        return MaybeMonad<int>.None();
    }
    return MaybeMonad<int>.Some(num/div);
}

MaybeMonad<int> Add(int num1, int num2)
{
    if (num1 < 0 || num2 <0)
    {
        return MaybeMonad<int>.None();
    }
    return MaybeMonad<int>.Some(num1 + num2);
}

var numberMM = MaybeMonad<int>.Some(80)
    .Bind(x => Div(x, 0)) // No da error, lo maneja internamente 
    .Bind(x => Add(x, 2));

Console.WriteLine(numberMM);

var myBeer = Search(1)
    .Bind(x => ValidateName(x.Name));

Console.WriteLine(myBeer);

var myBeer2 = Search(10)
    .Bind(x => ValidateName(x.Name)); // No falla, detecta el error

Console.WriteLine(myBeer2);

MaybeMonad<Beer> Search(int id)
{
    if (id == 1)
    {
        return MaybeMonad<Beer>.Some(
            new Beer() 
            {
                Id= 1,
                Name = "Erdinger",
                Alcohol = 8
            }
        );
    }
    return MaybeMonad<Beer>.None();
}

MaybeMonad<string> ValidateName(string name)
{
    if (string.IsNullOrEmpty(name))
    {
        return MaybeMonad<string>.None();
    }
    return MaybeMonad<string>.Some(name);
}

class Beer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Alcohol { get; set; }
}