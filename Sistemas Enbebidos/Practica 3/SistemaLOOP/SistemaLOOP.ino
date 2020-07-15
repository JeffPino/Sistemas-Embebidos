#define Ledazul 3
#define Ledverde 5
#define Potenciometro A0 


void setup() {
  Serial.begin(9600);
  pinMode(Ledazul, OUTPUT);
  pinMode(Ledverde, OUTPUT);
}

void loop()
{
Parpadeo100();
Parpadeo500(); 
}

void Parpadeo100(){
    digitalWrite(Ledazul, HIGH);
    delay(10);
    digitalWrite(Ledazul, LOW);  
    delay(90); 
 
}

void Parpadeo500(){
    
    digitalWrite(Ledverde, HIGH); 
    delay(10); 
    digitalWrite(Ledverde, LOW);
    delay(490);      
   
}
