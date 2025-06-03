using System;

public class TodoItem
{
    public int Id { get; set; } // idを格納するプロパティ
    public string Title { get; set; } = string.Empty; // タイトルを格納するプロパティ
    public bool IsCompleted { get; set; } // 完了状態を格納するプロパティ
}
