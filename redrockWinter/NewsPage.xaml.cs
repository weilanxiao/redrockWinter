using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using redrockWinter.RssFile;
using System.Xml;
using System.Threading.Tasks;
using redrockWinter.HttpRequest;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace redrockWinter
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class NewsPage : Page
    {
        private const string newsRss = "http://feed.cnblogs.com/news/rss";//新闻区
        public NewsPage()
        {
            this.InitializeComponent();
            MainPage.Current.SearchBox.Text = newsRss;
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await GetList(newsRss);
        }
        public async Task GetList(string rssurl)
        {
            string x = await HttpRequest.HttpRequest.DownloadRssString(rssurl);
            string eOri = "entry";
            if (x.IndexOf("item") > 0) { eOri = "item"; }
            List<Rss> list = new List<Rss>();
            list = HttpRequest.HttpRequest.GetRequest(list, x,eOri);
            NewsList.ItemsSource = list;
        }

        private void NewsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rss = (Rss)e.ClickedItem;
            MainPage.Current.Homeframe.Navigate(typeof(ContentPage),rss);
        }
    }
}
