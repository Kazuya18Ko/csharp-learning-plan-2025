using System;

class Program
{
    static void Main(string[] args)
    {
        // Random変数を生成するためのインスタンスを作成
        Random rnd = new Random();
        //1から100までのランダムな整数を生成
        int correctNum = rnd.Next(0, 101);

        int guessNum = -1; //ユーザー入力の初期値を設定
        int attempts = 0; //試行回数の初期値を設定

        // Console.WriteLine($"debug:correctNum={correctNum}");
    }
}
