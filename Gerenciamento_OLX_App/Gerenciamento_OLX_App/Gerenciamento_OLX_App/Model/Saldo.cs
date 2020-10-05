using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciamento_OLX_App.Model
{
    public class Saldo
    {
        [PrimaryKey, AutoIncrement]
        public int SaldoId { get; set; }
        public double SaldoConta { get; set; }
    }
}
