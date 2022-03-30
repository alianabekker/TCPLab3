using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPLab3
{
    public partial class ResultForm : Form
    {
        public ResultForm(List<int> listCountShoot, List<string> listResultStr, double averageCountShoot)
        {
            InitializeComponent();


            for (int i = 0; i < listResultStr.Count; i++)
                tbResult.Text += (i + 1) + " повторение - " + listCountShoot[i] + " выстрела(ов): " + listResultStr[i] + "\r\n\n";

            tbAverageCount.Text = averageCountShoot.ToString("0.##");
        }
    }
}
