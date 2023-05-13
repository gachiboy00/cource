using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace course
{
    public partial class PropsForm : Form
    {
        internal NetworkButton networkButton;

        internal PropsForm(NetworkButton networkButton)
        {
            InitializeComponent();
            this.networkButton = networkButton;
            ipTextBox.Text = this.networkButton.IP;
            macTextBox.Text = this.networkButton.MAC;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var validIP = networkButton.CheckValidIP(ipTextBox.Text);
            var validMAC = networkButton.CheckValidIP(macTextBox.Text);

            if (!validIP || !validMAC)
            {
                MessageBox.Show(!validIP ? "Не верно введенный IP-адрес!" : "Не верно введенный MAC-адрес!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.networkButton.IP = ipTextBox.Text;
            this.networkButton.MAC = macTextBox.Text;
        }

        private void buttonCancel_Click(object sender, EventArgs e) => this.Close();
    }
}
