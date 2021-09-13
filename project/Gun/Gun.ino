

void setup() {
  pinMode(10, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(3, INPUT_PULLUP);
  Serial.begin(9600);

}

void loop() {
  if(digitalRead(3) == LOW){
    Serial.println("BT ON");
    digitalWrite(10, LOW);
    digitalWrite(11, HIGH);
    delay(500);
  }
  else{
    digitalWrite(10, LOW);
    digitalWrite(11, LOW);
  }

}
