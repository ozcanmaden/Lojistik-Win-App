using KamyonTakip.Common.Command;
using KamyonTakip.Common.Message;
using KamyonTakip.Data;
using KamyonTakip.Data.Model;
using KamyonTakip.Main.View;
using KamyonTakip.Main.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using KamyonTakip.Common.Model;

namespace KamyonTakip.Main.ViewModel
{
    public class LoginViewModel:ViewModelBase<UserModel,KamyonContext>
    {
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand((o) => {
                PasswordBox passwordBox = (o as LoginView).userPass as PasswordBox;
                Selected.Parola = passwordBox.Password;
                if (List.Any(a => a.KullaniciAdi == Selected.KullaniciAdi && a.Parola == Selected.Parola))
                {
                    GlobalVariables.UserId = List.FirstOrDefault(a => a.KullaniciAdi == Selected.KullaniciAdi).Id;
                    GlobalVariables.UserName = List.FirstOrDefault(a => a.KullaniciAdi == Selected.KullaniciAdi).AdSoyad;
                    GlobalVariables.IsAdmin = List.FirstOrDefault(a => a.KullaniciAdi == Selected.KullaniciAdi).IsAdmin;
                    OpenWindow(new MainWindow());
                    CloseWindow(o as LoginView);
                    Toast.ShowSuccess("Bilgileriniz doğrulandı \n Hoşgeldiniz...", "Giriş İşlemi Başarılı");
                }
                else
                {
                    Toast.ShowError("Kullanıcı Adı veya Parola Yanlış", "Giriş İşlemi Başarısız");
                }
            }, o =>Selected.KullaniciAdi!=null&&((o as LoginView).userPass as PasswordBox).Password!=null);


            if (!(List.Count > 0))
            {
                UserModel firstuser = new UserModel() {AdSoyad="admin",KullaniciAdi="admin",Parola="admin",IsAdmin=true};
                SaveCommand.Execute(firstuser);
                IlkGirisString = "İlk kez giriş yapıyorsunuz. İlk giriş için bu bilgileri kullanın; \n Kullanıcı Adı : admin \n Şifre : admin";
            }
            //ImageSource
            IconColor = Brushes.Black;
        }

        public RelayCommand LoginCommand { get; set; }
        public Brush IconColor { get; set; }


        public string IlkGirisString { get; set; }

    }
}
