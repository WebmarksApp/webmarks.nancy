using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace webmarks.nancy.Models
{
    public class Speaker
    {
        public Speaker()
        {
        }

        public Speaker(string firstname, string lastname, string session, string image)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.image = image;
            this.session = session;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string image { get; set; }
        public string session { get; set; }
    }
}