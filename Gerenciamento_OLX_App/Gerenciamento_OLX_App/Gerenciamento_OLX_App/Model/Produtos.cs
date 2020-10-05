using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciamento_OLX_App.Model
{
    
    public class Produtos
    {
        [PrimaryKey, AutoIncrement]      
        public int ProdutoId { get; set; }
        public string Name { get; set; }
        public DateTime DataCompra { get; set; }
        public double PrecoCompra { get; set; }
        public double ValorInvestido { get; set; }
        public double PrecoCusto { get; set; }
        public string Estado { get; set; }
        public double MetaVenda { get; set; }
        public double LucroPrevisto { get; set; }
        public string OBS { get; set; }

    }
}
