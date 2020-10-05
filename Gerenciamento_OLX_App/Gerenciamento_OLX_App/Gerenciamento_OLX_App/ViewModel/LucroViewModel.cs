using Gerenciamento_OLX_App.Banco.Financas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Gerenciamento_OLX_App.ViewModel
{
    public class LucroViewModel : INotifyPropertyChanged
    {
        public Command SaqueLucroCommand { get; set; }

        private string _lucroDisponivel;
        private string _valorLucro;

        public string ValorLucro
        {
            get { return _valorLucro; }
            set { _valorLucro = value; OnPropertyChanged("ValorLucro"); }
        }

        public string LucroDisponivel
        {
            get { return _lucroDisponivel; }
            set { _lucroDisponivel = value; OnPropertyChanged("LucroDisponivel"); }
        }

        public LucroViewModel()
        {
            SaqueLucroCommand = new Command(SacarLucro);

            SaldoAtual();

            if (string.IsNullOrEmpty(LucroDisponivel))
            {
                LucroDisponivel = "0";
            }
            
        }

        private async void SacarLucro(object obj)
        {

            if (!string.IsNullOrEmpty(ValorLucro))
            {
                var ValorFinal = Double.Parse(LucroDisponivel) - double.Parse(ValorLucro);

                if (ValorFinal >= 0 && !ValorLucro.Contains("-"))
                {

                    var res = await App.Current.MainPage.DisplayAlert("Aviso", "Deseja Realmente Sacar R$ " + ValorLucro, "OK", "Cancelar");

                    if (res == true)
                    {
                        FinancasDB.AddLucro(new Model.Saldo() { SaldoConta = ValorFinal });

                        SaldoAtual();
                        ValorLucro = "";
                    }

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Aviso", "Saldo Insuficiente", "OK");

                }
            }

        }

        private void SaldoAtual()
        {
            try
            {
                LucroDisponivel = FinancasDB.GetAllLucro().SaldoConta.ToString();
            }
            catch (Exception)
            {

               
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string texto)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(texto));
        }

    }
}
