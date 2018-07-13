rem 生成proto输出文件
python run.py

rem 生成的cs输出路径
set cs_file=E:\GitProjects\GF_Demo\ProtoExport\output\csharp
rem 项目路径
set file=E:\GitProjects\GF_Demo\GF_3_1_3_Demo\Assets\GameMain\Scripts\Network\Packet\ProtoGen

rem 清理项目旧文件夹
rd /s /q %file%

rem 拷贝到项目路径
xcopy /e/s/i %cs_file% %file%	

pause