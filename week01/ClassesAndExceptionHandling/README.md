# �N���X�Ɨ�O�����̊�b(Day3)

## 1. �N���X�ƃI�u�W�F�N�g

### �N���X�Ƃ́H
�N���X(`class`)�́A**�f�[�^�Ə������܂Ƃ߂��݌v�}**�B�I�u�W�F�N�g�w���v���O���~���O�̊�b�B
```csharp
public class Person
{
	public string Name;
	public int Age;

	public void Great()
	{
		Console.WriteLine($"����ɂ��́A����{name}�A{Age}�΂ł��B");
	}
}
```
### �I�u�W�F�N�g�̐���
�N���X����C���X�^���X(=����)�����ɂ�`new`���g���܂��B
```csharp
Person person = new Person();
person.Name = "Kazuya";
person.Age = 28;
person.Great(); // ������ɂ��́A����Kazuya�A28�΂ł��B
```
