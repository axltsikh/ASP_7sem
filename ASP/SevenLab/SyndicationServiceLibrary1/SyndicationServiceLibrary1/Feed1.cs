using Microsoft.Samples.JsonFeeds;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;

namespace SyndicationServiceLibrary1
{
    [ServiceBehavior]
    public class Feed1 : IFeed1
    {
        public SyndicationFeedFormatter CreateFeed()
        {
            var alternate = new Uri("http://localhost:53920/WcfDataService1.svc/");
            var feed = new SyndicationFeed(
                "Оценки",
                "Успеваемость студентов по трем предметам",
                alternate
            );
            feed.Items = getNotesFromService();
            feed.LastUpdatedTime = DateTime.Now;

            //var rssFeed = new Rss20FeedFormatter(feed);
            //var atomFeed = new Atom10FeedFormatter(feed);
            string query = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["format"];
            return (query == "json") ? (SyndicationFeedFormatter)new JsonFeedFormatter(feed) : new Atom10FeedFormatter(feed);
        }

        private List<SyndicationItem> getNotesFromService()
        {
            SixthLabModel.SixthLabEntities entities = new SixthLabModel.SixthLabEntities(new Uri("http://localhost:53920/WcfDataService1.svc/"));
            List<SyndicationItem> notes = new List<SyndicationItem>();
            
            foreach (var a in entities.Notes)
            {
                string student = entities.Students.Where(e => e.id == a.studentId).First().name;
                notes.Add(new SyndicationItem(a.subject, student + ": " + a.note1.ToString(), new Uri("http://localhost:53920/WcfDataService1.svc/Notes(" + a.id.ToString() + ")"), a.id.ToString(), DateTime.Now));
            }
            return notes;
        }
    }
}
