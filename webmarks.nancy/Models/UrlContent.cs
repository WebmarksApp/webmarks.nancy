using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/*
{
  "title": "Why You Should Take Another Look at C#",
  "author": null,
  "date_published": null,
  "dek": null,
  "lead_image_url": "https://images.contentful.com/emmiduwd41v7/INqdGT1a2OOC6uY4Kc26C/f2161fb110e41e2cc42866e629d70100/gotocph-mads-torgersen-facebook.png",
  "content": "<div class=\"js-content-container\"> <p>Because you can and because you want to! You <em>can</em> because C# runs great on Mac, Linux, Android, and iOS (oh, and Windows); is targeted by your favorite editor; rests on a rock solid, time-tested industrial grade platform; and is open source. </div>",
  "next_page_url": null,
  "url": "https://realm.io/news/goto-mads-torgersen-why-take-another-look-at-c-sharp/",
  "domain": "realm.io",
  "excerpt": "Mads Torgersen talks about C#, and why it may be worth thinking about (even if you have not so far!)",
  "word_count": 6800,
  "direction": "ltr",
  "total_pages": 1,
  "rendered_pages": 1
}
//*/

namespace webmarks.nancy.Models
{

    public class UrlContent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string excerpt { get; set; }
        public string content { get; set; }
    }
}