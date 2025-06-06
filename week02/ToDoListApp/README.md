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
                                     ├── feature/day6-final-main
                                     └── feature/day6-cleanup-debug

```

## 備考
- 作業の見通しが甘く、完成までたどり着けなかった
- 現在はTodoService.csの完成までは出来ている
- 次の作業で、Program.csにコンソール表示から内部処理書いて仮完成、コンソール表示部分をConsoleView.csに切り分けてアプリケーションの完成まで行う予定

---

# Day 7 : ToDoListAppを実装する(完成編)

## 概要
- Day6で完成に至らなかったToDoリストアプリの最終仕上げを行う。
- `Program.cs`にてユーザー入力から処理実行までの仮実装を行い、  
  その後 `ConsoleView.cs` に表示ロジックを切り出してアプリケーションの本完成を目指す。

## 学習目的
- ユーザー操作に基づくアプリケーションの処理フローを完成させる
- 表示処理のView層への分離を通じてMVSモデルの責務分担を学ぶ
- 仮実装→整理（リファクタ）→完成という実務的な流れを経験する
- アプリ全体の挙動確認・微調整・例外対応の土台づくり

## ブランチ構成（予定）
```
feature/day7-todolist-implementation ─── feature/day7-program-main
                                     ├── feature/day7-consoleview
                                     └── feature/day7-final-adjustments
```

## 備考
- 表示処理は `Views/ConsoleView.cs` に切り出し、`Program.cs`は処理フローのみに集中させる設計とする
- 動作テストを通じて各処理の確認と小さな改善（例外処理など）も行う
- 次のステップでは、このアプリをベースにポートフォリオ整理（README補完、コードリファクタ、動作例GIFなど）を予定
