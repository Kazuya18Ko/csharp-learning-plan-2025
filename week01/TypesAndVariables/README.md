# �^�ƕϐ��̂܂Ƃ�(Day2)

## �l�^�ƕϐ��^�̈Ⴂ

- �l�^(`int`, `double`, `bool`, `char`, `struct`�Ȃ�)
	- ������ɒl���R�s�[�����(stack)
	- �����ύX���Ă���������ɂ͉e�����Ȃ�

- �Q�ƌ^(`class`, `string`, `array`, `List<T>`�Ȃ�)
	- ������ɎQ��(�|�C���^)���R�s�[�����(heap)
	- �����ύX����Ƃ�������ɂ��e������


```csharp
int a = 10;
int b = a; // b��a�̒l���R�s�[
a = 20; // a��ύX���Ă�b�͕ς��Ȃ�

List<int> listA = new List<int> { 1, 2, 3 };
List<int> listB = listA; // listB��listA�̎Q�Ƃ��R�s�[
listA[0] = 100; // listB[0]��100�ɕύX�����
```