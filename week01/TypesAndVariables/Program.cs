using System;

class Program
{
    static void Main(string[] args)
    {
        // --- 型の種類 ---
        // 値型(intなど)と参照型(Listなど)

        /*
         * □値型:int, double, bool, char, structなど
         * - 代入時に「値をコピー」
         * - Stackに格納される
         * - 元の変数は影響をうけない
         * 
         * □参照型:List<T>, string, classなど
         * - 代入時に「参照(ポインタ)をコピー」
         * - 実体はHeapに格納される
         * - 元の変数も影響を受ける
         */

        // --- 値型の例 ---
        int a = 10; // 値型の変数a
        int b = a; // aの値をbにコピー

        Console.WriteLine($"a: {a}, b: {b}"); // 出力: a: 10, b: 10

        a = 20; // aの値を変更
        Console.WriteLine($"a: {a}, b: {b}"); // 出力: a: 20, b: 10
        // bは影響を受けない

        Console.WriteLine(); // 改行のため

        //　--- 参照型の例 ---
        List<int> listA = new List<int> { 1, 2, 3 }; // 参照型の変数listA
        List<int> listB = listA; // listAの参照をlistBにコピー

        Console.WriteLine($"listA: {string.Join(", ", listA)}"); // 出力: listA: 1, 2, 3
        Console.WriteLine($"listB: {string.Join(", ", listB)}"); // 出力: listB: 1, 2, 3

        listA[0] = 10; // listAの要素を変更

        Console.WriteLine($"listA: {string.Join(", ", listA)}"); // 出力: listA: 10, 2, 3
        Console.WriteLine($"listB: {string.Join(", ", listB)}"); // 出力: listB: 10, 2, 3
        // listBも影響を受ける
    }
}