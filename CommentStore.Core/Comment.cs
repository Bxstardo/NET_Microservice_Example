using MongoDB.Bson.Serialization.Attributes;

namespace CommentStore.Core
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Description { get; set; }
        public string ResultadoId { get; set; }
    }
}
