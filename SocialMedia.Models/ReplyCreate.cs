using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class ReplyCreate
    {
        public string Text { get; set; }
        public int CommentId { get; set; }
        public string CommentText { get; set; }
    }
}
