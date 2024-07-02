using System;

public class Cliente
{  
  public string nome { get; set; }
  public string cpf { get; set; } //dentro do set coloca o private, pois um CPF não pode ser alterado
  public string endereco { get; set; }


  public Cliente (string nome, string cpf, string endereco)
  {
    this.nome= nome;
    this.cpf= cpf;
    this.endereco = endereco;
  }

  public void CadastrarCliente()
  {
    Console.WriteLine("Cliente cadastrado com sucesso!");
  }

  public void ExibirInformacoes()
  { 
    string infosCliente = $"Nome: {nome}\nCpf: {cpf}\nEndereco: {endereco}";
    Console.WriteLine(infosCliente.ToUpper());
  }
}