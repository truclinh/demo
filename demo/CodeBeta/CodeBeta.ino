

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
char n[20]="+84976904877"; //SĐT người gửi - chủ
char pos; //biến vị trí tin nhắn trong sim
char *p; //biến lệnh của người gửi

//Độ ẩm đất 1
#define Analog1 1
//#define Digital 3
#define Relay1 11
#define Relay2 12
//int doAmDatCanTuoi=500;//mặc định độ ẩm đất là 500
//Độ ẩm đất 2
#define Analog2 2
//#define Digital 1
#define Relay1 11
#define Relay2 12
//Độ ẩm không khí-nhiệt độ
#include "DHT.h"       // Gọi thư viện DHT11(độ ẩm đất-độ ẩm ko khí
const int DHTPIN = 2;       //Đọc dữ liệu từ DHT11 ở chân 2 trên mạch Arduino
const int DHTTYPE = DHT11;  //Khai báo loại cảm biến, có 2 loại là DHT11 và DHT22
DHT dht(DHTPIN, DHTTYPE);
//cảm biến quang
#define Analog3 3
int giatri;
giatri= analogRead(Analog3);
//----------------------------cam bien luu luong----------------
volatile int flow_frequency; // Đo xung cảm biến lưu lượng
unsigned int l_hour; // Tính toán số lít/giờ
unsigned char flowsensor = 8; // Cảm biến nối với chân 8
unsigned long currentTime;
unsigned long cloopTime; 
int luongnuoc=0;
void flow () // Hàm ngắt
{
   flow_frequency++;
}


/*****************************************************************************HÀM CÀI ĐẶT**************************************************************************/
void setup() 
{    
  //Khởi động cảm biến độ ẩm
    dht.begin(); 
  //Khởi động modun
  Serial.begin(9600);
  //Pin Relay 
  pinMode(Relay1, OUTPUT);
  pinMode(Relay2, OUTPUT);
  //Kết nối module sim900A
  Serial.println("GSM Shield testing.");
  if (gsm.begin(2400)) 
      Serial.println("\nstatus=READY");
  else Serial.println("\nstatus=IDLE");
  // cam bien luu luong
  pinMode(flowsensor, INPUT);
   digitalWrite(flowsensor, HIGH); // Optional Internal Pull-Up
   attachInterrupt(0, flow, RISING); // Setup Interrupt
   sei(); // Enable interrupts
   currentTime = millis();
   cloopTime = currentTime;
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
  //LấyGiá trị độ ẩm đất từ cảm biến 1
 int doAmDat=analogRead(Analog1);
// int kiemTraDoAmDat=digitalRead(Digital);//nếu có độ ẩm đất thì kiemTraDoAmDat=1 và ngược lại thì kiemTraDoAmDat=0
 int tinhtrangnuoc=analogRead(Analog2);
//Lấy giá trị độ ẩm không khí-nhiệt độ không khí
  int doAmKhongKhi = dht.readHumidity();    //Đọc độ ẩm không khí
  int nhietDoKhongKhi = dht.readTemperature(); //Đọc nhiệt độ không khí
  //----------------------------------------------------------------------------
  //-------------------------------------LUU LUONG---------------------------------------
  currentTime = millis();
   // Every second, calculate and print litres/hour
   if(currentTime >= (cloopTime + 1000))
   {
      cloopTime = currentTime; // Updates cloopTime
      // Pulse frequency (Hz) = 7.5Q, Q is flow rate in L/min.
      l_hour = (flow_frequency / 7.5); // (Pulse frequency x 60 min) / 7.5Q = flowrate in L/hour
      flow_frequency = 0; // Reset Counter  
      Serial.print(l_hour, DEC); // Print litres/hour
      Serial.println(" L/hour");
  //Do am dat
    Serial.println("Do am dat:");
  Serial.print(doAmDat);
  if(doAmDat>900)
  {
    Serial.print("=> QUA KHO !");
    delay(500);    
     if(tinhtrangnuoc<950) 
   {
     if(digitalWrite(Relay2,HIGH))
     {
       digitalWrite(Relay2,LOW);
     }
     digitalWrite(Relay1,HIGH); 
   }  
   else
   {
     digitalWrite(Relay2,HIGH);
     if(l_hour==0)
     {
        sms.SendSMS(n, "HET NUOC DU TRU HE THONG NGUNG HOAT DONG..!!"); 
        digitalWrite(Relay2,LOW);        
     }
   }
  }
  else
  {
    Serial.print("=> DA DU LUONG NUOC !");
     delay(500);
    digitalWrite(Relay1,LOW);
  }
  delay(500);
  //Do am va nhiet do KK
   Serial.println("Do am Khong Khi:");
  Serial.print(doAmKhongKhi);
   Serial.println("Nhiet do Khong Khi:");
  Serial.print(nhietDoKhongKhi);
 
  // Anh sang
  Serial.println("Cuong do anh sang:");
  Serial.print(giatri);
   if(giatri<700)
  {
    Serial.print("=> TROI NANG QUA !!");
    delay(500);
      digitalWrite(Relay3,HIGH);
  }
  else
  {
    Serial.print("TROI MAT !");
    delay(500);
    digitalWrite(Relay3,LOW);
    }
  delay(500);
  
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
              switch(p)
              {
          case strstr(smsbuffer,"BOMON"):
          {
            if(digitalWrite(Relay1,LOW)// neu Relay1 dang tat
            {
                 if (doAmDat>900)
                {
                   if(tinhtrangnuoc<950) 
                     {
                           if(digitalWrite(Relay2,HIGH))
                             {
                               digitalWrite(Relay,LOW);
                             }
                             digitalWrite(Relay1,HIGH); 
                       
                     }  
                     else
                     {
                       digitalWrite(Relay2,HIGH);
                       if(l_hour==0)
                       {
                          sms.SendSMS(n, "HET NUOC DU TRU HE THONG NGUNG HOAT DONG..!!"); 
                          digitalWrite(Relay2,LOW);
                       }
                     }
                }
                else
                {                 
                   //Serial.print("Du nuoc");
                  sms.SendSMS(n, "CAY DA DU NUOC KHONG CAN TUOI.!");  
                  delay(500);
                  digitalWrite(Relay1,LOW);
                }
            }
            else// neu Relay1 dang bat
            sms.SendSMS(n, "DANG BOM NUOC..!");
            break;
          }
          case strstr(smsbuffer,"BOMOFF"):
          {
            if(digitalWrite(Relay1,HIGH))// neu Relay1 dang bat
            {
              (digitalWrite(Relay1,LOW));
              sms.SendSMS(n, "DA TAT MAY BOM THANH CONG..!!");   
            }
            sms.SendSMS(n, "MAY BOM DA DUOC TAT ROI..!!");   //Neu Relay1 da duoc tat
            break; 
          }
          case strstr(smsbuffer,"VANON"):
          {
            if(digitalWrite(Relay2,LOW)// neu Relay2 dang tat
            {
            if(tinhtrangnuoc>=950)
            {
              digitalWrite(Relay2,HIGH);
              delay(30000);
              sms.SendSMS(n, "DA CUNG CAP NUOC CHO THUNG CHUA");     
            }
            else
            {
               sms.SendSMS(n, "NUOC VAN CON KHONG CAN TUOI .!!");     
            }
            }
            else// neu Relay2 da duoc bat
            sms.SendSMS(n, "DANG MO VAN..!");    
            break;
          }
          case strstr(smsbuffer,"VANOFF"):
          {  if(digitalWrite(Relay2,HIGH))
                {
                  digitalWrite(Relay2,LOW);
                  sms.SendSMS(n, "DA DONG VAN THANH CONG ..!!");   
                }
                sms.SendSMS(n, "VAN DA DUOC DONG ROI..!!");   
                break; 
          }
          case strstr(smsbuffer,"MANON"):
          { 
            if(digitalWrite(Relay3,LOW))// neu Relay3 dang tat
                {
                  if(giatri<700)
                  {
                  digitalWrite(Relay3,HIGH);
                delay(10000); 
                digitalWrite(Relay3,LOW); 
                sms.SendSMS(n, "DA KEO MAN CHE CHO CAY..!!");
                  }
                  else
                  {
                   sms.SendSMS(n, "TROI MAT KHONG CAN KEO MAN CHE.!!");      
                  }
                }
                else// Neu Relay3 dang duoc bat
                sms.SendSMS(n, "DANG KEO MAN.!!"); 
               break; 
          }
          case strstr(smsbuffer,"MANOFF"):
          {
            if(digitalWrite(Relay3,HIGH))// neu Relay3 dang tat
            {
               digitalWrite(Relay3,LOW);
              sms.SendSMS(n, "MANG DA DUOC THU LAI THANH CONG ..!!"); 
            }
            else
            sms.SendSMS(n, "MANG DANG THU LAI ..!!"); 
            break;
            
          }
          default:
          sms.SendSMS(n, "SAI CU PHAP ..!!"); 
          }
            }
                    
}
