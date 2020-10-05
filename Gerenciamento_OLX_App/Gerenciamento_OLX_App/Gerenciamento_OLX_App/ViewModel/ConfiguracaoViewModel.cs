using Gerenciamento_OLX_App.Banco.Configuracao;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Gerenciamento_OLX_App.ViewModel
{
    public class ConfiguracaoViewModel : INotifyPropertyChanged
    {
        public Command ConfigurarCommmand { get; set; }
        public Command LimparCommmand { get; set; }

        public const string Const_PagIniciao = "https://sp.olx.com.br/regiao-de-sorocaba";
        public const string Const_PagChat = "https://sp.olx.com.br/regiao-de-sorocaba";
        public DateTime Const_DataFecha = new DateTime(2020,09,01);
        public const string Const_CotaInve = "10%";

        private string _paginaInicial;
        private string _paginaChat;
        private DateTime _dataFechamento;
        private string _cotaInvestimento;

        public string PaginaInicial
        {
            get { return _paginaInicial; }
            set { _paginaInicial = value; OnPropertyChanged("PaginaInicial"); }
        }

        public string PaginaChat
        {
            get { return _paginaChat; }
            set { _paginaChat = value; OnPropertyChanged("PaginaChat"); }
        }

        public DateTime DataFechamento
        {
            get { return _dataFechamento; }
            set { _dataFechamento = value; OnPropertyChanged("DataFechamento"); }
        }

        public string CotaInvestimento
        {
            get { return _cotaInvestimento; }
            set { _cotaInvestimento = value; OnPropertyChanged("CotaInvestimento"); }
        }

        public ConfiguracaoViewModel()
        {
            ConfigurarCommmand = new Command(ConfigurarMethod);
            LimparCommmand = new Command(LimparMethod);

        }

        private void LimparMethod(object obj)
        {
            PaginaInicial = "";
            PaginaChat = "";
            DataFechamento = Const_DataFecha;
            CotaInvestimento = "";

        }

        private void ConfigurarMethod(object obj)
        {
            if (!string.IsNullOrEmpty(PaginaInicial) && !string.IsNullOrEmpty(PaginaChat) && !DataFechamento.Equals(null) && !string.IsNullOrEmpty(CotaInvestimento))
            {                
                ConfiguracaoDB.AddConfig(new Model.ConfigApp() { 
                    PaginaInicial = PaginaInicial, 
                    PaginaChat = PaginaChat, 
                    DataFechamento = DataFechamento, 
                    CotaInvestimento = CotaInvestimento 
                });
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string texto)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(texto)); 
        }

    }
}
