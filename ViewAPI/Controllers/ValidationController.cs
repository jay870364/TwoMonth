using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewAPI.Controllers
{
    public class ValidationController : BaseController
    {
        /// <summary>
        /// 取得病患資料
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public JsonResult ValidateUser(string ID)
        {
            return Json(Convert(new Models.DataService().GetUser(ID)), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 取得病患名單資料
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUsers()
        {
            return Json(Convert(new Models.DataService().ListUser()), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 取得關懷提醒名單資料
        /// </summary>
        /// <param name="TPKDate"></param>
        /// <returns></returns>
        public JsonResult GetCareUsers(string TPKDate)
        {
            return Json(Convert(new Models.DataService().ListCareUserByDate(TPKDate)), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 取得預掛名單資料
        /// </summary>
        /// <param name="TBKDT"></param>
        /// <returns></returns>
        public JsonResult GetRegUsers(string TBKDT) {
            return Json(Convert(new Models.DataService().ListRegUserByDate(TBKDT)), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 取的今日看診名單
        /// </summary>
        /// <param name="TBKDT"></param>
        /// <returns></returns>
        public JsonResult GetNowRegUsers(string TBKDT) {
            return Json(Convert(new Models.DataService().ListNowRegUserByDate(TBKDT)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetHistoryRegUsers(string TBKDT) {
            return Json(Convert(new Models.DataService().ListHistoryRegUserByDate(TBKDT)), JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Dels()
        //{
        //    new Models.DataService().DeleteData();
        //    return Content("<html><head><title>PACSAPI</title></head><body>Running..</body></html>");
        //}

        public static JsonDefinition.ViewAPI.UserData Convert(Models.User model)
        {
            if (model == null) return new JsonDefinition.ViewAPI.UserData();
            var nm = new JsonDefinition.ViewAPI.UserData();
            nm.HasData = true;
            nm.kcstmr = model.kcstmr;
            nm.mname = model.mname;
            nm.msts = model.msts;
            nm.msex = model.msex;
            nm.mbirthdt = model.mbirthdt;
            nm.labeno = model.labeno;
            nm.mwork = model.mwork;
            nm.mtelh = model.mtelh;
            nm.mfml = model.mfml;
            nm.mweight = model.mweight;
            nm.mheight = model.mheight;
            nm.mhead = model.mhead;
            nm.mchest = model.mchest;
            nm.mpersonid = model.mpersonid;
            nm.mlcaseno = model.mlcaseno;
            nm.mlcasedate = model.mlcasedate;
            nm.mlcasedise = model.mlcasedise;
            nm.mbegdt = model.mbegdt;
            nm.myamt = model.myamt;
            nm.mtamt = model.mtamt;
            nm.mcndate = model.mcndate;
            nm.mnote = model.mnote;
            nm.mrcost = model.mrcost;
            nm.mpayable = model.mpayable;
            nm.mlabdt = model.mlabdt;
            nm.mrec = model.mrec;
            nm.mmedi = model.mmedi;
            nm.mmsdt = model.mmsdt;
            nm.mbp = model.mbp;
            nm.mtem = model.mtem;
            nm.mtyp = model.mtyp;
            nm.mrh = model.mrh;
            nm.mexte = model.mexte;
            nm.mid = model.mid;
            nm.mids = model.mids;
            nm.mpid = model.mpid;
            nm.misno = model.misno;
            nm.mcpno = model.mcpno;
            nm.medlevel = model.medlevel;
            nm.mlmp = model.mlmp;
            nm.misrs = model.misrs;
            nm.msqno = model.msqno;
            nm.mpnasc = model.mpnasc;
            nm.mexinx = model.mexinx;
            nm.mnot = model.mnot;
            nm.mldno = model.mldno;
            nm.mtpcn = model.mtpcn;
            nm.mtpcn0 = model.mtpcn0;
            nm.mtpcn1 = model.mtpcn1;
            nm.mtpcn2 = model.mtpcn2;
            nm.mtpcn3 = model.mtpcn3;
            nm.mtpcn4 = model.mtpcn4;
            nm.mtpcn5 = model.mtpcn5;
            nm.menddt = model.menddt;
            nm.mtype = model.mtype;
            nm.mrm1 = model.mrm1;
            nm.mrm2 = model.mrm2;
            nm.mrm3 = model.mrm3;
            nm.mrm4 = model.mrm4;
            nm.mrm5 = model.mrm5;
            nm.maddr = model.maddr;
            nm.mremark = model.mremark;
            nm.mpamt = model.mpamt;
            nm.mcrp = model.mcrp;
            nm.mdsc = model.mdsc;
            nm.mgrp = model.mgrp;
            nm.mrm6 = model.mrm6;
            nm.mrm7 = model.mrm7;
            nm.mwrtic = model.mwrtic;
            nm.mfilt = model.mfilt;
            nm.mpcbs = model.mpcbs;
            nm.mclinickcs = model.mclinickcs;
            nm.mclinicno = model.mclinicno;
            nm.me2lidt = model.me2lidt;
            nm.msop = model.msop;
            nm.mscs = model.mscs;
            nm.mscsdt = model.mscsdt;
            return nm;
        }
        public static IEnumerable<JsonDefinition.ViewAPI.UserData> Convert(IEnumerable<Models.User> list)
        {
            List<JsonDefinition.ViewAPI.UserData> convertList = new List<JsonDefinition.ViewAPI.UserData>();
            if (list == null) return new List<JsonDefinition.ViewAPI.UserData>();
            return list.Select(x => new JsonDefinition.ViewAPI.UserData()
            {
                HasData = true,
                kcstmr = x.kcstmr,
                mname = x.mname,
                msts = x.msts,
                msex = x.msex,
                mbirthdt = x.mbirthdt,
                labeno = x.labeno,
                mwork = x.mwork,
                mtelh = x.mtelh,
                mfml = x.mfml,
                mweight = x.mweight,
                mheight = x.mheight,
                mhead = x.mhead,
                mchest = x.mchest,
                mpersonid = x.mpersonid,
                mlcaseno = x.mlcaseno,
                mlcasedate = x.mlcasedate,
                mlcasedise = x.mlcasedise,
                mbegdt = x.mbegdt,
                myamt = x.myamt,
                mtamt = x.mtamt,
                mcndate = x.mcndate,
                mnote = x.mnote,
                mrcost = x.mrcost,
                mpayable = x.mpayable,
                mlabdt = x.mlabdt,
                mrec = x.mrec,
                mmedi = x.mmedi,
                mmsdt = x.mmsdt,
                mbp = x.mbp,
                mtem = x.mtem,
                mtyp = x.mtyp,
                mrh = x.mrh,
                mexte = x.mexte,
                mid = x.mid,
                mids = x.mids,
                mpid = x.mpid,
                misno = x.misno,
                mcpno = x.mcpno,
                medlevel = x.medlevel,
                mlmp = x.mlmp,
                misrs = x.misrs,
                msqno = x.msqno,
                mpnasc = x.mpnasc,
                mexinx = x.mexinx,
                mnot = x.mnot,
                mldno = x.mldno,
                mtpcn = x.mtpcn,
                mtpcn0 = x.mtpcn0,
                mtpcn1 = x.mtpcn1,
                mtpcn2 = x.mtpcn2,
                mtpcn3 = x.mtpcn3,
                mtpcn4 = x.mtpcn4,
                mtpcn5 = x.mtpcn5,
                menddt = x.menddt,
                mtype = x.mtype,
                mrm1 = x.mrm1,
                mrm2 = x.mrm2,
                mrm3 = x.mrm3,
                mrm4 = x.mrm4,
                mrm5 = x.mrm5,
                maddr = x.maddr,
                mremark = x.mremark,
                mpamt = x.mpamt,
                mcrp = x.mcrp,
                mdsc = x.mdsc,
                mgrp = x.mgrp,
                mrm6 = x.mrm6,
                mrm7 = x.mrm7,
                mwrtic = x.mwrtic,
                mfilt = x.mfilt,
                mpcbs = x.mpcbs,
                mclinickcs = x.mclinickcs,
                mclinicno = x.mclinicno,
                me2lidt = x.me2lidt,
                msop = x.msop,
                mscs = x.mscs,
                mscsdt = x.mscsdt
            });
        }
        public static IEnumerable<JsonDefinition.ViewAPI.CareUserData> Convert(IEnumerable<Models.CareUser> list)
        {
            List<JsonDefinition.ViewAPI.CareUserData> convertList = new List<JsonDefinition.ViewAPI.CareUserData>();
            if (list == null) return new List<JsonDefinition.ViewAPI.CareUserData>();
            return list.Select(x => new JsonDefinition.ViewAPI.CareUserData()
            {
                HasData = (x != null),
                kcstmr = x.kcstmr,
                tbkdate = x.tbkdate,
                tbkdt = x.tbkdt,
                tno = x.tno,
                tnote = x.tnote,
                trec = x.trec,
                ttel = x.ttel
            });
        }
        public static IEnumerable<JsonDefinition.ViewAPI.RegUserData> Convert(IEnumerable<Models.RegUser> list)
        {
            List<JsonDefinition.ViewAPI.RegUserData> convertList = new List<JsonDefinition.ViewAPI.RegUserData>();
            if (list == null) return new List<JsonDefinition.ViewAPI.RegUserData>();
            return list.Select(x => new JsonDefinition.ViewAPI.RegUserData()
            {
                HasData = (x != null),
                kcstmr = x.kcstmr?.Trim(),
                tsec = x.tsts?.Trim(),
                tartime = x.tartime?.Trim(),
                tbkdt = x.tbkdt?.Trim(),
                name = x.bname?.Trim(),
                tid = x.tid?.Trim(),
                tids = x.tids?.Trim()
            });
        }
        public static IEnumerable<JsonDefinition.ViewAPI.RegUserData> Convert(IEnumerable<Models.CO05T> list)
        {
            List<JsonDefinition.ViewAPI.RegUserData> convertList = new List<JsonDefinition.ViewAPI.RegUserData>();
            if (list == null) return new List<JsonDefinition.ViewAPI.RegUserData>();
            return list.Select(x => new JsonDefinition.ViewAPI.RegUserData()
            {
                HasData = (x != null),
                kcstmr = x.kcstmr?.Trim(),
                tsts = x.tsts?.Trim(),
                tartime = x.tartime?.Replace("_","").Replace("補", "").Trim(),
                tbkdt = x.tbkdt?.Trim(),
                tid = x.tid?.Trim(),
                tids = x.tids?.Trim(),
                tsec = x.tsec?.Trim(),
                name = x.tname?.Trim()
            });
        }
        public static IEnumerable<JsonDefinition.ViewAPI.RegUserData> Convert(IEnumerable<Models.CO05BO> list)
        {
            List<JsonDefinition.ViewAPI.RegUserData> convertList = new List<JsonDefinition.ViewAPI.RegUserData>();
            if (list == null) return new List<JsonDefinition.ViewAPI.RegUserData>();
            return list.Select(x => new JsonDefinition.ViewAPI.RegUserData()
            {
                HasData = (x != null),
                kcstmr = x.kcstmr?.Trim(),
                tartime = x.tartime?.Trim(),
                tbkdt = x.tbkdt?.Trim(),
                tid = x.tid?.Trim(),
                tids = x.tids?.Trim(),
                tsec = x.tsts?.Trim(),
                name = x.bname?.Trim()
            });
        }
    }
}