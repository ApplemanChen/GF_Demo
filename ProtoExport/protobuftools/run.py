import os
import shutil

global proto_path
global output_path

# 导出cs文件
def export_cs():
	global proto_path
	protogen_path = os.getcwd()+"/protogen.exe"

	# protogen 生成CS时，必须将当前目录改到proto所在目录,参数中路径必须用相对路径
	os.chdir(proto_path)

	for file in os.listdir(proto_path):
		if file[-6:] == ".proto" and os.path.isfile(os.path.join(proto_path,file)):
			cs_file_name = file[0:-6] + ".cs"
			cmd = "{0} -i:{1} -o:{2}".format(protogen_path,file,"./../output/csharp/"+cs_file_name)
			res = os.system(cmd)

	# 改回当前路径
	os.chdir(os.path.dirname(protogen_path))
	pass

# 导出python文件
def export_py():
	global proto_path
	global protoc_path
	
	# protoc 生成py时，必须将当前目录改到proto所在目录，参数中路径必须用相对路径
	os.chdir(proto_path)

	for file in os.listdir(proto_path):
		if file[-6:] == ".proto" and os.path.isfile(os.path.join(proto_path,file)):
			cmd = "{0} --python_out={1} {2}".format(protoc_path,"./../output/python",file)
			os.system(cmd)			

	pass

# 导出pb(protobuf的二进制)文件
def export_pb():
	global proto_path
	global output_path
	global protoc_path

	for file in os.listdir(proto_path):
		if file[-6:] == ".proto" and os.path.isfile(os.path.join(proto_path,file)):
			pb_file = os.path.join(output_path,"pb",file.replace("proto","pb")) 
			proto_file = os.path.join(proto_path,file)
			cmd = "{0} --proto_path={1} -o {2} {3}".format(protoc_path,proto_path,pb_file,proto_file)
			os.system(cmd)		

	pass

def main():
	global proto_path,output_path,protoc_path
	proto_path = os.path.abspath(os.path.dirname(os.getcwd()))+"/proto/"
	output_path = os.path.abspath(os.path.dirname(os.getcwd()))+"/output/"
	print(proto_path)
	print(output_path)
	protoc_path = os.getcwd()+"/protoc"
	# export_cs()
	# export_py()
	export_pb()
	pass

if __name__ == '__main__':
	main()