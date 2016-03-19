const int quangtro =A2;
const int led =13;
int giatri;

void setup(){
Serial.begin(9600);
pinMode(led,OUTPUT);
}
void loop()
{
  giatri= analogRead(quangtro);
  Serial.print("Gia tri quang tro: ");
  Serial.println(giatri,DEC);
  if (giatri<500)
  { digitalWrite(led,HIGH);}
  else {digitalWrite(led,LOW);}
  delay(500);
}﻿
