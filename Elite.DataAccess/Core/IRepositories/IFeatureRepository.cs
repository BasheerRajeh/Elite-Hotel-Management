using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using Elite.AppDbContext;

namespace Elite.DataAccess.Core.IRepositories
{
    public interface IFeatureRepository: IRepository<Feature>
    {
        IEnumerable<SelectListItem> GetFeatureForDropDown();

        void Update(Feature feature);
    }
}
