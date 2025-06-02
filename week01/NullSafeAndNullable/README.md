# null���S��Nullable�^(Day2)

## C#�ɂ�����null���S
- C#�ł͒l�^(`int`,`bool`�Ȃ�)�͒ʏ�`null`����邱�Ƃ��ł��Ȃ��B
- `null`�����e����ɂ́ANullable�^���g�p����B
	- Nullable�^�͒l�^��`?`��t���邱�ƂŒ�`�ł���B
	- ��: `int?`, `bool?`

```csharp
int? number = null; // ok(null�����ł���)
int number2 = null; // �G���[(null�͑���ł��Ȃ�)
```
- `T?`��`Nullable<T>`�̏ȗ��L�@�B
- �Q�ƌ^(`string`,`object`�Ȃ�)��C# 8�ȍ~�Łunullable reference types�v���T�|�[�g�B


## null�`�F�b�N���Z�q
- `?.` ���Z�q�Ȃǂ��g�p����ƁAnull�`�F�b�N���Ȍ��ɍs����B

|���Z�q|����                            |��                        |
|------|--------------------------------|--------------------------|
|`?.`  |null�Ȃ�A�N�Z�X������null��Ԃ�|`user?.Name`              |
|`??`  |����null�Ȃ�E��Ԃ�            |`user?.Name ?? "Unknown"` |
|`??=` |����null�Ȃ�E��������        |`user.Name ??= "Unknown"` |