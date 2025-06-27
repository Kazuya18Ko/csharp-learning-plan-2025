## Day9,10: LINQ 実践編で学んだこと

### 1. LINQ の基本
- C# コード内で SQL ライクなクエリを記述できる  
- **メソッド構文** (`.Where()`, `.Select()`, `.OrderBy()` など) と **クエリ構文** (`from … in … where … select …`) の使い分け  

### 2. ラムダ式 (`=>`)
- `p => p.Category == "果物"` のように「入力パラメーター ⇒ 処理式」を書く匿名関数  

### 3. 遅延実行 vs 即時実行
- **遅延実行**：`Where` / `Select` などはクエリを組み立てるだけ  
- **即時実行**：`.ToList()`, `.Count()`, `.First()` を呼んだときに初めて評価が走る  

### 4. 主な LINQ 演算子
- `.Where(Func<T,bool>)`      : 絞り込み  
- `.OrderBy(Func<T,TKey>)`    : 昇順ソート  
- `.Select(Func<T,TResult>)`  : 投影・変換  
- `.GroupBy(Func<T,TKey>)`    : グループ化  
- `.Join(...)`                : 内部結合  
- **発展**: `.Aggregate()`, `.GroupJoin()`, クエリ構文の `let` 句 など  

### 5. 匿名型 (anonymous type)
- `new { Category = g.Key, AveragePrice = ... }` で一時的な型定義不要のオブジェクトを作成  
- メソッド内ローカルでのデータ整形に便利  

### 6. `let` キーワード (クエリ構文専用)
- 中間結果を名前付き変数に保持し、後続の `where` / `select` などで再利用  
- 例: `let priceRange = (…) ? "～99円" : "100円～"`  

### 7. 複合キーによるグループ化
- `group p by new { p.Category, PriceRange = priceRange } into g` でカテゴリー×価格帯でグループ分け  

### 8. 内部結合 (Join)
- メソッド構文:  
  ```csharp
  products.Join(stocks,
                p => p.Name,
                s => s.ProductName,
                (p, s) => new { p.Name, p.Price, s.Quantity });
  ```
