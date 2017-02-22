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
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace redrockWinter
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class KonwledgePage : Page
    {
        private const string konwledgeRss = "http://feed.cnblogs.com/kb/";//知识库
        public KonwledgePage()
        {
            this.InitializeComponent();
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await GetList(konwledgeRss);
        }
        public async Task GetList(string rssurl)
        {
            string x = await HttpRequest.HttpRequest.DownloadRssString(rssurl);
            string eOri = "entry";
            if (x.IndexOf("item") > 0) { eOri = "item"; }
            List<Rss> list = new List<Rss>();
            list = HttpRequest.HttpRequest.GetRequest(list, x, eOri);
            KnowledgeList.ItemsSource = list;
        }

        private void KnowledgeList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rss = (Rss)e.ClickedItem;
            MainPage.Current.Homeframe.Navigate(typeof(ContentPage), rss);
        }
    }
}
