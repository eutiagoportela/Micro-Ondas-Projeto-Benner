using Micro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Infra.Data.EntidadesConfiguracao;

public class ProgramasConfiguracao : IEntityTypeConfiguration<Programas>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Programas> builder)
    {

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Alimento).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Tempo).IsRequired();
        builder.Property(p => p.Potencia).IsRequired();
        builder.Property(p => p.Instrucoes).HasMaxLength(400);
        builder.Property(p => p.Aquece).HasMaxLength(1);
        //pre cadastro
        builder.HasData(
            new Programas(1,"Pipoca", "Pipoca (de micro-ondas)", 180, 7, "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um estouro e outro, interrompa o aquecimento.","$"),
            new Programas(2, "Leite", "Leite", 300, 5, "Cuidado com aquecimento de líquidos, o choque térmico aliado ao movimento do recipiente pode causar fervura imediata causando risco de queimaduras.","*"),
            new Programas(3, "Carnes de boi", "Carne em pedaço ou fatias", 840, 4, "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme.","%"),
            new Programas(4, "Frango", "Frango (qualquer corte)", 480, 7, ": Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme.","#"),
            new Programas(5, "Feijão", "Feijão congelado", 480, 9, "Deixe o recipiente destampado e em casos de plástico, cuidado ao retirar o recipiente pois o mesmo pode perder resistência em altas temperaturas.","@")
            );
    }
}
