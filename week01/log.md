# TroubleShooting Log -C# Learning Plan

## Day 1: 日本語入力時にVisualStudioのターミナルが固まる

**現象**
Visual Studioのターミナルで日本語を入力すると途中で固まり、
`The terminal process had exited with code 2` と表示された。

**原因**
vsの総合ターミナル(PowerShell)が日本語のIMEと相性が悪かった。

**対応**
- Windows Terminal + Git Bashに切り替えた
- 

