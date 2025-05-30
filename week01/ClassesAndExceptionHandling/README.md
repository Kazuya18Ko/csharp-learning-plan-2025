# クラスと例外処理の基礎(Day3)

## 1. クラスとオブジェクト

### クラスとは？
クラス(`class`)は、**データと処理をまとめた設計図**。オブジェクト指向プログラミングの基礎。
```csharp
public class Person
{
	public string Name;
	public int Age;

	public void Greet()
	{
		Console.WriteLine($"こんにちは、私は{Name}、{Age}歳です。");
	}
}
```
### オブジェクトの生成
クラスからインスタンス(=実体)を作るには`new`を使います。
```csharp
Person person = new Person();
person.Name = "Kazuya";
person.Age = 28;
person.Greet(); // →こんにちは、私はKazuya、28歳です。
```
## 2.コンストラクタとオーバーロード

### コンストラクタとは？
オブジェクト生成時に自動的に呼ばれる特別なメソッド。初期化処理を行います。
```csharp
public Person(string name, int age)
{
	Name = name;
	Age = age;
}
```

### オーバーロードとは？

同じ名前のメソッドやコンストラクトを**引数や肩の違いで複数定義すること。**
```csharp
public Person(){} // 引数なし
public Person(string name){Name = name} // 名前だけ