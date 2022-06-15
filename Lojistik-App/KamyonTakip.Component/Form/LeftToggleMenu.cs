using KamyonTakip.Common.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace KamyonTakip.Component.Form
{
    public class LeftToggleMenu:Control
    {
        static LeftToggleMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LeftToggleMenu), new FrameworkPropertyMetadata(typeof(LeftToggleMenu)));
        }





        public List<ToggleMenuModel> ToggleMenusSource
        {
            get { return (List<ToggleMenuModel>)GetValue(ToggleMenusSourceProperty); }
            set { SetValue(ToggleMenusSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ToggleMenusSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToggleMenusSourceProperty =
            DependencyProperty.Register("ToggleMenusSource", typeof(List<ToggleMenuModel>), typeof(LeftToggleMenu), new PropertyMetadata(new List<ToggleMenuModel>()));




        public Brush BackColor
        {
            get { return (Brush)GetValue(BackColorProperty); }
            set { SetValue(BackColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackColorProperty =
            DependencyProperty.Register("BackColor", typeof(Brush), typeof(LeftToggleMenu), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(0,122,204))));




        public Brush ForeColor
        {
            get { return (Brush)GetValue(ForeColorProperty); }
            set { SetValue(ForeColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ForeColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForeColorProperty =
            DependencyProperty.Register("ForeColor", typeof(Brush), typeof(LeftToggleMenu), new PropertyMetadata(Brushes.Black));






        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(LeftToggleMenu), new PropertyMetadata(null));



    }
}
