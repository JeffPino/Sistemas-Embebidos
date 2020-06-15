#include <Arduino_FreeRTOS.h>

#define Ledazul 3
#define Ledverde 5
#define Potenciometro A0 


void Parpadeo100( void *pvParameters );
void Parpadeo500( void *pvParameters );
void Leer( void *pvParameters );

void setup() {

  xTaskCreate(
    Parpadeo100
    ,  (const portCHAR *) "parpadeo1"
    , 128
    ,  NULL
    ,  2  
    ,  NULL );

      xTaskCreate(
    Parpadeo500
    ,  (const portCHAR *) "parpadeo2"
    ,  128  
    ,  NULL
    ,  3  
    ,  NULL );

  xTaskCreate(
    Leer
    ,  (const portCHAR *) "lectura"
    ,  128  
    ,  NULL
    ,  1  
    ,  NULL );

  
}

void loop()
{
 
}



void Parpadeo100(void *pvParameters)  
{
  (void) pvParameters;

  
  pinMode(Ledazul, OUTPUT);

  for (;;) 
  {
    digitalWrite(Ledazul, HIGH);  
    vTaskDelay( 10 / portTICK_PERIOD_MS ); 
    digitalWrite(Ledazul, LOW);    
    vTaskDelay( 90 / portTICK_PERIOD_MS ); 
  }
}

void Parpadeo500(void *pvParameters) 
{
  (void) pvParameters;

  
  pinMode(Ledverde, OUTPUT);

  for (;;) 
  {
    digitalWrite(Ledverde, HIGH); 
    vTaskDelay( 10 / portTICK_PERIOD_MS );   
    digitalWrite(Ledverde, LOW);    
    vTaskDelay( 490 / portTICK_PERIOD_MS ); 
  }
}

void Leer(void *pvParameters)  
{
  (void) pvParameters;
  Serial.begin(9600);
  for (;;)
  {
  
    int Valor = analogRead(Potenciometro);
    Serial.println(Valor);
    vTaskDelay(1000/ portTICK_PERIOD_MS);  
  }
}
