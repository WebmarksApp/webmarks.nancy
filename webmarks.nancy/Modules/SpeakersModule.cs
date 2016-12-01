using MongoDB.Driver;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webmarks.nancy.Models;

namespace webmarks.nancy.Modules
{
    public class SpeakersModule : NancyModule
    {
        private readonly IMongoCollection<Speaker> speakersCollection;

        public SpeakersModule(IMongoCollection<Speaker> collection) : base("/api")
        {
            speakersCollection = collection;

            Get["/speakers"] = GetSpeakers;

            Post["/speakers/"] = PostSpeakers;
        }

        private dynamic GetSpeakers(dynamic parameters)
        {
            IList<Speaker> speakers = speakersCollection.AsQueryable<Speaker>().ToList();
            //return speakers;
            //Response.AsJson<IList<Speaker>>(speakers);
            return Negotiate.WithModel(speakers);
        }

        private dynamic PostSpeakers(dynamic parameters)
        {
            Speaker speaker = this.Bind<Speaker>();
            speakersCollection.InsertOne(speaker);
            return speaker;
        }
    }
}