# �R���N�V�����̊�{(Day2)

## `List<T>`�̎g����(�ǉ��E�폜�E���[�v)
- `List<T>`�͉ϒ��̔z��ŁA�v�f�̒ǉ��E�폜���ȒP�ɂł���
- `Add`���\�b�h�ŗv�f��ǉ��A`Remove`���\�b�h�ō폜
- `foreach`���[�v�ŗv�f�����ɏ����ł���

�錾�̏������A�ǉ��A�폜�̗�:
```csharp
List<strin> fruits = new List<string>(); // List�̐錾�Ə�����
fruits.Add("Apple");	// �v�f�̒ǉ�(Add)
fruits.Add("Banana");	// �v�f�̒ǉ�(Add)
fruits.Add("Cherry");	// �v�f�̒ǉ�(Add)
fruits.Remove("Apple"); // �v�f�̍폜(Remove)
```
���[�v�ł̃A�N�Z�X�̗�:
```csharp
foreach (string fruit in fruits) // foreach���[�v�ŗv�f�����ɏ���
{
	Console.WriteLine(fruit); // �e�v�f���o��
}
```

## `Dictionary<TKey, TValue>`�̎g����(�ǉ��E�폜�E�l�̎擾�E���[�v)
- `Dictionary<TKey, TValue>`�̓L�[�ƒl�̃y�A�Ńf�[�^���Ǘ�����R���N�V����
- �L�[���g���Ēl�ɃA�N�Z�X�ł��邽�߁A����������

�錾�Ə������A�ǉ��A�폜�̗�:
```csharp
Dictionary<string, int> scores = new Dictionary<string, int>(); // Dictionary�̐錾�Ə�����
scores.Add("Alice", 90);// �L�[�ƒl�̃y�A��ǉ�
scores["Kazuya"] = 85;	// �L�[���g���Ēl��ǉ��܂��͍X�V
scores.Remove("Alice"); // �L�[���g���ėv�f���폜
scores["Kazuya"] = 95;	// �L�[���g���Ēl���X�V
```

�l�̎擾�̗�:
```csharp
if (scores.ContainsKey("Kazuya")) // �L�[�����݂��邩�m�F
{
	int score = scores["Kazuya"]; // �L�[���g���Ēl���擾
	Console.WriteLine($"Kazuya's score: {score}"); // Kazuya�̃X�R�A���o��
}

```

���[�v�ł̃A�N�Z�X�̗�:
```csharp
foreach (var pair in scores)
{
	Console.WriteLine($"{pair.Key}: {pair.Value}"); // �L�[�ƒl�̃y�A���o��
}

```