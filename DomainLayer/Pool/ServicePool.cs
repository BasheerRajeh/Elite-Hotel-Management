using DomainLayer.AppServices;
using Elite.DataAccess.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Pool
{
    public class ServicePool : IServicePool
    {

        public CategoryService CategoryService { get; }

        public ServicePool(IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            CategoryService = new CategoryService(unitOfWork, httpContextAccessor);
        }
    }
}
