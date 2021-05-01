using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CommentText { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        //public virtual List<Replies> CommentReplies { get; set; }

    }
}
