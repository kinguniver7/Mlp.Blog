using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mlp.Blog.Core.Domain
{
    public interface IKey<TKey>
    {
        TKey Id { get; set; }
    }
}
