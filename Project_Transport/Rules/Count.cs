using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Transport
{
    class Count
    {
        public void counts()
        {
            int i = Properties.Settings.Default.Counts;
            Properties.Settings.Default.Counts = i + 1;
            Properties.Settings.Default.Save();
        }
    }
}
