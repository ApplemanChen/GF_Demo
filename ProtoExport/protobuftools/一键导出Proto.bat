rem ���� ProtoBuf�ļ���
if exist Protobuf (
	rd /s /q ProtoBuf
)

rem ����ProtoBuf�ļ���
mkdir ProtoBuf

rem ����CS�ļ�
python3 run.py
rem ���Ƶ���ĿĿ¼
copyCsharp.bat
pause