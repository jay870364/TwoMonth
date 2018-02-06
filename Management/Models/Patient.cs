using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bossinfo.Caller.CallerAPP.Models
{
    public class Patient
    {
        public System.String test1 { get; set; }
        public System.String test2 { get; set; }
        //public System.Data.DataSet dataSet { get; set; }

        

        public static System.Reflection.PropertyInfo[] _pi = typeof(Patient).GetProperties();

        public static Patient Parse(System.Data.IDataReader reader)
        {
            var usr = new Patient();
            foreach (var p in _pi)
            {
                p.SetValue(usr, reader.GetValue(reader.GetOrdinal(p.Name)));
            }
            return usr;
        }

        public static Patient Parse(System.Data.DataRow dr)
        {
            return new Patient();
        }
    }
    
}
