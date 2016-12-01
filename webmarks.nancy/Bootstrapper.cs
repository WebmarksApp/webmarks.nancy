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

            //Conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/", @"public"));
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            //var connString = "mongodb://localhost:27017";
            //var connString = Environment.GetEnvironmentVariable("MONGOLAB_URI");
            var connString = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
            var databaseName = "speakersdb";

            var mongoClient = new MongoClient(connString);

            //MongoServer server = mongoClient.GetServer();
            var database = mongoClient.GetDatabase(databaseName);

            var collection = database.GetCollection<Speaker>("speakers");

            container.Register(database);
            container.Register(collection);
        }
    }
}