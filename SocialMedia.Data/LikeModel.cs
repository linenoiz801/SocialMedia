using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class LikeModel
    {
        [Key]
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
    }
}
