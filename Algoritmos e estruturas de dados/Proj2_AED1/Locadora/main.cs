using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        List<Filme> filmes = LerFilmes();
        List<Cliente> clientes = LerClientes();
        List<Locacao> locacoes = LerLocacoes(filmes, clientes);


        while (true)
        {
            Console.WriteLine("\n=== Menu ===");
            Console.WriteLine("1. Cadastrar Filme");
            Console.WriteLine("2. Cadastrar Cliente");
            Console.WriteLine("3. Registrar Locação");
            Console.WriteLine("4. Exibir Filmes Disponíveis");
            Console.WriteLine("5. Exibir Locações Registradas");
            Console.WriteLine("6. Sair\n");

            Console.WriteLine("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Insira os dados do filme abaixo!\n ");
                    Console.WriteLine("Titulo do filme: ");
                    string titulo = Console.ReadLine();
                    Console.WriteLine("Gênero: ");
                    string genero = Console.ReadLine();
                    Console.WriteLine("Ano de Laçamento: ");
                    string anoLancamento = Console.ReadLine();
                    Filme novoFilme = new Filme(titulo, genero, anoLancamento);
                    filmes.Add(novoFilme);
                    GravarFilme(novoFilme);
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Insira os dados do cliente");
                    Console.WriteLine("Nome: ");
                    string nome = Console.ReadLine();
                    Console.WriteLine("CPF: ");
                    string cpf = Console.ReadLine();
                    Console.WriteLine("Endereço: ");
                    string endereco = Console.ReadLine();
                    Cliente novoCliente = new Cliente(nome, cpf, endereco);
                    clientes.Add(novoCliente);
                    GravarCliente(novoCliente);
                    break;

                case "3":
                    Console.Clear();

                    if ((filmes.Count > 0) && (clientes.Count > 0))
                    {
                        Console.WriteLine("Lista de clientes e filmes cadastrados\n");
                        for (int i = 0; i < filmes.Count; i++)
                        {
                            Console.Write($"Filme Nº{i}:");
                            filmes[i].ExibirDetalhes();
                            Console.WriteLine("\n-----------\n");
                        }
                        for (int i = 0; i < clientes.Count; i++)
                        {
                            Console.WriteLine($"Cliente Nº{i}");
                            clientes[i].ExibirInformacoes();
                            Console.WriteLine("-----------\n");
                        }
                        Console.WriteLine("Digite somente numeros!!!\n     ------ ");
                        Console.WriteLine("Digite o número do filme desejado: ");
                        int indiceFilme = int.Parse(Console.ReadLine());
                        Console.WriteLine(filmes[indiceFilme].titulo); 

                        Console.WriteLine("Digite o número do cliente desejado: ");
                        int indiceCliente = int.Parse(Console.ReadLine());
                        DateTime data = DateTime.Now;  
                        string dataFormat = data.ToString("dd/MM/yyyy");
                        Locacao novaLocacao = new Locacao(filmes[indiceFilme], clientes[indiceCliente], dataFormat);

                        locacoes.Add(novaLocacao);
                        GravarLocacao(novaLocacao);
                        Console.WriteLine("Locação registrada com sucesso!");
                        break;
                    }

                    else 
                    {
                        Console.WriteLine("Você precisa ter ao menos 1 cliente e 1 filme regstrado para fazer a locação");
                        break;
                    }




                case "4":
                    Console.Clear();                    
                    Console.WriteLine("===Filmes disponiveis===");

                    foreach (Filme filme in filmes)
                    {
                        Console.WriteLine($"Título: {filme.titulo}, {filme.genero}, {filme.anoLancamento}");
                    }
                    break;
                    

                case "5":

                    Console.Clear();
                    Console.WriteLine("===Locações Registradas===");
                    for (int i = 0; i < locacoes.Count; i++)
                    {
                        locacoes[i].DetalhesLocacao();
                    }
                    break;

                case "6":
                    Console.Clear();
                    Console.WriteLine("Saindo do programa.Até mais!");
                    return;



                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida! \nTente novamente.");
                    break;
                }
            }
    
    }

    public static void GravarFilme(Filme filme)
    {
        using (StreamWriter conteudoFilme = new StreamWriter("filmesCadastrados.txt", true))
        {
            conteudoFilme.WriteLine($"{filme.titulo};{filme.genero};{filme.anoLancamento}");
        }
    }

    public static void GravarCliente(Cliente cliente)
    {
        using (StreamWriter conteudoCliente = new StreamWriter("clientesCadastrados.txt", true))
        {
            conteudoCliente.WriteLine($"{cliente.nome};{cliente.cpf};{cliente.endereco}");
        }
    }

    public static void GravarLocacao(Locacao locacao)
    {
        using (StreamWriter conteudoLocacao = new StreamWriter("locacoesRegistradas.txt", true))
        {
            conteudoLocacao.WriteLine($"{locacao.dataLocacao};{locacao.filme.titulo};{locacao.cliente.nome}");
        }
    }


    public static List<Filme> LerFilmes()
    {
        List<Filme> filmes = new List<Filme>();
        if (File.Exists("filmesCadastrados.txt"))
        {
            string[] linhas = File.ReadAllLines("filmesCadastrados.txt");
            foreach (string linha in linhas)
            {
                string[] dados = linha.Split(';');
                if (dados.Length == 3)
                {
                    Filme filme = new Filme(dados[0], dados[1], dados[2]);
                    filmes.Add(filme);
                }
            }
        }
        return filmes;

    }

    public static List<Cliente> LerClientes()
    {
        List<Cliente> clientes = new List<Cliente>();
        if (File.Exists("clientesCadastrados.txt"))
        {
            string[] linhas = File.ReadAllLines("clientesCadastrados.txt");
            foreach (string linha in linhas)
            {
                string[] dados = linha.Split(';');
                if (dados.Length == 3)
                {
                    Cliente cliente = new Cliente(dados[0], dados[1], dados[2]);
                    clientes.Add(cliente);
                }
            }
        }

        return clientes;
    }

    public static List<Locacao> LerLocacoes(List<Filme> filmes, List<Cliente> clientes)
    {
      List<Locacao> locacoes = new List<Locacao>();
      if  (File.Exists("locacoesRegistradas.txt"))
      {
          string[] linhas = File.ReadAllLines("locacoesRegistradas.txt");
          foreach (string linha in linhas)
          {
              string[] dados = linha.Split(';');
              if (dados.Length == 3)
              {
                Filme f = BuscaFilme(dados[1], filmes);
                Cliente c = BuscaCliente(dados[2], clientes);
                Locacao locacao = new Locacao(f, c, dados[0]);
                locacoes.Add(locacao);
              }
          }
      }

      return locacoes;
    }

    public static Filme BuscaFilme (string titulo, List<Filme> filmes) 
    {
        foreach ( Filme f in filmes){
            if(titulo == f.titulo)
                return f;
        }
        return null;
    }
    
    public static Cliente BuscaCliente (string nome, List<Cliente> clientes)
    {
        foreach ( Cliente c in clientes){
            if(nome == c.nome)
                return c;
        }
        return null;
    }

}
