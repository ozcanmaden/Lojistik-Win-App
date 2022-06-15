using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamyonTakip.Data.Model
{
    public enum FirmaTip
    {
        Nakliyeci=0,
        Müşteri=1,
        HemNakliyeciHemMüşteri=2

    }
    public enum AracTip
    {
        Minibüs=0,
        Kamyonet=1,
        Kamyon=2,
        Atego=3,
        Tır=4
    }
    public enum AracDurum
    {
        GidişDönüş = 0,
        Dönüş = 1,
        Gidiş =2,
    }

    public enum Guzergahlar
    {
        AvrupaYakası = 0,
        AnadoluYakası =1,
        Bursa=2,
        Adapazarı=3,
        İzmir=4,
        Denizli=5,
        Sakarya=6,
        Şehiriçi=7
    }
}
