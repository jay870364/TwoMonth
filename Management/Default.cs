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
    public partial class Default : Form
    {
        private DataImport DataImport = null;
        public Default()
        {
            InitializeComponent();
            DataImport = new DataImport(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            DataImport.Show();
        }
    }
}
