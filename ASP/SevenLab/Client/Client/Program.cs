using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlReader reader = XmlReader.Create("http://localhost:8000/BlogService/");
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            Console.WriteLine(feed.Title.Text);
            foreach (SyndicationItem a in feed.Items)
            {
                var b = (TextSyndicationContent)a.Content;
                Console.WriteLine(a.Id);
                Console.WriteLine(a.Title.Text);
                Console.WriteLine(b.Text);
                Console.WriteLine(a.LastUpdatedTime);            }
            Console.ReadLine();
        }
    }
}
