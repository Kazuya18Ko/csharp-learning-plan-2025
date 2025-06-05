# Day 5: TodoListAppを実装する(設計・外形構築)

## 概要
- TodoListAppの実装を開始。
- chatGPTを活用し、1から実装する際の考え方から学んでいく。

---

## 学習目的
- C#のコンソールアプリケーションの設計と実装の流れを理解する。
- 0からアプリケーションを作成する際の設計手法を重点的に学ぶ。
- 設計に関しては[AppDesign.md](./AppDesign.md)を参照。

---

## 仕様方針
- タスク（Todo）の追加・表示・完了・削除をサポートするコンソールアプリケーション
- データはメモリ上（`List<TodoItem>`）に保持し、ファイル保存は未対応（発展課題）。
- 処理は以下の構成で責任分離を意識して実装:
  - `Models/`:タスクのデータ構造を定義
  - `Services/`:ビジネスロジック（タスク操作）を管理
  - `Views/`:コンソール出力を管理
  - `Program.cs`:ユーザー入力・処理分岐を担当

---

## 使用技術
- C# 12 / .NET 8
- Visual Studio 2022 Community
- コンソールアプリケーション(`dotnet new console`)
- 基本的な構文、`System`ライブラリ

---

# Day 6 : ToDoListAppを実装する(内部処理実装・完成)

## 概要
- TodoListの各クラスのメソッドの内部処理を実装、コンソールからの操作フローを完成させる。
- 本日中に完成予定

## 学習目的
- タスクの追加・表示・削除など、基本的な機能を実装する
- 最低限のユーザー操作を受け付けるコンソールUI作成する
- 各メソッドの内部処理を実装し、MVSモデルの役割分担を学ぶ
- コンソールからの操作フローを完成させる
- 実務を意識して一つのアプリを完成させる

## ブランチ構成
```
feature/day6-todolist-implementation ─── feature/day6-method-getall
                                     ├── feature/day6-method-add
                                     ├── feature/day6-method-complete
                                     ├── feature/day6-method-delete
                                     └── feature/day6-cleanup-debug

```
