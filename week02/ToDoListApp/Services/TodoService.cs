using ToDoListApp.Models;

namespace ToDoListApp.Services;

public class TodoService
{
    // main稼働時に一度だけ呼び出す
    private List<TodoItem> tasks = new();
    private int nextId = 1;

    public void Add(string title)
    {
        // TodoItem型だと見てわかるからvar使用
        var task = new TodoItem
        {
            Id = nextId++,
            Title = title,
            IsCompleted = false,
        };
        tasks.Add(task); // 追加
    }
    public List<TodoItem> GetAll()
    {
        // 保持しているリストをコピーして返す
        return new List<TodoItem>(tasks);
    }
    public bool Complete(int id)
    {
        foreach (var task in tasks)
        {
            if(task.Id == id)
            {
                task.IsCompleted = true;
                return true;
            }
        }
        return false;
    }

    public bool Delete(int id)
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].Id == id)
            {
                tasks.RemoveAt(i);
                return true;
            }
        }
        return false;
    }
}
