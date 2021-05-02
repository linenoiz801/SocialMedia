using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class LikeListItem
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Guid OwnerId { get; set; }
    }
}
