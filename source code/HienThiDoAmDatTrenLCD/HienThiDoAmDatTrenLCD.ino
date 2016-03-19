#include<LiquidCrystal.h>
#define Analog 1
#define Digital 4
#define Led 12
//các chân được sử dụng ho việc kết nối LCD Keypad Shield với Arduino
LiquidCrystal lcd (8, 9, 4, 5, 6, 7);
int giatriAnalog, giatriDigital;
int doam;
float dienap;
void setup()
  {
    Serial.begin(9600);
    pinMode(Digital,INPUT);
    pinMode(Led,OUTPUT);
    lcd.begin(16,2);  //dùng LCD 16,2
  }
  void loop()
    {
      giatriAnalog= analogRead(Analog);
      giatriDigital=digitalRead(Digital);
      dienap=(giatriAnalog/1023.0)*5.0;
      doam= (dienap-0.958)/0.0307;
      Serial.print("Gia tri Analog: ");
      Serial.println(giatriAnalog);
      Serial.print("Gia tri digital: ");
      Serial.println(giatriDigital);
      delay(1000);
      if(doam>=30)// cái điều kiện này tui tự cho nha
      {
        digitalWrite(Led,HIGH);
      }
      else if(doam<30)
      {
        digitalWrite(Led,LOW);
      }
      delay(500);
      lcd.setCursor(0,0);//Thiết lập vị trí con trỏ
      lcd.print("Do AM: ");
      lcd.print(doam);
      lcd.print(" % ");
      delay(1000);// sau 1s cập nhật thông số nhiệt độ       
    }

