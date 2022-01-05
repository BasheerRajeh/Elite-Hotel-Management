using Elite.AppDbContext;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Elite.DataAccess.Core.IRepositories
{
    public interface IRoomStatusRepository : IRepository<RoomStatus>
    {
        IEnumerable<SelectListItem> GetRoomStatusForDropDown();

        void Update(RoomStatus roomStatus);
    }
}