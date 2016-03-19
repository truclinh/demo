#include <LiquidCrystal.h>
LiquidCrystal lcd(8,9,4,5,6,7);
byte doC[8]={
  B01110,
  B01010,
  B01010,
  B01110,
  B00000,
  B00000,
  B00000,
  B00000 
}; 

void setup()
{
  lcd.begin(16,2);
  lcd.clear();
  lcd.createChar(1,doC);
}
void loop()
{
  lcd.setCursor(0,0);
  lcd.print("DAK:");
  delay(500);
  lcd.setCursor(4,0);
  lcd.print("50");
  delay(500);
  lcd.setCursor(6,0);
  lcd.print("%");
  lcd.setCursor(8,0);
  lcd.print("ND:");
  delay(500);
  lcd.setCursor(11,0);
  lcd.print("32");
  lcd.setCursor(13,0);
  lcd.write(1);
  lcd.setCursor(14,0);
  lcd.print("C");
  lcd.setCursor(0,1);
  lcd.print("DAD:");
  delay(500);
  lcd.setCursor(4,1);
  lcd.print("60");
  lcd.setCursor(6,1);
  lcd.print("%");
  lcd.setCursor(8,1);
  lcd.print("LL:");
  delay(500);
  lcd.setCursor(11,1);
  lcd.print("10");
  lcd.setCursor(14,1);
  lcd.print("mL");
  delay(200);
  delay(10000);  
  lcd.clear();
  delay(1000);
}




