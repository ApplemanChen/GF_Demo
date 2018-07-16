import socket
from pb import login_pb2

def close():
	global server
	server.close()

def start():
	global server
	server = socket.socket()
	server.bind(('localhost',4455))

	server.listen(5)
	print("Start Connet Client ----------")
	while True:
		conn,addr = server.accept()
		print("Client:{0} Conneted,IP:{1}".format(conn,addr))
		while True:
			data = conn.recv(1024)
			print("ReceiveData:",data)
			print("Receive.Id:",int.from_bytes(data[0:4], byteorder = 'little'))
			print("Receive.Len:",int.from_bytes(data[4:8], byteorder = 'little'))

			print("Send Data -----")

			sc_login = login_pb2.sc_login()
			sc_login.result = 1
			sc_login.reason = "abcdefg"
			body_data = sc_login.SerializeToString()

			id_data = (1002).to_bytes(4,byteorder="little")
			len_data = (len(body_data)).to_bytes(4,byteorder="little")
			send_data = id_data + len_data + body_data
			print(send_data)
			print("len(body_data):",len(body_data))

			conn.sendall(send_data)
			break
			if len(data) <0:
				close()
				break
			print("Send Data Success!")

def main():
	global server
	start()

if __name__ == '__main__':
	main()