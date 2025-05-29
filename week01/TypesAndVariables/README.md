# 型と変数のまとめ(Day2)

## 値型と変数型の違い

- 値型(`int`, `double`, `bool`, `char`, `struct`など)
	- 代入時に値がコピーされる(stack)
	- 一方を変更してももう一方には影響しない

- 参照型(`class`, `string`, `array`, `List<T>`など)
	- 代入時に参照(ポインタ)がコピーされる(heap)
	- 一方を変更するともう一方にも影響する


```csharp
int a = 10;
int b = a; // bはaの値をコピー
a = 20; // aを変更してもbは変わらない

List<int> listA = new List<int> { 1, 2, 3 };
List<int> listB = listA; // listBはlistAの参照をコピー
listA[0] = 100; // listB[0]も100に変更される
```