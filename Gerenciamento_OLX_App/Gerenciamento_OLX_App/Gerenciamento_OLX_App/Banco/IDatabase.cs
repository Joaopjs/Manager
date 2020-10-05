using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciamento_OLX_App.Banco
{
    public interface IDatabase
    {
        string GetPathDB(string NomeArquivoBanco);
    }
}
