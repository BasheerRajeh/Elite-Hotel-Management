using Elite.AppDbContext;
using Elite.AppDbContext.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Elite.DataAccess.Core.IRepositories
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        void LockUser(string userId);

        void UnLockUser(string userId);
    }
}