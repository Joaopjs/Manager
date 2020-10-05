using Gerenciamento_OLX_App.Banco.Financas;
using Gerenciamento_OLX_App.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Xamarin.Forms;

namespace Gerenciamento_OLX_App.ViewModel
{
    public class CapitalGiroViewModel : INotifyPropertyChanged
    {
        public Command DepositarCommand { get; set; }
        public Command SacarCommand { get; set; }

        private string _valorGiro;
        private string _valorDeposito;
        private string _valorSaque;

        public string ValorSaque
        {
            get { return _valorSaque; }
            set { _valorSaque = value; OnPropertyChanged("ValorSaque"); }
        }

        public string ValorDeposito
        {
            get { return _valorDeposito; }
            set { _valorDeposito = value; OnPropertyChanged("ValorDeposito"); }
        }


        public string ValorGiro
        {
            get { return _valorGiro; }
            set { _valorGiro = value; OnPropertyChanged("ValorGiro"); }
        }

        public CapitalGiroViewModel()
        {
            DepositarCommand = new Command(Depositar);
            SacarCommand = new Command(Sacar);

            SaldoAtual();

            if (string.IsNullOrEmpty(ValorGiro))
            {
                ValorGiro = "0";
              
            }

            
        }

        private async void Sacar(object obj)
        {
            

            if (!string.IsNullOrEmpty(ValorGiro) && !string.IsNullOrEmpty(ValorSaque) )
            {
                var ValorFinal = Double.Parse(ValorGiro) - double.Parse(ValorSaque);
                
                if (ValorFinal >= 0 && !ValorSaque.Contains("-"))
                {

                    var res = await App.Current.MainPage.DisplayAlert("Aviso", "Deseja Realmente Sacar R$ " + ValorSaque, "OK", "Cancelar");

                    if (res == true)
                    {
                        FinancasDB.AddCapitalInvestido(new Model.CapitalGiro() { Capital = ValorFinal, CapitalInvestido = 0.0, DataCapital = DateTime.Now });

                        SaldoAtual();
                        ValorSaque = "";
                    }

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Aviso", "Saldo Insuficiente", "OK");

                }
            }

        }

        private async void Depositar(object obj)
        {
            if (!string.IsNullOrEmpty(ValorGiro) && !string.IsNullOrEmpty(ValorDeposito))
            {
                if (!ValorDeposito.Contains("-"))
                {
                    var ValorFinal = Double.Parse(ValorGiro) + double.Parse(ValorDeposito);

                    var resultado = await App.Current.MainPage.DisplayAlert("Aviso", "Deseja Realmente Depositar R$ "+ValorDeposito, "OK", "Cancelar");

                    if (resultado)
                    {                        
                        FinancasDB.AddCapitalInvestido(new Model.CapitalGiro() { Capital = ValorFinal, CapitalInvestido = 0.0, DataCapital = DateTime.Now });
                        SaldoAtual();
                        ValorDeposito = "";
                    }
             
                    
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Aviso", "Não é Aceito Numeros Negativos", "OK");
                }
                
            }
        }

        private void SaldoAtual()
        {
            try
            {
                ValorGiro = FinancasDB.GetAllCapitalInvestido().Capital.ToString();
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
