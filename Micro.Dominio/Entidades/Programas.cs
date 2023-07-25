
using Micro.Dominio.Validacao;
using static System.Net.Mime.MediaTypeNames;

namespace Micro.Dominio.Entidades;

public sealed class Programas
{
    public int Id { get; private set; }
    public string? Nome { get; private set; }
    public string? Alimento { get; private set; }
    public int Tempo { get; private set; }
    public int Potencia { get; private set; }
    public string? Instrucoes { get; private set; }
    public string? Aquece { get; private set; }

    public Programas(string Nome,string Alimento,int Tempo,int Potencia,string Instrucoes,string aquece)
    {
        ValidateDomain( Nome,  Alimento,  Tempo,  Potencia,  Instrucoes, aquece);
    }

    public Programas(int id,string Nome, string Alimento, int Tempo, int Potencia, string Instrucoes, string aquece)
    {
        DominioValidacaoExcecoes.When(id < 0, "Valor do ID inválido");
        Id = id;
        ValidateDomain(Nome, Alimento, Tempo, Potencia, Instrucoes, aquece);
    }

    private void ValidateDomain(string nome, string alimento, int tempo, int potencia, string instrucoes,string aquece)
    {
        DominioValidacaoExcecoes.When(string.IsNullOrEmpty(nome),
          "Informa o nome");
        DominioValidacaoExcecoes.When(nome.Length < 2,
         "Nome inválido, informe ao menos 2 caracteres");

        DominioValidacaoExcecoes.When(string.IsNullOrEmpty(alimento),
        "Informa o alimento");

        DominioValidacaoExcecoes.When(tempo < 1,
        "Informe o tempo com minimo 1 segundo");

        //comentado para ser adicionado os pre cadastros via entity em InfraData na classe ProgramasConfiguracao.cs
        //  DominioValidacaoExcecoes.When(tempo > 120,
        // "Informe o tempo com no maximo 120 segundos");

        DominioValidacaoExcecoes.When(potencia < 1,
         "Informe a potencia com minimo 1 ");

        DominioValidacaoExcecoes.When(potencia > 10,
       "Informe o potencia com no maximo 10 ");

        Nome = nome;
        Alimento = alimento;
        Tempo = tempo;
        Potencia = potencia;
        Instrucoes = instrucoes;
        Aquece = aquece;
    }
}
