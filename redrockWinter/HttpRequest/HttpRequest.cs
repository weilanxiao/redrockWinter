using redrockWinter.RssFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace redrockWinter.HttpRequest
{
    class HttpRequest
    {
        //public async void A(string rssurl)
        //{
        //    await GetList(rssurl);
        //}

        //public async Task GetList(string rssurl)
        //{
        //    string x = await DownloadRssString(rssurl);
        //    string eOri = "entry";
        //    if (x.IndexOf("item") > 0) { eOri = "item"; }
        //    List<Rss> list = new List<Rss>();
        //    list = GetRequest(list, x,eOri);
        //}

        public static async Task<string> DownloadRssString(string url)
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(new Uri(url));
            return result;
        }

        public static  List<Rss> GetRequest(List<Rss> list, string x,string eOri)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(x);
            XmlNodeList nodelist = null;
            if (eOri == "item")
            {
                nodelist = xml.GetElementsByTagName("item");
                foreach (XmlNode node in nodelist)
                {
                    XmlElement ele = (XmlElement)node;
                    Rss r = new Rss();
                    r.Link = ele.GetElementsByTagName("link")[0].InnerText;
                    r.Title = ele.GetElementsByTagName("title")[0].InnerText;
                    r.Description = ele.GetElementsByTagName("description")[0].InnerText;
                    r.PubDate = ele.GetElementsByTagName("pubDate")[0].InnerText;
                    list.Add(r);
                }
            }
            else if (eOri == "entry")
            {
                nodelist = xml.GetElementsByTagName("entry");
                foreach (XmlNode node in nodelist)
                {
                    XmlElement ele = (XmlElement)node;
                    Rss r = new Rss();
                    r.Link = ele.GetElementsByTagName("id")[0].InnerText;
                    r.Title = ele.GetElementsByTagName("title")[0].InnerText;
                    r.Description = ele.GetElementsByTagName("content")[0].InnerText;
                    r.PubDate = ele.GetElementsByTagName("published")[0].InnerText;
                    list.Add(r);
                }
            }
            return list;
        }

        private const string homeRss = "http://feed.cnblogs.com/blog/sitehome/rss";//主页区
        private const string digestRss = "http://feed.cnblogs.com/blog/picked/rss";//精华区
        private const string newRss = "http://feed.cnblogs.com/news/rss";//新闻区
        private const string konwledgeRss = "http://feed.cnblogs.com/kb/";//知识库
        private const string questionRss = "http://feed.cnblogs.com/q/";//博问
        private const string recruitRss = "http://feed.cnblogs.com/job/";//招聘
    }
}
