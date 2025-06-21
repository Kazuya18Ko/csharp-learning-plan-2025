using System;

public class Dog : Animal
{
    public override void Speak() // AnimalクラスのSpeak()をoverride
    {
        Console.WriteLine("ワン！");
    }
}
