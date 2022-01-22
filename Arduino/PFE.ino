
int sensor = 1;


int val = 0;                 // variable to store the sensor status (value)
const int hot=5;
const int cold=1;

 int Lampe = 8; 

int led2 = 12;                // the pin that the LED is atteched to
int sensor2 = 2;              // the pin that the sensor is atteched to
int state2 = LOW;             // by default, no motion detected
int val2 = 0;                 // variable to store the sensor status (value)



void setup()
{
  pinMode(A0,INPUT);
  pinMode(13,OUTPUT);//blue
 pinMode(8,OUTPUT);//Lampe
  pinMode(4,OUTPUT);//green
  pinMode(7,OUTPUT);//red
  Serial.begin(9600);

  pinMode(sensor, INPUT);    // initialize sensor as an input
  
  
   pinMode(led2, OUTPUT);      // initalize LED as an output
  pinMode(sensor2, INPUT);    // initialize sensor as an input

}
void loop()
{
 
     
 digitalWrite (8,HIGH);
  int sensor=analogRead(A0);
  float tempC = sensor * (5.0 / 1023.0 * 100.0);
  
  
   
   
     val2 = digitalRead(sensor2);   // read sensor value
 
  
  
  
  
  

    
  if (tempC<cold)
  {
     Serial.println ("#it's cold#");
    digitalWrite (13,HIGH);
    digitalWrite (7,LOW);
    digitalWrite (4,LOW);
  
}
else if (tempC >=hot){
  Serial.println ("#it's hot#");  
  digitalWrite (7,HIGH);
    digitalWrite (13,LOW);
   digitalWrite (4,LOW);
  
    }
    else if(cold<tempC<hot) {
      Serial.println ("#it's fine#");
      digitalWrite (4,HIGH);
    digitalWrite (7,LOW);
    digitalWrite (13,LOW);
 
    }
    
    delay(10);
     Serial.print("//Temp//");
      Serial.println(tempC);
       Serial.print("//Temp//");
  val = digitalRead(sensor);   // read sensor value
  if (val == HIGH) {           // check if the sensor is HIGH

   digitalWrite(led2,HIGH);
   delay(100);
    
     }
    
 
   if (val2 == HIGH) {           // check if the sensor is HIGH
    digitalWrite(led2, HIGH);   // turn LED ON
    delay(100);                // delay 100 milliseconds 
    
    if (state2 == LOW) {
      Serial.println("#Motion detected!#"); 
      state2 = HIGH;       // update variable state to HIGH
      delay(100);
    }
  } 
  else {
      digitalWrite(led2, LOW); // turn LED OFF
       Serial.println("#Motion stopped!#");
      delay(50);             // delay 200 milliseconds 
      
      if (state2 == HIGH){
        Serial.println("#Motion stopped!#");
        state2 = LOW;       // update variable state to LOW
    }
  
  
    
    
    
  }
    





}

