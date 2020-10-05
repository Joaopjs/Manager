using Gerenciamento_OLX_App.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Gerenciamento_OLX_App.Banco
{
    public class Database : IDisposable
    {
        public SQLiteConnection _connection;

        public Database()
        {
            var dependency = DependencyService.Get<IDatabase>();
            string path = dependency.GetPathDB("database.sqlite");

            _connection = new SQLiteConnection(path);

            _connection.CreateTable<Produtos>();
            _connection.CreateTable<Venda>();
            _connection.CreateTable<Model.Financas>();
            _connection.CreateTable<Model.Saldo>();
            _connection.CreateTable<CapitalGiro>();
            _connection.CreateTable<ConfigApp>();


        }

        public void Dispose()
        {
            _connection.Dispose();
            GC.SuppressFinalize(this);
            
        }
    }
}
