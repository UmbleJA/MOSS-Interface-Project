/*
Chris Zimmerman
4 November 2015
hw4_starter.cpp

Function definitions for the hw4_starter class
*/

#include "hw4_starter.h"

#include <QString>
#include <QFileDialog>
#include <string>
using namespace std;

HW4_Starter::HW4_Starter(QWidget *parent)
	: QMainWindow(parent)
{
	ui.setupUi(this);
	//this is needed to avoid dividing by zero
	dial = 1;
}

HW4_Starter::~HW4_Starter()
{

}

void HW4_Starter::loadFile() {
	QString filename = QFileDialog::getOpenFileName(this, tr("Open File"), QString(), tr("Images (*.bmp)"));

	pA = BMP_Handler::loadBMP(filename.toStdString().c_str(),width,height);
	//max chars based on resolution
	emit sendChars(width*height*dial*3);
	//no idea what this means, leaving it alone
	if(filename != QString()) {
		emit sendPixmap(QPixmap(filename));
	}
}

void HW4_Starter::saveFile(){
	QString filename = QFileDialog::getSaveFileName(this, tr("Save File"), QString(), tr("Images (*.bmp)"));

	//saves based on the pixel array stored, which already has the secret message in it.
	BMP_Handler::saveBMP(filename.toStdString().c_str(),pA,width,height);
	
	//it didn't work until I added this to save file as well, not sure why
	if(filename != QString()) {
		emit sendPixmap(QPixmap(filename));
	}
	
}

void HW4_Starter::read(){
	//gets the text from the image and displays it in the text box
	ui.textEdit->setPlainText(QString::fromStdString(standard.read(dial,pA))); //I was proud of this line of code, this function was like 5 lines long before
	
}

void HW4_Starter::write(){
	//grabs the string from the text box, after the user hits write
	string textString = ui.textEdit->toPlainText().toStdString();

	//needed to find max chars
	int size = textString.length();
	
	//adding a random char with an end char at the end of the string
	string holder = "$";
	holder.append(textString);
	holder.append("\0");

	const char *fname = holder.c_str();

	//writes the message to the file, based on which dial setting you are on
	standard.write(fname, pA,size, dial);
	

}

//I'm honestly not even sure this function is still in use, but it doesn't mess anything up so I'm leaving it alone
void HW4_Starter::dialChange(int d){
	dial = d;
	emit sendDial(dial);
	emit sendChars(width*height*dial*3);
}


