# クラスと例外処理の基礎(Day3)

## 1. クラスとオブジェクト

### クラスとは？
クラス(`class`)は、**データと処理をまとめた設計図**。オブジェクト指向プログラミングの基礎。
```csharp
public class Person
{
	public string Name;
	public int Age;

	public void Great()
	{
		Console.WriteLine($"こんにちは、私は{name}、{Age}歳です。");
	}
}
```
### オブジェクトの生成
クラスからインスタンス(=実体)を作るには`new`を使います。
```csharp
Person person = new Person();
person.Name = "Kazuya";
person.Age = 28;
person.Great(); // →こんにちは、私はKazuya、28歳です。
```
