int motorSpeed = 200;

void setup() {
  pinMode(10, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(3, INPUT_PULLUP);
  Serial.begin(9600);

}

void loop() {
  if(digitalRead(3) == LOW){
    Serial.println("BT ON");
    analogWrite(10, motorSpeed);
    analogWrite(11, 0);
    delay(500);
    analogWrite(10, 0);
    analogWrite(11, 0);
    delay(200);
  }
  else{
    analogWrite(10, 0);
    analogWrite(11, 0);
  }

}
