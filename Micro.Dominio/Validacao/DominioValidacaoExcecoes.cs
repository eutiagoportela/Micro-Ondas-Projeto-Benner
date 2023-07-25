

namespace Micro.Dominio.Validacao;

public class DominioValidacaoExcecoes : Exception
{
    public DominioValidacaoExcecoes(string error) : base(error) { }

    public static void When(bool hasError, string error)
    {
        if (hasError)
            throw new DominioValidacaoExcecoes(error);
    }
}
