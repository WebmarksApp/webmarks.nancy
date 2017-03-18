using MongoDB.Driver;
using Nancy;
using Nancy.Conventions;
using Nancy.TinyIoc;
using System;
using System.Configuration;
using webmarks.nancy.Models;

namespace webmarks.nancy
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            Conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/", @"Content"));
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            //var connString = "mongodb://localhost:27017";
            var connString = Environment.GetEnvironmentVariable("MONGOLAB_URI");
            if(connString == null)
            {
                connString = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
            }

            //var databaseName = "speakersdb";
            var databaseName = "appharbor_pq17xkjp";

            var mongoClient = new MongoClient(connString);

            var database = mongoClient.GetDatabase(databaseName);

            var speakersCollection = database.GetCollection<Speaker>("speakers");

            var contentCollection = database.GetCollection<UrlContent>("contents");

            container.Register(database);
            container.Register(speakersCollection);
            container.Register(contentCollection);
        }
    }
}