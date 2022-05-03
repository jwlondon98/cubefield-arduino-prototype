const int swPin = 8;
const int xPin = 0;
const int yPin = 1;

void setup() {
  Serial.begin(19200);
  pinMode(swPin, INPUT_PULLUP);
  pinMode(xPin, INPUT);
  pinMode(yPin, INPUT);
}

void loop() {
  float x = analogRead(xPin);
  float y = analogRead(yPin);

  int max = 100;
    
  if (x <= 516)
  {
    x = map(x, 516, 0, 0, -max);
  }  
  else
  {
    x = map(x, 1024, 517, max, 0);
  }
  
  if (y >= 516)
  {
    y = map(y, 1024, 516, -max, 0);
  }
  else
  {
    y = map(y, 516, 0, 0, max);
  }

  if (x == -1)
  {
    x = 0;  
  }
  
  if (y == -1)
  {
    y = 0;  
  }
  
  
//  Serial.print("X: ");
  Serial.print(x);
  Serial.print(",");
//  Serial.print(" | Y: ");
  Serial.print(y);  
  Serial.print(",");
//  Serial.print(" | "); 
  Serial.println(!digitalRead(swPin));

  delay(50);
}
