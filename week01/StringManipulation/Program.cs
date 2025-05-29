using System;
using System.Text;

class Program
{
    static void Main(string[] args)

        // ---文字列の操作---

        // 補完文字列
        // - $"..."の中に{}を使って変数を埋め込むことができる
        // +で文字列を繋ぐより可読性が高くバグが起きにくい
    {
        string name = "Kazuya";
        int age = 28;

        string introduction = $"こんにちは、私は{name}、{age}歳です。";

        Console.WriteLine(introduction); // こんにちは、私はKazuya、28歳です。

        Console.WriteLine(""); // 空行を出力

        // ---StringBuilder---
        // - 文字列を効率的に操作するためのクラス
        // - stringは不変（immutable）なので、文字列を繰り返し変更する場合はStringBuilderを使うとパフォーマンスが向上する

        StringBuilder sb = new StringBuilder();
        sb.Append("私は");
        sb.Append("C#を");
        sb.Append("勉強しています。");
        sb.Append("毎日");
        sb.Append("少しずつ");
        sb.Append("理解が深まっています。");

        Console.WriteLine(sb.ToString()); // 私はC#を勉強しています。毎日少しずつ理解が深まっています。
    }
}