
using Micro.FrontDesktop.Interfaces;

namespace Micro.FrontDesktop.Model;

public class ProgramaDto :IMicro
{
    public int Id { get; private set; }
    public string? Nome { get; private set; }
    public string? Alimento { get; private set; }
    public int Tempo { get; private set; }
    public int Potencia { get; private set; }
    public string? Instrucoes { get; private set; }
    public string? Aquece { get; private set; }

    public ProgramaDto()
    {
        Tempo = 0;
        Potencia = 0;
    }

    public void DefinerPotencia(int potencia)
    {
       Potencia = potencia;
    }

    public void DefineTempo(int tempo)
    {
       Tempo = tempo;
    }

    public bool ValidaTempo()
    {
        if (Tempo > 120)
        {
            MessageBox.Show("Informe o tempo com no maximo 120 segundos");
            LimpaValores();
            return false;

        }
        if (Tempo < 1)
        {
            MessageBox.Show("Informe o tempo com minimo 1 segundo");
            LimpaValores();
            return false;
        }

        return true;
    }

    public bool ValidaPotencia()
    {
        if (Potencia > 10)
        {
            MessageBox.Show("Informe o potencia com no maximo 10");
            LimpaValores();
            return false;
        }
        if (Potencia < 1)
        {
            MessageBox.Show("Informe a potencia com minimo 1");
            LimpaValores();
            return false;
        }

        return true;
    }

    public void LimpaValores()
    {
        Tempo = 0;
        Potencia = 0;
    }

    public void DefinerNome(string nome)
    {
       Nome = nome;
    }

    public void DefinerAlimento(string alimento)
    {
       Alimento = alimento;
    }

    public void DefinerInstrucoes(string instrucoes)
    {
        Instrucoes = instrucoes;
    }

    public void DefinerAquece(string aquece)
    {
        Aquece = aquece;
    }
}
