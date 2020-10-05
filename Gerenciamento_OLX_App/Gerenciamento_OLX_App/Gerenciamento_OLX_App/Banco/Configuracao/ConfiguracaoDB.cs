using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gerenciamento_OLX_App.Banco.Configuracao
{
    public class ConfiguracaoDB 
    {
        public static void AddConfig(Model.ConfigApp config)
        {
            using (Database database = new Database())
            {
                try
                {
                    database._connection.InsertOrReplace(config);
                }
                catch (Exception)
                {


                }
            }
        }

        public static List<Model.ConfigApp> GetAllConfigApp()
        {

            using (Database database = new Database())
            {
                try
                {
                    return database._connection.Table<Model.ConfigApp>().ToList();
                }
                catch (Exception)
                {

                    return new List<Model.ConfigApp>() { new Model.ConfigApp() { } };
                }
            }
        }
    }
}
