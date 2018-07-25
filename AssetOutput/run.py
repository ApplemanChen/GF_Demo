# 生成最新版本信息的json文件
from xml.dom.minidom import parse
import xml.dom.minidom
import json
import collections
import pprint,shutil,os

# 拷贝指定文件
def copy_file(file_path):
	print("开始拷贝文件{0}...".format(file_path))
	global from_path
	global to_path
	from_file_path = from_path+"/"+file_path
	to_file_path = to_path+"/"+file_path
	shutil.copy(from_file_path,to_file_path)
	print("完成拷贝文件{0}".format(file_path))


# 拷贝指定文件夹的所有内容
def copy_folder(root_folder):
	print("开始拷贝文件夹{0}的内容...".format(root_folder))
	global from_path
	global to_path
	from_com_path = from_path+"/"+root_folder
	to_com_path = to_path+"/"+root_folder
	if os.path.exists(to_com_path):
		shutil.rmtree(to_com_path)
	shutil.copytree(from_com_path,to_com_path)
	print("完成拷贝文件夹{0}的内容...".format(root_folder))

def gen_version_json():
	xml_file = "GameResourceVersion_1_0.xml"
	json_file = "version.json"

	dom_tree = xml.dom.minidom.parse(xml_file)
	resource_version_info = dom_tree.documentElement
	android_info = resource_version_info.getElementsByTagName("Android")[0]
	applicable_game_version = resource_version_info.getAttribute("ApplicableGameVersion")
	latest_internal_resourceVersion = resource_version_info.getAttribute("LatestInternalResourceVersion")
	resource_length = android_info.getAttribute("Length")
	resource_hashcode = android_info.getAttribute("HashCode")
	resource_zip_length = android_info.getAttribute("ZipLength")
	resource_zip_hashcode = android_info.getAttribute("ZipHashCode")

	json_dict = collections.OrderedDict()
	json_dict["LatestGameVersion"] = applicable_game_version
	json_dict["ApplicableGameVersion"] = applicable_game_version
	json_dict["LatestInternalResourceVersion"] = latest_internal_resourceVersion
	json_dict["ResourceUpdateUrl"] = "http://192.168.1.104/GF_Demo/Full"
	json_dict["ResourceLength"] = resource_length
	json_dict["ResourceHashCode"] = resource_hashcode
	json_dict["ResourceZipLength"] = resource_zip_length
	json_dict["ResourceZipHashCode"] = resource_zip_hashcode

	pprint.pprint(json.dumps(json_dict))

	with open(json_file,"w",encoding="utf-8") as f:
		f.write(json.dumps(json_dict,indent=4))

def main():
	global from_path,to_path
	from_path = "E:/GitProjects/GF_Demo/AssetOutput"
	to_path = "D:/phpStudy/WWW/GF_Demo"

	# 生成version.json
	gen_version_json()

	# 拷贝资源到资源服务器目录
	copy_file("version.json")
	copy_folder("Full")
	print("资源已全部上传至资源服务器！")


if __name__ == '__main__':
	main()