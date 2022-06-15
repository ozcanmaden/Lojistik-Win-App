using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace KamyonTakip.Common.Model
{
    public class ToggleMenuModel
    {
        public string PageName { get; set; }

        public Geometry IconSVG { get; set; }

        public UserControl Page { get; set; }
    }
}
