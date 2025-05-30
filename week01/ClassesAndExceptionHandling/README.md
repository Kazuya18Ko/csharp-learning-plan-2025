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
```
## 3.�A�N�Z�X�C���q��this

### �A�N�Z�X�C���q�Ƃ�
- �N���X�⃁���o��**�A�N�Z�X�͈͂𐧌䂷��L�[���[�h**�B

|�C���q	|�Ӗ�								|
|-------|-----------------------------------|
|public	|�ǂ�����ł��A�N�Z�X�\			|
|private|�����N���X������̂݃A�N�Z�X�\	|

### `this`�ɂ�鋤�ʏ���
- `this`�L�[���[�h���g���ƁA�����N���X���̃t�B�[���h�⃁�\�b�h���Q�Ƃł���B
- �ǂ̃R���X�g���N�^���͈����̐���^�Ō��܂�(�R���p�C�������f)�B

```csharp
// ���O�����̃R���X�g���N�^�����A���O�ƔN��̃R���X�g���N�^���Ăяo��
public Person(string name) : this(name, 0){} 
```

```csharp
private int age;
public void SetAge(int age)
{
	this.age = age; // ���ӂ�age�̓t�B�[���h�A�E�ӂ�age�͈���
}
```
 ���̂悤�ɁA**�����ƃt�B�[���h�̖��O�����Ԃ����Ƃ�**�A`this`���g�����ƂŁu�����̃N���X�̃t�B�[���h�v�𖾎��I�Ɏ����܂��B


