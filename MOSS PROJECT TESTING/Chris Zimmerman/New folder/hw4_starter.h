/*
Chris Zimmerman and (probably) Professor Boatright
4 November 2015
hw4_starter.cpp

Class Definition of the starter code, had to add all the random slots and signals
*/

#ifndef HW4_STARTER_H
#define HW4_STARTER_H

#include <QtWidgets/QMainWindow>
#include "ui_hw4_starter.h"
#include "Steg.h"

/*
Chris Zimmerman and (probably) Professor Boatright
4 November 2015
hw4_starter.cpp

Class definitions for the hw4_starter class
*/
class HW4_Starter : public QMainWindow
{
	Q_OBJECT

public:
	HW4_Starter(QWidget *parent = 0);
	~HW4_Starter();

private:
	Ui::HW4_StarterClass ui;
	//I added everything bu the ui
	unsigned char* pA;
	//object for steganography here
	Steg standard;
	int dial;
	int width;
	int height;

public slots:
	void loadFile(void);
	//I added the lower four
	void saveFile();
	void read();
	void write();
	void dialChange(int);

signals:
	void sendPixmap(QPixmap);
	//I added these 3
	void sendQString(QString);
	void sendChars(int);
	void sendDial(int);

};

#endif // HW4_STARTER_H
