## Day 8: 継承とポリモーフィズムの学習・実装ログ

### 概要

- C#における継承・ポリモーフィズムの基本的な概念を確認・整理。
- `virtual` / `override` / `new` の違いを明確にし、挙動の違いを検証。
- 実装を通じて、リストによる多態性の動作と、変数の型による動作の違いを把握。
- InterfaceやCompositionとの比較・使い分けも学習。

### 実装内容

| ファイル名         | 内容                                                          |
|--------------------|---------------------------------------------------------------|
| `Animal.cs`        | `Name` プロパティと `virtual Speak()` を定義                  |
| `Dog.cs`, `Cat.cs` | `override` を使って `Speak()` をカスタマイズ                  |
| `Bird.cs`          | `new` を使って `Speak()` を再定義（ポリモーフィズム対象外）   |
| `Program.cs`       | `List<Animal>` による動的ディスパッチ検証と `Bird` の挙動確認 |

### 実行結果と考察

```csharp
List<Animal> animals = new List<Animal>
{
    new Dog { Name = "ポチ" },
    new Cat { Name = "タマ" },
    new Bird { Name = "ピーちゃん" }
};

foreach (var animal in animals)
{
    animal.Speak(); 
    // Dog, Cat → override によりそれぞれの Speak() が呼ばれる（ポリモーフィズム成立）
    // Bird → new により基底の Speak() が呼ばれる（Animal型として扱ったため）
}

Bird bird = new Bird { Name = "真・ピーちゃん" };
bird.Speak(); // → "ピヨ！"（Bird型で呼び出すと new に定義された方が使われる）
```

- `override`は多態性を成立させるのに必要。
- `new`は元のメソッドを「隠す」だけで、基底型として使うと元のメソッドが呼ばれる。
- 変数の型が何かによって呼び出されるメソッドが変わるというのは重要な観点。

### 学んだこと・気付き
- `override`を使うことでポリモーフィズムを安全かつ正確に実現できる。
- `new`は基本的に推奨されない設計。どうしても必要なとき以外は避ける。
- 継承は「is-a」関係が自然なときに有効。過度に使うと保守性が落ちる。
- 実務では`ControllerBase`,`DbContext`などのフレームワーク設計上の継承がよく登場する。
- 委譲（Composition）やインターフェース（interface）の方が柔軟で安全な場合が多い。

### README整理
- 学習内容を`week03/InheritanceBasics/README.md`にまとめて記録。
- `Interface`・`Compsition`との比較表や実装例も記載。
- 実務で継承を使うケース、使わない方がいいケース等も実例を交えて整理。

### 今後の展望
- 次回は`LINQ`の基本（`Select`/`Where`/`OrderBy`等）を学習予定。
- クラス設計とLINQの組み合わせ（例:`OfType<T>()`による型分岐処理など）も試していく。
- ポートフォリオ用の学習リポジトリとして、整備と記録の両面を今後も強化。

---

