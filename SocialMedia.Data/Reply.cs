using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }

        // Foreign Key to Comment via Id w/ virtual Comment

        [Required]
        public string Text { get; set; }
        [Required]
        public Guid AuthorID { get; set; }
    }
}
