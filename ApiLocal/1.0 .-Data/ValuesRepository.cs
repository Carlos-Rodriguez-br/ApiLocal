using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLocal._1._0_._Data
{
    public class ValuesRepository
    {
        private MySqlConnection sql;
        private MySqlCommand cmd;
        
        public ValuesRepository(){}

        public void OpenStore(string nameStore,string stringConnection)
        {
            this.sql = new MySqlConnection(stringConnection);
            this.cmd = new MySqlCommand(nameStore, sql);
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.sql.Open();
        }

        public void AddParametherIn(string name, object value)
        {
            this.cmd.Parameters.AddWithValue(name, value);
        }

        public void AddParametherOut(string name, MySqlDbType type)
        {
            this.cmd.Parameters.Add(name, type).Direction = System.Data.ParameterDirection.Output;
        }

        public MySqlDataReader GetValuesStore()
        {
            return this.cmd.ExecuteReader();
        }

        public object GetParam(string name)
        {
            return this.cmd.Parameters[name].Value;
        }

        public void CloseStore()
        {
            this.sql.Close();
        }
    }
}
