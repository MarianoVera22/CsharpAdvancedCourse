using Generics;

var box = new Box<int>(12);
box.Set(15);
//Console.WriteLine(box.GetContent());

var box2 = new Box<bool>(false);
//Console.WriteLine(box2.GetContent());

var b = box2.Get();

var beerRepository = new BeerRepository();
beerRepository.Add("Delirium");
beerRepository.Add("Celebrator");
//Show(beerRepository);

void Show<T>(IRepository<T> repository) {
    foreach (var item in repository.GetAll()) {
        Console.WriteLine(item);
    }
}

void ShowQuantity<T>(T drink) where T : Drink {
    Console.WriteLine(drink.Quantity);
}

void ShowInfo<T>(T element) where T : IInfo { 
    Console.WriteLine(element.GetInfo());
}

var drink = new Drink(550);
var beer = new Beer("Erdinger", 500);
ShowQuantity(drink);
ShowQuantity(beer);
ShowInfo(beer);

Operation<int> add = (a, b) => a + b;
//Console.WriteLine(add(1,2));

Operation<double> addDouble = (a, b) => a + b;
//Console.WriteLine(addDouble(1.3, 2.5));

Operation<string> concatenate = (a, b) => a +" "+ b;
//Console.WriteLine(concatenate("Mariano","Vera"));

Action<IRepository<string>> s = Show;
//s(beerRepository);
var r2 = beerRepository;

delegate T Operation<T>(T elem1, T elem2);