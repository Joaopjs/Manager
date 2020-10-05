using Gerenciamento_OLX_App.Banco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Gerenciamento_OLX_App.ViewModel
{
    public class InvestidoViewModel : INotifyPropertyChanged
    {       
        private string investido;

        public string Investido
        {
            get { return investido; }
            set { investido = value; OnPropertyChanged("Investido"); }
        }

        public InvestidoViewModel()
        {
            //var valorInvestido = (from x in ProdutoDB.GetAllProdutos() select x.PrecoCompra + x.ValorInvestido).Sum();
           // var valorInvestido = ProdutoDB.GetAllProdutos().Select(x => x.PrecoCompra + x.ValorInvestido).Sum();

            SaldoAtual();
        
           
        }

        private void SaldoAtual()
        {
            try
            {
                var valorInvestido = ProdutoDB.GetAllProdutos().Select(x => x.PrecoCompra + x.ValorInvestido).Sum();
                Investido = valorInvestido.ToString();
            }
            catch (Exception)
            {

                
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string texto)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(texto));
        }

    }
}
