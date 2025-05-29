# �����񑀍�(Day2)

## �⊮������
- `$"..."`�̒���`{}`���g���ĕϐ��⎮�𖄂ߍ��ނ��Ƃ��ł���
- +�Ōq������**�ǐ��������A�o�O���N���ɂ���**

```csharp
string name = "Kazuya";
int age = 28;
string message = $"���O:{name},�N��;{age}";
```

- ���Ŏ���������
```csharp
Console.WriteLine($"1+2={1+2}"); // 1+2=3
```

## stringBuilder
- `string`��**�s�ό^(immutable)�̂��߁A���x���A������ƃ��������ׂ�����������I**
- `StringBuilder`�͘A���̂��тɐV��������������Ȃ����߁A**�p�t�H�[�}���X������**

```csharp
using System.Text;

StringBuilder sb = new StringBuilder();
sb.Append("Hello,");
sb.Append(" ");
sb.Append("World!");

Console.WriteLine(sb.ToString()); // ��Hello, World!
```