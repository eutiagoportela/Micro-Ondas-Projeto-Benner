
using FluentAssertions;
using Micro.Dominio.Entidades;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace Micro.Dominio.Tests;

public class ProgramaUnitTestes
{
    [Fact(DisplayName = "Criar Produto com estado valido")]
    public void CriarPrograma_ComParametrosValidos_ResultObjectValidState()
    {
        Action action = () => new Programas("Pipoca", "Pipoca (de micro-ondas)", 120, 7, "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um \r\nestouro e outro, interrompa o aquecimento.","*");
        action.Should()
            .NotThrow<Validacao.DominioValidacaoExcecoes>();
    }

    [Fact]
    public void CriarPrograma_ComIdNegativo_DomainExceptionInvalidId()
    {
        Action action = () => new Programas(-1, "Pipoca", "Pipoca (de micro-ondas)", 120, 7, "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um \r\nestouro e outro, interrompa o aquecimento.", "*");
        action.Should()
            .Throw<Validacao.DominioValidacaoExcecoes>()
            .WithMessage("Valor do ID inválido");
    }

    [Fact]
    public void CriarPrograma_ComNomeCurto_DomainExceptionShortName()
    {
        Action action = () => new Programas("P", "Pipoca (de micro-ondas)", 120, 7, "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um \r\nestouro e outro, interrompa o aquecimento.", "*");
        action.Should()
            .Throw<Validacao.DominioValidacaoExcecoes>()
            .WithMessage("Nome inválido, informe ao menos 2 caracteres");
    }

    /* [Fact]
     public void CriarPrograma_ComNomeAlimentoVazio_DomainException()
     {
         Action action = () => new Programas("Pipoca", "", 120, 7, "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um \r\nestouro e outro, interrompa o aquecimento.","*");
         action.Should()
             .Throw<Validacao.DominioValidacaoExcecoes>()
             .WithMessage("Informa o alimento");
     }*/

    [Fact]
    public void CreatePrograma_ValorTempoMenorInvalido_DomainException()
    {
        Action action = () => new Programas("Pipoca", "Pipoca (de micro-ondas)", 0, 7, "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um \r\nestouro e outro, interrompa o aquecimento.", "*");
        action.Should().Throw<Validacao.DominioValidacaoExcecoes>()
             .WithMessage("Informe o tempo com minimo 1 segundo");
    }

    [Fact]
    public void CreatePrograma_ValorTempoMaiorInvalido_DomainException()
    {
        Action action = () => new Programas("Pipoca", "Pipoca (de micro-ondas)", 121, 7, "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um \r\nestouro e outro, interrompa o aquecimento.", "*");
        action.Should().Throw<Validacao.DominioValidacaoExcecoes>()
             .WithMessage("Informe o tempo com no maximo 120 segundos");
    }

    [Fact]
    public void CreatePrograma_ValorPotenciaMenorInvalido_DomainException()
    {
        Action action = () => new Programas("Pipoca", "Pipoca (de micro-ondas)", 120, 0, "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um \r\nestouro e outro, interrompa o aquecimento.", "*");
        action.Should().Throw<Validacao.DominioValidacaoExcecoes>()
             .WithMessage("Informe a potencia com minimo 1 ");
    }

    [Fact]
    public void CreatePrograma_ValorPotenciaMaiorInvalido_DomainException()
    {
        Action action = () => new Programas("Pipoca", "Pipoca (de micro-ondas)", 120, 11, "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um \r\nestouro e outro, interrompa o aquecimento.", "*");
        action.Should().Throw<Validacao.DominioValidacaoExcecoes>()
             .WithMessage("Informe o potencia com no maximo 10 ");
    }
}
