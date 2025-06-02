# Day4 数あてゲーム（基礎編）

## 概要
C#の基本文法を用いた数あてゲームのコンソールアプリケーションです。  
ユーザーが1～100の間で数字を入力し、ランダムに生成された正解の数字を当てるまで繰り返し入力するシンプルなゲームです。

---

## 学習目的
- `Random`クラスを用いた乱数生成
- `Console.ReadLine`によるユーザー入力の取得
- `int.TryParse`を使った入力検証
- `try-catch`による例外処理の基礎理解
- 条件分岐(`if`/`else if`)とループ(`while`)処理の実装

---

## 使用技術
- C# 12 / .NET 8
- Visual Studio 2022 Community
- コンソールアプリケーション(`dotnet new console`)
- 基本的な構文、`System`ライブラリ

---

## 実行方法
1.このディレクトリへ移動
```bash
cd week02/NumberGuessingGame
```
2.ビルド(コンパイル)
```bash
dotnet build
```
3.実行
```bash
dotnet run
```
---

## 工夫点
- `TryParse`による入力形式の安全な検証(例外を出さない)
- 空入力・非数値・範囲外入力の3段階の検証
- `try-catch`を使って読みやすく、メッセージも親切に
- 試行回数をカウントして最後に表示
- 実務でも使えるような例外の分類と対応 (`ArgumentException`/ `ArgumentOutOfRangeException`/ `FormatException`)

---

## ディレクトリ構成

```
NumberGuessingGame/
├── NumberGuessingGame.csproj
├── Program.cs
└── README.md

```
