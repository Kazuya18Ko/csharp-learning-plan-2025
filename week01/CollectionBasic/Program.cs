using System;

class Program
{
    static void Main(string[] args)
    {
        // ---コレクションの基本---

        // ---List<T>---
        // List<T>は、同じ型の要素を順序付けて格納するコレクション
        // 要素の追加、削除、検索が可能で、インデックスを使用してアクセスできる
        // List<T>は、可変長の配列のように振る舞う

        List<string> animals = new List<string> (); // animalsリストの作成、初期化

        animals.Add("Dog"); // animalsリストに要素を追加
        animals.Add("Cat"); // animalsリストに要素を追加
        animals.Add("Fox"); // animalsリストに要素を追加

        animals.Remove("Fox"); // animalsリストから要素を削除

        foreach (string animal in animals) // animalsリストの要素を順に表示
        {
            Console.WriteLine(animal);
        }

        Console.WriteLine(""); // 改行

        // ---Dictionary<TKey, TValue>---
        // Dictionary<TKey, TValue>は、キーと値のペアを格納するコレクション
        // キーは一意で、値は任意の型を格納できる
        // キーを使用して値にアクセスでき、キーの重複は許されない
        // Dictionaryは、ハッシュテーブルのように振る舞う

        Dictionary<string,int> list = new Dictionary<string,int> (); // list辞書の作成、初期化

        list["Kazuya"] = 28; // list辞書に要素を追加
        list.Add("Yuki", 25); // list辞書に要素を追加
        list.Add("Taro", 12); // list辞書に要素を追加

        foreach(var pair in list) // list辞書の要素を順に表示
        {
            if(pair.Value >= 20) // 年齢が20歳以上の人を表示
            {
                Console.WriteLine($"{pair.Key} is {pair.Value} years old.");
            }
        }


    }
}