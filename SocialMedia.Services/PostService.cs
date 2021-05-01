using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class PostService
    {
        private readonly Guid _userId;
        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    AuthorId = _userId,
                    Text = model.Text,
                    Title = model.Title
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }       
        private List<CommentListItem> GetCommentsByPostId(int postId)
        {
            List<CommentListItem> result = new List<CommentListItem>();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.PostId == postId)
                        .Select(
                            e => new CommentListItem
                            {
                                Id = e.Id,
                                PostId = e.PostId,
                                CommentText = e.CommentText,
                                AuthorId = e.AuthorId
                            }
                        );
                return query.ToList();
            }
        } 
        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.AuthorId == _userId)
                        .Select(
                            e =>
                                new PostListItem
                                {
                                    AuthorId = _userId,
                                    Id = e.Id,
                                    Title = e.Title,
                                    Comments = GetCommentsByPostId(e.Id)
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
