using Gerenciamento_OLX_App.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciamento_OLX_App.Banco.CapítalGiro
{
    public class CapitalGirosDB
    {
        public static void AddProduto(CapitalGiro CapitalGiro)
        {
            using (Database database = new Database())
            {
                try
                {
                    database._connection.InsertOrReplace(CapitalGiro);
                }
                catch (Exception)
                {


                }
            }
        }

        public static List<CapitalGiro> GetAllCapitalGiro()
        {

            using (Database database = new Database())
            {
                try
                {
                    return database._connection.Table<CapitalGiro>().ToList();
                }
                catch (Exception)
                {

                    return new List<CapitalGiro>() { new CapitalGiro() {  } };
                }
            }
        }

        public static void AtualizaProduto(CapitalGiro CapitalGiro)
        {
            using (Database database = new Database())
            {
                try
                {
                    database._connection.Update(CapitalGiro);

                }
                catch (Exception)
                {


                }
            }
        }

        public static void DeleteProduto(CapitalGiro CapitalGiro)
        {
            using (Database database = new Database())
            {
                try
                {
                    database._connection.Delete(CapitalGiro);

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
                    database._connection.Table<CapitalGiro>().Where(x => x.CapitalId == id);

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
                    database._connection.Table<CapitalGiro>().Where(x => x.Capital == 100);

                }
                catch (Exception)
                {


                }
            }
        }
    }
}
