

/*****************************************************************************KHỞI TẠO****************************************************************************/
#include <SoftwareSerial.h>
#include<stdlib.h>
#include <string.h>
//SIM-SMS
SoftwareSerial SIM900(5,6);
#include "SIM900.h"
#include "sms.h"
SMSGSM sms;
char smsbuffer[160]; //biến tin nhắn nhận
char n[20]="+841249558108"; //SĐT người gửi - chủ
char pos; //biến vị trí tin nhắn trong sim
char *p; //biến lệnh của người gửi

//Độ ẩm đất
#define Analog 1
#define Digital 3
#define Relay1 11
#define Relay2 12
#define Led 12
int doAmDatCanTuoi=500;//mặc định độ ẩm đất là 500

//Độ ẩm không khí-nhiệt độ
#include "DHT.h"       // Gọi thư viện DHT11(độ ẩm đất-độ ẩm ko khí
const int DHTPIN = 2;       //Đọc dữ liệu từ DHT11 ở chân 2 trên mạch Arduino
const int DHTTYPE = DHT11;  //Khai báo loại cảm biến, có 2 loại là DHT11 và DHT22
DHT dht(DHTPIN, DHTTYPE);

/*****************************************************************************HÀM CÀI ĐẶT**************************************************************************/
void setup() 
{    
  //Khởi động cảm biến độ ẩm
    dht.begin(); 
  //Khởi động modun
  Serial.begin(9600);
  pinMode(Digital,INPUT);
  pinMode(Led,OUTPUT);
  //Pin Relay 
  //pinMode(Relay1, OUTPUT);
  //pinMode(Relay2, OUTPUT);
  //Khởi động LCD
  /*lcd.begin(16,2);
  lcd.clear();
  lcd.createChar(1,doC);*/
  //Kết nối modu sim900a
  Serial.println("GSM Shield testing.");
  if (gsm.begin(2400)) 
      Serial.println("\nstatus=READY");
  else Serial.println("\nstatus=IDLE");
}
/*****************************************************************************HÀM TIN NHẮN TRẢ VỀ*****************************************************************************/
char *Reply(int Doamdat,int Doamkhongkhi,int Nhietdo)
{  
  char q[10],w[10],e[10];
  char DO_AM[30]="Do am dat: ";
  char DO_AM_KK[30]="Do am khong khi: ";
  char NHIET_DO[30]="Nhiet do: ";
  char result[160]="\0";
  itoa(Doamdat,q,10);//chuyển đổi doAm về chuổi DO_AM
  itoa(Doamkhongkhi,w,10);
  itoa(Nhietdo,e,10);
  strcat(result,DO_AM); //nối biến DO_AM vào sau biến result->kết quả là: "Độ ẩm: 123" 
  strcat(result,q);
  strcat(result,"%\n");//xuống dòng
  strcat(result,DO_AM_KK);
  strcat(result,w);
  strcat(result,"%\n");
  strcat(result,NHIET_DO);
  strcat(result,e);
  strcat(result,"*C");
  return result;
}


/*****************************************************************************VÒNG LẶP TRONG MẠCH*****************************************************************************/
void loop() 
{
  //Xuất thông tin ra màn hình LCD
  XuatLCD();
 
  //LấyGiá trị độ ẩm đất
 int doAmDat=analogRead(Analog);
 int kiemTraDoAmDat=digitalRead(Digital);//nếu có độ ẩm đất thì kiemTraDoAmDat=1 và ngược lại thì kiemTraDoAmDat=0
 
//Lấy giá trị độ ẩm không khí-nhiệt độ không khí
  int doAmKhongKhi = dht.readHumidity();    //Đọc độ ẩm không khí
  int nhietDoKhongKhi = dht.readTemperature(); //Đọc nhiệt độ không khí
  
  //Đọc tin nhắn và phân tích lệnh
  pos=sms.IsSMSPresent(SMS_UNREAD);
  Serial.println((int)pos);
  Serial.print("POS=");
  Serial.println((int)pos);
  smsbuffer[0]='\0';
  sms.GetSMS((int)pos,n,20,smsbuffer,160);
  p=strstr(smsbuffer,"STATUS ");//tìm kiếm chuổi STATUS trong nội dung tin nhắn
    if(p)//nếu mà nội dung tin nhắn là STATUS 
    {
      sms.SendSMS(n, Reply(doAmDat,doAmKhongKhi,nhietDoKhongKhi));//thì gửi lại thông tin cho người dùng
    }
    else//ngược lại nếu nội dung tin nhắn ko phải là STATUS
    {
          p=strstr(smsbuffer,"WATERING");//thì tìm kiếm chuổi WATERING trong nội dung tin nhắn
          if(p)//nếu mà nội dung tin nhắn là WATERING 
          {
            digitalWrite(Led,HIGH);
             /*digitalWrite(Relay1,HIGH);
             delay(300000);
             digitalWrite(Relay1,LOW);*/
          }
          else//ngược lại nếu nội dung tin nhắn ko phải là WATERING
          {
                 p=strstr(smsbuffer,"CHANGE");//thì tìm kiếm chuổi CHANGE trong nội dung tin nhắn dùng để thay đổi nhiệt độ
              if(p)//nếu mà nội dung tin nhắn là CHANGE 
              {  
                int length=sizeof(smsbuffer);//lấy độ dài của chuổi tin nhắn
                char changeNhietDo[30];//biến để lấy ra giá trị nhiệt độ từ nội dung tin nhắn thay đổi nhiệt độ
                strncpy(changeNhietDo,smsbuffer+7,3);//cắt giá trị nhiệt độ từ trong nội dung chuổi tin nhắn
                doAmDatCanTuoi=(int)changeNhietDo;//gán doAmDatCanTuoi bằng với giá trị nhiệt độ cần thay đổi trong nội dung tin nhắn
              //  digitalWrite(Relay1,HIGH);
                delay(300000);
                //digitalWrite(Relay1,LOW);
              }
         }
   }
   
   //Kiểm tra độ ẩm đất
    if (doAmDat>doAmDatCanTuoi)
  {
   digitalWrite(Led,HIGH);
  }
  else if(doAmDat<=doAmDatCanTuoi)
  {
   digitalWrite(Led,LOW);
  }
 
  
    delay (1000);
}
