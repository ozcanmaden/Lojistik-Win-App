using KamyonTakip.Common.Command;
using System;
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
    public class WindowHeader:Control
    {
        static WindowHeader()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowHeader), new FrameworkPropertyMetadata(typeof(WindowHeader)));
        }




        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(WindowHeader), new PropertyMetadata(null));



        public RelayCommand CloseCommand
        {
            get { return (RelayCommand)GetValue(CloseCommandProperty); }
            set { SetValue(CloseCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CloseCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register("CloseCommand", typeof(RelayCommand), typeof(WindowHeader), new PropertyMetadata(null));




        public RelayCommand MinimizeCommand
        {
            get { return (RelayCommand)GetValue(MinimizeCommandProperty); }
            set { SetValue(MinimizeCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinimizeCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimizeCommandProperty =
            DependencyProperty.Register("MinimizeCommand", typeof(RelayCommand), typeof(WindowHeader), new PropertyMetadata(null));




        public RelayCommand MaximizeCommand
        {
            get { return (RelayCommand)GetValue(MaximizeCommandProperty); }
            set { SetValue(MaximizeCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaximizeCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximizeCommandProperty =
            DependencyProperty.Register("MaximizeCommand", typeof(RelayCommand), typeof(WindowHeader), new PropertyMetadata(null));





        public ImageSource WindowIcon
        {
            get { return (ImageSource)GetValue(WindowIconProperty); }
            set { SetValue(WindowIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WindowIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WindowIconProperty =
            DependencyProperty.Register("WindowIcon", typeof(ImageSource), typeof(WindowHeader), new PropertyMetadata(null));





        public string WindowName    
        {
            get { return (string)GetValue(WindowNameProperty); }
            set { SetValue(WindowNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WindowName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WindowNameProperty =
            DependencyProperty.Register("WindowName", typeof(string), typeof(WindowHeader), new PropertyMetadata(""));




        public Brush ForeColor
        {
            get { return (Brush)GetValue(ForeColorProperty); }
            set { SetValue(ForeColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ForeColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForeColorProperty =
            DependencyProperty.Register("ForeColor", typeof(Brush), typeof(WindowHeader), new PropertyMetadata(Brushes.Black));






        public RelayCommand MouseDownCommand
        {
            get { return (RelayCommand)GetValue(MouseDownCommandProperty); }
            set { SetValue(MouseDownCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MouseDownCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MouseDownCommandProperty =
            DependencyProperty.Register("MouseDownCommand", typeof(RelayCommand), typeof(WindowHeader), new PropertyMetadata(null));




    }
}
