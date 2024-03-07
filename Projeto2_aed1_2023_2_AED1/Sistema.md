## Descrição do Sistema

Utilize [Markdown](https://gist.github.com/cuonggt/9b7d08a597b167299f0d) para formatar 
o documento descrição do sistema.

Você pode colocar títulos e subtítulos, numeração, etc.
   
Pode incluir imagens com diagramas de casos de uso ou outros diagramas importantes.
(Obs.: se for colocar figuras crie uma pasta chamada assets ou imagens)


----------------------------------


**Descrição do Projeto: Locadora de Filmes**

  > Problema Mapeado:
    Escolhemos desenvolver um sistema para uma locadora de filmes, visando 
    otimizar o gerenciamento   dos filmes disponíveis, clientes e locações. 
    O e gerenciamento manual é propenso a erros, falta de eficiência e dificuldades na manutenção dos dados.  

  > Funcionalidades do Sistema:
    
    1. Cadastro de Filmes:
      •	Descrição:
      •	Permitirá o cadastro de novos filmes no sistema, incluindo 
        informações como título, gênero e ano de lançamento.
      •	Métodos e Atributos Envolvidos:
      •	Classe: Filme
      •	Atributos: titulo, genero, anoLancamento
      •	Método: CadastrarFilme
   
    2. Cadastro de Clientes:
      •	Descrição:
      •	Permitirá o cadastro de novos clientes, coletando 
        informações como nome, CPF e endereço.
      •	Métodos e Atributos Envolvidos:
      •	Classe: Cliente
      •	Atributos: nome, cpf, endereco
      •	Método: CadastrarCliente
  
    3. Registro de Locações:
      •	Descrição:
      •	Possibilitará o registro de locações, associando um cliente a 
        um filme específico e registrando a data da locação.
      •	Métodos e Atributos Envolvidos:
      •	Classe: Locacao
      •	Atributos: filmeLocado, clienteLocatario, dataLocacao
      •	Método: RegistrarLocacao
  
    4. Exibição de Filmes Disponíveis:
      •	Descrição:
      •	Exibirá a lista de filmes disponíveis no acervo da locadora.
      •	Métodos e Atributos Envolvidos:
      •	Classe: Filme
      •	Método: ExibirFilmes *
  
    5. Exibição de Locações Registradas:
      •	Descrição:
      •	Exibirá a lista de locações registradas, incluindo detalhes como 
        filme locado, cliente locatário e data da locação.
      •	Métodos e Atributos Envolvidos:
      •	Classe: Locacao
      •	Método: DetalhesLocacao *
   
    6. Menu de Interação com o Usuário:
      •	Descrição:
      •	Fornecerá um menu interativo para que o usuário possa 
        escolher entre as diversas funcionalidades do sistema.
      •	Métodos e Atributos Envolvidos:
      •	Classe: Program
      •	Método: Main

