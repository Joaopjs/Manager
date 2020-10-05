using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciamento_OLX_App.Model
{
   
    public class Financas
    {
        [PrimaryKey, AutoIncrement]
        public int FinancaId { get; set; }
        public float Lucro { get; set; }
        public DateTime DataLucro { get; set; }

    }
}
        