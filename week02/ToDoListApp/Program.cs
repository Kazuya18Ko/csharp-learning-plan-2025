using System;
using ToDoListApp.Services;
using ToDoListApp.Views;

namespace ToDoListApp;

class Program
{
    static void Main()
    {

        // リストの初回読み込み
        var service = new TodoService();
        int n = 0;

        while (true)
        {
            // ConsoleViewからShowMenuメソッド呼び出し
            ConsoleView.ShowMenu();

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out n))
            {
                ConsoleView.ShowMessage("数字を入力してください");
                ConsoleView.ShowMessage(""); //改行
                continue;
            }
            if (n <= 0 || n > 5)
            {
                ConsoleView.ShowMessage("1～5の数字を入力してください");
                ConsoleView.ShowMessage(""); //改行
                continue;
            }

            // ここがProgram.csの本当の処理領域
            switch (n)
            {
                case 1: // タスクを追加
                    Console.Write("タスク名を入力してください:");
                    string? title = Console.ReadLine();
                    service.Add(title);
                    break;
                case 2: // タスクを一覧表示(ほとんどConsoleView.csに投げる)
                    var tasks = service.GetAll();
                    // ConsoleView.ShowList(tasks); に移譲
                    ConsoleView.ShowList(tasks);
                    break;
                case 3: // タスクを完了
                    {
                        Console.Write("完了したタスク番号を入力してください:");
                        input = Console.ReadLine();
                        if (!int.TryParse(input, out int taskId))
                        {
                            ConsoleView.ShowMessage("タスク番号を正しく入力してください");
                            break;
                        }
                        if (!service.Complete(taskId))
                        {
                            ConsoleView.ShowMessage("指定されたタスクが存在しません");
                        }
                        break;
                    }
                case 4: // タスクを削除
                    {
                        Console.Write("削除したいタスク番号を入力してください:");
                        input = Console.ReadLine();
                        if (!int.TryParse(input, out int taskId))
                        {
                            ConsoleView.ShowMessage("タスク番号を正しく入力してください");
                            break;
                        }
                        if (!service.Delete(taskId))
                        {
                            ConsoleView.ShowMessage("指定されたタスクが存在しません");
                        }
                        break;
                    }
                case 5: // 終了
                    ConsoleView.ShowMessage($"{n}:が入力されました"); //デバッグ
                    ConsoleView.ShowMessage("プログラムを終了します"); //終了処理
                    return;
            }

            ConsoleView.ShowMessage(""); //改行
        }
    }
}
