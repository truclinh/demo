switch(p)
{
  case strstr(smsbuffer,"BOMON"):
  {
    if(digitalWrite(Relay1,LOW)// neu Relay1 dang tat
    {
         if (doAmDat>900)
        {
          digitalWrite(Relay1,HIGH);
        delay(10000); 
        digitalWrite(Relay1,LOW); 
        sms.SendSMS(n, "DA TUOI CAY ..!!");}
        else
        {
          if(doAmDat<900)
        {
           //Serial.print("Du nuoc");
          sms.SendSMS(n, "CAY DA DU NUOC KHONG CAN TUOI.!");     
        }
        }
    }
    else// neu Relay1 dang bat
    sms.SendSMS(n, "DANG BOM NUOC..!");
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
