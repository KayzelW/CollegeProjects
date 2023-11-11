/*
Dynamic18. Дано число D и ссылки A1 и A2 на начало и конец очереди, 
содержащей не менее двух элементов. Добавить элемент со значением D в 
конец очереди и извлечь из очереди первый (начальный) элемент. Вывести 
значение извлеченного элемента, а также ссылки на начало и конец 
полученной очереди. После извлечения элемента из очереди вызвать для 
него метод Dispose.

Капитонов Роман 11.11.2023 ~ минут
*/


var queue = new Queue<int>();
queue.Enqueue(10);
queue.Enqueue(20);

Console.WriteLine("Исходная очередь:");
PrintQueue(queue);

Console.WriteLine("Введите D:");
var D = int.Parse(Console.ReadLine());
queue.Enqueue(D);

var extractedElement = queue.Dequeue();

Console.WriteLine($"\nИзвлеченный элемент: {extractedElement}");
Console.WriteLine("Новая очередь после добавления и извлечения:");
PrintQueue(queue);
GC.Collect(); //В C# нет метода Dispose

static void PrintQueue(Queue<int> queue)
{
    foreach (var item in queue)
    {
        Console.Write($"{item} ");
    }
    Console.WriteLine();
}