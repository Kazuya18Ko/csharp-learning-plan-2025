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
```
## 3.アクセス修飾子とthis

### アクセス修飾子とは
- クラスやメンバの**アクセス範囲を制御するキーワード**。

|修飾子	|意味								|
|-------|-----------------------------------|
|public	|どこからでもアクセス可能			|
|private|同じクラス内からのみアクセス可能	|

### `this`による共通処理
- `this`キーワードを使うと、同じクラス内のフィールドやメソッドを参照できる。
- どのコンストラクタかは引数の数や型で決まる(コンパイラが判断)。

```csharp
// 名前だけのコンストラクタだが、名前と年齢のコンストラクタを呼び出す
public Person(string name) : this(name, 0){} 
```

```csharp
private int age;
public void SetAge(int age)
{
	this.age = age; // 左辺のageはフィールド、右辺のageは引数
}
```
 このように、**引数とフィールドの名前がかぶったとき**、`this`を使うことで「自分のクラスのフィールド」を明示的に示します。


