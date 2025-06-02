# `using`ディレクティブと名前空間の理解(Day2)

## `using`ディレクティブとは？
### 役割
- **クラスやメソッドの完全修飾名を省略**して記述できるようにするもの
- 主に **.NETの標準ライブラリや外部ライブラリ**を使う際に必要

```csharp
using System; 
Console.WriteLine("Hello, World!"); // System名前空間をusingしてConsoleクラスを直接使用
```

### よく使う例

|名前空間					|主な用途													|
|---------------------------|-----------------------------------------------------------|
|System						|基本的な型や入出力(`Console`, `String` など)				|
|System.Collections.Generic	|コレクション(`List<T>`, `Dictionary<TKey, TValue>` など)	|
|System.text				|文字列操作(`StringBuilder`, `Regex` など)					|
|System.Linq				|LINQクエリ操作(`Select`, `Where` など)						|


## 名前空間(`namespace`)とは？
### クラスや型を分類するための「箱」
```csharp
namespace MyApp.Utilities
{
	public class MathHelper
	{
		public static int Double(int x) => x * 2;
	}
}
```

- 上記クラスは`MyApp.Urilities.MathHelper` として扱われる
- 同じ名前のクラスがあっても、**名前空間で衝突を避けられる**

## Javaとの違い
| 比較項目							| Java (`import`)			| C# (`using`)								| 備考									|
| --------------------------------- | ------------------------- | ----------------------------------------- | ------------------------------------- |
| クラスの省略使用					| ◯						| ◯										| 両者とも省略して使える				|
| staticメンバーの省略使用			| ◯（`import static`）		| ◯（`using static`）						| 両言語で可能（文法が少し違う）		|
| 完全修飾での利用					| ◯（import不要）			| ◯（using不要）							| **どちらも省略せず書けば使える**	|
| 実行時の影響						| なし						| なし										| どちらも**コンパイル時のみの機能**	|
| namespace/module 構造への影響		| なし						| 一部影響あり（file-scoped namespaceなど）	| C#では構造整理にも使うことがある		|

結論:ほぼ違いなし
```csharp
using static System.Math; // staticメンバーを省略して使う例

double result = Sqrt(16); // => 4
```

## 使用例

### ファイル構成

```markdown
/ProjectRoot
  ├── Program.cs
  └── Utils/
       └── MathHelper.cs
```

### MathHelper.csの内容
```csharp
namespace MyApp.Utils
{
	public class MathHelper
	{
		public static int Double(int value)
		{
			return value * 2;
		} 
	}
}
```

### Program.csの内容
```csharp
using System;
using MyApp.Utils; // ←これで名前空間のクラスが使えるようになる

class Program
{
	static void Main()
	{
		int result = MathHelper.Double(5);		// MyApp.Utils.MathHelperを直接使用
		Console.WriteLine($"2倍の値:{result}"); // → 2倍の値:10
	}
}
```
### 解説
|項目						|内容												|
|---------------------------|---------------------------------------------------|
|`namespace MyApp.Utils`	|名前の衝突を避けるための分類フォルダのようなもの	|
|`using MyApp.Utils`		|`Program.cs`から`MathHelper`を短くアクセスできる	|
|`MyApp.Utils.MathHelper`	|`using`を省略しても完全修飾名でアクセス可能		|		

