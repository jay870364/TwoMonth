using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewAPI.Models
{
    /// <summary>
    /// CO01M.DBF
    /// </summary>
    public class User
    {
        public System.String kcstmr { get; set; }
        public System.String mname { get; set; }
        public System.String msts { get; set; }
        public System.String msex { get; set; }
        public System.String mbirthdt { get; set; }
        public System.String labeno { get; set; }
        public System.String mwork { get; set; }
        public System.String mtelh { get; set; }
        public System.String mfml { get; set; }
        public System.Decimal mweight { get; set; }
        public System.Decimal mheight { get; set; }
        public System.Decimal mhead { get; set; }
        public System.Decimal mchest { get; set; }
        public System.String mpersonid { get; set; }
        public System.Decimal mlcaseno { get; set; }
        public System.String mlcasedate { get; set; }
        public System.String mlcasedise { get; set; }
        public System.String mbegdt { get; set; }
        public System.Decimal myamt { get; set; }
        public System.Decimal mtamt { get; set; }
        public System.String mcndate { get; set; }
        public System.Decimal mnote { get; set; }
        public System.Decimal mrcost { get; set; }
        public System.Decimal mpayable { get; set; }
        public System.String mlabdt { get; set; }
        public System.String mrec { get; set; }
        public System.String mmedi { get; set; }
        public System.String mmsdt { get; set; }
        public System.String mbp { get; set; }
        public System.String mtem { get; set; }
        public System.String mtyp { get; set; }
        public System.String mrh { get; set; }
        public System.String mexte { get; set; }
        public System.String mid { get; set; }
        public System.String mids { get; set; }
        public System.String mpid { get; set; }
        public System.String misno { get; set; }
        public System.String mcpno { get; set; }
        public System.String medlevel { get; set; }
        public System.String mlmp { get; set; }
        public System.String misrs { get; set; }
        public System.String msqno { get; set; }
        public System.String mpnasc { get; set; }
        public System.String mexinx { get; set; }
        public System.String mnot { get; set; }
        public System.String mldno { get; set; }
        public System.String mtpcn { get; set; }
        public System.String mtpcn0 { get; set; }
        public System.String mtpcn1 { get; set; }
        public System.String mtpcn2 { get; set; }
        public System.String mtpcn3 { get; set; }
        public System.String mtpcn4 { get; set; }
        public System.String mtpcn5 { get; set; }
        public System.String menddt { get; set; }
        public System.String mtype { get; set; }
        public System.String mrm1 { get; set; }
        public System.String mrm2 { get; set; }
        public System.String mrm3 { get; set; }
        public System.String mrm4 { get; set; }
        public System.String mrm5 { get; set; }
        public System.String maddr { get; set; }
        public System.String mremark { get; set; }
        public System.String mpamt { get; set; }
        public System.String mcrp { get; set; }
        public System.String mdsc { get; set; }
        public System.String mgrp { get; set; }
        public System.String mrm6 { get; set; }
        public System.String mrm7 { get; set; }
        public System.String mwrtic { get; set; }
        public System.String mfilt { get; set; }
        public System.String mpcbs { get; set; }
        public System.String mclinickcs { get; set; }
        public System.String mclinicno { get; set; }
        public System.String me2lidt { get; set; }
        public System.String msop { get; set; }
        public System.String mscs { get; set; }
        public System.String mscsdt { get; set; }



        public static System.Reflection.PropertyInfo[] _pi = typeof(User).GetProperties();
        public static User Parse(System.Data.IDataReader reader)
        {
            var usr = new User();
            foreach (var p in _pi)
            {
                p.SetValue(usr, reader.GetValue(reader.GetOrdinal(p.Name)));
            }
            return usr;
        }

        public static User Parse(System.Data.DataRow dr)
        {
            return new User();
        }
    }
}