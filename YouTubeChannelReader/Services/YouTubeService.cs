using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using YouTubeChannelReader.Model;

namespace YouTubeChannelReader.Services
{
    public class YouTubeService
    {
        private string ChannelUrl;

        public List<YouTubeItem> Items { get; set; }

        public YouTubeService(string channelID)
        {
            ChannelUrl = $"{Constants.Constants.YouTubeBaseAddress}{channelID}";
        }

        public async Task<IEnumerable<YouTubeItem>> QueryVideosAsync(CancellationToken token)
        {
            try
            {
                //Access via HTTP to the feed and download data as a string
                var client = new HttpClient();
                this.Items = null;
                this.Items = new List<YouTubeItem>();
                string url = ChannelUrl;
                string data = await client.GetStringAsync(new Uri(url));
                //var actualData = await data.Content.ReadAsStringAsync();

                //Execute a LINQ to XML query against the feed
                var doc = XDocument.Parse(data);
                var media = XNamespace.Get("http://search.yahoo.com/mrss/");
                var yt = XNamespace.Get("http://www.youtube.com/xml/schemas/2015");
                var atomns = XNamespace.Get("http://www.w3.org/2005/Atom");

                var query = (from entry in doc.Descendants(atomns.GetName("entry"))
                             select new YouTubeItem
                             {
                                 Title = entry.Element(atomns.GetName("title")).Value,
                                 Link = entry.Element(atomns.GetName("link")).Attribute("href").Value,
                                 IconUrl = "YouTube.png",
                                 PubDate = DateTime.Parse(entry.Element(atomns.GetName("published")).Value, System.Globalization.CultureInfo.InvariantCulture),
                                 ThumbnailUrl = (from thumbnail in entry.Descendants(media.GetName("thumbnail"))
                                                 select thumbnail.Attribute("url").Value).FirstOrDefault()
                             });

                if (query.Any()) Items.AddRange(query);

                return Items.OrderByDescending(p => p.PubDate).AsEnumerable();
            }
            catch (Exception)
            {
                if (Items != null) return Items; else return null;
            }
        }
    }
}
