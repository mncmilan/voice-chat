#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>


int main(void) {
	struct sockaddr_in serv_adr, si_other;
	int BUFLEN = 8000;
	int sock_listen, i, blen, slen = sizeof(si_other);
	char buf[BUFLEN];
	
	
	sock_listen = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
	if (sock_listen == -1)
		printf("Error in socket connection\n");
	
	memset((char *) &serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_port = htons(9050);
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	
	if (bind(sock_listen, (struct sockaddr*) &serv_adr, sizeof(serv_adr))==-1)
		printf("Error binding\n");

	for(;;){
		blen = recvfrom(sock_listen, buf, sizeof(buf), 0, (struct sockaddr*) &si_other, &slen);
		
		if (blen == -1)
			printf("Error receiving the message\n");
		else{
			printf("Message received\n");
			
			// Send answer back to the client
			if (sendto(sock_listen, buf, blen, 0, (struct sockaddr*) &si_other, slen) == -1)
				printf("Error sending the message\n");
			printf("Message sent\n\n");
		}
	}
    return 0;
}
