// Importando bibliotecas
#include <WiFi.h>                          // Importa biblioteca para conectar ESP32 com WiFi
#include <IOXhop_FirebaseESP32.h>          // Importa biblioteca para ESP32 se comunicar com Firebase
#include <ArduinoJson.h>                   // Importa biblioteca para formatar informações em JSON, utilizado no Firebase (instalar versão 5)
#include <Wire.h>
// Biblioteca DS18B20 Dallas Temperatura
#include <OneWire.h>
#include <DallasTemperature.h>

// Definindo constantes para evitar repetição de texto durante o código
#define WIFI_SSID "herick"   // Substitua "Nome_do_seu_wifi" pelo nome da sua rede WiFi
#define WIFI_PASSWORD "herick123"           // Substitua "Senha_do_seu_wifi" pela senha da sua rede WiFi
#define FIREBASE_HOST "https://agroucl-default-rtdb.firebaseio.com"  // Substitua "Link_do_seu_banco_de_dados" pelo link do seu banco de dados
#define FIREBASE_AUTH "FVi51mExNObRynr7bNwS4XUhhDZ5QPJL41iOGlkd"     // Substitua "Senha_do_seu_banco_de_dados" pela senha do seu banco de dados

#define umidadeAnalogica 32 //Atribui o pino A0 a variável umidade - leitura analógica do sensor

#define DS18B20 14

#define POTENCIOMETRO_PIN_CALCIO 33

const int pinrele1 = 16;
const int pinrele2 = 17;
const int pinrele3 = 18;

int botao;
int temperatura;
float ETP;
float valorpotenciometro;
float p;
int valorumidade; //Declaração da variável que armazenará o valor da umidade lida - saída analogica

// Sensor de Temperatura DS18B20
//Instacia o Objeto oneWire e Seta o pino do Sensor para iniciar as leituras
OneWire oneWire(DS18B20);

//Repassa as referencias do oneWire para o Sensor Dallas (DS18B20)
DallasTemperature Sensor(&oneWire);

// Variavel para Armazenar os dados de Leitura
float leitura;

void setup() {
  Serial.begin(9600);      // Inicia comunicação serial
  Serial.println();        // Imprime pulo de linha

  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);  // Inicia comunicação com WiFi com rede definida anteriormente
  
  Serial.print("Conectando ao WiFi");  // Imprime "Conectando ao WiFi"
  while (WiFi.status() != WL_CONNECTED) {  // Enquanto se conecta ao WiFi, fica colocando pontos
    Serial.print(".");
    delay(300);
  }
  Serial.println();  // Imprime pulo de linha

  Firebase.begin(FIREBASE_HOST, FIREBASE_AUTH);  // Inicia comunicação com Firebase definido anteriormente

  Sensor.begin();

  pinMode(pinrele1, OUTPUT);
  pinMode(pinrele2, OUTPUT);
  pinMode(pinrele3, OUTPUT);
  digitalWrite(pinrele1, HIGH);
  digitalWrite(pinrele2, HIGH);
  digitalWrite(pinrele3, HIGH);
  pinMode(umidadeAnalogica, INPUT); //Define umidadeAnalogica como entrada

  pinMode(POTENCIOMETRO_PIN_CALCIO, INPUT);  

}
void loop() {
  // TEMPERATURA
  Sensor.requestTemperatures();

  // Armazerna na variavel o valor da Leitura
  temperatura = Sensor.getTempCByIndex(0);

  // Imprime na Tela a Leitura
  Serial.print("TEMPERATURA:"); 
  Serial.print(temperatura);
  Serial.println("ºC"); 
  Serial.println("--------------------------------------"); 
  // TEMPERATURA

  // POTENCIOMETRO CALCIO
  Serial.println("--------------------------------------"); 
  valorpotenciometro = analogRead(POTENCIOMETRO_PIN_CALCIO);
  Serial.print("CALCIO: ");
  Serial.println(valorpotenciometro);
  Serial.println("--------------------------------------"); 
  // POTENCIOMETRO CALCIO

  // UMIDADE
  valorumidade = analogRead(umidadeAnalogica); //Realiza a leitura analógica do sensor e armazena em valorumidade
  valorumidade = map(valorumidade, 1023, 315, 0, 100); //Transforma os valores analógicos em uma escala de 0 a 100
  Serial.print("Umidade encontrada: "); //Imprime mensagem
  Serial.print(valorumidade); //Imprime no monitor serial o valor de umidade em porcentagem
  Serial.println(" % " );
  Serial.println("--------------------------------------"); 
  // UMIDADE

  // ETP
  p = 11.11;
  ETP = (p * (0.46 * temperatura + 8.13)) / 100;
  Serial.print("Evapotranspiração Potencial (mm/dia): ");
  Serial.println(ETP);
  Serial.println("--------------------------------------"); 
  // ETP

  
  // COMANDOS RELE

  if (valorpotenciometro > 1500)
  {

    digitalWrite(pinrele2, LOW);
    delay(600);
    digitalWrite(pinrele2, HIGH);

    delay(1000);

    digitalWrite(pinrele1, LOW);
    delay(600);
    digitalWrite(pinrele1, HIGH);

    delay(1000);

    digitalWrite(pinrele3, LOW);
    delay(700);
    digitalWrite(pinrele3, HIGH);
    delay(1000);
  } 

  if (valorumidade > -250)
  {

    digitalWrite(pinrele1, LOW);
    delay(600);
    digitalWrite(pinrele1, HIGH);

    delay(1000);

    digitalWrite(pinrele3, LOW);
    delay(700);
    digitalWrite(pinrele3, HIGH);
  }
  // COMANDOS RELE

  
  // FIREBASE
  Firebase.setInt("solo/temperatura", temperatura);
  Firebase.setFloat("solo/ETP", ETP);
  Firebase.setFloat("solo/Calcio", POTENCIOMETRO_PIN_CALCIO);
  Firebase.setFloat("solo/Umidade", valorumidade);
  Firebase.setInt("solo/botao", botao);

  // FIREBASE
}