using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;

namespace SyndicationServiceLibrary2
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Feed1" в коде и файле конфигурации.
    [ServiceBehavior]
    public class Feed1 : IFeed1
    {

        public SyndicationFeedFormatter CreateFeed()
        {
            SyndicationFeed feed = new SyndicationFeed(
                title: "Оценки",
                description: "Успеваемость студентов по трем различным предметам",
                null
                );
            feed.Items = getNotesFromService();
            feed.LastUpdatedTime = DateTime.Now;

            //var rssFeed = new Rss20FeedFormatter(feed);
            //var atomFeed = new Atom10FeedFormatter(feed);
            string query = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["format"];
            return (query == "atom") ? (SyndicationFeedFormatter)new Atom10FeedFormatter(feed) : new Rss20FeedFormatter(feed);
        }

        private List<SyndicationItem> getNotesFromService()
        {
            SixthLabModel.SixthLabEntities entities = new SixthLabModel.SixthLabEntities(new Uri("http://localhost:53920/WcfDataService1.svc/"));
            List<SyndicationItem> notes = new List<SyndicationItem>();
            foreach (var a in entities.Notes)
            {
                string student = entities.Students.Where(e => e.id == a.studentId).First().name;
                notes.Add(new SyndicationItem(a.subject, student, new Uri("http://localhost/" + a.id.ToString()), a.note1.ToString(), DateTime.Now));
            }
            return notes;
        }
    }
}
