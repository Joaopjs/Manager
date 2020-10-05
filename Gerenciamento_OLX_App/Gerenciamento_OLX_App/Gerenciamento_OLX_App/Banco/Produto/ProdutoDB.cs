using Gerenciamento_OLX_App.Model;
using Gerenciamento_OLX_App.View;
using Gerenciamento_OLX_App.View.UtilView;
using Gerenciamento_OLX_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciamento_OLX_App.Banco
{
    public class ProdutoDB
    {

        public static void AddProduto(Produtos produtos)
        {
            using (Database database = new Database())
            {
                try
                {
                    database._connection.Insert(produtos);
                }
                catch (Exception)
                {

                    
                }
            }
        }

        public static List<Produtos> GetAllProdutos()
        {
                    
            using (Database database = new Database())
            {
                try
                {
                    return database._connection.Table<Produtos>().ToList();
                }
                catch (Exception)
                {

                    return new List<Produtos>() { new Produtos() { Name = "Erro" } };
                }
            }
        }

        public static void AtualizaProduto(Produtos produtos)
        {
            using (Database database = new Database())
            {
            
                try
                {
                    var res = database._connection.InsertOrReplace(produtos);

                }
                catch (Exception)
                {

                    
                }
            }
        }

        public static void DeleteProduto(Produtos produtos)
        {
            using (Database database = new Database())
            {
                try
                {
                    database._connection.Delete(produtos);

                }
                catch (Exception)
                {

                   
                }
            }
        }

        public static void GetProdutoId(int id)
        {
            using (Database database = new Database())
            {
                try
                {
                    //Retorna todos os dados da tabela
                    database._connection.Table<Produtos>().Where(x => x.ProdutoId == id);

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
                    database._connection.Table<Produtos>().Where(x => x.Name == palavra);

                }
                catch (Exception)
                {

                    
                }
            }
        }


    }
}
