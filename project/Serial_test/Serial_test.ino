const int trigPin = 4;     //btn
const int LED = 5;


void setup() {
  Serial.begin(9600);
  pinMode(trigPin, INPUT_PULLUP);
  pinMode(LED, OUTPUT);
}

void loop() {
  int trig = digitalRead(trigPin);
  String RV = Serial.readString();
  if(RV != "R"){
    if (trig == HIGH) {
      Serial.println("F");
      //솔레노이드 액추에이터
      delay(500);
    }
  }else if(RV == "R"){
    digitalWrite(LED,HIGH);
    delay(3000);
    digitalWrite(LED, LOW);
  }
}
