using redrockWinter.RssFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace redrockWinter
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public bool IoN = true;
        public static MainPage Current;
        public MainPage()
        {
            this.InitializeComponent();
            Current = this;
            Homeframe.Navigate(typeof(HomePage));
            ReturnButton.Visibility = Visibility.Collapsed;
            First.IsSelected = true;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void IconsListBos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IoN = true;
            if (First.IsSelected)//选择该项
            {
                ReturnButton.Visibility = Visibility.Visible;//设置可见性
                Homeframe.Navigate(typeof(HomePage));//跳转到该页
                //MainText.Text = "首页";
            }else if(Second.IsSelected)
            {
                ReturnButton.Visibility = Visibility.Visible;
                Homeframe.Navigate(typeof(DigestPage));
                //MainText.Text = "精华";
            }
            else if (Third.IsSelected)
            {
                ReturnButton.Visibility = Visibility.Visible;
                Homeframe.Navigate(typeof(NewsPage));
                //MainText.Text = "新闻";
            }
            else if (Fourth.IsSelected)
            {
                ReturnButton.Visibility = Visibility.Visible;
                Homeframe.Navigate(typeof(KonwledgePage));
                //MainText.Text = "知识";
            }
            else if (Fifth.IsSelected)
            {
                ReturnButton.Visibility = Visibility.Visible;
                Homeframe.Navigate(typeof(QuestionPage));
                //MainText.Text = "博问";
            }
            else if (Sixth.IsSelected)
            {
                ReturnButton.Visibility = Visibility.Visible;
                Homeframe.Navigate(typeof(RecruitPage));
                //MainText.Text = "招聘";
            }
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            if (Homeframe.CanGoBack)
            {
                Homeframe.GoBack();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == null || SearchBox.Text == "请输入网址")
            {
                Homeframe.Navigate(typeof(SearchPage));
            }
        }
    }
}
