using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    internal class ButtonServer : NetworkButton
    {
        public ButtonServer()
        {
            Image = course.Properties.Resources.server;
        }

        public void GenerateIP()
        {
            this.IP = "192.168.0.0";
            int l = 1;
            foreach (int id in this._connection_with_buttons)
            {
                
            }
        }
    }
}
