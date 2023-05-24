using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace course
{
    internal class NetworkButton : Button
    {
        public static int index = 0;
        public int Id { get; set; }
        public string IP { get; set; }
        public string NetMask { get; set; }
        public string MAC { get; set; }
        public HashSet<int> _connection_with_buttons = new HashSet<int>();

        public NetworkButton()
        {
            this.IP = "192.189.1.1";
            this.NetMask = "255.255.255.0";
            this.Id = ++index;
            this.MAC = GenerateMACAddress();

            Height = 50;
            Width = 40;
            Location = new Point(100, 100);
            ImageAlign = ContentAlignment.TopCenter;
            Text = Id.ToString();
            TextAlign = ContentAlignment.BottomCenter;
        }

        public void ChangeIP(string ip) => this.IP = ip; 
        public void ChangeMAC(string mac) => this.NetMask = mac;

        private string GenerateMACAddress()
        {
            Random random = new Random();
            byte[] mac = new byte[6];
            random.NextBytes(mac);
            mac[0] = (byte)(mac[0] & 0xFE); // set the second-least-significant bit to 0 to make it a locally-administered address
            return string.Join(":", mac.Select(b => b.ToString("X2")));
        }

        public bool IsInSameNetwork(NetworkButton button)
        { 
            if (this.NetMask != button.NetMask) return false;
            if (this.MAC == button.MAC) return false;

            IPAddress ip1Address = IPAddress.Parse(this.IP);
            IPAddress ip2Address = IPAddress.Parse(button.IP);

            byte[] ip1Bytes = ip1Address.GetAddressBytes();
            byte[] ip2Bytes = ip2Address.GetAddressBytes();
            
            bool f = false;

            for (int i = 0; i < 2; ++i)
                if (ip1Bytes[i] != ip2Bytes[i]) 
                    return false;
            
            for (int i = 2; i < 4; ++i)
                f = f || ip1Bytes[i] != ip2Bytes[i];
            
            return f;
        }

        public bool CheckValidIP(string ipAddressString) => IPAddress.TryParse(ipAddressString, out IPAddress ipAddress);
        public bool CheckValidMACAddress(string macAddress)
        {
            Regex regex = new Regex("^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$");
            return regex.IsMatch(macAddress);
        }
        public void ConnectWithButton(NetworkButton button) => _connection_with_buttons.Add(button.Id);
        public void DisconnectWithButton(NetworkButton button) => _connection_with_buttons.Remove(button.Id); 
        public void RemoveAllConnection() => _connection_with_buttons.Clear();

        public void IPGenerationBasedOnCurrent(List<NetworkButton> networkButtons)
        {
            IPAddress ipAddress = IPAddress.Parse(this.IP);
            Byte[] bytes = ipAddress.GetAddressBytes();
            byte counter = bytes[3];
            foreach (NetworkButton button in networkButtons)
            {
                button.NetMask = this.NetMask;
                counter++;
                if (bytes[3] >= 255)
                {
                    bytes[3] = 0;
                    if (bytes[2] >= 255)
                    {
                        bytes[2] = 0;
                        bytes[1]++;
                    }
                    else
                        bytes[2]++;
                }
                bytes[3] = counter;

                string result = string.Join(".", bytes.Select(x => x.ToString()));                
                button.IP = result;
            }
        }
    }
}
