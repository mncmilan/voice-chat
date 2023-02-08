#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>


int main(void) {
    struct sockaddr_in si_me, si_other;
	int BUFLEN = 8000;
    int s, i, blen, slen = sizeof(si_other);
    char buf[BUFLEN];

    s = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
    if (s == -1)
        printf("Error in socket connection\n");

    memset((char *) &si_me, 0, sizeof(si_me));
    si_me.sin_family = AF_INET;
    si_me.sin_port = htons(9050);
    si_me.sin_addr.s_addr = htonl(INADDR_ANY);
	
    if (bind(s, (struct sockaddr*) &si_me, sizeof(si_me))==-1)
        printf("Error binding\n");
	for (;;){
	blen = recvfrom(s, buf, sizeof(buf), 0, (struct sockaddr*) &si_other, &slen);
	if (blen == -1)
		printf("Error receiving the message\n");

	printf("Message received\n");

	// Send answer back to the client
	if (sendto(s, buf, blen, 0, (struct sockaddr*) &si_other, slen) == -1)
		printf("Error sending the message\n");
	
	printf("Message sent\n\n");
	}
    close(s);
    return 0;
}
