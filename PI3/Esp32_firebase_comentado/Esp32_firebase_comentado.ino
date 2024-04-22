//importando bibliotecas
#include <WiFi.h>                          //importa biblioteca para conectar esp32 com wifi
#include <IOXhop_FirebaseESP32.h>          //importa biblioteca para esp32 se comunicar com firebase
#include <ArduinoJson.h>                   //importa biblioteca para colocar informação no formato json, utilizado no firebase (intalar versão 5)
#include <Wire.h>
#include <Adafruit_MLX90614.h>

//fazendo definições para não repetir muito texto durante o código 
#define WIFI_SSID "herick"                  //substitua "Nome_do_seu_wifi" pelo nome da sua rede wifi 
#define WIFI_PASSWORD "herick123"             //substitua "Senha_do_seu_wifi" pela senha da sua rede wifi 
#define FIREBASE_HOST "https://agroucl-default-rtdb.firebaseio.com"    //substitua "Link_do_seu_banco_de_dados" pelo link do seu banco de dados 
#define FIREBASE_AUTH "FVi51mExNObRynr7bNwS4XUhhDZ5QPJL41iOGlkd"   //substitua "Senha_do_seu_banco_de_dados" pela senha do seu banco de dados

Adafruit_MLX90614 mlx = Adafruit_MLX90614();
int x;

void setup() {
  Serial.begin(9600);      //inicia comunicação serial
  Serial.println();          //imprime pulo de linha

  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);     //inicia comunicação com wifi com rede definica anteriormente
  
  Serial.print("Conectando ao wifi");       //imprime "Conectando ao wifi"
  while (WiFi.status() != WL_CONNECTED)     //enquanto se conecta ao wifi fica colocando pontos
  {
    Serial.print(".");
    delay(300);
  }
  Serial.println();                         //imprime pulo de linha

  Firebase.begin(FIREBASE_HOST, FIREBASE_AUTH);   //inicia comunicação com firebase definido anteriormente


  Serial.begin(9600);
  Serial.println("Adafruit MLX90614 test");  
  mlx.begin();

  //pinMode(24, OUTPUT); // declara o pino do led como saída

}

void loop() {

//função Set//

  x = mlx.readObjectTempC();
  Serial.println(x);

  delay(500);
  Firebase.setInt("solo/temperatura", x);

}
