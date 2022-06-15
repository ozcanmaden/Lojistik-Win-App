using KamyonTakip.Data.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamyonTakip.Data.Model
{
    public class TakipModel : ModelBase
    {
        public DateTime Tarih { get; set; } = DateTime.Now;
        //Harf-Rakam ayrılabilir
        public string FisNo { get; set; }
        //Firma Tablosu Ad cekilecek  (Firma Adı,Vergi Dairesi,Vergi Numarası,Telefon Numarası,Yetkili,Tip[Nakliyeci,Müşteri])
        public int FirmaId { get; set; }
        //Araç tipi tanım listesi ekle çıkar vs.(AraTipi)
        //public int AracTuruId { get; set; }
        //Araç tanım listesi ekle çıkar vs. (foreignkey AracTuruId)(Plaka,AracTipi)
        public int AracId { get; set; }
        public double YakitMiktari { get; set; }
        public double AracKM { get; set; }
        //Personel Tablosu(FirmaId Tip:Nakliyeci) 
        public int NakliyeciId { get; set; }
        //enum tanımı (Gidiş/Dönüş/Gidiş Dönüş)
        public Guzergahlar Guzergah { get; set; }
        public AracDurum Durum { get; set; }
        public double Fiyat { get; set; }
        public string Aciklama { get; set; }
        public bool Faturalandi { get; set; }
        public string Cins { get; set; }

        [NotMapped]
        public AracModel Arac { get; set; }
        [NotMapped]
        public FirmaModel Firma { get; set; }
        [NotMapped]
        public FirmaModel Nakliyeci { get; set; }






    }
}
