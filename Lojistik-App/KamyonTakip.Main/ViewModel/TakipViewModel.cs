using KamyonTakip.Data;
using KamyonTakip.Data.Model;
using KamyonTakip.Main.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamyonTakip.Main.ViewModel
{
    public class TakipViewModel:ViewModelBase<TakipModel,KamyonContext>
    {
        public AracViewModel aracViewModel { get; set; }
        public FirmaViewModel firmaViewModel { get; set; }


        private List<FirmaModel> musteriList;

        public List<FirmaModel> MusteriList
        {
            get { return musteriList; }
            set { musteriList = value; }
        }

        private List<FirmaModel> nakliyeciList;

        public List<FirmaModel> NakliyeciList
        {
            get { return nakliyeciList; }
            set { nakliyeciList = value; }
        }

        private List<AracModel> aracList;

        public List<AracModel> AracList
        {
            get { return aracList; }
            set { aracList = value; }
        }


        public TakipViewModel()
        {
           
        }
        public override void Init()
        {
            base.Init();
            List = List.OrderByDescending(a => a.Id).ToList();
            aracViewModel = new AracViewModel();
            firmaViewModel = new FirmaViewModel();
            AracList = aracViewModel.List;
            MusteriList = firmaViewModel.List.Where(a => a.Tip == FirmaTip.Müşteri || a.Tip == FirmaTip.HemNakliyeciHemMüşteri).ToList();
            NakliyeciList = firmaViewModel.List.Where(a => a.Tip == FirmaTip.Nakliyeci || a.Tip == FirmaTip.HemNakliyeciHemMüşteri).ToList();
            foreach (TakipModel takip in List)
            {
                takip.Arac = AracList.FirstOrDefault(a => a.Id == takip.AracId);
                takip.Firma = MusteriList.FirstOrDefault(a => a.Id == takip.FirmaId);
                takip.Nakliyeci = NakliyeciList.FirstOrDefault(a => a.Id == takip.NakliyeciId);
            }
        }
    }
}
