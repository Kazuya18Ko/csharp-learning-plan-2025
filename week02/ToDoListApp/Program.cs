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
        Console.WriteLine("GetAll()のデバッグ");
        service.AddTestDataForGetAll();
        foreach (var task in service.GetAll()) {
            Console.WriteLine($"{task.Id}: {task.Title} - {task.IsCompleted}");
        }

        Console.WriteLine(""); // デバッグを見やすくするために改行

        // Add(string title)メソッドのデバッグ(GetAll()メソッドも利用)
        Console.WriteLine("Add(string title)のデバッグ");
        service.Add("kazuya2");
        service.Add("kazuya3");
        foreach (var task in service.GetAll()) {
            Console.WriteLine($"{task.Id}: {task.Title} - {task.IsCompleted}");
        }

        Console.WriteLine(""); // デバッグを見やすくするため改行

        // Complete(int id)メソッド
        Console.WriteLine("Complete(int id)のデバッグ");
        service.Complete(2);
        // id:2だけTrueになっているか確認
        foreach (var task in service.GetAll()) {
            Console.WriteLine($"{task.Id}: {task.Title} - {task.IsCompleted}");
        }
        Console.WriteLine("");

        // コンソールからの入力テスト
        var input = Console.ReadLine();

        if(!int.TryParse(input, out int id))
        {
            Console.WriteLine("数字を入力してください");
            return;
        }

        if (id <= 0)
        {
            Console.WriteLine("IDは1以上を入力してください");
            return;
        }

        var success = service.Complete(id);
        if (success)
        {
            Console.WriteLine("タスクを完了しました");
        }
        else
        {
            Console.WriteLine("指定したタスクが存在しません");
            return;
        }
        // 正しく入力した場合反映されているか確認
        foreach (var task in service.GetAll()) {
            Console.WriteLine($"{task.Id}: {task.Title} - {task.IsCompleted}");
        }
        Console.WriteLine(""); // デバッグを見やすくするため改行
    }
}
