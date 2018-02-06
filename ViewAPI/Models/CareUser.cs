using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewAPI.Models
{
    /// <summary>
    /// CO05C.DBF 檔
    /// </summary>
    public class CareUser
    {
        public System.String kcstmr { get; set; }
        public System.String tno { get; set; }
        public System.String tbkdate { get; set; }
        public System.String tbktime { get; set; }
        public System.String tartime { get; set; }
        public System.String tnote { get; set; }
        public System.String tendtime { get; set; }
        public System.String tbkdt { get; set; }
        public System.String ttel { get; set; }
        public System.String trec { get; set; }



        public static System.Reflection.PropertyInfo[] _pi = typeof(CareUser).GetProperties();
        public static CareUser Parse(System.Data.IDataReader reader)
        {
            var usr = new CareUser();
            foreach (var p in _pi)
            {
                p.SetValue(usr, reader.GetValue(reader.GetOrdinal(p.Name)));
            }
            return usr;
        }

        public static CareUser Parse(System.Data.DataRow dr)
        {
            return new CareUser();
        }
    }
}