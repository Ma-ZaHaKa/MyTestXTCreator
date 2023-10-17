using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTestXTCreator
{
    public partial class GetData : Form
    {
        public bool exit = false; // if need exit for while break
        public bool getdata = false; // if form not closed without data
        public string _data = ""; // data
        public string label_text = ""; // label text
        public GetData()
        {
            InitializeComponent();
        }

        void GetData_Load(object sender, EventArgs e)
        {
            this.text.Text = this.label_text;
            try { this.text.Focus(); } catch { }
        }

        void ok_Click(object sender, EventArgs e)
        {
            // can valid data
            if (data.Text == "") { MessageBox.Show("Enter data!", "Warn"); return; }
            this._data = data.Text;
            if (this._data != "") { getdata = true; exit = true; this.Close(); } else { MessageBox.Show("Enter data!", "Warn"); return; }
        }

        void data_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') { ok_Click(sender, new EventArgs()); }
        }

        //----------------SHOW--EXAMPLE--BY--DIKTOR
        /*void start_Click(object sender, EventArgs e)
        {
            GetData form = new GetData();
            form.ShowDialog();
            //--аналог-gettaskfromevent
            //form.Show();
            MessageBox.Show(form._data);
        }*/

    }
}
