using System;
using ToDoListApp.Models;

namespace ToDoListApp.Views;

public class ConsoleView
{
    public static void ShowMenu()
    {
        Console.WriteLine("=== Todoリスト アプリ ===");
        Console.WriteLine("1. タスクを追加");
        Console.WriteLine("2. タスクを一覧表示");
        Console.WriteLine("3. タスクを完了");
        Console.WriteLine("4. タスクを削除");
        Console.WriteLine("5. 終了");
        Console.Write("番号を選んでください: ");
    }
    public static void ShowList(List<TodoItem> items)
    {
        Console.WriteLine(""); //改行
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Id}:{item.Title} - {item.IsCompleted}");
        }
    }

    public static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}
