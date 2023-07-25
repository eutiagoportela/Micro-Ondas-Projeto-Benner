using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.FrontDesktop.Interfaces;

public interface IMicro
{
    void DefinerNome(string nome);
    void DefinerAlimento(string alimento);
    void DefineTempo(int tempo);
    void DefinerPotencia(int potencia);
    void DefinerInstrucoes(string instrucoes);
    void DefinerAquece(string aquece);

    bool ValidaTempo();
    bool ValidaPotencia();
}
