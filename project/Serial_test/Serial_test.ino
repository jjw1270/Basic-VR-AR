const int trigPin = 4;     //btn
const int LED = 5;


void setup() {
  Serial.begin(9600);
  pinMode(trigPin, INPUT_PULLUP);
  pinMode(LED, OUTPUT);
}

void loop() {
  int trig = digitalRead(trigPin);
  String txt = Serial.readString();
  if (trig == HIGH) {
    Serial.write(9);
  }
  if(txt == "5"){
    digitalWrite(LED, HIGH);
    delay(300);
    digitalWrite(LED, LOW);
    delay(100);
  }
  //if(Serial.available()){
  //}
}
