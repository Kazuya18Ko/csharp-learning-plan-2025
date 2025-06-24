using System;
using System.Collections.Generic;
using System.Linq;
// サンプルコード
class Program
{
    static void Main()
    {
        // データの準備
        var products = new List<Product>
        {
            new Product("リンゴ", 120, "果物"),
            new Product("バナナ", 80, "果物"),
            new Product("牛乳", 200, "飲料"),
            new Product("ヨーグルト", 150, "飲料"),
            new Product("パン", 100, "食品")
        };

        // 1) LINQ演算子を使って果物カテゴリーの価格を昇順で取得

        var fruits = products
            .Where(p => p.Category == "果物")   // 絞り込み：Category が "果物" のアイテムだけ取得
            .OrderBy(p => p.Price)              // ソート：Price をキーに昇順ソート
            .ToList();                          // 即時実行トリガー：「ここ」でクエリを実行して List<Product> を生成
        /*
         * ---ラムダ式の基本---
         * ラムダ式 は「入力パラメーター => 処理式」の匿名関数を定義する構文です。
         * 例えば:
         * p => p.xxx
         * は「引数 p を受け取り、その p の xxx プロパティを返す」関数を表します。
         * 
         * --- 主なLINQ演算子 ---
         * .Where(Func<Product,bool>)      : シーケンスの絞り込み
         * .OrderBy(Func<Product,TKey>)    : 指定キーでの昇順ソート
         * .OrderByDescending(Func<…,…>) : 降順ソート（必要に応じて使い分け）
         * .Select(Func<Product, TResult>) : 投影・変換（今回は使っていませんが、別の型や匿名型へのマッピングに使用）
         * .ToList()                       : Enumeration を確定し、List に格納
         * 
         * --- 遅延実行 vs 即時実行 ---
         * ・Where / OrderBy / Select など：遅延実行（評価は実際に列挙 or ToList()/Count()/First() 呼び出し時）
         * ・ToList() / Count() / First(): 即時実行（ここで初めてクエリ処理が走る）
         * 
         * --- 発展要素 ---
         * ・匿名型 new { … }                    : クラス定義不要の一時オブジェクト生成
         * ・Aggregate(Func<…>)                : 複雑集計（例：文字列連結や最大最小など）
         * ・Join / GroupJoin                 : 複数シーケンスの結合
         */

        Console.WriteLine("【果物（価格昇順）】");
        // 絞り込み、ソートしたfruitsを出力
        // （.ForEachはLINQではなくList<T>型に定義されているメソッド）
        fruits.ForEach(p => Console.WriteLine($"{p.Name}：{p.Price}円"));
    }
}

// 商品情報を表すデータモデルクラス
class Product
{
    public string Name { get; }
    public int Price { get; }
    public string Category { get; }
    // 商品名・価格・カテゴリーを指定して Product を初期化する
    public Product(string name, int price, string category) =>
        (Name, Price, Category) = (name, price, category);
}

