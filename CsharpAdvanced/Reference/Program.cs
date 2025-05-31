// por referencia asociada a ref
int num = 1;
Console.WriteLine(num);
change(ref num);
Console.WriteLine(num);


// los objetos se mandan siempre por referencia default
var number = new Number() { Num = 1 };
Console.WriteLine(number.Num);
changeObject(number);
Console.WriteLine(number.Num);

// excepcion string
string name = "Pedro";
Console.WriteLine(name);
changeString(name);
Console.WriteLine(name);

void change(ref int num2) {
    num2= 2;
}

void changeObject(Number n) {
    n.Num = 2;
}

void changeString(string str)
{
    str = "Juan";
}
public class Number { 
    public decimal Num {  get; set; }
}