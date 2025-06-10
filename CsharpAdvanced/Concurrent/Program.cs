// Task

//Console.WriteLine("--------------Inicia mi programa--------------");

//var task = Task.Run(async () =>
//{
//    Console.WriteLine("Inicio de tarea asincrona");

//    await Task.Delay(1000);

//    Console.WriteLine("Fin de tarea asincrona");
//});

//Console.WriteLine("Algo extra"); // Se muestra antes de task, mientras este se ejecuta

//await task;

//Console.WriteLine("Algo extra despues de await"); // Se muestra despues de task

//Console.WriteLine("--------------Fin de mi programa--------------");

// Async await

using Concurrent;

//Console.WriteLine("--------------Inicia mi programa--------------");


//var task = Methods.Wait(1000);
//Console.WriteLine("Hago algo mas");
//await task; // Debe ser await para que respete el await de la funcion

//Console.WriteLine("--------------Fin de mi programa--------------");


// TResult

var taskResult = Methods.AddAsync(3, 5);

//Console.WriteLine("Mientras voy a comer");
var result = await taskResult;

//Console.WriteLine("Voy a banarme");
//Console.WriteLine(result);

// ContinueTask

var tasks = Task.Run(() =>
{
    //Console.WriteLine("--------------Inicia mi tarea secuencial--------------");

    var resultTask = Methods.AddAsync(5, 10);

    //Console.WriteLine("--------------Finaliza mi tarea secuencial--------------");

    return resultTask.Result;

}).ContinueWith((resultTask) =>
{
    //Console.WriteLine("--------------Inicia mi segunda tarea secuencial--------------");

    var result = resultTask.Result;
    Console.WriteLine($"El resultado es {result}");

    Task.Delay(2000).Wait();

    //Console.WriteLine("--------------Finaliza mi segunda tarea secuencial--------------");
});

await tasks;

//Console.WriteLine("--------------Fin de las tareas secuenciales--------------");


// WhenAll

List<Task> waitTasks = new List<Task>()
{
    Methods.Wait(1000),
    Methods.Wait(3000)
};

await Task.WhenAll(waitTasks);

Console.WriteLine("Terminaron las tareas de espera");

List<Task<double>> addTasks = new List<Task<double>>() {
    Methods.AddAsync(10,10), Methods.AddAsync(20,20),Methods.AddAsync(30,30)
};

double[] results = await Task.WhenAll(addTasks);

foreach (var res in results) {
    Console.WriteLine("Resultado:" + res);
}

Console.WriteLine("Terminaron las tareas de suma");