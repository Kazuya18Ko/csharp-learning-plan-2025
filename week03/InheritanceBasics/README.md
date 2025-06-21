# Day 8 継承とポリモーフィズムの基本

## 概要
C#のオブジェクト指向における重要な概念である「継承」と「ポリモーフィズム」の基礎を学習。
`virtual` / `overriade` / `new` の使い分けを通じて、多態性の効果をコードベースで確認。

---

## 学習目的
- 基底クラスと派生クラスの構造を理解する
- 共通処理の再利用と、柔軟な動作切り替えの方法を学ぶ
- `new`の注意点を体験を通じて把握する

---
## 0.用語解説

### virtual/overriade/new の違い
C#でメソッドを継承・上書き・再定義する際に使われる3つのキーワード

- `virtual`: 親クラスで「このメソッドは子クラスで上書き可能」と宣言する
- `override`: 子クラスで親の`virtual`メソッドを上書きする
- `new`: 親クラスのメソッドと「同じ名前の別メソッド」を子クラスで定義する（隠蔽）

それぞれの違いは、**継承元の型でメソッドを呼び出したときにどの処理が使われるか**に現れる。

## 1.継承（Inheritance）

### 定義
**既存のクラス（親・基底クラス）の機能やプロパティを再利用して、新しいクラス（子・派生クラス）を作る仕組み**

### 目的
- **共通処理を一元化**する（重複コードをなくす）
- 「～は～である（is-a関係）」を表現できる
- 拡張性のある設計（後から機能追加がしやすい）

### イメージ
```text
Animal
  ├─ Dog = Animalの一種
  └─ Cat = Animalの一種
```

### コード例
```csharp
public class Animal
{
    public string Name {get; set;}
    public virtual void Spead() => Console.WriteLine("...");
}

public class Dog
{
    public override void Speak() => Console.WriteLine("ワン！");
}
public class Cat
{
    public override void Speak() => Console.WriteLine("ニャー！");
}
```
## 2.ポリモーフィズム
### 定義
**同じインターフェース（親クラス）を使って、異なる実装（子クラス）を実行時に選ぶ仕組み**

### 目的
- 型を固定しながら異なる処理を切り替えられる
- 拡張性の高い実装が出来る（if/elseを増やさず機能追加できる）

### イメージ
`List<Animal>`に`Dog`や`Cat`を入れても、`Speak()`の中身は実体ごとに異なる

### コード例
コード
```csharp
List<Animal> animals = new List<Animal>{new Dog(), new Cat()};
foreach(var a in animals)
{
    a.Speak(); // 実体ごとに異なる出力 -> ワン！ / ニャー！
}
```
コンソール出力
```
ワン！
ニャー！
```

## 3.実務でのベストプラクティス
### 使いすぎに注意

継承はとても強力だが、実務では以下の理由から**安易な使用は避けるべき**とされる。

**継承のデメリット**
- **密結合になる** : 親クラスの変更が子クラスに波及しやすく、保守性が下がる
- **多重継承できない** : C#では1つのクラスしか継承できず、柔軟性に欠ける
- **意味の破綻が起きやすい** : is-a関係が成立していても動作が破綻する場合がある
 （例:Bird（飛べる） -> Penguin（飛べない））

**代替:移譲（Compasition）を優先する**
- 継承よりも「〇〇を持っている（has-a関係）」という関係でクラスを構成する方が、十なんで安全な設計になることが多い

```csharp
// 継承
class Dog : Animal
{
    public override void Speak() => Console.WriteLine("ワン！");
}

// 移譲
class Dog
{
    private AnimalBehavior behavior = new AnimalBehavior();
    public void Speak() = behacior.Speak("ワン！");
}
```
**->とはいえ、継承が有効な場合もある**
- フレームワークやライブラリが継承を前提にしている場合（例：ControllerBaseなど）
- 抽象クラス＋ポリモーフィズムで実装の切り替えを行いたいとき
- 自然なis-a関係があり、今後の拡張可能性が高いとき
- **具体例**  

1.UIコンポーネントの描画クラス
```csharp
abstract class View {
    public abstract void Render();
}

class Button : View {
    public override void Render() => Console.WriteLine("ボタンを描画");
}

class TextBox : View {
    public override void Render() => Console.WriteLine("テキストボックスを描画");
}
```
  - `Bottun`や`TextBox`は`View`の一種（自然なis-a関係）
  - 新しいUIパーツ（Slider，CheckBoxなど）も後から追加しやすい（拡張可能性）

2.決済処理（PaymentMethod）
```csharp
abstract class PaymentMethod {
    public abstract void Pay(int amount);
}

class CreditCard : PaymentMethod {
    public override void Pay(int amount) => Console.WriteLine($"カードで{amount}円支払い");
}

class BankTransfer : PaymentMethod {
    public override void Pay(int amount) => Console.WriteLine($"振込で{amount}円支払い");
}
```
  - `CreditCard`は`PaymentMethod`の一種（自然なis-a関係）
  - 将来的に`電子マネー`や`仮想通過`などを追加しやすい（拡張可能性）

3.ファイル出力（Exporter）
```csharp
abstract class Exporter {
    public abstract void Export(string content);
}

class CsvExporter : Exporter {
    public override void Export(string content) => Console.WriteLine("CSV出力");
}

class PdfExporter : Exporter {
    public override void Export(string content) => Console.WriteLine("PDF出力");
}
```
  - `CsvExporter`は`Expoter`の一部（自然なis-a関係）
  - `Excel`や`HTML出力`などの形式を後から自由に追加できる（拡張可能性）

## 4.今後の応用

### Interface（インターフェース）
- 「この機能を持っているべき」という契約（ルール）を定義する型。
- 実装は持たず、実際の動作はクラス側で実装する。
- C#では**多重継承は不可だが、複数のInterface実装は可能**
```csharp
interface IAnimal {
    void Speak(); // 「このクラスにはSpeakメソッドが必要」という契約だけを定義
}

class Dog : IAnimal {
    public void Speak() => Console.WriteLine("ワン！"); //クラス側で具体的な処理を実装
}
```
- ->`List<IAnimal>`に入れて多態性を利用できる

### Composition（合成/移譲）
- 「〇〇を持っている（has-a関係）」という関係で機能を組み合わせる設計手法。
- **継承より柔軟で、安全性・保守性が高い。**

```csharp
class AnimalSpeaker {
    public void Speak(string sound) => Console.WriteLine(sound); // 共通の発話処理を提供する部品クラス
}

class Dog {
    private AnimalSpeaker speaker = new AnimalSpeaker(); // 機能を持たせる（has-a）
    public void Speak() => speaker.Speak("ワン！"); // 内部のspeakerに処理を委譲
}
```
- ->部品化された処理を組み合わせることで、機能を「構成」するスタイル。

### 【Tips】 Inheritance vs Interface vs Composition
|**概念**                        |**特徴**                    |**主な目的**                |
|---------------------------------|-----------------------------|-----------------------------|
|Inheritance（継承）              |is-a関係                     |共通ロジックの再利用         |
|Interface（インターフェース）    |動作の保障・契約             |多態性・共通API化            |
|Compsition（合成/移譲）          |has-a関係                    |機能の柔軟な構成・安全性重視 |

- `Interface`を使ってより柔軟な多態性を実現
- LINQなどと組み合わせて、オブジェクト指向×関数型の融合設計へ展開

---

## 作業内容
- Animalクラスを定義（NameプロパティとSpeak()メソッドを持つ）
- Dog,CatクラスをAnimalから継承し、それぞれSpeak()をoverride
- BirdクラスをAnimalから継承し、newを使ってSpeak()を再定義
- List<Animal>に各インスタンスを追加し、foreachでSpeal()を呼び出して多態性を確認
- 結果をProgram.csにまとめて出力確認

---

## 実行結果
作業してから書く

## 気付き・注意点
作業中に何かあれば書く

## フォルダ構成
```
InheritanceBasics/
  ├─ Animal.cs
  ├─ Dog.cs
  ├─ Cat.cs
  ├─ Bird.cs
  ├─ Program.cs
  └─ README.md
```

## 関連Issue・ブランチ
- Issue: `【学習ログ Day8】継承の基本とポリモーフィズム #46`
- Branch: `feature/day1-inheritance-basics`
