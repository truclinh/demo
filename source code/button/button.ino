#include <LiquidCrystal.h>
LiquidCrystal lcd(8,9,4,5,6,7);
int lcd_key     = 0;
int adc_key_in  = 0;
#define btnRIGHT  0
#define btnUP     1
#define btnDOWN   2
#define btnLEFT   3
#define btnSELECT 4
#define btnNONE   5
int read_LCD_buttons()
{
 adc_key_in = analogRead(0); 
  if (adc_key_in > 1000) return btnNONE; 
  if (adc_key_in < 50)   return btnRIGHT;  
 if (adc_key_in < 250)  return btnUP;
 if (adc_key_in < 400)  return btnDOWN;
 if (adc_key_in < 600)  return btnLEFT;
 if (adc_key_in < 650)  return btnSELECT;  
 return btnNONE; 
}
void setup()
{
 lcd.begin(16, 2);             
 lcd.setCursor(0,0);            
 lcd.print("MOI CHON NUT BAM"); 
 lcd.setCursor(0,1);            
 lcd.print("Tuoi"); 
 lcd.setCursor(7,1);            
 lcd.print("Keo man"); 
}
 
void loop()
{  
 lcd.setCursor(0,1);            
 lcd_key = read_LCD_buttons();  
 switch(lcd_key)
 {
   case btnLEFT:
{
  lcd.print("CHON");
     delay(1000);
     lcd.clear();
     delay(1000);
     lcd.setCursor(4,0);
     lcd.print("Da tuoi !!");
       delay(500);
       break;
}
  case btnRIGHT:
 {
    lcd.setCursor(7,1);            
    lcd.print("CHON-->");
     delay(1000);
     lcd.clear();
     delay(1000);
     lcd.setCursor(4,0);
     lcd.print("Da keo man !!");
       delay(500);
       break;
}
 }
}

