
// --- usingディレクティブと名前空間 ---

// usingディレクティブは、名前空間を参照するために使用される。
// - クラスやメソッドの完全修飾名を省略できるようにするもの。

using System; // usingディレクティブを追加
using MyApp.Utils; // MyApp.Utils名前空間を参照するためのusingディレクティブ

class Program
{
    
    static void Main(string[] args)
    {
        System.Console.WriteLine("Hello, World!"); // usinディレクティブを使用していない場合、完全修飾名を使用する必要がある
        
        Console.WriteLine("Hello, World!"); // usingディレクティブを使用しているので、完全修飾名を省略できる

        Console.WriteLine(""); // 空行を出力

        // 名前空間は、クラスやメソッドをグループ化するためのもの。
        // - 名前空間を使用することで、同じ名前のクラスやメソッドが存在しても、名前空間で区別できる。

        int result = MathHelper.Double(10); // MyApp.Utils.MathHelperクラスのDoubleメソッドを呼び出す
        Console.WriteLine($"Result: {result}"); // 結果を表示 → Result: 20
    }
}



