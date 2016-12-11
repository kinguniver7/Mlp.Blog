using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mlp.Blog.Core.Domain
{
    /// <summary>
    /// Post - news
    /// </summary>
    public class Post: ICreated, IUpdated, IDeleted
    {
        public int Id { get; set; }
        /// <summary>
        /// Author ID
        /// </summary>
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser User { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Content - full content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Content - short content(preview)
        /// </summary>
        public string ShortContent { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool IsDeleted { get; set; }

        public string PostType { get;}
        
        /// <summary>
        /// Return current PostType
        /// </summary>
        /// <returns></returns>
        public PostType GetPostType()
        {
            switch (this.PostType)
            {
                case "post":
                    return Domain.PostType.Post;
                case "page":
                    return Domain.PostType.Page;
                default:
                    throw new Exception("PostType is not available! Please, a set is correct of type!");
            }
        }

        /// <summary>
        /// Set current PostType
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string SetPostType(PostType type)
        {
            string result;
            switch (type)
            {
                case Domain.PostType.Post:
                    result = "post";
                    break;
                case Domain.PostType.Page:
                    result = "page";
                    break;
                default:
                    throw new Exception("PostType is not available! Please, a set is correct of type!");
            }
            return result;
        }

        /// <summary>
        /// Collection of comments
        /// </summary>
        public virtual IQueryable<Comment> Comments { get; set; }
    }
}
