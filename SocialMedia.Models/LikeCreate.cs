using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class LikeCreate
    {
        public int PostId { get; set; }
        public Guid OwnerId { get; set; }
    }
}
