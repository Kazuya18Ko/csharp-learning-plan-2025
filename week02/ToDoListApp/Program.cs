using System;
using ToDoListApp.Services;
using ToDoListApp.Views;

namespace ToDoListApp;

class Program {
    static void Main() {

        // リストの初回読み込み
        var service = new TodoService();
    }
}
