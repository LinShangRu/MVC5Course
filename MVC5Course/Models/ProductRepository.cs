using System;
using System.Linq;
using System.Collections.Generic;

namespace MVC5Course.Models
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }

        public override IQueryable<Product> All()
        {
            //return base.All().Where(m => false == m.IsDeleted &&  m.Stock < 500);
            return base.All().Where(m => false == m.IsDeleted);
        }

        public IQueryable<Product> All(bool showAll)
        {
            if (showAll)
            {
                return base.All();
            }
            else
            {
                return this.All();
            }
        }

        public override void Delete(Product entity)
        {
            entity.IsDeleted = true;
            //base.Delete(entity);
        }
    }

    public interface IProductRepository : IRepository<Product>
    {

    }
}