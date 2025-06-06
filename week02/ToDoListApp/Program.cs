using System;
using ToDoListApp.Services;
using ToDoListApp.Views;

namespace ToDoListApp;

class Program {
    static void Main() {

        // リストの初回読み込み
        var service = new TodoService();
        service.AddTestDataForGetAll();
        int n = 0;

        while(true)
        {
            // コンソール表示処理
            // この部分は後にConsoleView.csに切り分ける
            Console.WriteLine("=== Todoリスト アプリ ===");
            Console.WriteLine("1. タスクを追加");
            Console.WriteLine("2. タスクを一覧表示");
            Console.WriteLine("3. タスクを完了");
            Console.WriteLine("4. タスクを削除");
            Console.WriteLine("5. 終了");
            Console.Write("番号を選んでください: ");

            string? input = Console.ReadLine();

            if(!int.TryParse(input,out n))
            {
                Console.WriteLine("数字を入力してください");
                Console.WriteLine(""); //改行
                continue;
            }
            if(n <= 0 ||  n > 5)
            {
                Console.WriteLine("1～5の数字を入力してください");
                Console.WriteLine(""); //改行
                continue;
            }
            else
            {
                // ここがProgram.csの本当の処理領域
                // ConsoleView.ShowMenu(); とか？
                switch(n)
                {
                    case 1: // タスクを追加
                        Console.WriteLine($"{n}:が入力されました"); //デバッグ
                        break;
                    case 2: // タスクを一覧表示
                        var tasks = service.GetAll();
                        // ConsoleView.ShowTask(todos); とか？
                        Console.WriteLine(""); //改行
                        foreach (var task in tasks)
                        {
                            Console.WriteLine($"{task.Id}:{task.Title} - {task.IsCompleted}");
                        }
                        break;
                    case 3: // タスクを完了
                        Console.WriteLine($"{n}:が入力されました"); //デバッグ
                        break;
                    case 4: // タスクを削除
                        Console.WriteLine($"{n}:が入力されました"); //デバッグ
                        break;
                    case 5: // 終了
                        Console.WriteLine($"{n}:が入力されました"); //デバッグ
                        Console.WriteLine("プログラムを終了します"); //終了処理
                        return;
                }
            }
            Console.WriteLine(""); //改行
        }
    }
}
