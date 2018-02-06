//using Bossinfo.Caller.Enums.Caller;
//using Bossinfo.Caller.Enums.Utility;
using Bossinfo.Caller.LocalDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bossinfo.Caller.Utilitys
{
    public class Config
    {
        public static string GetDES_Key()
        {
            return "12345678";
        }

        public static string GetDES_IV()
        {
            return "12345678";
        }
        public static string CurrentDirectory()
        {
            return System.IO.Directory.GetCurrentDirectory();
        }

        public static string BaseDirectory()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory;
        }



        //public static string GetMediaBuzzPath()
        //{
        //    return BaseDirectory() + @"Data\Media\Message.wav";
        //}

        //public static string GetKetBoardDataPath()
        //{
        //    return BaseDirectory() + @"Data\KeyBoard\熱鍵維護表.xlsx";
        //}

        public static string GetSystemModeConfig()
        {
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.系統模式);

            return config == null ? string.Empty : config.Value;
        }
        public static string GetServerLocationConfig()
        {
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.伺服器位置);
            return config == null || string.IsNullOrWhiteSpace(config.Value) ? "192.168.1.80" : config.Value;
        }
        public static int GetServerLocationPortConfig()
        {
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.伺服器位置連接埠);

            return config == null || string.IsNullOrWhiteSpace(config.Value) ? 8080 : int.Parse(config.Value);

        }
        public static string GetMqttLocationConfig()
        {
            //var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.MQTT位置);
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.MQTT位置);

            return config == null || string.IsNullOrWhiteSpace(config.Value) ? "192.168.1.80" : config.Value;
        }
        public static int GetMqttLocationPortConfig()
        {
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.MQTT位置連接埠);

            return config == null || string.IsNullOrWhiteSpace(config.Value) ? 1883 : int.Parse(config.Value);

        }
        public static string GetStationConfig()
        {
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.服務站);

            return config == null ? string.Empty : config.Value;
        }

        public static string GetCounterConfig()
        {
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.櫃台);
            return config == null ? string.Empty : config.Value;
        }

        public static string GetNumberingMachineConfig()
        {
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.取號機);
            return config == null ? string.Empty : config.Value;
        }

        public static string GetNumberingMachineLocationConfig()
        {
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.取號機程式位置);
            string path = $@"{BaseDirectory()}Site\index.html";
            return config == null || string.IsNullOrWhiteSpace(config.Value) ? path : config.Value;
        }

        public static bool GetIsPrintConfig()
        {
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.於取號時啟用印表機列印);

            try
            {
                return config == null ? false : bool.Parse(config.Value);
            }
            catch
            {
                return false;
            }
        }

        public static string GetPrintNameConfig()
        {
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.印表機名稱);
            return config == null ? string.Empty : config.Value;
        }

        public static string GetLoginAccountConfig()
        {
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.登入帳號);
            return config == null ? string.Empty : config.Value;
        }

        public static string GetLoginPasswordConfig()
        {
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.登入密碼);
            return config == null ? string.Empty : config.Value;
        }

        public static bool GetAutoLoginConfig()
        {
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.自動登入);
            return config == null ? false : bool.Parse(config.Value);
        }

        public static bool GetAutoStartUpConfig()
        {
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.於Windows開機時自動啟動);
            return config == null ? false : bool.Parse(config.Value);
        }

        public static bool GetChangeServicesTypeConfig()
        {
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.轉換業務優先);
            return config == null ? false : bool.Parse(config.Value);
        }

        public static string GetLEDListenComPort()
        {
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.LED主機偵聽ComPort);
            return config == null ? string.Empty : config.Value;

        }

        public static string GetLEDSendComPort()
        {
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.LED主機發送ComPort);
            return config == null ? string.Empty : config.Value;

        }


        public static bool GetIsOpenLedFunction()
        {
            var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.啟用LED功能);
            return config == null ? false : bool.Parse(config.Value);
        }

        public static bool GetIsOpenLogForm()
        {
            var result = System.Configuration.ConfigurationManager.AppSettings["IsOpenLogForm"];

            return result == null ? false : bool.Parse(result);
        }


        public static string PassCompare()
        {
            var result = 

            return result == null ? false : bool.Parse(result);
        }
        //public static bool GetIsRepeat()
        //{
        //    var result = System.Configuration.ConfigurationManager.AppSettings["IsRepeat"];

        //    return result == null ? false : bool.Parse(result);
        //}

        //public static MachineUIStyleType GetMachineUIStyle()
        //{
        //    var result = System.Configuration.ConfigurationManager.AppSettings["MachineUIStyle"];

        //    var code = int.Parse(result);

        //    MachineUIStyleType machineUIStyleType = (MachineUIStyleType)code;

        //    return machineUIStyleType;

        //}

        //public static OperatingSystemType GetOperatingSystemType()
        //{
        //    var result = System.Configuration.ConfigurationManager.AppSettings["OS"];

        //    var code = int.Parse(result);

        //    OperatingSystemType operatingSystemType = (OperatingSystemType)code;

        //    return operatingSystemType;
        //}

        //public static string GetPhysicianSchedulingUid()
        //{
        //    var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.排班資料系統編號);
        //    return config == null ? string.Empty : config.Value;
        //}

        //public static string GetNursingUid()
        //{
        //    var config = DbService.GetSystemConfig(LocalDB.Enums.SystemConfigType.護理人員系統編號);
        //    return config == null ? string.Empty : config.Value;
        //}

        //public static string GetApiLocation()
        //{
        //    var path = GetServerLocationConfig();
        //    var port = GetServerLocationPortConfig();
        //    string apiLocation = $"http://{path}:{port}";

        //    return apiLocation;
        //}
    }
}
