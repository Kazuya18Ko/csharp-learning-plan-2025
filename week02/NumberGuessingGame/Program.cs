using System;

class Program
{
    static void Main(string[] args)
    {
        // 1.乱数の生成
        // Random変数を生成するためのインスタンスを作成
        Random rnd = new Random();
        //1から100までのランダムな整数を生成
        int correctNum = rnd.Next(1, 101);

        int guessNum = -1; //ユーザー入力の初期値を設定
        int attempts = 0; //試行回数の初期値を設定

        // Console.WriteLine($"debug:correctNum={correctNum}");

        // 2.ユーザー入力の取得

        while (true)
        {
            Console.WriteLine($"1～100までの数字を入力してください");
            string input = Console.ReadLine();
            attempts++;

            // 入力値の検証
            if (!int.TryParse(input, out guessNum)) {
                Console.WriteLine($"数字を入力してください。\n");
                continue;
            }

            if (guessNum < 1 || guessNum > 100)
            {
                Console.WriteLine($"1～100までの数字を入力してください。入力された数字:({guessNum})\n");
                continue;

            }
            else
            {
                Console.WriteLine($"入力された数字:{guessNum}, 試行回数:{attempts}");
                break;
            }
        }
    }
}
