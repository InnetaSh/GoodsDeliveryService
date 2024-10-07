//Необходимо реализовать консольное приложение на C#, которое моделирует работу службы доставки товаров.
// У вас есть список заказов, каждый из которых должен быть обработан. Каждый заказ состоит из следующих данных:

//ID заказа
//Наименование товара
//Время обработки (в секундах)
//Условия:

//Каждый заказ обрабатывается в отдельном Task.
//Во время обработки заказа программа должна выводить в консоль сообщение о начале обработки заказа с указанием времени и ID заказа.
//После завершения обработки заказа должно выводиться сообщение с указанием ID заказа и времени завершения.
//Обработка каждого заказа занимает различное время
//В конце приложение должно дождаться завершения всех задач и вывести общее время обработки всех заказов.


using static System.Runtime.InteropServices.JavaScript.JSType;
class Program
{
    static void Main()
    {
        var startTimeTotal = DateTime.Now;
        Delivery();
        var endTimeTotal = DateTime.Now;
        Console.WriteLine($"завершено обработкa заказов, время ожидания {endTimeTotal.Subtract(startTimeTotal).TotalSeconds} секунд.");
    }
    static void Delivery()
    {
        List<Order> orders = new List<Order>
    {
        new Order(1, "iPhone",2),
        new Order(2, "Samsung Galaxy",1),
        new Order(3, "Google Pixel",3)

    };

        Task[] tasks = new Task[orders.Count];
        for (int i = 0; i < tasks.Length; i++)
        {
            int taskIndex = i;

            tasks[i] = Task.Run(() =>
            {
                var order = orders[taskIndex];
                var startTime = DateTime.Now;
                Console.WriteLine($"начало обработки заказа: Id - {order.OrderId}, Name - {order.OrderName}");
                Thread.Sleep(order.ProcessingTime * 1000);
                var endTime = DateTime.Now;
                Console.WriteLine($"завершено обработкa заказа: Id - {order.OrderId}, время ожидания {endTime.Subtract(startTime).TotalSeconds} секунд.");
            });
        }
            Task.WaitAll(tasks);
            Console.WriteLine("Все задачи завершены.");
        }
    }

class Order
{
    public int OrderId { get; set; }
    public string OrderName { get; set; }

    public int ProcessingTime { get; set; }
    public Order(int id, string name, int processingTime)
    {
        OrderId = id;
        OrderName = name;
        ProcessingTime = processingTime;
    }
}
