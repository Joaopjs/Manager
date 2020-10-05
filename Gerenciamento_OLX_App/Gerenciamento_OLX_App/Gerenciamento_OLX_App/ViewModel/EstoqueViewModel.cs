using Gerenciamento_OLX_App.Banco;
using Gerenciamento_OLX_App.Banco.CapítalGiro;
using Gerenciamento_OLX_App.Banco.Vendas;
using Gerenciamento_OLX_App.Model;
using Gerenciamento_OLX_App.View;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Gerenciamento_OLX_App.ViewModel
{
    public class EstoqueViewModel : INotifyPropertyChanged
    {
        
        private bool _visible;
        private List<Produtos> _produtos;        
        private string _idProduto;
        private string _valorVendido;
        private Produtos _item;
        private string _pesquisar;
        private EstoquePage estoquePage;
        private StackLayout stackLayout;
        private string _valorLucros;

        public string ValorLucros
        {
            get { return _valorLucros; }
            set { _valorLucros = value; OnPropertyChanged("ValorLucros"); }
        }


        public StackLayout StackLayout
        {
            get { return stackLayout; }
            set { stackLayout = value; OnPropertyChanged("StackLayout"); }
        }


        public EstoquePage EstoquePage
        {
            get { return estoquePage; }
            set { estoquePage = value; OnPropertyChanged("EstoquePage"); }
        }

        public string Pesquisar
        {
            get { return _pesquisar; }
            set { _pesquisar = value; OnPropertyChanged("Pesquisar"); }
        }

        public Produtos Item
        {
            get { return _item; }
            set { _item = value; OnPropertyChanged("Item"); }
        }

        public string ValorVendido
        {
            get { return _valorVendido; }
            set { _valorVendido = value; OnPropertyChanged("ValorVendido"); }
        }

        private AddEstoqueViewModel _addEstoqueViewModel;

        public AddEstoqueViewModel AddEstoqueViewModel
        {
            get { return _addEstoqueViewModel; }
            set { _addEstoqueViewModel = value; OnPropertyChanged("AddEstoqueViewModel"); }
        }


        public string IdProduto
        {
            get { return _idProduto; }
            set { _idProduto = value; OnPropertyChanged("IdProduto"); }
        }

        public bool OptionsVisible
        {
            get { return _visible; }
            set 
            {    _visible = value; 
                 OnPropertyChanged("OptionsVisible");
            }
        }

        public List<Produtos> Produtos
        {
            get { return _produtos; }
            set { _produtos = value; OnPropertyChanged("Produtos"); }
        }

        public Command AdcionarCommand { get; set; }
        public Command GoChatCommand { get; set; }
        public Command OptionsCommand { get; set; }
        public Command EditarCommand { get; set; }
        public Command DeletarCommand { get; set; }
        public Command VendidoCommand { get; set; }
        public Command CancelarCommand { get; set; }
        public Command OkCommand { get; set; }
        public Command PesquisarCommand { get; set; }
        public Command DetalhesCommand { get; set; }
        public Command RefreshedCommand { get; set; }

        public Command TesteCommand { get; set; }


        public EstoqueViewModel(EstoquePage estoquePage)
        {
            EstoquePage = estoquePage;
            StackLayout = EstoquePage.FindByName("OptionVendido") as StackLayout;

            OptionsVisible = false;
            AdcionarCommand = new Command(AddEstoque);
            GoChatCommand = new Command(PageGoChat);
            EditarCommand = new Command(PageGoEdit);
            DeletarCommand = new Command(DeletarProduto);
            VendidoCommand = new Command(VendidoProduto);
            CancelarCommand = new Command(CancelarVenda);
            OkCommand = new Command(OkVenda);
            DetalhesCommand = new Command(DetalhesProduto);
            PesquisarCommand = new Command<string>(PesquisarItem);
            RefreshedCommand = new Command(RefreshedAction);

            Produtos = ProdutoDB.GetAllProdutos();

        }

        private void RefreshedAction(object obj)
        {
            ((MasterPage)App.Current.MainPage).Detail.Navigation.PushAsync(new DetalhesPage(Produtos.Where(x => x.ProdutoId == Convert.ToInt32(IdProduto)).FirstOrDefault(), this));
        }

        private void DetalhesProduto(object obj)
        {
            ((MasterPage)App.Current.MainPage).Detail.Navigation.PushAsync(new DetalhesPage(Produtos.Where(x => x.ProdutoId == Convert.ToInt32(IdProduto)).FirstOrDefault(), this));

        }

        private void PesquisarItem(string Texto)
        {
            Produtos = ProdutoDB.GetAllProdutos().Where(x => x.Name.ToLower().StartsWith(Texto.ToLower())).ToList();
            if (Produtos == null)
            {
                Produtos = ProdutoDB.GetAllProdutos();
                
            }
            
        }

        private void OkVenda(object obj)
        {

            Item.MetaVenda = double.Parse(ValorVendido);

            try
            {
                double precoCusto = Item.PrecoCompra + Item.ValorInvestido;
                double lucro = Item.MetaVenda - (Item.PrecoCompra + Item.ValorInvestido);
                double lucroPecent = (lucro * 100) / (Item.PrecoCompra + Item.ValorInvestido);

                Venda venda = new Venda()
                {
                    Nomev = Item.Name,
                    DataComprav = Item.DataCompra,
                    PrecoCusto = precoCusto,
                    DataVendav = DateTime.Now,
                    PrecoComprav = Item.PrecoCompra,
                    PrecoVenda = Item.MetaVenda,
                    LucroVenda = lucro,
                    Lucrov = lucroPecent
                };

                VedasDB.AddVenda(venda, Item);

                Produtos = ProdutoDB.GetAllProdutos();
            }
            catch (Exception)
            {
            }

            ValorVendido = "";
            StackLayout.IsVisible = false;
        }

        private void CancelarVenda(object obj)
        {
            StackLayout.IsVisible = false;
        }

        private void VendidoProduto()
        {
            
            StackLayout.IsVisible = true;

            Item = Produtos.Where(x => x.ProdutoId == Convert.ToInt32(IdProduto)).FirstOrDefault();

            ValorVendido = Item.MetaVenda.ToString();

                       
        }

        private async void DeletarProduto(object obj)
        {

            try
            {
                var resultado = await App.Current.MainPage.DisplayAlert("Aviso", "Tem Certeza Que Deseja Deletar Este Item", "Ok","Cancelar");
               
                if (resultado == true)
                {
                    var capital = CapitalGirosDB.GetAllCapitalGiro().FirstOrDefault();
                    var produt = Produtos.Where(x => x.ProdutoId == Convert.ToInt32(IdProduto)).FirstOrDefault();

                    capital.Capital = produt.PrecoCompra + produt.ValorInvestido;

                    CapitalGirosDB.AddProduto(capital);
                    VedasDB.DeleteVenda(produt);
                    Produtos = ProdutoDB.GetAllProdutos();
                }
            }
            catch (Exception)
            {               
            }
            
        }

        private void PageGoChat(object obj)
        {
            ((MasterPage)App.Current.MainPage).Detail.Navigation.PushAsync(new ChatPage());
        }
        
        private void PageGoEdit(object obj)
        {
          
            ((MasterPage)App.Current.MainPage).Detail.Navigation.PushAsync(new AddEstoquePage(Produtos.Where(x => x.ProdutoId == Convert.ToInt32(IdProduto)).FirstOrDefault(), this));
        }

        private void  AddEstoque(object obj)
        {
            (((MasterPage)App.Current.MainPage).Detail).Navigation.PushAsync(new AddEstoquePage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string texto)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(texto));
        }
    }
}
