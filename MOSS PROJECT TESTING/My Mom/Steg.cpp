/*
Chris Zimmerman
4 November 2015
Steg.cpp

Function definitions for the Steg class
*/

#include "Steg.h"


//I was having random number changes and this was the easiest way to make sure it wasn't happening
const int BITS = 8;
using namespace std;

using namespace std;
Steg::Steg(){
	//nothing really to initialize
}

Steg::~Steg(){
	//nothing here yet
}

//decodes the secret message
string Steg::read(int d, unsigned char* pA){
	string MESSAGE = "";
		char temp = 0;
		int counter = 0;
		int bit = 0;
		while (true)
		{
			for(int i=0;i<BITS;i++,bit++){
				char mask = bitShiftOr(bit%d);
				if (bitShiftAnd(d,bit,mask,pA))
				{
					temp = bitShift(temp,i);
				}
				else
				{
					//this is the case that inverts the bits
					temp = bitShift(~temp,i);
					temp = ~temp;
				}
			}
			if(temp == 0)
			{
				return MESSAGE;
			}
			//finds the beginning character to know there is a message
			if(temp != '$')
			{
				MESSAGE += temp;
			}
			temp = 0;
			counter++;

		}
}

void Steg::write(const char* f, unsigned char* & pA, int size, int dial){
	//this was doing some weird stuff until I made it size+2, probably because of the first and last characters that were appended
	for (int i = 0; i < size+2; i++){
			for(int j = 0; j < BITS; j++)
			{
				int maskChar = 1 << (BITS-j-1);
				if(f[i] & maskChar)
				{
					pA[(BITS*i+j)/ dial] = writeShift(pA,i,j,dial);
				}
				//similar to reading, it decides here whether or not to invert the bits
				else{
					pA[(BITS*i+j)/ dial] = writeBitShift(pA,i,j,dial);
					pA[(BITS*i+j)/ dial] = ~(pA[(BITS*i+j)/ dial]);
				}
			}
		}

}

//simple or shift
char Steg::bitShift(char t, int count){
	t = t | 1 << ((BITS-1)-count);
	return t;
}

//simple shift
char Steg::bitShiftOr(int count){
	return 1 << count;
}

//decides whether or not to invert the bits
bool Steg::bitShiftAnd(int d, int current, char mask, unsigned char* pA){
	return(pA[current/d] &mask);
}

//slightly less simple or shift
int Steg::writeShift(unsigned char* pA, int i, int j, int d){
	int temp;
	temp = pA[(BITS*i+j)/d] | 1 << ((BITS*i+j)%d);
	return temp;
}
//same as writeShift, except with inverted bits, it was throwing errors when I tried having it in the actual code
int Steg::writeBitShift(unsigned char* pA, int i, int j, int d){
	int temp;
	temp = ~pA[(BITS*i+j)/d] | 1 << ((BITS*i+j)%d);
	return temp;
}
