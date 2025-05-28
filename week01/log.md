# TroubleShooting Log -C# Learning Plan

## Day 1: 日本語入力時にVisualStudioのターミナルが固まる(#1)

**現象**

Visual Studioのターミナルで日本語を入力すると途中で固まり、
`The terminal process had exited with code 2` と表示された。


**原因**

vsの総合ターミナル(PowerShell)が日本語のIMEと相性が悪かった。


**対応**

- ちょっと面倒だが、ターミナルは Windows Terminal + Git Bash を利用することとした。
- ここでも問題が発生したため、以下にそれらを記載する。

-----------------------------------------------------------------------------------
## Day 1: Git Bashで日本語入力時に異常が発生する(#2)

**現象**

Git Bashで日本語を入力すると、半角スペースが入力されたり文字化けしたりする。


**原因**

localeの設定が原因である可能性が高い。


**対応**

- Git BashのlocaleをUTF-8に設定するため、以下のコマンドを実行する。
```
export LC_ALL=ja_JP.utf8
export LANG=ja_JP.utf8
export LANGUAGE=ja_JP.utf8
export LC_CTYPE="ja_JP.utf8"
export LC_NUMERIC="ja_JP.utf8"
export LC_TIME="ja_JP.utf8"
export LC_COLLATE="ja_JP.utf8"
export LC_MONETARY="ja_JP.utf8"
export LC_MESSAGES="ja_JP.utf8"
```
- これらの設定を永続化するために、`~/.bash_profile`に追加する。
- 再起動時に一部(LANGなど)が消えるため、Windows TerminalのGit Bashのコマンドラインに`-l`オプションを追加する。

-----------------------------------------------------------------------------------
## Day 1: Conflict発生(#3)

**現象**

week1のlog.mdをターミナルからcommitした結果、conflictが発生した。


**原因**

githubサイト上でREADMEを一度commitしていたのにpushしていなかったため、ローカルのcommitとgithub上のcommit内容が異なっていた。


**対応**

1.　作業中の変更を一時退避（stash）
`git stash push -m "log.md 追記前の退避"`
2. rebaseを実行
`git pull --rebase origin main`
3. 再度、作業中の変更を復元
`git stash pop`
4, 差分を確認して問題なければpush
`git status`
`git push origin main`

`--rebase`オプションをつけることで、ローカルの変更内容をgithub上の最新の内容に適用することができる。

-----------------------------------------------------------------------------------

## Day 1: commitの取り消しによるメッセージの不備(#4)

**現象**

HelloWorldAppのcommitメッセージが想定と異なっていた。


**原因**

commitの取り消しなどを行った際に状態を戻し過ぎてしまった。
逐次commit→pushを行ったつもりだったが、全てまとめてcommitしてしまった。


**対応**
ポートフォリオとしては見栄えは悪いが、そこまで気にしないことにする。
次回から気を付けることにする。
