using Bossinfo.Caller.CallerAPP.UserControls;
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
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class BaseForm : Form
    {

        private static bool isLogin;
        private static bool enableTopMost;
        private static double opacityValue = 1;
        private static bool enableOpacity;

        private OpaqueCommand cmd = new OpaqueCommand();

        public BaseForm()
        {
            //InitializeComponent();
            BaseInitialization();
        }

        public void BaseInitialization()
        {
            this.MaximizeBox = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.TopMost = IsTopMost();

        }



        public string GetTitle()
        {
            string title = "智慧分流暨叫號系統";
            return title;
        }

        public bool IsTopMost()
        {
            return enableTopMost;
        }

        public double GetOpacity()
        {
            return opacityValue;
        }

        public void Login(bool status)
        {
            isLogin = status;
            //loginUser = user;
        }
        public void HideOpaque()
        {
            cmd.HideOpaqueLayer();
        }
        //public void CreateLogForm()
        //{
        //    if (logForm == null || logForm.IsDisposed)
        //    {
        //        logForm = new LogForm();
        //        if (!Config.GetIsOpenLogForm())
        //        {
        //            logForm.Create();
        //        }
        //        ToggleShowLogForm();
        //    }
        //}
    }

   
}
