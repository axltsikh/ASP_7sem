using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WebServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlReader reader = XmlReader.Create("http://localhost:3000/SyndicationService/Notes/");
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            Console.WriteLine(feed.Title.Text);
            foreach(SyndicationItem a in feed.Items)
            {
                Console.WriteLine(a.Id);
                Console.WriteLine(a.Title.Text);
                Console.WriteLine(a.Summary.Text);
                Console.WriteLine(a.LastUpdatedTime);
            }
            Console.ReadLine();
        }
    }
}
