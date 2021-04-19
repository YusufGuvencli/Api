using System;
using System.Data;
using System.Data.OleDb;
using Microsoft.Extensions.Configuration;

namespace Data.DapperRepository
{
    public abstract class ConnectionFactory
    {
        protected IDbConnection Connection()
        {
            
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            string connStr = configuration.GetConnectionString("OleDbConnection");

            IDbConnection connection = new OleDbConnection(connStr);
            connection.Open();

            return connection;
        }
        public void Dispose()
        {
            Connection().Dispose();
        }
        public void Close()
        {
            Connection().Close();
        }
    }
}