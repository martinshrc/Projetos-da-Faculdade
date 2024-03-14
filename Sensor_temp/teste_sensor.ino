#include <Wire.h>
#include <Adafruit_MLX90614.h>

Adafruit_MLX90614 mlx = Adafruit_MLX90614();
double x; 

void setup()
{
  Serial.begin(9600);
  pinMode(8, OUTPUT);
  Serial.println("TESTE MLX90614");
  mlx.begin();
}

void loop()
{
  x = mlx.readObjectTempC();
  Serial.print("Temperatura: ");
  Serial.print(x);
  Serial.println(" ºC");
  digitalWrite(8, HIGH);

  if (x > 35.00)  //temp aumentada pra 38
  { 
    digitalWrite(8, LOW);
    delay(2000); //TEMPO DE BOMBA LIGADA
    Serial.println("Alerta: Temperatura acima de 35.00 ºC");
    digitalWrite(8, HIGH);  // Desliga o pino após 5 segundos
  }
  
  delay(2000); //DELAY DE LEITURA
}