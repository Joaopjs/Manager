using Gerenciamento_OLX_App.Banco;
using Gerenciamento_OLX_App.Banco.Configuracao;
using Gerenciamento_OLX_App.Banco.Vendas;
using Gerenciamento_OLX_App.Model;
using Gerenciamento_OLX_App.View;
using Gerenciamento_OLX_App.View.UtilView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Gerenciamento_OLX_App.ViewModel
{
    public class VendasViewModel : INotifyPropertyChanged
    {
        public Command GoChatCommand { get; set; }
        public Command GoEstoqueCommand { get; set; }

        private List<Venda> _Vendas;
        private string _cCapital;
        private string _vLucro;
        private string _vMargem;

        public string V_Margem
        {
            get { return _vMargem; }
            set { _vMargem = value; OnPropertyChanged("V_Margem"); }
        }


        public string V_Lucro
        {
            get { return _vLucro; }
            set { _vLucro = value; OnPropertyChanged("V_Lucro"); }
        }


        public string V_Investido
        {
            get { return _cCapital; }
            set { _cCapital = value; OnPropertyChanged("V_Investido"); }
        }


        public List<Venda> Vendas
        {
            get { return _Vendas; }
            set { _Vendas = value; OnPropertyChanged("Vendas"); }
        }

        public VendasViewModel()
        {
            List<Venda> Lista = new List<Venda>();
            string Configu = "";

            GoChatCommand = new Command(GoChat);
            GoEstoqueCommand = new Command(GoEstoque);
            var mes = DateTime.Now.Month;
           

            try
            {
                Configu = ConfiguracaoDB.GetAllConfigApp().FirstOrDefault().PaginaInicial;
            }
            catch (Exception)
            {

                
            }
           

            if (string.IsNullOrEmpty(Configu))
            {
                try
                {
                    Lista = VedasDB.GetAllVenda().Where(x => x.DataVendav.Month == mes).ToList();

                }
                catch (Exception)
                {

                    Lista = new List<Venda>() { };
                }
            }
            else
            {
                var confg = ConfiguracaoDB.GetAllConfigApp().LastOrDefault();
              
                try
                {
                    var fechamento = new DateTime(DateTime.Now.Year, DateTime.Now.Month, confg.DataFechamento.Day);
                    var abreMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month -1, confg.DataFechamento.Day);

                    Lista = VedasDB.GetAllVenda().Where(x => x.DataVendav >= abreMes && x.DataVendav <= fechamento).ToList();
                }
                catch (Exception)
                {
                    if (confg.DataFechamento.Day >= 29 && confg.DataFechamento.Day >= 31)
                    {
                        var fechamento = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        var abreMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);

                        Lista = VedasDB.GetAllVenda().Where(x => x.DataVendav >= abreMes && x.DataVendav <= fechamento).ToList();
                    }
                   

                }             
             
            }

            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

            V_Investido = Lista.Select(x => x.PrecoCusto).Sum().ToString();
            V_Lucro = Lista.Select(x => x.LucroVenda).Sum().ToString();
            V_Margem = ((((double.Parse(V_Lucro) * 100) / double.Parse(V_Investido))) - 100).ToString("F", nfi);

            Vendas = Lista;            
            
        }


        private void GoEstoque(object obj)
        {
            ((MasterPage)App.Current.MainPage).Detail = new NavigationPage(new EstoquePage());
        }

        private void GoChat(object obj)
        {
            ((MasterPage)App.Current.MainPage).Detail.Navigation.PushAsync(new ChatPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string texto)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(texto));
        }
    }
}
