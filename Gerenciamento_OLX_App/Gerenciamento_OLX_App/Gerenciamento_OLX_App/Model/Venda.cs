using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciamento_OLX_App.Model
{
    public class Venda
    {
        [PrimaryKey, AutoIncrement]
        public int Idvenda { get; set; }
        public string Nomev { get; set; }
        public double PrecoComprav { get; set; }
        public double PrecoCusto { get; set; }        
        public double PrecoVenda { get; set; }
        public DateTime DataComprav { get; set; }
        public DateTime DataVendav { get; set; }
        public double LucroVenda { get; set; }
        public double Lucrov { get; set; }
    }
}
