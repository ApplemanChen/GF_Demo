rem 清理 ProtoBuf文件夹
if exist Protobuf (
	rd /s /q ProtoBuf
)

rem 创建ProtoBuf文件夹
mkdir ProtoBuf

rem 生成CS文件
python3 run.py
rem 复制到项目目录
copyCsharp.bat
pause