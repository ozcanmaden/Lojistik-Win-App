using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KamyonTakip.Component.Form
{
    public class IconicButton:Button
    {
        static IconicButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconicButton), new FrameworkPropertyMetadata(typeof(IconicButton)));
        }

        #region Properties

        #region Text
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(IconicButton), new PropertyMetadata(""));

        #endregion

        #region ImageSource



        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource), typeof(IconicButton), new PropertyMetadata(null));



        #endregion
        #endregion


    }
}
