using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bossinfo.Caller.LocalDB.Enums
{
    public enum SystemConfigType
    {
        系統模式 = 1,
        伺服器位置,
        伺服器位置連接埠,
        MQTT位置,
        MQTT位置連接埠,
        服務站,
        櫃台,
        取號機,
        取號機程式位置,
        於取號時啟用印表機列印,
        印表機名稱,
        登入帳號,
        登入密碼,
        自動登入,
        於Windows開機時自動啟動,
        轉換業務優先,
        LED主機偵聽ComPort,
        LED主機發送ComPort,
        啟用LED功能,
        排班資料系統編號,
        醫師名稱,
        醫師英文名稱,
        護理人員系統編號,
        護理人員名稱,
        護理人員英文名稱
    }
}
