# null安全とNullable型(Day2)

## C#におけるnull安全
- C#では値型(`int`,`bool`など)は通常`null`を取ることができない。
- `null`を許容するには、Nullable型を使用する。
	- Nullable型は値型に`?`を付けることで定義できる。
	- 例: `int?`, `bool?`

```csharp
int? number = null; // ok(nullを代入できる)
int number2 = null; // エラー(nullは代入できない)
```
- `T?`は`Nullable<T>`の省略記法。
- 参照型(`string`,`object`など)はC# 8以降で「nullable reference types」もサポート。


## nullチェック演算子
- `?.` 演算子などを使用すると、nullチェックを簡潔に行える。

|演算子|説明                            |例                        |
|------|--------------------------------|--------------------------|
|`?.`  |nullならアクセスせずにnullを返す|`user?.Name`              |
|`??`  |左がnullなら右を返す            |`user?.Name ?? "Unknown"` |
|`??=` |左がnullなら右を代入する        |`user.Name ??= "Unknown"` |