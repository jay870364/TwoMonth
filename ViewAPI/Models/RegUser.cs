using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewAPI.Models
{
    /// <summary>
    /// CO05B.DBF (預掛名單)
    /// </summary>
    public class RegUser
    {
        /// <summary>
        /// 病歷號
        /// </summary>
        public System.String kcstmr { get; set; }
        /// <summary>
        /// 看診日期
        /// </summary>
        public System.String tbkdt { get; set; }

        /// <summary>
        /// 看診序號
        /// </summary>
        public System.String tartime { get; set; }

        /// <summary>
        /// 時段
        /// </summary>
        public System.String tsts { get; set; }

        /// <summary>
        /// 病患名稱
        /// </summary>
        public System.String bname { get; set; }


        /// <summary>
        /// 診別
        /// </summary>
        public System.String tid { get; set; }
        /// <summary>
        /// 醫師別
        /// </summary>
        public System.String tids { get; set; }

        //public System.String tbktime { get; set; }
        //public System.String tnote { get; set; }
        //public System.String tendtime { get; set; }
        //public System.String tbkdt { get; set; }
        //public System.String tbkdate { get; set; }
        //public System.String lm { get; set; }
        //public System.String tpids { get; set; }
        //public System.Decimal trcost { get; set; }
        //public System.String trm1 { get; set; }
        //public System.String trm2 { get; set; }
        //public System.String tduty { get; set; }
        //public System.String bname { get; set; }
        //public System.Decimal btimec { get; set; }
        //public System.String tidsrm { get; set; }


        public static System.Reflection.PropertyInfo[] _pi = typeof(RegUser).GetProperties();
        public static RegUser Parse(System.Data.IDataReader reader)
        {
            var usr = new RegUser();
            foreach (var p in _pi)
            {
                p.SetValue(usr, reader.GetValue(reader.GetOrdinal(p.Name)));
            }
            return usr;
        }

        public static RegUser Parse(System.Data.DataRow dr)
        {
            return new RegUser();
        }
    }
}