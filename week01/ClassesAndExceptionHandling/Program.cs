using System;
using System.Text.RegularExpressions;

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
        Console.WriteLine("クラスの話\n");
        // classとは
        // クラス(`class`)は、データと処理をまとめた設計図。オブジェクト指向プログラミングの基礎。
        // クラスからインスタンスを生成するには`new`キーワードを使用。
        Person person = new Person();
        person.Name = "Kazuya";
        person.Age = 28;
        person.Greet(); // →こんにちは、私はKazuya、28歳です。

        Console.WriteLine(""); // 空行で出力を見やすくする

        Console.WriteLine("コンストラクタの話\n");
        // オーバーロードコンストラクタを使用してインスタンスを生成
        Person person2 = new Person("Taro"); // 名前だけ指定
        person2.Greet(); // →こんにちは、私はTaro、0歳です。

        Console.WriteLine(""); // 空行で出力を見やすくする

        Console.WriteLine("例外処理の話\n");

        // 例外処理
        // 例外は、プログラムの実行中に発生する予期しないエラー。`try-catch`ブロックで処理する。
        // 例外が発生する可能性のあるコードを`try`ブロックに書き、
        // 例外が発生した場合の処理を`catch`ブロックに書く。

        // finallyブロックは、例外の有無に関わらず必ず実行される部分。
        // 例えば、リソースの解放や後処理に使用される。

        try
        {
            // 例外が発生する可能性のあるコード
            Console.WriteLine("数値を入力してください:");
            int number = int.Parse(Console.ReadLine()!); // ユーザー入力を整数に変換
            Console.WriteLine($"入力された数値は: {number}"); //ここは数値が正しく入力されないと実行されない
        }
        catch (FormatException ex)
        {
            // 入力が数値でない場合の処理
            Console.WriteLine("無効な入力です。数値を入力してください。");
        }
        catch (Exception ex)
        {
            // その他の例外の処理
            Console.WriteLine($"エラーが発生しました: {ex.Message}");
        }
        finally
        {
            // 例外の有無に関わらず実行される部分
            Console.WriteLine("プログラムを終了します。\n");
        }

        // throwキーワードを使用して、意図的に例外を発生させることも可能。
        // 例えば、特定の条件が満たされない場合に例外を投げることができる。
        try
        {
            int age = -1; // 無効な年齢
            Console.WriteLine($"age={age}");
            if (age < 0)
            {
                throw new ArgumentOutOfRangeException("年齢は0以上でなければなりません。");
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"例外が発生しました: {ex.Message}\n");
        }

        // 例外を発生させることで、プログラムの流れを制御することができる。
        // 例えば、ユーザーが不正な入力をした場合に、適切なエラーメッセージを表示して処理を中断することができる。
        // これにより、プログラムの安定性とユーザビリティを向上させることができる。


        Console.WriteLine("応用例\n");
        // 応用例
        // 名前入力が例外処理なく成功するまで繰り返す

        string? name = null;
        while (true)
        {
            try
            {
                Console.WriteLine("名前を入力してください:");
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("名前は空にできません。");
                }

                if (Regex.IsMatch(name, @"\d")) // 名前に数字が含まれている場合
                {
                    throw new ArgumentException("名前に数字を含めることはできません。");
                }

                break; // 正しい名前が入力されたらループを抜ける
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"入力エラー: {ex.Message}\nもう一度入力してください\n");
            }
        }

        Console.WriteLine($"\nこんにちは、{name}さん！");
    }
}