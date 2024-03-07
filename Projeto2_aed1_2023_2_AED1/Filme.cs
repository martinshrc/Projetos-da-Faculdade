using System;

public class Filme
{
    public string titulo { get; set; }
    public string genero { get; set; }
    public string anoLancamento { get; set; }

    public Filme(string titulo, string genero, string anoLancamento)
    {
        this.titulo = titulo;
        this.genero = genero;
        this.anoLancamento = anoLancamento;
    }

    public void ExibirDetalhes()
    {
        string detalhesFilme = $" {titulo}, {genero}, {anoLancamento}";
        Console.Write(detalhesFilme.ToUpper());
    }

}