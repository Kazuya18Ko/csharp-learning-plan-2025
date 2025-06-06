# TroubleShooting Log -C# Learning Plan Week02

## Day 4: リポジトリの整理を行う(#6)
- C#学習リポジトリをポートフォリオとして提出できるように。構成の統一とREADMEの整備を行う。
- また、ソリューションファイルを追加し、各プロジェクトをソリューションで管理するように変更。  

 ---

## Day 4: 数あてゲームを実装する(#7)
- week01の内容を活かし、数あてゲームを実装。
- 関数を利用してもう少しスマートにしても良かったが、一応week01の内容だけで実装。
- TodoListApp作成後に余裕があればリファクタリングを実施予定。

 ---

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

 ---

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

 ---

## Day 6: 本日の作業を明日へ持ち越し
### 概要
全ての実装を明日までに終わらせる予定だったが、予想以上に作業に手間取ったため一部作業を明日へ持ち越す

### 原因
- Issue内容、ブランチ構成などの考案に時間がかかり、思った以上に作業が進まなかった
- 機能ごとにIssue作成して粒の細かい作業をしようとするとどうしても時間がかかてしまった
- また、pr作成 -> merge ごとにひと段落つき、またIssue作成でスピードが失われているような感覚があった

### 対策
- その日の作業の最初の作業内容やブランチ構成を考える時間を最低でも0.5～1時間は設ける
- この際にあらかじめ今日の作業から逆算してIssue内容をある程度メモ帳にまとめておく

### 備考
- 明日は数あてゲーム、ToDoリストアプリの発展課題（リファクタリングなど）を行う予定だったが、一日押しているため、また違う機会に行うこととする。

---

## Day 7: Issue管理とMilestone
### 概要
- 本日の作業から親Issue作成後、本日作成が予測される子Issueを分けて仮作成作成し、作業毎のIssue作成による減速の逓減を測った。
- また、Milestoneの存在も知ったため、これを導入し、子Issueと紐づけることで作業進捗を分かりやすくした。

---

# Day7 Git Rebase トラブルと対処ログ

## 🔹 発生した問題
- `git pull --rebase` 実行時、以下のエラーが発生：
  ```
  fatal: It seems that there is already a rebase-merge directory...
  ```
- 原因は、**前回のrebaseが中断状態で残っていた**こと。
- さらに、別ブランチ（feature/day7-consoleview）をpullしようとして**未解決の競合が大量発生**。

## 🔹 原因の詳細
- `git pull --rebase` は内部で `rebase` を行うが、**前回のrebaseが未完了**だと `rebase-merge` フォルダが残り、次のrebaseが実行できない。
- `git rebase --abort` を行う前に `pull --rebase` を続行しようとしたため、状態が壊れかけた。
- 解消後の `git push` でも「non-fast-forward」エラーが出たが、これはリモートとの差分が生じていたため。

## ✅ 対処手順
1. **中断されたrebaseのキャンセル**
   ```bash
   git rebase --abort
   ```

2. **リモートとの差異確認とリセット**
   ```bash
   git fetch
   git merge origin/feature/day7-consoleview
   # → Already up to date が出ればOK
   ```

3. **状態がクリーンなことを確認**
   ```bash
   git status
   ```

4. **問題ないことを確認した上で、pull --rebase を再実行**
   ```bash
   git pull --rebase origin feature/day7-consoleview
   ```

## 🔍 今後の教訓
- `rebase` を使っているときは、**途中で止めたら必ず `--abort` を実行**する。
- `pull --rebase` 前に `git status` で中断状態や未解決の競合がないか確認する。
- `push` 時の「non-fast-forward」は、`pull`で差分を先に取り込む必要がある。
- 面倒な場合は、`rebase`より`merge`の方が安全なこともある（特にチーム開発では要注意）。
