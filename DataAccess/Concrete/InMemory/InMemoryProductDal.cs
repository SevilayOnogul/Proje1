﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle,Mongodb,Sql gibi veritabanından gelsin
            _products = new List<Product>
         {
             new Product{ProductId=1,ProductName="Klavye",UnitPrice=15,UnitsInStock=15},
             new Product{ProductId=2,ProductName="Mause",UnitPrice=25,UnitsInStock=10},
             new Product{ProductId=3,ProductName="Led",UnitPrice=55,UnitsInStock=75}
         };       
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete=_products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=>p.CategoryId==categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate=_products.SingleOrDefault(p=>p.ProductId== product.ProductId);
            productToUpdate.ProductName=product.ProductName;
            productToUpdate.CategoryId=product.CategoryId;
            productToUpdate.UnitPrice=product.UnitPrice;
            productToUpdate.UnitsInStock=product.UnitsInStock;
        }
    }
}
