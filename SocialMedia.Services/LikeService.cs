using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class LikeService
    {
        private readonly Guid _userId;
        public LikeService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateLike(LikeCreate model)
        {
            var entity =
                new Like()
                {
                    OwnerId = _userId,
                    PostId = model.PostId
                };
            using (var ctx=new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LikeListItem> GetLikesByPostId(int postId)
        {
            using (var ctx=new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Likes
                        .Where(e => e.PostId == postId)
                        .Select(
                            e =>
                                new LikeListItem
                                {
                                    Id = e.Id,
                                    OwnerId = e.OwnerId,
                                    PostId = e.PostId,
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
