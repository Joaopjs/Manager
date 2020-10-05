using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciamento_OLX_App.Model
{
    public class CapitalGiro
    {
        [PrimaryKey, AutoIncrement]
        public int CapitalId { get; set; }
        public double Capital { get; set; }
        public double CapitalInvestido { get; set; }
        public DateTime DataCapital { get; set; }

    }
}
