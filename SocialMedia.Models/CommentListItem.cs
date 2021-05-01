using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
   public class CommentListItem
    {
        public int Id { get; set; }
        
        public string CommentText { get; set; }
     
        public Guid AuthorId { get; set; }
        
        public int PostId { get; set; }
        public virtual PostListItem Post { get; set; }
    }
}
