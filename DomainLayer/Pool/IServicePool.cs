using DomainLayer.AppServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Pool
{
    public interface IServicePool
    {
        public CategoryService CategoryService { get; }
    }
}
