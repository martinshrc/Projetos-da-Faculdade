#include <Wire.h>
#include <Adafruit_MLX90614.h>

Adafruit_MLX90614 mlx = Adafruit_MLX90614();
float x; 

void setup()
{
  Serial.println("TESTE MLX90614");
  mlx.begin();
  Serial.begin(9600);
  
}

void loop()
{
  x = mlx.readObjectTempC();
  //Serial.print("Temperatura: ");
  Serial.println(x);
  //Serial.println(" ºC");
  
  delay(1000); //DELAY DE LEITURA
}