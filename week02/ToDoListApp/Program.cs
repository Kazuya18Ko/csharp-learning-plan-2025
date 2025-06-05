using System;
using ToDoListApp.Services;
using ToDoListApp.Views;

namespace ToDoListApp;

class Program {
    static void Main() {

        // リストの初回読み込み
        var service = new TodoService();

        // デバッグエリア
        // GetAll()メソッドのデバッグ
        service.AddTestDataForGetAll();
        foreach (var task in service.GetAll()) {
            Console.WriteLine($"{task.Id}: {task.Title} - {task.IsCompleted}");
        }

        Console.WriteLine(""); // デバッグを見やすくするために改行

        // Add()メソッドのデバッグ(GetAll()メソッドも利用)
        service.Add("kazuya2");
        service.Add("kazuya3");
        foreach (var task in service.GetAll()) {
            Console.WriteLine($"{task.Id}: {task.Title} - {task.IsCompleted}");
        }
    }
}
