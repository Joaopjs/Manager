using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciamento_OLX_App.Banco.Financas
{
    public class FinancasDB
    {
        /// <summary>
        /// Responsavel pelo Capital de giro
        /// </summary>
        /// <param name="capitalInvestido"></param>
        public static void AddCapitalInvestido(Model.CapitalGiro capitalInvestido)
        {
            using (Database database = new Database())
            {
                try
                {
                    database._connection.InsertOrReplace(capitalInvestido);
                }
                catch (Exception)
                {


                }
            }
        }

        /// <summary>
        /// Responsavel pelo Capital de giro
        /// </summary>
        /// <param name="capitalInvestido"></param>
        public static Model.CapitalGiro GetAllCapitalInvestido()
        {
            using (Database database = new Database())
            {
                try
                {
                    return database._connection.Table<Model.CapitalGiro>().FirstOrDefault();
                }
                catch (Exception)
                {

                    return new Model.CapitalGiro() {  };
                }
            }
        }


        /// <summary>
        /// Responsavel pelo Lucro
        /// </summary>
        /// <param name="capitalInvestido"></param>
        public static void AddLucro(Model.Saldo saldo)
        {
            using (Database database = new Database())
            {
                try
                {
                    if (saldo.SaldoConta >= 0)
                    {
                        database._connection.InsertOrReplace(saldo);  
                    }                                     
                                        
                }
                catch (Exception)
                {
                }
            }
        }


        /// <summary>
        /// Responsavel pelo Saldo Lucro
        /// </summary>
        /// <param name="capitalInvestido"></param>
        public static Model.Saldo GetAllLucro()
        {
            using (Database database = new Database())
            {
                try
                {
                    var saldo = database._connection.Table<Model.Saldo>().FirstOrDefault();
                    if(saldo == null)
                    {
                        return new Model.Saldo() { SaldoConta = 0 };
                    }
                    else
                    {
                        return database._connection.Table<Model.Saldo>().FirstOrDefault();
                    }
                    
                }
                catch (Exception)
                {

                    return new Model.Saldo() { };
                }
            }
        }

        public static void AtualizaProduto(Model.Financas Financas)
        {
            using (Database database = new Database())
            {
                try
                {
                    database._connection.Update(Financas);

                }
                catch (Exception)
                {


                }
            }
        }

        public static void DeleteProduto(Model.Financas Financas)
        {
            using (Database database = new Database())
            {
                try
                {
                    database._connection.Delete(Financas);

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
                    database._connection.Table<Model.Financas>().Where(x => x.FinancaId == id);

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
                    database._connection.Table<Model.Financas>().Where(x => x.Lucro == 100);

                }
                catch (Exception)
                {


                }
            }
        }
    }
}
