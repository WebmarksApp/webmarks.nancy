using Nancy;

namespace webmarks.nancy.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = Index;

            Get["/api"] = Index;
        }

        private dynamic Index(dynamic parameters)
        {
            return Response.AsFile("Content/index.html", "text/html");
        }
    }
}