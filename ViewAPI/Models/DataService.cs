using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
namespace ViewAPI.Models
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
        public IEnumerable<User> ListUser()
        {
            string sql = @"select * from CO01M.DBF";

            var reader = GetReqder(sql);
            while (reader.Read())
            {
                yield return User.Parse(reader);
            }
        }
        public User GetUser(string ID)
        {
            if (string.IsNullOrWhiteSpace(ID)) return null;
            string sql = @"select * from CO01M.DBF WHERE mpersonid = ? ";
            var p = new List<OleDbParameter>();
            p.Add(new OleDbParameter("?", ID));
            var reader = GetReqder(sql, p.ToArray());
            if (reader.Read())
                return User.Parse(reader);
            else return null;
        }

        public IEnumerable<CareUser> ListCareUserByDate(string date)
        {
            string sql = @"select * from CO05C.DBF WHERE tbkdate = ? ";
            var p = new List<OleDbParameter>();
            p.Add(new OleDbParameter("?", date));
            var reader = GetReqder(sql, p.ToArray());
            while (reader.Read())
            {
                yield return CareUser.Parse(reader);
            }
        }

        public IEnumerable<RegUser> ListRegUserByDate(string date)
        {
            string sql = @"select * from CO05B.DBF WHERE tbkdt = ? ";
            var p = new List<OleDbParameter>();
            p.Add(new OleDbParameter("?", date));
            var reader = GetReqder(sql, p.ToArray());
            while (reader.Read())
            {
                yield return RegUser.Parse(reader);
            }
        }

        public IEnumerable<CO05T> ListNowRegUserByDate(string date)
        {
            string sql = @"select * from CO05T.DBF WHERE tbkdt = ? and (tsts = 'A' or tsts = 'E' or tsts = '1' or tsts = '2' or tsts = '3' or tsts = '4' or tsts = '5' or tsts = '6' or tsts = '7' or tsts = '8' or tsts = '9')";
            var p = new List<OleDbParameter>();
            p.Add(new OleDbParameter("?", date));
            var reader = GetReqder(sql, p.ToArray());
            while (reader.Read())
            {
                yield return CO05T.Parse(reader);
            }
        }

        public IEnumerable<CO05BO> ListHistoryRegUserByDate(string date)
        {
            string sql = @"select * from CO05BO.DBF WHERE tbkdt = ? ";
            var p = new List<OleDbParameter>();
            p.Add(new OleDbParameter("?", date));
            var reader = GetReqder(sql, p.ToArray());
            while (reader.Read())
            {
                yield return CO05BO.Parse(reader);
            }
        }

        public void DeleteData() {
            string sql = @"delete from CO01M.DBF ";
            ExecuteNonQuery(sql);
        }

        public CareUser GetCareUser(string ID) {
            if (string.IsNullOrWhiteSpace(ID)) return null;
            string sql = @"select * from CO05C.DBF WHERE kcstmr = ? ";
            var p = new List<OleDbParameter>();
            p.Add(new OleDbParameter("?", ID));
            var reader = GetReqder(sql, p.ToArray());
            if (reader.Read())
                return CareUser.Parse(reader);
            else return null;
        }

        private OleDbCommand GetCommand(string sql, params OleDbParameter[] parameters)
        {
            var cmd = new OleDbCommand(sql, _conn);

            foreach (var p in parameters)
                cmd.Parameters.Add(p);
            return cmd;
        }
        public OleDbDataReader GetReqder(string sql, params OleDbParameter[] parameters)
        {
            var cmd = GetCommand(sql, parameters);

            return cmd.ExecuteReader();

        }

        public void ExecuteNonQuery(string sql) {
            using (var cmd = new OleDbCommand(sql, _conn)) {
                cmd.ExecuteNonQuery();
            }
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
    }
}