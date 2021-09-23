using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentStore.Core
{
    public class CommentServices : ICommentServices
    {
        private readonly IMongoCollection<Comment> _comments;
        public CommentServices(IDbClient dbClient)
        {
            _comments = dbClient.GetCommentsCollection();
        }

        public Comment AddComent(Comment comment)
        {
            _comments.InsertOne(comment);
            return comment;
        }

        public Comment GetComment(string id) => _comments.Find(comment => comment.Id == id).First();

        public void DeleteComment(string id)
        {
            _comments.DeleteOne(comment => comment.Id == id);
        }
        public List<Comment> GetComments()
        {
            return _comments.Find(book => true).ToList();
        }

        public Comment UpdateComment(Comment comment)
        {
            GetComment(comment.Id);
            _comments.ReplaceOne(c => c.Id == comment.Id, comment);
            return comment;
        }
    }
}
