#include <LiquidCrystal.h>

//#include<LiquidCrystal>
LiquidCrystal lcd(8,9,4,5,6,7);
byte traitim[8]={
  B01010,
  B11111,
  B11111,
  B01110,
  B00100,
  B00000,
  B00000,
  B00000 
  };
  void setup()
  {
    lcd.begin(16,2);
    lcd.clear();
    lcd.createChar(1,traitim);
  }
  void loop()
  {
    lcd.setCursor(3,0);
    lcd.print("I LOVE YOU ");
    lcd.setCursor(0,1);
    lcd.write(1);
    delay(200);
    lcd.setCursor(1,1);
    lcd.write(1);
    delay(200);
    lcd.setCursor(2,1);
    lcd.write(1);
    delay(200);
    lcd.setCursor(3,1);
    lcd.write(1);
    delay(200);
    lcd.setCursor(4,1);
    lcd.write(1);
    delay(200);
    lcd.setCursor(5,1);
    lcd.write(1);
    delay(200);
    lcd.setCursor(6,1);
    lcd.write(1);
    delay(200);
    lcd.setCursor(7,1);
    lcd.write(1);
    delay(200);
    lcd.setCursor(8,1);
    lcd.write(1);
    delay(200);
    lcd.setCursor(9,1);
    lcd.write(1);
    delay(200);
    lcd.setCursor(10,1);
    lcd.write(1);
    delay(200);
    lcd.setCursor(11,1);
    lcd.write(1);
    delay(200);
    lcd.setCursor(12,1);
    lcd.write(1);
    delay(200);
    lcd.setCursor(13,1);
    lcd.write(1);
    delay(200);
    lcd.setCursor(14,1);
    lcd.write(1);
    delay(200);
    lcd.setCursor(15,1);
    lcd.write(1);
    delay(200);
    delay(1000);  
  lcd.clear();
  delay(2000);
 
  }
 
