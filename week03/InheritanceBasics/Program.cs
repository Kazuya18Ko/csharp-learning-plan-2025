using System;

class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>
        {
            new Dog{Name = "ポチ"},
            new Cat{Name = "タマ"},
            new Bird{Name = "ピーちゃん"}
        };

        foreach(var animal in animals)
        {
            Console.Write($"{animal.Name}:");
            animal.Speak();
            // Dog,CatはSpeak()をoverrideしてるからそれぞれ"ワン！"、"ニャー！"と出力される
            // BirdはSpeakをnewで実装しているため、基底クラス(Animal)のSoeak() "..." が呼び出される
        }

        Console.WriteLine(""); // 改行

        var bird = new Bird { Name = "真・ピーちゃん" };

        Console.Write($"{bird.Name}:");
        bird.Speak(); //Bird型としてSpeakを呼び出せば"ピヨ！"と出力される
    }
}
