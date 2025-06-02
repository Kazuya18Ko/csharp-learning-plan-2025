using System;

class Program
{
    static void Main(string[] args)
    {
        // ---varの使い方---
        // varは推論型
        // 変数の型を明示的に指定することなく、コンパイラが自動的に型を推論するために使用される。
        // 変数の型は、初期化時に代入された値の型に基づいて推論される。(注意!:動的型付けではない)

        var number = 10; // int型として推論される
        var message = "Hello, World!"; // string型として推論される
        var isActive = true; // bool型として推論される

        // varを使用する際は初期値を設定する必要がある
        /* 
         * var name;
         * エラー: 初期化されていないため、型を推論できない
         */

        // varと明示的な型指定は同じ意味を持つが、varはコードの可読性を向上させるために使用されることが多い。
        // ただし、varを使用する際は、変数の型が明確であることが重要である。
        // 使い分け方はREADME.mdを参照
    }
}