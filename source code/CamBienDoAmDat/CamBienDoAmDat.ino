#define Analog 1
#define Digital 4
#define Led 12
int giatriAnalog, giatriDigital;
void setup() {
  Serial.begin(9600);
  pinMode(Digital,INPUT);
  pinMode(Led,OUTPUT);
}
void loop() {
giatriAnalog=analogRead(Analog);
giatriDigital=digitalRead(Digital);
Serial.print("Gia tri Analog: ");
Serial.println(giatriAnalog);
Serial.print("Gia tri digital: ");
Serial.println(giatriDigital);
dienap=(giatriAnalog/1023.0)*5.0;
      doam= (dienap-0.958)/0.0307;
delay(1000);
if (giatriAnalog>500)
{
  digitalWrite(Led,HIGH);
}
else if(giatriAnalog<=500)
{
  digitalWrite(Led,LOW);
}
delay(1000);
}
