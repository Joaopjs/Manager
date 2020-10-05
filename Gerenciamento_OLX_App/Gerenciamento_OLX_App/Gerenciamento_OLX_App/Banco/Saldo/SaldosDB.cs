using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciamento_OLX_App.Banco.Saldo
{
    public class SaldosDB
    {
        public static void AddProduto(Model.Saldo Saldo)
        {
            using (Database database = new Database())
            {
                try
                {
                    database._connection.Insert(Saldo);
                }
                catch (Exception)
                {


                }
            }
        }

        public static List<Model.Saldo> GetAllSaldo()
        {

            using (Database database = new Database())
            {
                try
                {
                    return database._connection.Table<Model.Saldo>().ToList();
                }
                catch (Exception)
                {

                    return new List<Model.Saldo>() { new Model.Saldo() { } };
                }
            }
        }

        public static void AtualizaProduto(Model.Saldo Saldo)
        {
            using (Database database = new Database())
            {
                try
                {
                    database._connection.Update(Saldo);

                }
                catch (Exception)
                {


                }
            }
        }

        public static void DeleteProduto(Model.Saldo Saldo)
        {
            using (Database database = new Database())
            {
                try
                {
                    database._connection.Delete(Saldo);

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
                    database._connection.Table<Model.Saldo>().Where(x => x.SaldoId == id);

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
                    database._connection.Table<Model.Saldo>().Where(x => x.SaldoConta == 100);

                }
                catch (Exception)
                {


                }
            }
        }
    }
}
