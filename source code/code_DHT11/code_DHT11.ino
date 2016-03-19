          #include <SoftwareSerial.h>
          #include <DHT.h>
          #include<stdlib.h>
          #include <string.h>
          const int DHTPIN = 7;
          const int DHTTYPE = DHT11;
          DHT dht(DHTPIN, DHTTYPE);
          #define Analog1 1
          #define Analog3 3
          #define Digital 3
          #define Led 12
          int doam;
          float dienap;
          int giatri;//SENSOR QUANG TRO
          /****LUU LUONG***/
          /*volatile int flow_frequency; // Đo xung cảm biến lưu lượng
          unsigned int l_hour; // Tính toán số lít/giờ
          unsigned char flowsensor = 7
          ; // Cảm biến nối với chân 2
          unsigned long currentTime;
          unsigned long cloopTime;
          void flow () // Hàm ngắt
          {
             flow_frequency++;
          }*/
                    //SIM-SMS
          SoftwareSerial SIM900(4,5);
          #include "SIM900.h"
          #include "sms.h"
          SMSGSM sms;
          char smsbuffer[160]; //biến tin nhắn nhận
          char n[20]="+841249558108"; //SĐT người gửi - chủ
          char pos; //biến vị trí tin nhắn trong sim
          char *p; //biến lệnh của người gửi
          //-----------------------------------------------------------------------------
          void setup() {
          Serial.begin(9600);
            dht.begin();  
            pinMode(Digital,INPUT);
            pinMode(Led,OUTPUT);
           //--------------LUU LUONG-------------
           
             /*pinMode(flowsensor, INPUT);
             digitalWrite(flowsensor, HIGH); // Optional Internal Pull-Up
             Serial.begin(9600);
             attachInterrupt(0, flow, RISING); // Setup Interrupt
             sei(); // Enable interrupts
             currentTime = millis();
             cloopTime = currentTime;*/
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
          void loop() {
            //--------------------DHT11------------------------------
            float doAmKhongKhi = dht.readHumidity();
            float nhietDoKhongKhi = dht.readTemperature();
          
            if (isnan(nhietDoKhongKhi) || isnan(doAmKhongKhi)) { // ham kiem tra xem co doc duoc hay khong
            } 
            else {
              Serial.println("Nhiet do:");
              Serial.print(nhietDoKhongKhi);
              Serial.println("*C");
              Serial.println("Do am: ");
              Serial.print(doAmKhongKhi);
              Serial.println("%");
              //---------------------CAM BIEN DO AM DAT-------------------
              int giatriAnalog=analogRead(Analog1);
              int giatriDigital=digitalRead(Digital);
              Serial.print("Gia tri Analog: ");
              Serial.println(giatriAnalog);
              dienap=(giatriAnalog/1023.0)*5.0;  
              doam= (dienap-0.958)/0.0307;
              Serial.print("Do am dat: ");
              Serial.println(doam);
              Serial.print("Gia tri digital: ");
              Serial.println(giatriDigital);
          
          /*if (giatriAnalog>500)
          {
            digitalWrite(Led,HIGH);
          }
          else if(giatriAnalog<=500)
          {
            digitalWrite(Led,LOW);
          }
          */
          //---------------------------- CAM BIEN QUANG TRO------------------------------------
                giatri= analogRead(Analog3);
                  Serial.print("Gia tri quang tro: ");
                  Serial.println(giatri,DEC);
                  /*if (giatri>700)
                  { digitalWrite(Led,HIGH);}
                  else {digitalWrite(Led,LOW);}*/
                  //---------------------- CAM BIEN LUU LUONG NUOC------------------------------------
                   /*currentTime = millis();
                   // Every second, calculate and print litres/hour
                   if(currentTime >= (cloopTime + 1000))
                   {
                      cloopTime = currentTime; // Updates cloopTime
                      // Pulse frequency (Hz) = 7.5Q, Q is flow rate in L/min.
                      l_hour = ((flow_frequency )/ 7.5); // (Pulse frequency x 60 min) / 7.5Q = flowrate in L/hour
                      flow_frequency = 0; // Reset Counter
                      Serial.println(" Luu luong nuoc:");
                      Serial.print(l_hour, DEC); // Print litres/hour
                      Serial.print(" L/MIN");
                      Serial.println("\n");*/
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
                      sms.SendSMS(n, Reply(doam,doAmKhongKhi,nhietDoKhongKhi));//thì gửi lại thông tin cho người dùng
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
                                int doAmDatCanTuoi=(int)changeNhietDo;//gán doAmDatCanTuoi bằng với giá trị nhiệt độ cần thay đổi trong nội dung tin nhắn
                              //  digitalWrite(Relay1,HIGH);
                                delay(300000);
                                //digitalWrite(Relay1,LOW);
                              }
                         }
                   }
                    delay(1000);
                    delay(1000);
                  }
                }
                 
