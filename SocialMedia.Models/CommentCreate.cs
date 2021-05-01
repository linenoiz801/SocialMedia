using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    class CommentCreate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage ="Please Enter More Charaters.")]
        [MaxLength (6000,ErrorMessage ="You Entered Too Many Characters.")]
        public string CommentText { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
    }
}
