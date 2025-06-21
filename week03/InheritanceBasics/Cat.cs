using System;

public class Cat : Animal
{
    public override void Speak() // AnimalクラスのSpeak()をoverride
    {
        Console.WriteLine("ニャー！");
    }
}
