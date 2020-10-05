using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciamento_OLX_App.Model
{
    public class ConfigApp
    {
        [PrimaryKey, AutoIncrement]
        public int IdConfigApp { get; set; }
        public string PaginaInicial { get; set; }
        public string PaginaChat { get; set; }
        public DateTime DataFechamento { get; set; }
        public string CotaInvestimento { get; set; }

    }
}
