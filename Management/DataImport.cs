using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bossinfo.Caller.CallerAPP
{
    public partial class DataImport : Form
    {
        private Default DefaultForm = null;
        public DataImport(Default DefaultForm)
        {
            InitializeComponent();
            dataGridView1.Visible = false;
            comboBox1.Text = comboBox1.Items[1].ToString();
            this.DefaultForm = DefaultForm;
        }

        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();  // 資料擊結

        private void FileGet_Load(object sender, EventArgs e)
        {
            Models.DataService dataService = new Models.DataService();
            var test = dataService.Test1(comboBox1.Text);

            bs.DataSource = test;
            dataGridView2.DataSource = bs.DataSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DefaultForm.Show();
            Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string t = comboBox1.Text;

            switch (t)
            {

                case "TestTable.dbf":

                    //dataGridView1.Visible = false;
                    //dataGridView2.Visible = true;

                    Models.DataService dataService = new Models.DataService();
                    var test = dataService.Test1(comboBox1.Text);

                    bs.DataSource = test;
                    dataGridView2.DataSource = bs.DataSource;
                    break;
                case "TestTable1.dbf":

                    dataGridView1.Visible = true;
                    dataGridView2.Visible = false;

                    dataService = new Models.DataService();
                    test = dataService.Test1(comboBox1.Text);

                    bs.DataSource = test;
                    dataGridView1.DataSource = bs.DataSource;
                    break;
            }
        }

        private void startDate_TextChanged(object sender, EventArgs e)
        {

        }

        //private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        //{
        //    startDate.Text = e.ToString();
        //}

        private void DataImport_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DefaultForm.Close();
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    monthCalendar1.Visible = true;
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    monthCalendar2.Visible = true;
        //}

        //private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        //{
        //    startDate.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
        //    monthCalendar1.Visible = false;
        //}

        //private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        //{
        //    endDate.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
        //    monthCalendar2.Visible = false;
        //}


    }
}
