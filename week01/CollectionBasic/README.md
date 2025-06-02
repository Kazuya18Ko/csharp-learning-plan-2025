# コレクションの基本(Day2)

## `List<T>`の使い方(追加・削除・ループ)
- `List<T>`は可変長の配列で、要素の追加・削除が簡単にできる
- `Add`メソッドで要素を追加、`Remove`メソッドで削除
- `foreach`ループで要素を順に処理できる

宣言の初期化、追加、削除の例:
```csharp
List<strin> fruits = new List<string>(); // Listの宣言と初期化
fruits.Add("Apple");	// 要素の追加(Add)
fruits.Add("Banana");	// 要素の追加(Add)
fruits.Add("Cherry");	// 要素の追加(Add)
fruits.Remove("Apple"); // 要素の削除(Remove)
```
ループでのアクセスの例:
```csharp
foreach (string fruit in fruits) // foreachループで要素を順に処理
{
	Console.WriteLine(fruit); // 各要素を出力
}
```

## `Dictionary<TKey, TValue>`の使い方(追加・削除・値の取得・ループ)
- `Dictionary<TKey, TValue>`はキーと値のペアでデータを管理するコレクション
- キーを使って値にアクセスできるため、検索が高速

宣言と初期化、追加、削除の例:
```csharp
Dictionary<string, int> scores = new Dictionary<string, int>(); // Dictionaryの宣言と初期化
scores.Add("Alice", 90);// キーと値のペアを追加
scores["Kazuya"] = 85;	// キーを使って値を追加または更新
scores.Remove("Alice"); // キーを使って要素を削除
scores["Kazuya"] = 95;	// キーを使って値を更新
```

値の取得の例:
```csharp
if (scores.ContainsKey("Kazuya")) // キーが存在するか確認
{
	int score = scores["Kazuya"]; // キーを使って値を取得
	Console.WriteLine($"Kazuya's score: {score}"); // Kazuyaのスコアを出力
}

```

ループでのアクセスの例:
```csharp
foreach (var pair in scores)
{
	Console.WriteLine($"{pair.Key}: {pair.Value}"); // キーと値のペアを出力
}

```