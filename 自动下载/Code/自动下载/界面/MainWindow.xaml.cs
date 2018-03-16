using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test;

namespace 界面
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        TestCookie cookie = new TestCookie();//放在这就不要连续点了，会出事的！！！
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text =  cookie.GetCookies();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri("D:\\pic.gif");
            bi.EndInit();
            image.Source = bi;


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            cookie.TestLogin(textBox2.Text);
        }
    }
}
