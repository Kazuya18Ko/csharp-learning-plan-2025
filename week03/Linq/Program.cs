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
         * .ToList()                       : Enumeration を確定し、List に格納
         * 
         * --- 遅延実行 vs 即時実行 ---
         * ・Where / OrderBy / Select など : 遅延実行（評価は実際に列挙 or ToList()/Count()/First() 呼び出し時）
         * ・ToList() / Count() / First()  : 即時実行（ここで初めてクエリ処理が走る）
         * 
         * --- 発展要素 ---
         * ・匿名型 new { … }             : クラス定義不要の一時オブジェクト生成
         * ・Aggregate(Func<…>)           : 複雑集計（例：文字列連結や最大最小など）
         * ・Join / GroupJoin              : 複数シーケンスの結合
         */

        // 1α) クエリ構文で「果物」を絞り込み・価格昇順ソート
        // （処理の仕方は1と同じ）
        var fruits2 =
            from p in products
            where p.Category == "果物"
            orderby p.Price ascending
            select p;
        /*
         * クエリ構文方式
         * ---メリット---
         * ・SQLライクで直感的に読める（SELECT ... FROM ... WHERE ... ORDER BY ...）
         * ・複雑なグループ化や結合が書きやすい（・group … by … into g や join … on … equals … がひとまとまりの句として見える
         * ・複数句の順序をビジュアルに追いやすい（from → where → orderby → select の順に自然に並ぶため、「どの段階で何をしているか」がひと目で分かる。）
         * 
         * ---主なクエリ構文---
         * from ... in                          : データソースを指定。
         * where                                : 絞り込み。クエリ構文版はメソッド構文の Where と同じ。
         * orderby ... ascending/descending     : ソート。ascending は省略可、descending で降順。
         * group ... by ... into                : グループ化。into g でグループ変数を定義。
         * join ... on ... equals ...           : 内部結合。SQL の JOIN と同じイメージで書ける。
         * select new { ... }                   : 投影＋匿名型生成。
         */

        // 1)の出力
        Console.WriteLine("【果物（価格昇順）】");
        // 絞り込み、ソートしたfruitsを出力
        // （.ForEachはLINQではなくList<T>型に定義されているメソッド）
        fruits.ForEach(p => Console.WriteLine($"{p.Name}：{p.Price}円"));

        // 1α)の出力
        Console.WriteLine("\n【果物2（価格昇順）】");
        foreach(var p in fruits2)
        {
            Console.WriteLine($"{p.Name}：{p.Price}円");
        }


        // 2) グループ化＋集計
        var avgByCategory = products
            .GroupBy(p => p.Category)                   // Categoryプロパティでグループ化
            .Select(g => new                            // グループ化したavgByCategoryの利用する要素をプロパティ化
            {
                Category = g.Key,                       // Key要素をavgByCategoryのCategoryプロパティとする
                AveragePrice = g.Average(p => p.Price)  // CategoryのPriceの平均値をavgByCategoryのAveragePriceプロパティとする
            });
        /*
         * --- 主なLINQ演算子 ---
         * .GroupBy(Func<Product, TKey>)   : 指定したキーセレクター（例：p => p.Category）で要素をグループ化し、IEnumerable<IGrouping<TKey, Product>> を返す
         * .Select(Func<Product, TResult>) : 投影・変換（別の型や匿名型へのマッピングに使用）
         */

        // 2α) クエリ構文でグループ化＋集計
        var avgByCategory2 =
            from p in products
            group p by p.Category into g
            select new
            {
                Category = g.Key,
                AveragePrice = g.Average(x => x.Price)
            };
        /*
        * ---主なクエリ構文---
        * group ... by ... into                : グループ化。into g でグループ変数を定義。
        * select new { ... }                   : 投影＋匿名型生成。
        */

        // 2)の出力
        Console.WriteLine("\n【カテゴリー別 平均価格】");
        // Categoryでグループ化したavgByCategoryを出力
        // （avgByCategoryはList<T>型じゃないので.ForEachは使えない）
        foreach(var grp in avgByCategory)
        {
            Console.WriteLine($"{grp.Category} -> {grp.AveragePrice:F1}円");
        }

        // 2α)の出力
        Console.WriteLine("\n【カテゴリー別2 平均価格】");
        foreach (var grp in avgByCategory2)
        {
            Console.WriteLine($"{grp.Category} -> {grp.AveragePrice:F1}円");
        }


        // 3) 別リスト（在庫数）と内部結合（Inner Join）
        var stocks = new List<Stock>
        {
            new Stock("リンゴ", 50),
            new Stock("牛乳", 20),
            new Stock("パン", 30)
        };

        var inventory = products
            .Join(
                stocks,                     // ① inner シーケンス：結合対象のもうひとつのリスト
                p => p.Name,                // ② outerKeySelector：外側（products）からキーを取り出す関数
                s => s.ProductName,    // ③ innerKeySelector：内側（stocks）からキーを取り出す関数
                (p, s) => new               // ④ resultSelector：キーが一致したときの出力形式
                {
                    p.Name,                 //  ・ProductのNameをinventoryのNameプロパティとする
                    p.Price,                //  ・ProductのPriceをinventoryのPriceプロパティとする
                    s.Quantity              //  ・StockのQuantityをinventoryのQuantityプロパティとする
                }
            );
        /*
         * --- 主なLINQ演算子 ---
         * .Join<TOuter,TInner,TKey,TResult>: リストの結合
         */

        // 3α) クエリ構文で内部結合
        var inventory2 =
            from p in products
            join s in stocks
              on p.Name equals s.ProductName
            select new
            {
                p.Name,
                p.Price,
                s.Quantity
            };

        // 3)の出力
        Console.WriteLine("\n【在庫情報】");
        // リストの結合によって出来たinventoryの出力
        foreach(var item in inventory )
        {
            Console.WriteLine($"{item.Name}: 価格={item.Price}円, 在庫数={item.Quantity}");
        }

        // 3α)の出力
        Console.WriteLine("\n【在庫情報2】");
        // リストの結合によって出来たinventoryの出力
        foreach (var item in inventory2)
        {
            Console.WriteLine($"{item.Name}: 価格={item.Price}円, 在庫数={item.Quantity}");
        }

        /*-------------------------------------------------------------------------------------------------*/
        // 練習問題
        // 1. 遅延実行 vs 即時実行の動作確認
        var numbers = new List<int> { 1, 2, 3 };

        // 遅延実行クエリの組み立て
        var q = numbers.Where(n => n % 2 == 1);

        // 元リストに"5"を追加して動作を観察
        numbers.Add(5);
        Console.WriteLine("\n遅延実行:");
        foreach (var n in q)
        {
            Console.WriteLine(n);
        }

        // 即時実行トリガー実行後に元リストに"7"を追加
        var list = q.ToList();
        numbers.Add(7);

        // TODO: list を foreach で回して出力するコードを記述
        Console.WriteLine("\n即時実行後に7追加:");//
        list.ForEach(n => Console.WriteLine(n));
        // listでqを即時実行させてからnumbersに7を追加しているので出力に7は含まれない

        // 2.Aggregate による文字列連結
        // 10行目のproductsを再利用
        var namesSeq = products.Select(p => p.Name);

        // TODO: namesSeq を Aggregate を使って「,」区切りの文字列に連結し、Console.WriteLine で表示するコードを記述
        var names = namesSeq.Aggregate((one, two) => one + "," + two);
        Console.WriteLine($"\n文字列の連結\n{names}\n");
        // Aggregate内の"one","two"は任意の文字列を用いていい
        // "one","two"はコレクションの要素と要素の関係性を示している

        // 3.複数キーによるグループ化
        // ■ 「価格帯」を表す文字列を作成
        // TODO: 以下の priceRange を三段階に分ける
        //    ・100円未満 → "～99円"
        //    ・100～199円 → "100～199円"
        //    ・200円以上 → "200円～"
        var stats =
            from p in products
            let priceRange = p.Price < 100 ? "～99円"
                           : p.Price < 200 ? "100～200円"
                           :                 "200円～"

            group p by new { p.Category, PriceRange = priceRange } into g
            select new
            {
                Category = g.Key.Category,
                PriceRange = g.Key.PriceRange,
                Count = g.Count(),
                Avg = g.Average(x => x.Price)
            };

        Console.WriteLine("複数キーによるグループ化");
        foreach (var x in stats)
        {
            // TODO: 結果をわかりやすく出力
            Console.WriteLine($"{x.Category} / {x.PriceRange} → 件数:{x.Count}, 平均:{x.Avg:F1}円");
        }
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

// Productと違う要素数（共通点あり）のデータモデルクラス
class Stock
{
    public string ProductName { get; }
    public int Quantity { get; }
    // 商品名、数量を指定して Stock を初期化する
    public Stock(string n, int q) =>
        (ProductName, Quantity) = (n, q);
}

