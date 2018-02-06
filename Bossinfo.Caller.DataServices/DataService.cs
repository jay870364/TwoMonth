using Bossinfo.Caller.Enums.Caller;
using Bossinfo.Caller.Enums.Utility;
using Bossinfo.Caller.Logger;
using Bossinfo.Caller.Models.Results;
using Bossinfo.Caller.Models.Utilitys;
using Bossinfo.Caller.Models.Waiting;
using Bossinfo.Caller.Utilitys;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

namespace Bossinfo.Caller.DataServices
{
    public class DataService
    {
        private string Url { get; set; }

        private OperatingSystemType OperatingSystemType;

        public static Log log = new Log();

        private string GetDir()
        {
            string dir;
            switch (OperatingSystemType)
            {
                case OperatingSystemType.智慧分流暨叫號系統:
                    dir = "Caller";
                    break;
                case OperatingSystemType.候診系統:
                    dir = "Clinic";
                    break;
                default:
                    dir = string.Empty;
                    break;
            }

            return dir;
        }

        public DataService(OperatingSystemType OperatingSystemType)
        {
            this.OperatingSystemType = OperatingSystemType;

            string dir = GetDir();

            if (string.IsNullOrWhiteSpace(dir))
            {
                this.Url = $"{Config.GetApiLocation()}/api";
            }
            else
            {
                this.Url = $"{Config.GetApiLocation()}/api/{dir}";
            }
        }
        public DataService(OperatingSystemType OperatingSystemType, string url)
        {
            this.OperatingSystemType = OperatingSystemType;

            string dir = GetDir();

            if (string.IsNullOrWhiteSpace(dir))
            {
                this.Url = $"{url}/api";
            }
            else
            {
                this.Url = $"{url}/api/{dir}";
            }

        }

        private string GetData(string rumUrl, NameValueCollection nc)
        {
            string result = string.Empty;

            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                byte[] bResult = wc.UploadValues(rumUrl, nc);

                result = Encoding.UTF8.GetString(bResult);

            }

            log.Trace(result);

            return result;
        }

        /// <summary>
        /// 判斷是否連線正常
        /// </summary>
        /// <returns></returns>
        public bool IsConnection(out ConnectionJsonResult result)
        {
            result = new ConnectionJsonResult();

            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/Caller_checkServer_Alive";

                var resultJsonString = GetData(rumUrl, nc);

                result = JsonConvert.DeserializeObject<ConnectionJsonResult>(resultJsonString);

                // log.Error("這是Data："+resultJsonString);

            }
            catch (Exception ex)
            {
                result = new ConnectionJsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };

                log.Error("判斷是否連線正常：" + result.Message);

            }

            return result.IsEffective;
        }

        /// <summary>
        ///  登入
        /// </summary>
        /// <param name="account">帳號</param>
        /// <param name="password">密碼</param>
        /// <param name="stationID">服務台ID</param>
        /// <param name="counterID">櫃台ID</param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool Login(string account, string password, string stationID, SystemModeType type, string id, out LoginJsonResult result)
        {
            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/Caller_Login";

                nc["account"] = account;
                nc["password"] = password;
                nc["stationID"] = stationID;
                string mode = ToolLib.GetEnumDescription(type);
                nc["type"] = mode;
                nc["id"] = id;

                var resultJsonString = GetData(rumUrl, nc);

                //log.Info($"登入：{rumUrl}，參數：", nc);

                result = JsonConvert.DeserializeObject<LoginJsonResult>(resultJsonString);

            }
            catch (Exception ex)
            {
                result = new LoginJsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };

                log.Error("登入：" + result.Message);

            }

            return result.IsEffective;
        }

        /// <summary>
        /// 服務台資訊
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public StationJsonResult GetStations(User user)
        {
            var result = new StationJsonResult();

            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/Caller_GetStationData";

                nc["token"] = user.Token;
                nc["stationID"] = user.IsAdmin ? string.Empty : user.StationID;

                var resultJsonString = GetData(rumUrl, nc);

                result = JsonConvert.DeserializeObject<StationJsonResult>(resultJsonString);

            }
            catch (Exception ex)
            {
                result = new StationJsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };
            }

            return result;
        }

        /// <summary>
        /// 開啟/關閉/暫停服務櫃檯
        /// </summary>
        /// <param name="user"></param>
        /// <param name="counterStatusType">執行動作</param>
        /// <returns></returns>
        public JsonResult UpdateCounterUseStatus(User user, CounterUseStatusType counterStatusType)
        {
            var result = new JsonResult();

            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/Caller_UpdateStatus";

                nc["token"] = user.Token;
                nc["stationID"] = user.StationID;
                nc["counterID"] = user.CounterID;
                nc["action"] = counterStatusType.ToString();

                var resultJsonString = GetData(rumUrl, nc);

                result = JsonConvert.DeserializeObject<JsonResult>(resultJsonString);

            }
            catch (Exception ex)
            {
                result = new JsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };
            }

            return result;
        }

        /// <summary>
        /// 取下一號
        /// </summary>
        /// <param name="user"></param>
        /// <param name="serviceID"></param>
        /// <returns></returns>
        public SeqNoInfoJsonResult GetNextSeqNo(User user, string serviceID)
        {
            var result = new SeqNoInfoJsonResult();

            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/Caller_GetNextSeqno";

                nc["token"] = user.Token;
                nc["stationID"] = user.StationID;
                nc["counterID"] = user.CounterID;
                nc["serviceID"] = serviceID;

                var resultJsonString = GetData(rumUrl, nc);

                result = JsonConvert.DeserializeObject<SeqNoInfoJsonResult>(resultJsonString);

            }
            catch (Exception ex)
            {
                result = new SeqNoInfoJsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };
            }

            return result;
        }

        /// <summary>
        /// 重叫號
        /// </summary>
        /// <param name="token">認證碼</param>
        /// <param name="stationID">服務台ID</param>
        /// <param name="counterID">櫃台ID</param>
        /// <param name="serviceID">業務別ID</param>
        /// <param name="seqno">取號號碼</param>
        /// <returns></returns>
        public SeqNoInfoJsonResult GetReCallSeqNo(User user, string serviceID, int seqno)
        {
            var result = new SeqNoInfoJsonResult();

            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/Caller_RecallSeqno";

                nc["token"] = user.Token;
                nc["stationID"] = user.StationID;
                nc["counterID"] = user.CounterID;
                nc["serviceID"] = serviceID;
                nc["seqno"] = seqno.ToString();

                var resultJsonString = GetData(rumUrl, nc);

                result = JsonConvert.DeserializeObject<SeqNoInfoJsonResult>(resultJsonString);

            }
            catch (Exception ex)
            {
                result = new SeqNoInfoJsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };
            }

            return result;
        }


        /// <summary>
        /// 保留: 更新資料庫CALLER的保留號碼
        /// </summary>
        /// <param name="token">認證碼</param>
        /// <param name="stationID">服務台ID</param>
        /// <param name="counterID">櫃台ID</param>
        /// <param name="serviceID">業務別ID</param>
        /// <param name="seqno">取號號碼</param>
        /// <returns></returns>
        public SeqNoInfoJsonResult UpdateDBReservedSeqNo(User user, string serviceID, int seqno)
        {
            var result = new SeqNoInfoJsonResult();

            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/Caller_UpdateDBReservedSeqno";

                nc["token"] = user.Token;
                nc["stationID"] = user.StationID;
                nc["counterID"] = user.CounterID;
                nc["serviceID"] = serviceID;
                nc["seqno"] = seqno.ToString();

                var resultJsonString = GetData(rumUrl, nc);

                result = JsonConvert.DeserializeObject<SeqNoInfoJsonResult>(resultJsonString);

            }
            catch (Exception ex)
            {
                result = new SeqNoInfoJsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };
            }

            return result;
        }

        /// <summary>
        /// 保留叫號: 呼叫保留號碼
        /// </summary>
        /// <param name="token">認證碼</param>
        /// <param name="stationID">服務台ID</param>
        /// <param name="counterID">櫃台ID</param>
        /// <param name="serviceID">業務別ID</param>
        /// <param name="seqno">取號號碼</param>
        /// <returns></returns>
        public SeqNoInfoJsonResult UpdateReservedSeqNo(User user, string serviceID, int seqno)
        {
            var result = new SeqNoInfoJsonResult();

            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/Caller_UpdateReservedSeqno";

                nc["token"] = user.Token;
                nc["stationID"] = user.StationID;
                nc["counterID"] = user.CounterID;
                nc["serviceID"] = serviceID;
                nc["seqno"] = seqno.ToString();

                var resultJsonString = GetData(rumUrl, nc);

                result = JsonConvert.DeserializeObject<SeqNoInfoJsonResult>(resultJsonString);

            }
            catch (Exception ex)
            {
                result = new SeqNoInfoJsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };
            }

            return result;
        }


        /// <summary>
        /// 呼叫指定號碼
        /// </summary>
        /// <param name="token">認證碼</param>
        /// <param name="stationID">服務台ID</param>
        /// <param name="counterID">櫃台ID</param>
        /// <param name="serviceID">業務別ID</param>
        /// <param name="seqno">取號號碼</param>
        /// <param name="getSeqNoModeType">取號模式</param>
        /// <returns></returns>
        public SeqNoInfoJsonResult UpdateAssignSeqNo(User user, string serviceID, int seqno)
        {
            var result = new SeqNoInfoJsonResult();

            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/Caller_UpdateAssignSeqno";

                nc["token"] = user.Token;
                nc["stationID"] = user.StationID;
                nc["counterID"] = user.CounterID;
                nc["serviceID"] = serviceID;
                nc["seqno"] = seqno.ToString();

                var resultJsonString = GetData(rumUrl, nc);

                result = JsonConvert.DeserializeObject<SeqNoInfoJsonResult>(resultJsonString);

            }
            catch (Exception ex)
            {
                result = new SeqNoInfoJsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };
            }

            return result;
        }

        /// <summary>
        /// 預先叫號
        /// </summary>
        /// <param name="token">認證碼</param>
        /// <param name="stationID">服務台ID</param>
        /// <param name="counterID">櫃台ID</param>
        /// <param name="preCallerStatusType">執行動作</param>
        /// <returns></returns>
        public SeqNoInfoJsonResult UpdateOrderSeqNo(User user, PreCallerStatusType preCallerStatusType)
        {
            var result = new SeqNoInfoJsonResult();

            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/Caller_UpdateOrderSeqno";

                nc["token"] = user.Token;
                nc["stationID"] = user.StationID;
                nc["counterID"] = user.CounterID;
                nc["action"] = preCallerStatusType.ToString();


                var resultJsonString = GetData(rumUrl, nc);

                result = JsonConvert.DeserializeObject<SeqNoInfoJsonResult>(resultJsonString);

            }
            catch (Exception ex)
            {
                result = new SeqNoInfoJsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };
            }

            return result;
        }

        /// <summary>
        /// 取號
        /// </summary>
        /// <param name="token">認證碼</param>
        /// <param name="stationID">服務站ID</param>
        /// <param name="machineID">取號機ID</param>
        /// <param name="serviceID">業務別ID</param>
        /// <returns></returns>
        public SeqNoInfoJsonResult InsertPatient(User user, string serviceID, string servicesTimePeriodUid)
        {
            var result = new SeqNoInfoJsonResult();

            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/NumberingMachine_InsertPatient";

                nc["token"] = user.Token;
                nc["stationID"] = user.StationID;
                nc["machineID"] = user.MachineID;
                nc["serviceID"] = serviceID;
                nc["servicesTimePeriodUid"] = servicesTimePeriodUid;

                var resultJsonString = GetData(rumUrl, nc);

                result = JsonConvert.DeserializeObject<SeqNoInfoJsonResult>(resultJsonString);

            }
            catch (Exception ex)
            {
                result = new SeqNoInfoJsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };
            }

            return result;

        }

        public MediaBoardMarqueeJsonResult GetMediaBoardMarquee(User user)
        {
            var result = new MediaBoardMarqueeJsonResult();

            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/Caller_GetMediaBoardMarquee";

                nc["token"] = user.Token;
                nc["stationID"] = user.StationID;
                nc["counterID"] = user.CounterID;

                var resultJsonString = GetData(rumUrl, nc);

                result = JsonConvert.DeserializeObject<MediaBoardMarqueeJsonResult>(resultJsonString);

            }
            catch (Exception ex)
            {
                result = new MediaBoardMarqueeJsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };
            }

            return result;
        }

        public JsonResult UpdateMediaBoardMarquee(User user, List<MediaBoardMarquee> data)
        {
            var result = new JsonResult();

            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/Caller_UpdateMediaBoardMarquee";

                nc["token"] = user.Token;
                nc["stationID"] = user.StationID;
                nc["counterID"] = user.CounterID;
                nc["data"] = JsonConvert.SerializeObject(data);

                var resultJsonString = GetData(rumUrl, nc);

                result = JsonConvert.DeserializeObject<JsonResult>(resultJsonString);

            }
            catch (Exception ex)
            {
                result = new JsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };
            }

            return result;
        }

        public CounerClinicSettingDataJsonResult GetCounerClinicSettingData(User user)
        {
            var result = new CounerClinicSettingDataJsonResult();

            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/Caller_GetCounerClinicSettingData";

                nc["token"] = user.Token;
                nc["stationID"] = user.StationID;
                nc["counterID"] = user.CounterID;

                var resultJsonString = GetData(rumUrl, nc);

                result = JsonConvert.DeserializeObject<CounerClinicSettingDataJsonResult>(resultJsonString);

            }
            catch (Exception ex)
            {
                result = new CounerClinicSettingDataJsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };
            }

            return result;
        }

        public JsonResult UpdateCounerClinicSettingData(User user, CounerClinicSettingData data)
        {
            var result = new JsonResult();

            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/Caller_UpdateCounerClinicSettingData";

                nc["token"] = user.Token;
                nc["stationID"] = user.StationID;
                nc["counterID"] = user.CounterID;
                nc["result"] = JsonConvert.SerializeObject(data);

                var resultJsonString = GetData(rumUrl, nc);

                result = JsonConvert.DeserializeObject<JsonResult>(resultJsonString);

            }
            catch (Exception ex)
            {
                result = new JsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };
            }

            return result;
        }


        public NursingInformationJsonResult GetNursingInformation(User user)
        {
            var result = new NursingInformationJsonResult();

            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/Caller_GetNursingInformation";

                nc["token"] = user.Token;

                var resultJsonString = GetData(rumUrl, nc);

                result = JsonConvert.DeserializeObject<NursingInformationJsonResult>(resultJsonString);

            }
            catch (Exception ex)
            {
                result = new NursingInformationJsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };
            }

            return result;
        }

        public PhysicianSchedulingJsonResult GetPhysicianScheduling(User user)
        {
            var result = new PhysicianSchedulingJsonResult();

            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/Caller_GetPhysicianScheduling";

                nc["token"] = user.Token;

                var resultJsonString = GetData(rumUrl, nc);

                result = JsonConvert.DeserializeObject<PhysicianSchedulingJsonResult>(resultJsonString);

            }
            catch (Exception ex)
            {
                result = new PhysicianSchedulingJsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };
            }

            return result;
        }


        public OpenClinicJsonResult OpenClinic(User user, PhysicianScheduling physicianScheduling, CounerClinicSettingData counerClinicSettingData)
        {
            var result = new OpenClinicJsonResult();

            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/Caller_OpenClinic";

                nc["token"] = user.Token;
                nc["stationID"] = user.StationID;
                nc["counterID"] = user.CounterID;
                nc["physicianScheduling"] = JsonConvert.SerializeObject(physicianScheduling);
                nc["counerClinicSettingData"] = JsonConvert.SerializeObject(counerClinicSettingData);

                var resultJsonString = GetData(rumUrl, nc);

                result = JsonConvert.DeserializeObject<OpenClinicJsonResult>(resultJsonString);

            }
            catch (Exception ex)
            {
                result = new OpenClinicJsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };
            }

            return result;
        }

        public ClinicListJsonResult GetVisitingList(User user, string uid)
        {
            var result = new ClinicListJsonResult();

            try
            {
                NameValueCollection nc = new NameValueCollection();

                string rumUrl = $"{this.Url}/Caller_GetVisitingList";

                nc["token"] = user.Token;

                var resultJsonString = GetData(rumUrl, nc);

                result = JsonConvert.DeserializeObject<ClinicListJsonResult>(resultJsonString);

            }
            catch (Exception ex)
            {
                result = new ClinicListJsonResult
                {
                    Result = ((int)MessageCodeType.例外訊息).ToString(),
                    Message = $"連線失敗：{ex.Message}，請確認網路連線是否正常。"
                };
            }

            return result;
        }
    }
}
