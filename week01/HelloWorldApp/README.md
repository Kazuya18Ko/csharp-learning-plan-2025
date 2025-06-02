# Hello World !!

## 1.はじめに
- C#のはじまり
- 各行の解説を行う

## 2.コード解説
```csharp
using System;
```
->Javaでいうところのimportに相当。<br>C#では、`System`名前空間を使用することで、基本的な機能(コンソール出力など)が利用できるようになる。
<br>
<br>

```csharp
class Program
```
->クラスの定義。基本的には`*.cs`と同じ名前のクラスを定義することが多い。
<br>
<br>

```csharp
static void Main(string[] args)
```
->C#でコードの実行が開始されるところ。
<br>
`static`は静的メソッドを示し、`void`は戻り値がないことを示す。
<br>
`(string[] args)`はコマンドライン引数を受け取るためのパラメーター。
<br>
<br>

```csharp
Console.WriteLine("Hello, World!");
```
->コンソールに文字列を出力。 `Hello, World!`というメッセージが出力される。
<br>
<br>

```csharp
Console.ReadLine();
```
->コンソールの入力を待機する。これにより、プログラムが終了する前にユーザーが何か入力するのを待つことが出来る。

## 3.実行方法
- コンソールやターミナルで以下のコマンドを実行。

```bash
dotnet build
```
-> C#のコンパイルを行う。

```bash
dotnet run
```
->アプリケーションの実行。

