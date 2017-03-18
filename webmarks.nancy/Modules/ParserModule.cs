using MongoDB.Driver;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webmarks.nancy.Models;

namespace webmarks.nancy.Modules
{
    public class ParserModule : NancyModule
    {
        private readonly IMongoCollection<UrlContent> contentCollection;

        public ParserModule(IMongoCollection<UrlContent> collection) : base("/api")
        {
            contentCollection = collection;

            Get["/parser"] = GetContent;

        }

        private dynamic GetContent(dynamic parameters)
        {
            UrlContent content = new UrlContent();
            content.url = parameters.url;

            int[] rev = new int[10];

            return Negotiate.WithModel(content);
        }
    }
}