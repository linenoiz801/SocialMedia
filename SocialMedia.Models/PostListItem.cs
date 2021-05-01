using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class PostListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }        
        public Guid AuthorId { get; set; }
        //public virtual List<Comment> Comments { get; set; } = new List<Comment>();
        //public virtual List<Like> Likes { get; set; } = new List<Like>();
    }
}
