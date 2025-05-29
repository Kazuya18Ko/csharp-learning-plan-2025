# `using`�f�B���N�e�B�u�Ɩ��O��Ԃ̗���(Day2)

## `using`�f�B���N�e�B�u�Ƃ́H
### ����
- **�N���X�⃁�\�b�h�̊��S�C�������ȗ�**���ċL�q�ł���悤�ɂ������
- ��� **.NET�̕W�����C�u������O�����C�u����**���g���ۂɕK�v

```csharp
using System; 
Console.WriteLine("Hello, World!"); // System���O��Ԃ�using����Console�N���X�𒼐ڎg�p
```

### �悭�g����

|���O���					|��ȗp�r													|
|---------------------------|-----------------------------------------------------------|
|System						|��{�I�Ȍ^����o��(`Console`, `String` �Ȃ�)				|
|System.Collections.Generic	|�R���N�V����(`List<T>`, `Dictionary<TKey, TValue>` �Ȃ�)	|
|System.text				|�����񑀍�(`StringBuilder`, `Regex` �Ȃ�)					|
|System.Linq				|LINQ�N�G������(`Select`, `Where` �Ȃ�)						|


## ���O���(`namespace`)�Ƃ́H
### �N���X��^�𕪗ނ��邽�߂́u���v
```csharp
namespace MyApp.Utilities
{
	public class MathHelper
	{
		public static int Double(int x) => x * 2;
	}
}
```

- ��L�N���X��`MyApp.Urilities.MathHelper` �Ƃ��Ĉ�����
- �������O�̃N���X�������Ă��A**���O��ԂŏՓ˂��������**

## Java�Ƃ̈Ⴂ
| ��r����							| Java (`import`)			| C# (`using`)								| ���l									|
| --------------------------------- | ------------------------- | ----------------------------------------- | ------------------------------------- |
| �N���X�̏ȗ��g�p					| ��						| ��										| ���҂Ƃ��ȗ����Ďg����				|
| static�����o�[�̏ȗ��g�p			| ���i`import static`�j		| ���i`using static`�j						| ������ŉ\�i���@�������Ⴄ�j		|
| ���S�C���ł̗��p					| ���iimport�s�v�j			| ���iusing�s�v�j							| **�ǂ�����ȗ����������Ύg����**	|
| ���s���̉e��						| �Ȃ�						| �Ȃ�										| �ǂ����**�R���p�C�����݂̂̋@�\**	|
| namespace/module �\���ւ̉e��		| �Ȃ�						| �ꕔ�e������ifile-scoped namespace�Ȃǁj	| C#�ł͍\�������ɂ��g�����Ƃ�����		|

���_:�قڈႢ�Ȃ�
```csharp
using static System.Math; // static�����o�[���ȗ����Ďg����

double result = Sqrt(16); // => 4
```

## �g�p��

### �t�@�C���\��

```markdown
/ProjectRoot
  ������ Program.cs
  ������ Utils/
       ������ MathHelper.cs
```

### MathHelper.cs�̓��e
```csharp
namespace MyApp.Utils
{
	public class MathHelper
	{
		public static int Double(int value)
		{
			return value * 2;
		} 
	}
}
```

### Program.cs�̓��e
```csharp
using System;
using MyApp.Utils; // ������Ŗ��O��Ԃ̃N���X���g����悤�ɂȂ�

class Program
{
	static void Main()
	{
		int result = MathHelper.Double(5);		// MyApp.Utils.MathHelper�𒼐ڎg�p
		Console.WriteLine($"2�{�̒l:{result}"); // �� 2�{�̒l:10
	}
}
```
### ���
|����						|���e												|
|---------------------------|---------------------------------------------------|
|`namespace MyApp.Utils`	|���O�̏Փ˂�����邽�߂̕��ރt�H���_�̂悤�Ȃ���	|
|`using MyApp.Utils`		|`Program.cs`����`MathHelper`��Z���A�N�Z�X�ł���	|
|`MyApp.Utils.MathHelper`	|`using`���ȗ����Ă����S�C�����ŃA�N�Z�X�\		|		

