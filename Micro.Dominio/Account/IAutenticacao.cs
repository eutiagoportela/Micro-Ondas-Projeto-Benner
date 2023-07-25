using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Dominio.Account;

public interface IAutenticacao
{
    Task<bool> Autenticar(string email, string senha);

    Task<bool> RegistrarUsuario(string email, string senha);

    Task Logout();
}
