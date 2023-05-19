using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace course
{
    internal class NetworkButton : Button
    {
        public static int index = 0;
        public int Id { get; set; }
        public string IP { get; set; }
        public string MAC { get; set; }
        public HashSet<int> _connection_with_buttons = new HashSet<int>();

        public NetworkButton()
        {
            this.IP = "192.189.1.1";
            this.MAC = "255.255.255.0";
            this.Id = ++index;

            Height = 50;
            Width = 40;
            Location = new Point(100, 100);
            ImageAlign = ContentAlignment.TopCenter;
            Text = Id.ToString();
            TextAlign = ContentAlignment.BottomCenter;

        }

        public void ChangeIP(string ip) => this.IP = ip; 
        public void ChangeMAC(string mac) => this.MAC = mac;

        public bool IsInSameNetwork(NetworkButton button)
        { 
            if (this.MAC != button.MAC) return false;

            IPAddress ip1Address = IPAddress.Parse(this.IP);
            IPAddress ip2Address = IPAddress.Parse(button.IP);
            IPAddress maskAddress = IPAddress.Parse(button.MAC);

            byte[] ip1Bytes = ip1Address.GetAddressBytes();
            byte[] ip2Bytes = ip2Address.GetAddressBytes();
            byte[] maskBytes = maskAddress.GetAddressBytes();

            bool f = false;

            for (int i = 0; i < 2; ++i)
                if (ip1Bytes[i] != ip2Bytes[i]) 
                    return false;
            
            
            for (int i = 2; i < 4; ++i)
            {
                f = f || ip1Bytes[i] != ip2Bytes[i];
            }
    
            return f;
        }

        public bool CheckValidIP(string ipAddressString) => IPAddress.TryParse(ipAddressString, out IPAddress ipAddress);

        public void ConnectWithButton(NetworkButton button) => _connection_with_buttons.Add(button.Id);
        public void DisconnectWithButton(NetworkButton button) => _connection_with_buttons.Remove(button.Id); 
        public void RemoveAllConnection() => _connection_with_buttons.Clear(); 

    }
}
