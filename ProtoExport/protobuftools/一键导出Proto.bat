rem 生成proto输出文件
python run.py

rem 生成的cs输出路径
set cs_file=E:\GitProjects\GF_Demo\ProtoExport\output\csharp
set py_file=E:\GitProjects\GF_Demo\ProtoExport\output\python

rem 项目路径
set project_cs=E:\GitProjects\GF_Demo\GF_3_1_3_Demo\Assets\GameMain\Scripts\Network\Packet\ProtoGen
set project_py=E:\GitProjects\GF_Demo\PythonServer\pb

rem 清理项目旧文件夹
rd /s /q %project_cs%
rd /s /q %project_py%

rem 拷贝到项目路径
xcopy /e/s/i %cs_file% %project_cs%	
xcopy /e/s/i %py_file% %project_py%	

pause