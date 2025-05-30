using System;

public class Person
{
    public string? Name;
    public int? Age;
    public void Greet()
    {
        Console.WriteLine($"こんにちは、私は{Name}、{Age}歳です。");
    }
}
public class Program
{   
    public static void Main(string[] args)
    {
        // classとは
        // クラス(`class`)は、データと処理をまとめた設計図。オブジェクト指向プログラミングの基礎。
        // クラスからインスタンスを生成するには`new`キーワードを使用。
        Person person = new Person();
        person.Name = "Kazuya";
        person.Age = 28;
        person.Greet(); // →こんにちは、私はKazuya、28歳です。
    }
}