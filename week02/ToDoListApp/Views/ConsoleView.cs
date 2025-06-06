using System;
using ToDoListApp.Models;

namespace ToDoListApp.Views;

public class ConsoleView
{
    // メニュー表示
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
    // タスク一覧表示
    public static void ShowList(List<TodoItem> items)
    {
        Console.WriteLine(""); //改行
        foreach (var item in items)
        {
            if(item.IsCompleted)
            {
                Console.WriteLine($"{item.Id}:{item.Title} - ✅");
            }
            else
            {
                Console.WriteLine($"{item.Id}:{item.Title} - ☐");
            }
        }
    }
    // メッセージ出力
    public static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
    // メッセージ入力 ひとまず入力部分だけ
    public static string? ReadInput(string promptMessage)
    {
        Console.Write(promptMessage);
        return Console.ReadLine();
    }
}
