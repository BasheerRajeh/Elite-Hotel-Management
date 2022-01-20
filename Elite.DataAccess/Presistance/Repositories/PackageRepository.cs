using Elite.AppDbContext;
using Elite.DataAccess.Core.IRepositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite.DataAccess.Presistance.Repositories
{
    public class PackageRepository : Repository<Package>, IPackageRepository
    {
        private readonly HotelContext _db;

        public PackageRepository(HotelContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetPackageForDropDown()
        {
            return _db.Package.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
        }

        /*        public void Update(Package package)
                {
                    var objFromDb = _db.Package.FirstOrDefault(s => s.Id == package.Id);
                    objFromDb.Name = package.Name;
                    objFromDb.RoomId = package.RoomId;
                    objFromDb.FeatureId = package.FeatureId;

                    _db.SaveChanges();
                }
        */
    }
}