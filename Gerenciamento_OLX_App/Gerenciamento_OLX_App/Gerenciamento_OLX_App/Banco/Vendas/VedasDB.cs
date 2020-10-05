using Gerenciamento_OLX_App.Banco.Financas;
using Gerenciamento_OLX_App.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciamento_OLX_App.Banco.Vendas
{
    public class VedasDB
    {
        public static void AddVenda(Venda venda, Produtos Item)
        {
            using (Database database = new Database())
            {
                try
                {                    
                    //Insere o objeto na tabela Venda
                    database._connection.Insert(venda);

                    //Retorna uma objeto com dados a respeito de saldo lucro
                    var allLucro = FinancasDB.GetAllLucro();         

                    //Pega o valor de capital de giro na tabela
                    var allCapitalGiro = database._connection.Table<Model.CapitalGiro>().FirstOrDefault(); ;
                    allCapitalGiro.Capital = allCapitalGiro.Capital + (Item.PrecoCompra + Item.ValorInvestido);

                    //Insere o objeto na tabela 
                    database._connection.InsertOrReplace(new Model.Saldo() { SaldoConta = (Item.MetaVenda - (Item.PrecoCompra + Item.ValorInvestido)) + allLucro.SaldoConta });
                      
                    //Insere o capital de giro
                    database._connection.InsertOrReplace(allCapitalGiro);

                    //Deleta o item do estoque
                    database._connection.Delete(Item);

                }
                catch (Exception)
                {


                }
            }
        }

        public static List<Venda> GetAllVenda()
        {
            using (Database database = new Database())
            {
                try
                {                    
                    return database._connection.Table<Venda>().ToList();
                    
                }
                catch (Exception)
                {

                    return new List<Venda>() { new Venda() {  } };
                }
            }
        }

        public static void AtualizaVenda(Venda Venda)
        {
            using (Database database = new Database())
            {
                try
                {
                    database._connection.Update(Venda);

                }
                catch (Exception)
                {


                }
            }
        }

        public static void DeleteVenda(Produtos Item)
        {
            using (Database database = new Database())
            {
                try
                {
                    database._connection.Delete(Item);

                }
                catch (Exception)
                {


                }
            }
        }

        public static void GetVendaId(int id)
        {
            using (Database database = new Database())
            {
                try
                {
                    //Retorna todos os dados da tabela
                    database._connection.Table<Venda>().Where(x => x.Idvenda == id);

                }
                catch (Exception)
                {


                }
            }
        }

        public static void Pesquisar(string palavra)
        {
            using (Database database = new Database())
            {
                try
                {
                    //Retorna todos os dados da tabela
                    database._connection.Table<Venda>().Where(x => x.Nomev == palavra);

                }
                catch (Exception)
                {


                }
            }
        }
    }
}
