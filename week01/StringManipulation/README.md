# 文字列操作(Day2)

## 補完文字列
- `$"..."`の中に`{}`を使って変数や式を埋め込むことができる
- +で繋ぐよりも**可読性が高く、バグが起きにくい**

```csharp
string name = "Kazuya";
int age = 28;
string message = $"名前:{name},年齢;{age}";
```

- 中で式も書ける
```csharp
Console.WriteLine($"1+2={1+2}"); // 1+2=3
```

## stringBuilder
- `string`は**不変型(immutable)のため、何度も連結するとメモリ負荷が高く非効率的**
- `StringBuilder`は連結のたびに新しい文字列を作らないため、**パフォーマンスがいい**

```csharp
using System.Text;

StringBuilder sb = new StringBuilder();
sb.Append("Hello,");
sb.Append(" ");
sb.Append("World!");

Console.WriteLine(sb.ToString()); // →Hello, World!
```