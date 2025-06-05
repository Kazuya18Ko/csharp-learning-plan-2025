using System;
using ToDoListApp.Services;
using ToDoListApp.Views;

namespace ToDoListApp;

class Program {
    static void Main() {
        // デバッグエリア

        var service = new TodoService();
        service.AddTestDataForGetAll();
        foreach (var task in service.GetAll()) {
            Console.WriteLine($"{task.Id}: {task.Title} - {task.IsCompleted}");
        }
    }
}
