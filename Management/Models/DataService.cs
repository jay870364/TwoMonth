using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Bossinfo.Caller.CallerAPP.Models
{
    
    public class DataService : IDisposable
    {
        private OleDbConnection _conn;


        public DataService()
        {
            if (!string.IsNullOrWhiteSpace(Configs.DBIP) && !string.IsNullOrWhiteSpace(Configs.DBADAccount))
            {
                Helper.WindowsAD.Authorization.LoginServer(Configs.DBADAccount, Configs.DBADPasswrod, Configs.DBIP);
            }
            _conn = new OleDbConnection(Configs.DBConnection);
            _conn.Open();
        }

        //public IEnumerable<Patient> ListPatient()
        //{
        //    string sql = @"select * from TestTable.DBF";

        //    var reader = GetReqder(sql);
        //    while (reader.Read())
        //    {
        //        yield return Patient.Parse(reader);
        //    }
        //}

        public System.Data.DataTable Test1(string inptut)
        {
            string sql = string.Format("select * from {0}", inptut);

            var dt = new System.Data.DataTable();
            using (var cmd = GetCommand(sql))
            {
                var da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public System.Data.DataTable ListPatient()
        {
            string sql = @"select * from TestTable.dbf";

            var dt = new System.Data.DataTable();
            using (var cmd = GetCommand(sql))
            {
                var da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public OleDbDataReader GetReqder(string sql, params OleDbParameter[] parameters)
        {
            var cmd = GetCommand(sql, parameters);

            return cmd.ExecuteReader();

        }


        public System.Data.DataTable GetDataTable(string sql, params OleDbParameter[] parameters)
        {
            var dt = new System.Data.DataTable();
            using (var cmd = GetCommand(sql, parameters))
            {
                var da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }


        public void Dispose()
        {
            _conn.Close();
            _conn.Dispose();
        }


        private OleDbCommand GetCommand(string sql, params OleDbParameter[] parameters)
        {
            var cmd = new OleDbCommand(sql, _conn);

            foreach (var p in parameters)
                cmd.Parameters.Add(p);
            return cmd;
        }
    }
}