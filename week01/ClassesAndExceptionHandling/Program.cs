using System;

public class Person
{
    // クラスのフィールド（プロパティ）を定義
    // フィールドはクラスのデータを保持する変数。`public`はアクセス修飾子で、外部からアクセス可能にする。
    public string? Name;
    public int? Age;
    public void Greet()
    {
        Console.WriteLine($"こんにちは、私は{Name}、{Age}歳です。");
    }

    // 名前と年齢を受け取るコンストラクタ
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // 名前だけ受け取るオーバーロードコンストラクタ
    public Person(string name)
    {
        Name = name;
        Age = 0; // 年齢は不明
    }

    /* thisキーワードを使用して、同じクラスの他のコンストラクタを呼び出すことも可能
     * 
     * public Person(string name) : this(name, 0){}
     * 
     * C#のコンパイラが引数の数や種類に応じて適切なコンストラクタを自動的に選択してくれる。
     * この場合は、`Person(string name)`が呼ばれたときに、`Person(string name, int age)`を呼び出す。
     */

    // デフォルトコンストラクタ（引数なし）
    public Person()
    {
        Name = "名無し"; // デフォルト値
        Age = 0; // デフォルト値
    }
}
public class Program
{   
    public static void Main(string[] args)
    {
        // classとは
        // クラス(`class`)は、データと処理をまとめた設計図。オブジェクト指向プログラミングの基礎。
        // クラスからインスタンスを生成するには`new`キーワードを使用。
        Person person = new Person();
        person.Name = "Kazuya";
        person.Age = 28;
        person.Greet(); // →こんにちは、私はKazuya、28歳です。

        // オーバーロードコンストラクタを使用してインスタンスを生成
        Person person2 = new Person("Taro"); // 名前だけ指定
        person2.Greet(); // →こんにちは、私はTaro、0歳です。
    }
}