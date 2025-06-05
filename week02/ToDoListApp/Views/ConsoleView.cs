using System;
using ToDoListApp.Models;

namespace ToDoListApp.Views;

public class ConsoleView
{
    public static void ShowMenu() { }

    public static void ShowList(List<TodoItem> items) { }

    public static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}
