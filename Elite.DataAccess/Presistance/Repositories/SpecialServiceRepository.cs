﻿using Elite.AppDbContext;
using Elite.DataAccess.Core.IRepositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite.DataAccess.Presistance.Repositories
{
    public class SpecialServiceRepository : Repository<SpecialService>, ISpecialServiceRepository
    {
        private readonly HotelContext _db;

        public SpecialServiceRepository(HotelContext db) : base(db)
        {
            _db = db;
        }
    }
}