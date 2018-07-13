rem 项目目录
set file=E:\GitProjects\GF_3_0_9_Demo\GF_3_0_9_Demo\Assets\GameMain\Scripts\Network\Packet

rem 清理目录
rd /s /q %file%\ProtoGen

rem 复制到项目目录
xcopy /e/s/i Protobuf %file%\ProtoGen	

pause