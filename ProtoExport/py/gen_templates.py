#coding=utf-8
import os

def gen_cs_template():
	global root_path
	template_name = "PacketId.cs.template"
	template_path = root_path+"/templates/"+template_name

	output_path = root_path+"/output/csharp/"+template_name[:-9]
	source = ""
	proto_content = ""
	with open(template_path,"r",encoding='utf-8') as file:
		source = file.read()
		for key,value in proto_id_dict.items():
			line = "{0}={1}".format(key.upper(),int(value))
			proto_content = proto_content+line+",\n\t"

	with open(output_path,"w",encoding="utf-8") as output_file:
		output_content = source.replace("#0",proto_content)
		output_file.write(output_content)

def read_proto_id():
	global root_path,proto_id_dict
	proto_id_name = "ProtoId.txt"
	proto_id_path = root_path+"/"+proto_id_name
	proto_id_dict = {}
	with open(proto_id_path,"r",encoding='utf-8') as file:
		for line in file.readlines():
			line_list = line.split(',')
			proto_id_dict[line_list[0]] = line_list[1]

	pass

def main():
	global root_path
	global proto_id_dict
	root_path = os.path.dirname(os.getcwd())
	read_proto_id()
	gen_cs_template()

if __name__ == '__main__':
	main()