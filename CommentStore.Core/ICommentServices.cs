using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentStore.Core
{
    public interface ICommentServices
    {
        List<Comment> GetComments();
        Comment AddComent(Comment comment);
        Comment GetComment(string id);
        void DeleteComment(string id);
        Comment UpdateComment(Comment comment);
    }
}
