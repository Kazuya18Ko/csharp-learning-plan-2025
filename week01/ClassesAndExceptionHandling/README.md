# �N���X�Ɨ�O�����̊�b(Day3)

## 1. �N���X�ƃI�u�W�F�N�g

### �N���X�Ƃ́H
�N���X(`class`)�́A**�f�[�^�Ə������܂Ƃ߂��݌v�}**�B�I�u�W�F�N�g�w���v���O���~���O�̊�b�B
```csharp
public class Person
{
	public string Name;
	public int Age;

	public void Greet()
	{
		Console.WriteLine($"����ɂ��́A����{Name}�A{Age}�΂ł��B");
	}
}
```
### �I�u�W�F�N�g�̐���
�N���X����C���X�^���X(=����)�����ɂ�`new`���g���܂��B
```csharp
Person person = new Person();
person.Name = "Kazuya";
person.Age = 28;
person.Greet(); // ������ɂ��́A����Kazuya�A28�΂ł��B
```
## 2.�R���X�g���N�^�ƃI�[�o�[���[�h

### �R���X�g���N�^�Ƃ́H
�I�u�W�F�N�g�������Ɏ����I�ɌĂ΂����ʂȃ��\�b�h�B�������������s���܂��B
```csharp
public Person(string name, int age)
{
	Name = name;
	Age = age;
}
```

### �I�[�o�[���[�h�Ƃ́H

�������O�̃��\�b�h��R���X�g���N�g��**�����⌨�̈Ⴂ�ŕ�����`���邱�ƁB**
```csharp
public Person(){} // �����Ȃ�
public Person(string name){Name = name} // ���O����