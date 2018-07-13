import os
import shutil

#proto_path = '.\\'
proto_path = '..\\proto\\'
#export_path = '.\\'
export_path = 'Protobuf'

real_export_path = os.path.join(os.getcwd(), export_path);

os.chdir(proto_path)

print (os.getcwd())

for f in os.listdir(".\\"):
    if f[-6:] == ".proto" and os.path.isfile(os.path.join(proto_path, f)):
        file_name = f[0:-6] + ".cs"
        cmd = "..\\protobuftools\\protogen -i:%s -o:%s" % (f, file_name)
        print (cmd)
        s = os.system(cmd)
        
        shutil.copyfile(file_name, os.path.join(real_export_path, file_name))
        os.remove(file_name)
