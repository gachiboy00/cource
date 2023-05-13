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
    }
}
