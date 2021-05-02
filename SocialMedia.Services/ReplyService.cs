using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;
        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    AuthorID = _userId,
                    Text = model.Text,
                    CommentID = model.CommentId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        private CommentListItem GetCommentById(int commentId)
        {
            CommentListItem result = new CommentListItem();
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.Id == commentId);
                result.AuthorId = _userId;
                result.Id = entity.Id;
                result.CommentText = entity.CommentText;
            }

            return result;
        }

        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(e => e.AuthorID == _userId)
                        .Select(
                            e =>
                                new ReplyListItem
                                {
                                    Id = e.Id,
                                    Text = e.Text,
                                    CommentID = (int)e.CommentID
                                    //Comment = GetCommentById(e.Id)
                                }
                         );
                return query.ToArray();
            }
        }
    }
}
