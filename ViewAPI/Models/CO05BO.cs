using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewAPI.Models
{
    public class CO05BO
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
        /// 時段
        /// </summary>
        public System.String tsts { get; set; }
        /// <summary>
        /// 看診序號
        /// </summary>
        public System.String tartime { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public System.String bname { get; set; }


        public static System.Reflection.PropertyInfo[] _pi = typeof(CO05BO).GetProperties();
        public static CO05BO Parse(System.Data.IDataReader reader)
        {
            var usr = new CO05BO();
            foreach (var p in _pi)
            {
                p.SetValue(usr, reader.GetValue(reader.GetOrdinal(p.Name)));
            }
            return usr;
        }

        public static CO05BO Parse(System.Data.DataRow dr)
        {
            return new CO05BO();
        }
    }
}