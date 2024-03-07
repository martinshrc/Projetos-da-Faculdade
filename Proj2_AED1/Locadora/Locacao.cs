using System;

public class Locacao 
{
    public string dataLocacao { get; set; }
    public Cliente cliente { get; set; }
    public Filme filme { get; set;}

    public Locacao(Filme filme, Cliente cliente, string data)
    {
        this.filme = filme; 
        this.cliente = cliente; 
        this.dataLocacao = data;
    }

    public void DetalhesLocacao()
    {
        Console.WriteLine("Detalhes da Locação:");
        Console.WriteLine($"{filme.titulo}");
        Console.WriteLine("Cliente Locatário: ");
        Console.WriteLine($"{cliente.nome}");
        Console.WriteLine($"Data de Locação: {dataLocacao}");
        Console.WriteLine("--------");
    }
}
    