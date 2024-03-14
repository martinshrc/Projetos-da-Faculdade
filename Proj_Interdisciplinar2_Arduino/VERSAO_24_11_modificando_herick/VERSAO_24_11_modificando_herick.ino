#include <Wire.h>
#include <Adafruit_MLX90614.h>

Adafruit_MLX90614 mlx = Adafruit_MLX90614();
double temp; 

void setup()
{
  Serial.begin(9600);
  pinMode(8, OUTPUT);
  Serial.println("TESTE SERIAL");
  mlx.begin();
}

void loop()
{
  temp = mlx.readObjectTempC();
  Serial.print("Temperatura: ");
  Serial.print(temp);
  Serial.println(" ºC");
  digitalWrite(8, LOW);


  
  if (temp > 36.00)  //temp aumentada pra 38
  { 
    digitalWrite(8, LOW);
    delay(4000);
    Serial.println("Alerta: Temperatura acima de 38.00 ºC");
    digitalWrite(8, HIGH);  // Desliga o pino após 5 segundos
  }
  
  delay(3000);//recomendado pelo gepeto esse delay de leitura, pra não ficar bugando
          // depois temos que ajustar para um delay maior
}
