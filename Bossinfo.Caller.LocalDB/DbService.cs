using Bossinfo.Caller.LocalDB.Entity;
using Bossinfo.Caller.LocalDB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bossinfo.Caller.LocalDB
{
    public class DbService
    {
        public static void Init()
        {
            using (var db = new CallerContext())
            {
                if (db.SystemConfigs.Count() == 0)
                {
                    SystemConfig config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.系統模式,
                        Name = SystemConfigType.系統模式.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);


                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.伺服器位置,
                        Name = SystemConfigType.伺服器位置.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.伺服器位置連接埠,
                        Name = SystemConfigType.伺服器位置連接埠.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.MQTT位置,
                        Name = SystemConfigType.MQTT位置.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.MQTT位置連接埠,
                        Name = SystemConfigType.MQTT位置連接埠.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.服務站,
                        Name = SystemConfigType.服務站.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.取號機,
                        Name = SystemConfigType.取號機.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);


                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.櫃台,
                        Name = SystemConfigType.櫃台.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.取號機程式位置,
                        Name = SystemConfigType.取號機程式位置.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.於取號時啟用印表機列印,
                        Name = SystemConfigType.於取號時啟用印表機列印.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.印表機名稱,
                        Name = SystemConfigType.印表機名稱.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);


                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.登入帳號,
                        Name = SystemConfigType.登入帳號.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);


                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.登入密碼,
                        Name = SystemConfigType.登入密碼.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);


                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.自動登入,
                        Name = SystemConfigType.自動登入.ToString(),
                        Value = false.ToString()
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.於Windows開機時自動啟動,
                        Name = SystemConfigType.於Windows開機時自動啟動.ToString(),
                        Value = false.ToString()
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.轉換業務優先,
                        Name = SystemConfigType.轉換業務優先.ToString(),
                        Value = false.ToString()
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.LED主機偵聽ComPort,
                        Name = SystemConfigType.LED主機偵聽ComPort.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.LED主機發送ComPort,
                        Name = SystemConfigType.LED主機發送ComPort.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.啟用LED功能,
                        Name = SystemConfigType.啟用LED功能.ToString(),
                        Value = false.ToString()
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.排班資料系統編號,
                        Name = SystemConfigType.排班資料系統編號.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.護理人員系統編號,
                        Name = SystemConfigType.護理人員系統編號.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.醫師名稱,
                        Name = SystemConfigType.醫師名稱.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.醫師英文名稱,
                        Name = SystemConfigType.醫師英文名稱.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.護理人員名稱,
                        Name = SystemConfigType.護理人員名稱.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);

                    config = new SystemConfig
                    {
                        Code = (int)SystemConfigType.護理人員英文名稱,
                        Name = SystemConfigType.護理人員英文名稱.ToString(),
                        Value = string.Empty
                    };
                    db.SystemConfigs.Add(config);

                    db.SaveChanges();
                }
            }
        }

        public static SystemConfig GetSystemConfig(SystemConfigType systemConfigType)
        {
            using (var db = new CallerContext())
            {
                return db.SystemConfigs.Where(x => x.Code == (int)systemConfigType).FirstOrDefault();
            }
        }

        public static void SaveSystemConfig(SystemConfig systemConfig)
        {
            using (var db = new CallerContext())
            {
                var obj = db.SystemConfigs.Where(x => x.Code == systemConfig.Code).FirstOrDefault();

                obj.Value = systemConfig.Value;

                db.SaveChanges();
            }
        }

        public static bool GetPassword(string Account, string Pass)
        {
            using (var db = new CallerContext())
            {
                return db.User.Where(x => x.Name == Account).FirstOrDefault().Password == Pass ? true : false;
                
            }
        }
    }
}