using Gerenciamento_OLX_App.Banco;
using Gerenciamento_OLX_App.Banco.CapítalGiro;
using Gerenciamento_OLX_App.Model;
using Gerenciamento_OLX_App.View;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gerenciamento_OLX_App.ViewModel
{
    public class AddEstoqueViewModel : INotifyPropertyChanged 
    {
        public ICommand SalvarCommand { get; set; }
        public ICommand LimparCommand { get; set; }
        public ICommand EstadoCommand { get; set; }

        /// <summary>
        /// Propriedade 
        /// </summary>
        private string _nomeProduto;
        private string _valorCompra;
        private string _valorInvestido;
        private string _metaVenda;
        private string _observacao;
        private Produtos produtos;
        private EstoqueViewModel estoque;
        private bool _valorCompraVisible;
        private static string _estadoItem;

        public static string EstadoItem
        {
            get { return _estadoItem; }
            set { _estadoItem = value; }
        }

        public bool ValorCompraVisible
        {
            get { return _valorCompraVisible; }
            set { _valorCompraVisible = value; OnPropertyChanged("ValorCompraVisible"); }
        }

        public EstoqueViewModel Estoque
        {
            get { return estoque; }
            set { estoque = value; OnPropertyChanged("Estoque"); }
        }
        
        public Produtos ProdutosItem
        {
            get { return produtos; }
            set { produtos = value; OnPropertyChanged("ProdutosItem"); }
        }


        public string NomeProduto
        {
            get { return _nomeProduto; }
            set { _nomeProduto = value; OnPropertyChanged("NomeProduto"); }
        }

        public string ValorCompra
        {
            get { return _valorCompra; }
            set { _valorCompra = value; OnPropertyChanged("ValorCompra"); }
        }
       
        public string ValorInvestidos
        {
            get { return _valorInvestido; }
            set { _valorInvestido = value; OnPropertyChanged("ValorInvestidos"); }
        }


        public string MetaVenda
        {
            get { return _metaVenda; }
            set { _metaVenda = value; OnPropertyChanged("MetaVenda"); }
        }

        public string Observacao
        {
            get { return _observacao; }
            set { _observacao = value; OnPropertyChanged("Observacao"); }
        }

        public double valorinvest { get; set; }

        public AddEstoqueViewModel(Produtos produtos = null, EstoqueViewModel estoqueViewModel = null)
        {
            SalvarCommand = new Command(SalvarNoEstoque);
            LimparCommand = new Command(LimparCampos);
            EstadoCommand = new Command<string>(SetEstado);

            ValorCompraVisible = true;

            Estoque = estoqueViewModel;

            ProdutosItem = null;

            if (produtos != null)
            {
                ValorCompraVisible = false;


                NomeProduto = produtos.Name;
                ValorCompra = produtos.PrecoCompra.ToString();
                ValorInvestidos = produtos.ValorInvestido.ToString();
                MetaVenda = produtos.MetaVenda.ToString();
                Observacao = produtos.OBS;
                ProdutosItem = produtos;
                valorinvest = produtos.ValorInvestido; 
            }

        }

        private void SetEstado(string texto)
        {
            
        }

        private void LimparCampos()
        {
            NomeProduto = "";
            ValorCompra = "";
            ValorInvestidos = "";
            MetaVenda = "";
            Observacao = "";

        }

        private async void SalvarNoEstoque()
        {

            if (!string.IsNullOrEmpty(NomeProduto) &&                 
                !string.IsNullOrEmpty(ValorCompra) && 
                !string.IsNullOrEmpty(ValorInvestidos) && 
                !string.IsNullOrEmpty(MetaVenda) && 
                !string.IsNullOrEmpty(Observacao))
            {
                var capital = CapitalGirosDB.GetAllCapitalGiro().FirstOrDefault();

                if (ProdutosItem == null)
                {
                    var prod = new Produtos()
                    {
                        Name = NomeProduto,
                        DataCompra = DateTime.Now,
                        PrecoCompra = double.Parse(ValorCompra),
                        ValorInvestido = double.Parse(ValorInvestidos),
                        Estado = EstadoItem,
                        PrecoCusto = double.Parse(ValorCompra),
                        MetaVenda = double.Parse(MetaVenda),
                        LucroPrevisto = ((double.Parse(MetaVenda) * 100) / (double.Parse(ValorCompra) + double.Parse(ValorInvestidos))) - 100,
                        OBS = Observacao

                    };

                    if (capital.Capital >= (prod.PrecoCompra + prod.ValorInvestido))
                    {
                        capital.Capital = capital.Capital - (prod.PrecoCompra + prod.ValorInvestido);
                        CapitalGirosDB.AddProduto(capital);

                        ProdutoDB.AddProduto(prod);

                        await App.Current.MainPage.DisplayAlert("Aviso", "    Salvo Com Sucesso", "Ok");
                        (((MasterPage)App.Current.MainPage).Detail).Navigation.PopAsync();

                    
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Aviso", "    Saldo Insuficiente", "Ok");
                    }                 
                                                        
                    LimparCampos();
                }
                else
                {

                    var produ = new Produtos()
                    {
                        ProdutoId = ProdutosItem.ProdutoId,
                        Name = NomeProduto,
                        DataCompra = ProdutosItem.DataCompra,
                        PrecoCompra = double.Parse(ValorCompra),
                        Estado = EstadoItem,
                        ValorInvestido = double.Parse(ValorInvestidos),
                        PrecoCusto = double.Parse(ValorCompra),
                        MetaVenda = double.Parse(MetaVenda),
                        LucroPrevisto = ((double.Parse(MetaVenda) * 100) / (double.Parse(ValorCompra) + double.Parse(ValorInvestidos))) - 100,
                        OBS = Observacao

                    };                    

                    if (capital.Capital >= produ.ValorInvestido)
                    {
                        // TODO - Fazer uma correção na inserção do capital
                        if (produ.ValorInvestido == valorinvest)
                        {
                            
                        }
                        else if (produ.ValorInvestido > valorinvest)
                        {
                            capital.Capital = capital.Capital - (produ.ValorInvestido - valorinvest);
                        }
                        else if (produ.ValorInvestido < valorinvest)
                        {
                            capital.Capital = capital.Capital + (valorinvest - produ.ValorInvestido);
                        }
                        

                        CapitalGirosDB.AddProduto(capital);

                         

                        ProdutoDB.AtualizaProduto(produ);
                        await App.Current.MainPage.DisplayAlert("Aviso", "Atualizado Com Sucesso", "Ok");
                        await (((MasterPage)App.Current.MainPage).Detail).Navigation.PopAsync();

                        Estoque.Produtos = ProdutoDB.GetAllProdutos();

                        LimparCampos();
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Aviso", "Saldo Insuficiente", "Ok");

                    }

                    _ = (((MasterPage)App.Current.MainPage).Detail).Navigation.PopAsync();

                    Estoque.Produtos = ProdutoDB.GetAllProdutos();

                    LimparCampos();
                }

                
            }
            else
            {
                //var re = await App.Current.MainPage.DisplayAlert("Mensagem", "Todos os Campos Devem ser Preenchidos", "Ok", "Cancel");

                //if(re == true)
                //{
                //    await App.Current.MainPage.DisplayAlert("Mensagem", "Ok", "Ok", "cancel");
                //}
                //else
                //{
                //    await App.Current.MainPage.DisplayAlert("Mensagem", "Cancel", "Ok", "cancel");
                //}
            }                   

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string texto)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(texto));
        }
    }
}
