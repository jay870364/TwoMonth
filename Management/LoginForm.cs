using Bossinfo.Caller.LocalDB;
using Bossinfo.Caller.Utilitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bossinfo.Caller.CallerAPP
{
    public partial class LoginForm : BaseForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public void Initialization()
        {
            this.Text = GetTitle();

            this.MinimizeBox = false;
            this.MaximizeBox = false;

            this.Opacity = GetOpacity();

            this.KeyPreview = true;

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            var config = Config.GetSystemModeConfig();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var account = "bossinfo";
            var pass = "1234";
            var t = DbService.GetPassword(account, pass);
            //DbService.Init();
            //var config = Config.GetSystemModeConfig();

            BackgroundWorkerLoginSetup01 = new BackgroundWorker();
            BackgroundWorkerLoginSetup01.DoWork += new DoWorkEventHandler(BackgroundWorkerLoginSetup01_DoWork);
            BackgroundWorkerLoginSetup01.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorkerLoginSetup01_RunWorkerCompleted);
            BackgroundWorkerLoginSetup01.RunWorkerAsync();
        }
        private BackgroundWorker BackgroundWorkerLoginSetup01;
        private BackgroundWorker BackgroundWorkerLoginSetup02;
        private bool isLogin = false;
        private LoginJsonResult result = new LoginJsonResult();
        private void BackgroundWorkerLoginSetup01_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);

            //DataService dataService = new DataService(Config.GetOperatingSystemType());

            //登入，假設Caller有設定過工作站及櫃台，同時傳入，沒有設定就是空值。

            switch (1)
            {
                case 1:
                    //isLogin = dataService.Login(this.txtAccount.Text.Trim(), this.txtPassword.Text.Trim(), Config.GetStationConfig(), mode, Config.GetCounterConfig(), out result);
                    break;
            }
        }
        private void BackgroundWorkerLoginSetup01_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            //是否登入
            if (isLogin)
            {
                //若登入了，寫入登入資訊


                result.Data.StationID = Config.GetStationConfig();
                result.Data.CounterID = Config.GetCounterConfig();
                result.Data.MachineID = Config.GetNumberingMachineConfig();

                Login(true, result.Data);
                var mode = 1;
                switch (mode)
                {
                    case 1:

                        if (!string.IsNullOrWhiteSpace(Config.GetStationConfig()) && !string.IsNullOrWhiteSpace(Config.GetCounterConfig()))
                        {
                            //UpdateCounterUseStatus(CounterUseStatusType.ONLINE, false);

                            BackgroundWorkerLoginSetup02 = new BackgroundWorker();
                            BackgroundWorkerLoginSetup02.DoWork += new DoWorkEventHandler(BackgroundWorkerLoginSetup02_DoWork);
                            BackgroundWorkerLoginSetup02.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorkerLoginSetup02_RunWorkerCompleted);
                            BackgroundWorkerLoginSetup02.RunWorkerAsync();
                        }
                        else
                        {
                            OpenCallerForm();
                        }

                        break;
                }
            }
            else
            {
                HideOpaque();

                //若未登入，顯示訊息
                MessageBox.Show(result.Message);
            }
        }

        private void BackgroundWorkerLoginSetup02_DoWork(object sender, DoWorkEventArgs e)
        {
            //UpdateCounterUseStatus(CounterUseStatusType.ONLINE, false);

        }

        //執行完成
        private void BackgroundWorkerLoginSetup02_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            switch (mode)
            {
                case SystemModeType.智慧分流暨叫號系統:
                    OpenCallerForm();
                    break;
                case SystemModeType.候診系統:
                    OpenClinicForm();
                    break;
            }
        }

        private void OpenCallerForm()
        {
            HideOpaque();
            CallerForm callerForm = new CallerForm();
            this.Hide();
            callerForm.ShowDialog(this);
            callerForm.Dispose();
        }
    }
}
