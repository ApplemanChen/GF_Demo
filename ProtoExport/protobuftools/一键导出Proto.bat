rem ����proto����ļ�
python run.py

rem ���ɵ�cs���·��
set cs_file=E:\GitProjects\GF_Demo\ProtoExport\output\csharp
set py_file=E:\GitProjects\GF_Demo\ProtoExport\output\python

rem ��Ŀ·��
set project_cs=E:\GitProjects\GF_Demo\GF_3_1_3_Demo\Assets\GameMain\Scripts\Network\Packet\ProtoGen
set project_py=E:\GitProjects\GF_Demo\PythonServer\pb

rem ������Ŀ���ļ���
rd /s /q %project_cs%
rd /s /q %project_py%

rem ��������Ŀ·��
xcopy /e/s/i %cs_file% %project_cs%	
xcopy /e/s/i %py_file% %project_py%	

pause