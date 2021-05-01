using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SocialMedia.Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        public CommentService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    AuthorId = model.AuthorId,

                    CommentText = model.CommentText,

                    PostId = model.PostId

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.AuthorId == _userId)
                        .Select(
                        e =>
                            new CommentListItem
                            {
                                AuthorId = e.AuthorId,
                                CommentText = e.CommentText,
                                PostId = e.PostId,
                                Id = e.Id
                            }
                        );
                return query.ToArray();
            }
        }
    }
}
