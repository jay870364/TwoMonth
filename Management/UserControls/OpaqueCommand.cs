using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bossinfo.Caller.CallerAPP.UserControls
{
    class OpaqueCommand
    {
        private OpaqueLayerUserControl opaqueLayer = null;


        public void ShowOpaqueLayer(Control control, int alpha, bool isShowLoadingImage)
        {
            try
            {
                if (this.opaqueLayer == null)
                {
                    this.opaqueLayer = new OpaqueLayerUserControl(alpha, isShowLoadingImage);
                    control.Controls.Add(this.opaqueLayer);
                    this.opaqueLayer.Dock = DockStyle.Fill;
                    this.opaqueLayer.BringToFront();
                }
                this.opaqueLayer.Enabled = true;
                this.opaqueLayer.Visible = true;
            }
            catch { }
        }


        public void HideOpaqueLayer()
        {
            try
            {
                if (this.opaqueLayer != null)
                {
                    this.opaqueLayer.Visible = false;
                    this.opaqueLayer.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
