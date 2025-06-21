using System;

public class Animal
{
    public string Name { get; set; }

    public virtual void Speak() // virtualにしてるから子クラスで上書き可能
    {
        Console.WriteLine("...");
    }
}
