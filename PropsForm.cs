using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace course
{
    public partial class PropsForm : Form
    {
        internal NetworkButton networkButton;
        private List<NetworkButton> networkButtons = new List<NetworkButton>();

        internal PropsForm(NetworkButton networkButton, List<NetworkButton> buttons)
        {
            InitializeComponent();
            this.networkButton = networkButton;
            ipTextBox.Text = this.networkButton.IP;
            macTextBox.Text = this.networkButton.MAC;

            if (networkButton is ButtonServer)
            {
                Button bt = new Button();
                bt.Text = "Generate IP";
                bt.Name = "buttonGenIP";
                bt.Click += new EventHandler(buttonGenIP_Click);
                bt.Location = new Point(buttonSave.Location.X, buttonSave.Location.Y + buttonSave.Height + 10);
                
                this.Controls.Add(bt);
                this.networkButtons = buttons;
            }
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

        private void buttonGenIP_Click(object sender, EventArgs e)
        {
            this.networkButton.IPGenerationBasedOnCurrent(this.networkButtons);
            MessageBox.Show("Генерация IP осуществлена", "Готово", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}
