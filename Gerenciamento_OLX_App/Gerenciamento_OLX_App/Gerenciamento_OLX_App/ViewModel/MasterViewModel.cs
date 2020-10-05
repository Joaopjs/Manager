using Gerenciamento_OLX_App.View;
using Gerenciamento_OLX_App.View.UtilView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Gerenciamento_OLX_App.ViewModel
{
    public class MasterViewModel : INotifyPropertyChanged
    {

        private ListaItens _selectedItem;

        public ListaItens SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != null)
                {
                    _selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                    
                    GoPage(value);
                }
                   
                
            }
        }

        private List<ListaItens> _selectedCommand;

        public List<ListaItens> SelectedCommand
        {   
            get { return _selectedCommand; }
            set 
            {
                if (_selectedCommand != value)
                {
                    _selectedCommand = value;
                    OnPropertyChanged("SelectedCommand");
                }
            }
        }

        public MasterViewModel()
        {
            //Commands


            //Itens do NavegationaPage
            ListaOptions();
        }

        private void GoPage(ListaItens value)
        {
            if (value.Pagina == "Home")
            {
                ((MasterPage)App.Current.MainPage).Detail = new NavigationPage(new HomePage());
                ((MasterPage)App.Current.MainPage).IsPresented = false;
                ListaOptions();

            }
            else if(value.Pagina == "Estoque")
            {
                ((MasterPage)App.Current.MainPage).Detail = new NavigationPage(new EstoquePage());
                ((MasterPage)App.Current.MainPage).IsPresented = false;
                ListaOptions();
            }

            else if(value.Pagina == "Finanças")
            {
                ((MasterPage)App.Current.MainPage).Detail = new NavigationPage(new FinancasPage());
                ((MasterPage)App.Current.MainPage).IsPresented = false;
                ListaOptions();
            }

            else if(value.Pagina == "Vendas no Mês")
            {
                ((MasterPage)App.Current.MainPage).Detail = new NavigationPage(new VendasPage());
                ((MasterPage)App.Current.MainPage).IsPresented = false;
                ListaOptions();
            }

             else if(value.Pagina == "Configuração")
            {
                ((MasterPage)App.Current.MainPage).Detail = new NavigationPage(new ConfiguracaoPage());
                ((MasterPage)App.Current.MainPage).IsPresented = false;
                ListaOptions();
            }



        }

        public void ListaOptions()
        {
            SelectedCommand = new List<ListaItens>()
            {
                new ListaItens(){Pagina = "Home" },
                new ListaItens(){Pagina = "Estoque" },
                new ListaItens(){Pagina = "Finanças" },
                new ListaItens(){Pagina = "Vendas no Mês" },
                new ListaItens(){Pagina = "Configuração" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string texto)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(texto));
        }
    }
}
