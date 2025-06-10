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

//var taskResult = Methods.AddAsync(3, 5);

//Console.WriteLine("Mientras voy a comer");
//var result = await taskResult;

//Console.WriteLine("Voy a banarme");
//Console.WriteLine(result);

// ContinueTask

//var tasks = Task.Run(() =>
//{
//Console.WriteLine("--------------Inicia mi tarea secuencial--------------");

//var resultTask = Methods.AddAsync(5, 10);

//Console.WriteLine("--------------Finaliza mi tarea secuencial--------------");

//    return resultTask.Result;

//}).ContinueWith((resultTask) =>
//{
//Console.WriteLine("--------------Inicia mi segunda tarea secuencial--------------");

//var result = resultTask.Result;
//Console.WriteLine($"El resultado es {result}");

//Task.Delay(2000).Wait();

//Console.WriteLine("--------------Finaliza mi segunda tarea secuencial--------------");
//});

//await tasks;

//Console.WriteLine("--------------Fin de las tareas secuenciales--------------");


// WhenAll

//List<Task> waitTasks = new List<Task>()
//{
//    Methods.Wait(1000),
//    Methods.Wait(3000)
//};

//await Task.WhenAll(waitTasks);

//Console.WriteLine("Terminaron las tareas de espera");

//List<Task<double>> addTasks = new List<Task<double>>() {
//    Methods.AddAsync(10,10), Methods.AddAsync(20,20),Methods.AddAsync(30,30)
//};

//double[] results = await Task.WhenAll(addTasks);

//foreach (var res in results) {
//    Console.WriteLine("Resultado:" + res);
//}

//Console.WriteLine("Terminaron las tareas de suma");


// Thread (Mejor para procesos paralelos)

//Thread thread = new Thread(() => {
//    Console.WriteLine("Inicia ejecucion de hilo");

//    Thread.Sleep(5000);

//    Console.WriteLine("Fin ejecucion de hilo");
//});

//Console.WriteLine("Inicio de programa...");

//thread.Start();

//Console.WriteLine("El programa principal hace otra cosa...");

//thread.Join();

//Console.WriteLine("Fin de programa");


// Parallel.For

//int numberOfFiles = 100;

//Parallel.For(0, numberOfFiles, i =>
//{
//    string fileName = $"archivo_{i}.txt";
//    string content = $"archivo numero {i}.";

//    File.WriteAllText(fileName, content);

//    Console.WriteLine($"Archivo '{fileName}' creado por el hilo: {Task.CurrentId}");
//});

// Parallel.ForEach

//List<int> ids = new List<int>()
//{
//    15,7,543,87,23,654,765,45,31,12
//};

//Parallel.ForEach(ids, id =>
//{
//    string fileName = $"Archivo_{id}.txt";
//    string content = $"Archivo numero {id}";

//    File.WriteAllText(fileName , content );

//    Console.WriteLine($"Archivo '{fileName}' creado por el hilo: {Task.CurrentId}");
//}
//);

//Console.WriteLine("Se ha terminado de hacer todos los procesos");

// Parallel.ForEachAsync

List<int> episodes = new List<int>()
{
    1,5,6,2,10,22,54,33,22,15
};

var URL = "https://rickandmortyapi.com/api/episode/";
var httpClient = new HttpClient();

await Parallel.ForEachAsync(episodes, async(episode, cancellationToken) => {
    try
    {
        int threadId = Thread.CurrentThread.ManagedThreadId;

        HttpResponseMessage response = await httpClient.GetAsync(URL+episode);
        string responseBody = await response.Content.ReadAsStringAsync();

        string fileName = $"Episode{episode}.txt";
        await File.WriteAllTextAsync(fileName, responseBody);

        Console.WriteLine($"Archivo '{fileName}' creado por el hilo: {Task.CurrentId}");
    }
    catch (Exception ex) {
        Console.WriteLine($"Error al solicitar {URL}: {ex.Message}");
    }
});

Console.WriteLine("Se ha terminado de hacer todos los procesos");