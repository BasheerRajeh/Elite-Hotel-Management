using DomainLayer.Dtos;
using Elite.AppDbContext;
using Elite.DataAccess.Core;
using Elite.DataAccess.Core.IRepositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DomainLayer.AppServices
{
    public class CategoryService : BaseService.BaseService<
        CategoryDto, ICategoryRepository, Category>
    {
        public CategoryService(IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor) : base(unitOfWork,
                httpContextAccessor)
        {

        }

        public override ICategoryRepository DbRepo => UnitOfWork.Category;

        public override CategoryDto Create(CategoryDto dto)
        {
            return base.Create(dto);
        }

        public override CategoryDto Update(CategoryDto dto)
        {
            return base.Update(dto);
        }

        public List<CategoryDto> GetAll(Expression<Func<Category, bool>> condition = null)
        {
            return Mapper.Map<List<CategoryDto>>(DbRepo.GetAll(condition));
        }

        public void TestMethod()
        {
            GetAll();
        }
    }
}
