rem ��ĿĿ¼
set file=E:\GitProjects\GF_3_0_9_Demo\GF_3_0_9_Demo\Assets\GameMain\Scripts\Network\Packet

rem ����Ŀ¼
rd /s /q %file%\ProtoGen

rem ���Ƶ���ĿĿ¼
xcopy /e/s/i Protobuf %file%\ProtoGen	

pause