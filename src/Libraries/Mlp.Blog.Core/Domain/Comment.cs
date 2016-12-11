using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mlp.Blog.Core.Domain
{
    public class Comment : ICreated
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser User { get; set; }

        public string Text { get; set; }

        public string IpAddress { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }


    }
}
