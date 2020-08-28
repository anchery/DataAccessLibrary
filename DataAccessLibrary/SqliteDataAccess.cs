using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary
{
    public class SqliteDataAccess : IDisposable
    {
        private string _connectionString;

        public SqliteDataAccess(string connectionStirng)
        {
            _connectionString = connectionStirng;
        }

        public void Dispose()
        {
            //Nothing to dispose
        }

        public dynamic GetDataList<T, U>(string sql, U parameters)
        {
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    var result = connection.Query<dynamic>(sql, parameters);
                    return result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public int SaveData<T>(string sql, T parameters,out string ErrMsg)
        {
            int rows = 0;
            ErrMsg = "";
            try
            {
                using (IDbConnection connection = new SQLiteConnection(_connectionString))
                {
                    rows = connection.Execute(sql, parameters);
                }
            }
            catch (Exception e)
            {
                ErrMsg = e.Message;
                Console.WriteLine(e.Message);
                return 0;
            }
            return rows;
        }
    }
}
