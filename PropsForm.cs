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

        internal PropsForm(NetworkButton networkButton, Control.ControlCollection control)
        {
            
            InitializeComponent();
            this.networkButton = networkButton;
            ipTextBox.Text = this.networkButton.IP;
            macTextBox.Text = this.networkButton.MAC;

            if (networkButton is ButtonServer)
            {
                Console.WriteLine("Hello World");
                Button bt = new Button();
                bt.Text = "Generate IP";
                bt.Location = new Point(buttonSave.Location.X, buttonSave.Location.Y + buttonSave.Height + 10);

                this.Controls.Add(bt);
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
    }
}
