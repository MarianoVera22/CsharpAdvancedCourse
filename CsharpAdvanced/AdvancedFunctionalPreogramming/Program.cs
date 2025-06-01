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
    );


Console.WriteLine(cleanText);
Console.WriteLine(cleanText2);
numbersxPipe.ForEach(Console.WriteLine);