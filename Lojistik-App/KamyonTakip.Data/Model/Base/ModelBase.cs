using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KamyonTakip.Data.Model.Base
{
    public class ModelBase:INotifyPropertyChanged
    {
        public int Id { get; set;}
        [Display(Name ="Silindi mi?")]
        public bool isDeleted { get; set; } = false;
        /*
         #1:Insert
         #2:Update
         #3 Delete
         */
         [Display(Name ="Son İşlemci")]
        public int LastOperation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
