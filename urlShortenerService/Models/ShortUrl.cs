using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace urlShortenerService.Models
{
    public class ShortUrl
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Url")]
        public string Url { get; set; }

        [BsonElement("LongUrl")]
        public string LongUrl { get; set; }
    }
}