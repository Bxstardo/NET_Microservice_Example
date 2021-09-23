using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentStore.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Comment> _comments;
        public DbClient(IOptions<ElementicDbConfig> elementicDbConfig)
        {
            var client = new MongoClient(elementicDbConfig.Value.Connection_String);
            var database = client.GetDatabase(elementicDbConfig.Value.Database_Name);
            _comments = database.GetCollection<Comment>(elementicDbConfig.Value.Comments_Collection_Name);

        }
        public IMongoCollection<Comment> GetCommentsCollection() => _comments;
    }
}
