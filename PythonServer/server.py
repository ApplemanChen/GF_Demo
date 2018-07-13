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

			print("Send Data -----")
			sc_login = login_pb2.sc_login()
			sc_login.result = 1
			sc_login.reason = "abcdefg"
			send_data = sc_login.SerializeToString()
			conn.send(send_data)
			print("Send Data Success!")

def main():
	global server
	start()

if __name__ == '__main__':
	main()