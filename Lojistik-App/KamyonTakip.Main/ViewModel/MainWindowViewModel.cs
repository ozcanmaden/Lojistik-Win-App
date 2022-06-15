using KamyonTakip.Common.Command;
using KamyonTakip.Common.Model;
using KamyonTakip.Data;
using KamyonTakip.Data.Model;
using KamyonTakip.Data.Model.Base;
using KamyonTakip.Main.View;
using KamyonTakip.Main.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace KamyonTakip.Main.ViewModel
{
    public class MainWindowViewModel : ViewModelBase<UserModel, KamyonContext>
    {
        public MainWindowViewModel()
        {
            UserName = GlobalVariables.UserName;
            MenuItems = new List<ToggleMenuModel>() {
                new ToggleMenuModel(){PageName="Araçlar",Page=new AracUserControl(),IconSVG=Geometry.Parse("M621.3 237.3l-58.5-58.5c-12-12-28.3-18.7-45.3-18.7H480V64c0-17.7-14.3-32-32-32H32C14.3 32 0 46.3 0 64v336c0 44.2 35.8 80 80 80 26.3 0 49.4-12.9 64-32.4 14.6 19.6 37.7 32.4 64 32.4 44.2 0 80-35.8 80-80 0-5.5-.6-10.8-1.6-16h163.2c-1.1 5.2-1.6 10.5-1.6 16 0 44.2 35.8 80 80 80s80-35.8 80-80c0-5.5-.6-10.8-1.6-16H624c8.8 0 16-7.2 16-16v-85.5c0-17-6.7-33.2-18.7-45.2zM80 432c-17.6 0-32-14.4-32-32s14.4-32 32-32 32 14.4 32 32-14.4 32-32 32zm128 0c-17.6 0-32-14.4-32-32s14.4-32 32-32 32 14.4 32 32-14.4 32-32 32zm272-224h37.5c4.3 0 8.3 1.7 11.3 4.7l43.3 43.3H480v-48zm48 224c-17.6 0-32-14.4-32-32s14.4-32 32-32 32 14.4 32 32-14.4 32-32 32z")},
                new ToggleMenuModel(){PageName="Firmalar",Page=new FirmaUserControl(),IconSVG=Geometry.Parse("M475.115 163.781L336 252.309v-68.28c0-18.916-20.931-30.399-36.885-20.248L160 252.309V56c0-13.255-10.745-24-24-24H24C10.745 32 0 42.745 0 56v400c0 13.255 10.745 24 24 24h464c13.255 0 24-10.745 24-24V184.029c0-18.917-20.931-30.399-36.885-20.248z")},
                new ToggleMenuModel(){PageName="Hareketler",Page=new TakipUserControl(),IconSVG=Geometry.Parse("M640 264v-16c0-8.84-7.16-16-16-16H344v-40h72c17.67 0 32-14.33 32-32V32c0-17.67-14.33-32-32-32H224c-17.67 0-32 14.33-32 32v128c0 17.67 14.33 32 32 32h72v40H16c-8.84 0-16 7.16-16 16v16c0 8.84 7.16 16 16 16h104v40H64c-17.67 0-32 14.33-32 32v128c0 17.67 14.33 32 32 32h160c17.67 0 32-14.33 32-32V352c0-17.67-14.33-32-32-32h-56v-40h304v40h-56c-17.67 0-32 14.33-32 32v128c0 17.67 14.33 32 32 32h160c17.67 0 32-14.33 32-32V352c0-17.67-14.33-32-32-32h-56v-40h104c8.84 0 16-7.16 16-16zM256 128V64h128v64H256zm-64 320H96v-64h96v64zm352 0h-96v-64h96v64z")},
            };
            if (GlobalVariables.IsAdmin)
            {
                MenuItems.Add(new ToggleMenuModel() { PageName = "Kullanıcılar", Page = new UserManagementUserControl(), IconSVG = Geometry.Parse("M96 224c35.3 0 64-28.7 64-64s-28.7-64-64-64-64 28.7-64 64 28.7 64 64 64zm448 0c35.3 0 64-28.7 64-64s-28.7-64-64-64-64 28.7-64 64 28.7 64 64 64zm32 32h-64c-17.6 0-33.5 7.1-45.1 18.6 40.3 22.1 68.9 62 75.1 109.4h66c17.7 0 32-14.3 32-32v-32c0-35.3-28.7-64-64-64zm-256 0c61.9 0 112-50.1 112-112S381.9 32 320 32 208 82.1 208 144s50.1 112 112 112zm76.8 32h-8.3c-20.8 10-43.9 16-68.5 16s-47.6-6-68.5-16h-8.3C179.6 288 128 339.6 128 403.2V432c0 26.5 21.5 48 48 48h288c26.5 0 48-21.5 48-48v-28.8c0-63.6-51.6-115.2-115.2-115.2zm-223.7-13.4C161.5 263.1 145.6 256 128 256H64c-35.3 0-64 28.7-64 64v32c0 17.7 14.3 32 32 32h65.9c6.3-47.4 34.9-87.3 75.2-109.4z") });
            }
            TabItems = new ObservableCollection<TabItemModel>();
            OpenUserControlCommand = new RelayCommand((o) => {
                UserControl userControl = o as UserControl;
                if (!TabItems.Any(a => a.UserControlContent.Name == userControl.Name))
                {
                    TabItemModel tabItemModel = new TabItemModel();
                    if (userControl.Name == "UserSettings")
                    {
                        tabItemModel.Header = "Kullanıcılar";
                        tabItemModel.UserControlContent = new UserManagementUserControl();
                    }
                    else if (userControl.Name == "TakipSettings")
                    {
                        tabItemModel.Header = "Hareketler";
                        tabItemModel.UserControlContent = new TakipUserControl();

                    }
                    else if (userControl.Name == "FirmaSettings")
                    {
                        tabItemModel.Header = "Firmalar";
                        tabItemModel.UserControlContent = new FirmaUserControl();

                    }
                    else if (userControl.Name == "AracSettings")
                    {
                        tabItemModel.Header = "Araçlar";
                        tabItemModel.UserControlContent = new AracUserControl();

                    }
                    TabItems.Add(tabItemModel);
                }
                else
                {
                    SelectedTabItem = TabItems.FirstOrDefault(a => a.UserControlContent.Name == userControl.Name);
                }
            }, o => true);
        }

        //ModelBase yerine koyulabilecek ama koyulursa db de tutulması gereken bir veri
        public List<ToggleMenuModel> MenuItems { get; set; }

        private ObservableCollection<TabItemModel> tabItems;

        public ObservableCollection<TabItemModel> TabItems
        {
            get { return tabItems; }
            set { tabItems = value; OnChanged(); }
        }

        private TabItemModel selectedTabItem;

        public TabItemModel SelectedTabItem
        {
            get { return selectedTabItem; }
            set { selectedTabItem = value; OnChanged(); }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }



        public RelayCommand OpenUserControlCommand { get; set; }
    }
}
