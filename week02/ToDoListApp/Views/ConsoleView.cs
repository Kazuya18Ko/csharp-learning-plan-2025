using Models;

public class ConsoleView
{
    public static void ShowMenu() { }

    public static void ShowList(List<TodoItem> items) { }

    public static void ShowMessage(string message)
    {
        ConsoleView.WriteLine(message);
    }
}
