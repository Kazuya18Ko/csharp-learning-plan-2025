using System;

class Program
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    static void Main(string[] args)
    {
        // ---C＃におけるnull安全---
        // C#では、値型にnullを代入できない
        // そのため、nullを許容する場合は、Nullable型（?）を使用する必要がある

        int? age= null; // Nullable<int>と同じ意味
        Console.WriteLine($"Age: {age}"); // 出力: Age:

        Console.WriteLine(""); // 改行のため

        // ---null関係の演算子---
        // 1. ?.演算子 (Null条件演算子)
        //    nullならアクセスせずにnullを返す
        // 2. ??演算子 (Null合体演算子)
        //    左辺がnullなら右辺を返す
        // 3. ??=演算子 (Null合体代入演算子)
        //    左辺がnullなら右辺を代入する

        Person person = null;
        // ?.演算子の使用例
        string personName = person?.Name; // personがnullならpersonNameもnullになる
        Console.WriteLine($"Person Name: {personName}"); // 出力: Person Name:
        // ??演算子の使用例
        String name = person?.Name ?? "Unknown"; // personがnullなら"Unknown"を代入
        Console.WriteLine($"Person Name: {name}"); // 出力: Person Name: Unknown
        // ??=演算子の使用例
        person ??= new Person { Name = "Default", Age = 30 }; // personがnullなら新しいPersonを代入
        Console.WriteLine($"Person Name: {person.Name}, Age: {person.Age}"); // 出力: Person Name: Default, Age: 30

    }
}