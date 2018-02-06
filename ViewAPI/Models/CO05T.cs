using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewAPI.Models
{
    /// <summary>
    /// 今日看診名單
    /// </summary>
    public class CO05T
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
        /// 診別
        /// </summary>
        public System.String tid { get; set; }
        /// <summary>
        /// 醫師別
        /// </summary>
        public System.String tids { get; set; }
        /// <summary>
        /// 狀態 TSTS-F代表看完，H代表取消，A代表候診
        /// </summary>
        public System.String tsts { get; set; }
        /// <summary>
        /// 看診序號
        /// </summary>
        public System.String tartime { get; set; }
        /// <summary>
        /// 時段
        /// </summary>
        public System.String tsec { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        public System.String tname { get; set; }
        

        public static System.Reflection.PropertyInfo[] _pi = typeof(CO05T).GetProperties();
        public static CO05T Parse(System.Data.IDataReader reader)
        {
            var usr = new CO05T();
            foreach (var p in _pi)
            {
                p.SetValue(usr, reader.GetValue(reader.GetOrdinal(p.Name)));
            }
            return usr;
        }

        public static CO05T Parse(System.Data.DataRow dr)
        {
            return new CO05T();
        }
    }
}