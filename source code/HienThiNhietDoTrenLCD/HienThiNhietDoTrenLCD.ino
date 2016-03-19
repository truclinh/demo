#include<LiquidCrystal.h>
//các chân được sử dụng ho việc kết nối LCD Keypad Shield với Arduino
LiquidCrystal lcd (8, 9, 4, 5, 6, 7);
//Khai báo biến cho cảm biến nhiệt LM35
float nhietdo;
int chanlaynhietdo;// chọn chân A1 làm chân lấy tín hiệu nhiệt độ
void setup()
  {
    lcd.begin(16,2);  //dùng LCD 16,2
  }
  void loop()
    {
      nhietdo= analogRead(chanlaynhietdo);//lấy nhiệt độ từ LM35
      nhietdo=(nhietdo*5.0*1000.0/1024.0)/10;//chuyển nhiệt độ lấy được sang độ C
      lcd.setCursor(0,0);//Thiết lập vị trí con trỏ
      lcd.print("NHIET DO: ");
      lcd.print(nhietdo);
      lcd.print(" do C");
      delay(1000);// sau 1s cập nhật thông số nhiệt độ       
    }

