# TroubleShooting Log -C# Learning Plan Week02

## Day 4: リポジトリの整理を行う(#6)
- C#学習リポジトリをポートフォリオとして提出できるように。構成の統一とREADMEの整備を行う。
- また、ソリューションファイルを追加し、各プロジェクトをソリューションで管理するように変更。  

## Day 4: 数あてゲームを実装する(#7)
- week01の内容を活かし、数あてゲームを実装。
- 関数を利用してもう少しスマートにしても良かったが、一応week01の内容だけで実装。
- TodoListApp作成後に余裕があればリファクタリングを実施予定。

## Day 6: ToDoリストアプリを実装する(#8)
（Day5に書き忘れてた内容）
- 先日作成した数あてゲームの応用編としてToDoリストアプリを作成する。
- ２日間に分けて開発を行い、１日目は設計とコードの外形作成、２日目は内部処理やUIの実装 -> 完成という段取りとする。
- MVSモデルを採用し、Models（内部で保持するデータ） -> Services（内部処理） -> Views（UI）の順番に実装する。
- 適宜デバッグを行い、確認するようにする。

### 反省点
- Day5時にこちらにログとして残すのを失念していた。
- Day5,6共にブランチを複数作成してその時どのような作業をしていたか履歴を残すのを失念していた。
  - Day6途中で思い出したため、その地点からサブブランチを切って作業を勧めることとする
  - 対策として、その日の作業が始まる前にブランチ構成を考える時間を設ける。

## Day 6: TodoServiceの`GetAll`メソッド実装&ブランチ履歴整理ログ
### 概要
- ブランチ切り替えの際に色々起きて混乱したのでログに残す

### ログ
### 作業内容
- `TodoService.cs`に`GetAll()`メソッドを実装（タスク一覧の取得処理）
- `AddTestDataGorGetAll()`メソッドを追加し、テスト用ダミーデータを投入
- `Program.cs`で`GetAll()`の動作確認用ループを追加

### Git操作履歴整理
- `feature/say6-todolist-implementation`ブランチ上で進んでいたため、**rebaseを用いて履歴整理**
- `git stash` -> `git checkout feature/day6-method-getall` -> `git stash pop`で作業を移動
- コンフリクト発生個所（Program.cs）を手動解決し、`git rebase --continue`
- rebase後のブランチ状態をリモートに反映するため、以下を実行:
```bash
git push --force-with-lease --set-upstream origin feature/day6-method-getall
```

### 反省点
- **rebase前に意図するブランチで作業開始しておくことが重要**
- 今後は作業開始前に`README.md`にその日のブランチ構成と予定を明記しておく
- rebase後にpushする時は、`--force-with-lease`を使うことで安全に上書きできると学んだ。
- **注意点として、チームで作業している際は、--force や --force-with-lease による push が他人の作業を上書き・削除してしまう可能性があるため、慎重に使う必要がある**
