using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace KamyonTakip.Common.Message
{
    public static class Toast
    {
        static Toast()
        {
            notificationManager = new NotificationManager(Dispatcher.CurrentDispatcher);


        }
        private static NotificationManager notificationManager;



        public static void Init(Dispatcher dispatcher)
        {

            notificationManager = new NotificationManager(dispatcher);

        }


        public static void Show(string message, string title = "", NotificationType type = NotificationType.Information)
        {
            if (notificationManager == null)
            {
                throw new Exception("Toast.Init() çalıştırılmamış.");
            }

            Action click = () => {
                Window win = new Window();
                win.Title = title;
                win.Content = message;
                win.Show();
            };
            notificationManager.Show(new NotificationContent
            {
                Title = title,
                Message = message,
                Type = type
            }, "", null, click);
        }


        public static void ShowError(string message, string title = "", Exception e = null)
        {
            if (e != null)
                message += e.Message;

            Show(message, title, NotificationType.Error);
        }

        public static void ShowInfo(string message, string title = "")
        {
            Show(message, title, NotificationType.Information);
        }

        public static void ShowSuccess(string message, string title = "")
        {
            Show(message, title, NotificationType.Success);
        }
        public static void ShowWarning(string message, string title = "")
        {
            Show(message, title, NotificationType.Warning);
        }
    }
}
