using KamyonTakip.Common.Command;
using KamyonTakip.Common.Message;
using KamyonTakip.Common.Model;
using KamyonTakip.Data;
using KamyonTakip.Data.Model;
using KamyonTakip.Data.Model.Base;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Converter;
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KamyonTakip.Main.ViewModel.Base
{
    public abstract class ViewModelBase<TModel, TContext> : INotifyPropertyChanged
        where TModel : ModelBase, new()
        where TContext : DbContext, new()
    {
        public ViewModelBase()
        {
            Context = new TContext();
            Init();
            GridHeight = 450;
            CloseCommand = new RelayCommand((o) =>
            {
                Application.Current.Shutdown();
            }, o => true);
            MinimizeCommand = new RelayCommand((o) =>
            {
                Window window = o as Window;
                window.WindowState = WindowState.Minimized;
            }, o => true);
            MaximizeCommand = new RelayCommand((o) =>
            {
                Window window = o as Window;
                if (window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                }
                else
                {
                    window.WindowState = WindowState.Maximized;
                }
                GridHeight = window.Height - 100;
            }, o => true);
            NewCommand = new RelayCommand((o) =>
            {
                New();
            }, o => Selected.Id > -1);
            SaveCommand = new RelayCommand((o) =>
            {
                try
                {
                    TModel model = o as TModel;
                    if (model != null)
                    {
                        if (model.Id == 0)
                        {
                            Insert(model);
                        }
                        else
                        {
                            Update(model);
                        }
                    }
                    else
                    {
                        Toast.ShowWarning("Eklemek istenen veri bulunamadı. \nLütfen yeni bir veri eklemeyi deneyiniz", "Ekleme Hatası");
                    }
                }
                catch (Exception ex)
                {
                    Toast.ShowError(ex.Message, "Hata");
                }
            }, o => true);
            DeleteCommand = new RelayCommand((o) =>
            {
                try
                {
                    TModel model = o as TModel;
                    if (model != null)
                    {
                        Delete(model);
                    }
                    else
                    {
                        Toast.ShowWarning("Düzetilmek istenen veri bulunamadı. \nLütfen tekrar şeçip deneyiniz", "Düzeltme Hatası");
                    }
                }
                catch
                {

                }
            }, o => Selected.Id > -1);
            ExportCommand = new RelayCommand((o) =>
            {
                try
                {
                    SfDataGrid dataGrid = o as SfDataGrid;
                    string tablename = Selected.GetType().Name;
                    tablename = tablename == "TakipModel" ? "Hareketler" : tablename == "FirmaModel" ? "Firmalar" : tablename == "AracModel" ? "Araçlar" : tablename == "UserModel" ? "Kullanıcılar" : tablename;
                    var options = new ExcelExportingOptions();
                    options.ExcelVersion = ExcelVersion.Excel2013;
                    var excelEngine = dataGrid.ExportToExcel(dataGrid.View, options);
                    var workBook = excelEngine.Excel.Workbooks[0];
                    string documentpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\KamyonTakip\\Raporlar";
                    workBook.SaveAs(documentpath + "\\" + DateTime.Now.ToShortDateString() + "_" + tablename + ".xls");
                    Toast.ShowSuccess("İşlem Başarılı \nKonum:" + documentpath, "Excel Çıkartma");
                }
                catch
                {
                    Toast.ShowError("Hata", "Mesaj");
                }

            }, o => true);
            PrintCommand = new RelayCommand((o) =>
            {
                SfDataGrid dataGrid = o as SfDataGrid;
                string tablename = Selected.GetType().Name;
                tablename = tablename == "TakipModel" ? "Araç Hareketleri" : tablename == "FirmaModel" ? "Firmalar" : tablename == "AracModel" ? "Araçlar" : tablename == "UserModel" ? "Kullanıcılar" : tablename;
                dataGrid.PrintSettings.AllowRepeatHeaders = true;
                dataGrid.PrintSettings.AllowColumnWidthFitToPrintPage = true;
                dataGrid.PrintSettings.PrintPageHeaderHeight = 35;
                dataGrid.PrintSettings.PrintPageFooterHeight = 35;
                dataGrid.PrintSettings.PrintPageFooterTemplate = Application.Current.Resources["FooterTemplate"] as DataTemplate;
                Application.Current.Resources["PrintTableName"] = tablename;
                dataGrid.PrintSettings.PrintPageHeaderTemplate = Application.Current.Resources["HeaderTemplate"] as DataTemplate;
                dataGrid.ShowPrintPreview();
            }, o => true);
        }
        public virtual void Init()
        {
            List = Context.Set<TModel>().Where(a => a.isDeleted == false).ToList();
            Selected = new TModel();
            SelectedIndex = -1;
        }
        public TContext Context { get; set; }
        private List<TModel> list;
        public List<TModel> List
        {
            get { return list; }
            set { list = value; OnChanged(); }
        }

        private TModel selected;
        public TModel Selected
        {
            get { return selected; }
            set { selected = value != null ? value : new TModel(); OnChanged(); }
        }

        private int selectedIndex;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                if (SelectedIndex == -1)
                {
                    SaveName = "Ekle";
                }
                else
                {
                    SaveName = "Kaydet";
                }
                OnChanged();
            }
        }

        private string saveName;

        public string SaveName
        {
            get { return saveName; }
            set { saveName = value; OnChanged(); }
        }

        private double gridHeight;

        public double GridHeight
        {
            get { return gridHeight; }
            set { gridHeight = value; OnChanged(); }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public RelayCommand CloseCommand { get; set; }
        public RelayCommand MinimizeCommand { get; set; }
        public RelayCommand MaximizeCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand NewCommand { get; set; }
        public RelayCommand ExportCommand { get; set; }
        public RelayCommand PrintCommand { get; set; }

        public void CloseWindow(Window window)
        {
            if (window != null)
                window.Close();
        }
        public void OpenWindow(Window window)
        {
            if (window != null)
                window.Show();
        }

        public virtual void New()
        {
            Init();
        }

        public virtual void Insert(TModel model)
        {
            try
            {
                model.LastOperation = GlobalVariables.UserId;
                Context.Set(model.GetType()).Add(model);
                Context.SaveChanges();
                Init();
            }
            catch (DbEntityValidationException ex)
            {
                string mesaj = "";
                foreach (var error in ex.EntityValidationErrors.First().ValidationErrors)
                {
                    mesaj += error.ErrorMessage + "\n";
                }
                throw new Exception(mesaj);
            }
            catch (Exception ex)
            {

                if (ex.InnerException.InnerException.Message != null)
                {
                    string exstring = ex.InnerException.InnerException.Message;
                    string excolumn = exstring.Substring(exstring.IndexOf("unique index 'IX_")).Substring(17);
                    string excolumn2 = excolumn.Substring(0, excolumn.IndexOf("'"));
                    throw new Exception("Bu " + excolumn2 + " değeri daha önce kullanılmış");
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public virtual void Delete(TModel model)
        {
            try
            {
                model.LastOperation = GlobalVariables.UserId;
                TModel test = Context.Set<TModel>().FirstOrDefault(a => a.Id == model.Id);
                test.GetType().GetProperty("isDeleted").SetValue(test, true);
                Context.SaveChanges();
                Init();
            }
            catch
            {
                throw new Exception("Silme işlemi başarısız");
            }
        }
        public virtual void Update(TModel model)
        {
            try
            {
                model.LastOperation = GlobalVariables.UserId;
                TModel test = Context.Set<TModel>().FirstOrDefault(a => a.Id == model.Id);
                foreach (PropertyInfo property in test.GetType().GetProperties())
                {
                    property.SetValue(test, model.GetType().GetProperty(property.Name).GetValue(model));
                }
                Context.SaveChanges();
                Init();
            }
            catch (DbEntityValidationException ex)
            {
                string mesaj = "";
                foreach (var error in ex.EntityValidationErrors.First().ValidationErrors)
                {
                    mesaj += error.ErrorMessage + "\n";
                }
                throw new Exception(mesaj);
            }
            catch (Exception ex)
            {

                if (ex.InnerException.InnerException.Message != null)
                {
                    string exstring = ex.InnerException.InnerException.Message;
                    string excolumn = exstring.Substring(exstring.IndexOf("unique index 'IX_")).Substring(17);
                    string excolumn2 = excolumn.Substring(0, excolumn.IndexOf("'"));
                    throw new Exception("Bu " + excolumn2 + " değeri daha önce kullanılmış");
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }

    }
}
