using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mlp.Blog.Core.Domain
{
    public interface ICreated: IKey<int>
    {
        DateTime CreatedDate { get; set; }
    }

    public interface IUpdated : IKey<int>
    {
        DateTime? UpdatedDate { get; set; }
    }

    public interface IDeleted : IKey<int>
    {
        DateTime? DeletedDate { get; set; }

        bool IsDeleted { get; set; }
    }
}
