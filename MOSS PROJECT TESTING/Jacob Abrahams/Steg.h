/*
Chris Zimmerman
4 November 2015
Steg.h

Class definition for the Steg Class
*/

#include "BMP_Handler.h"
#include <string>
using namespace std;
class Steg
{
public:
	Steg();
	~Steg();

	string read(int holder, unsigned char* pA);
	void write(const char* message, unsigned char* &pA, int size, int dial);
	char bitShift(char t, int count);
	char bitShiftOr(int count);
	bool bitShiftAnd(int, int, char, unsigned char*);
	int returnDial(int, int, int);
	int writeShift(unsigned char*, int, int, int);
	int writeBitShift(unsigned char*, int, int, int);
private:
	BMP_Handler image;
	unsigned char* holder;
};