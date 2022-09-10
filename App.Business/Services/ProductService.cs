using App.Data.DBContext;
using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Business.Services
{
    public class ProductService
    {
        private readonly AppDBContext _dBContext;
        
        public ProductService(AppDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        //GET ALL PRODUCTS
        public async Task<List<Product>> GetProductList()
        {
            var productList =await _dBContext.Products.ToListAsync();
            return productList;
        }

        //Add Product  
        public async Task<Product> Create(Product model)
        {
            var obj = await _dBContext.Products.AddAsync(model);
            _dBContext.SaveChanges();
            return obj.Entity;
        }

        //Delete Product
        public void Delete(Product model)
        {
            _dBContext.Remove(model);
            _dBContext.SaveChanges();
        }
        //Delete Product By Title   
        public bool DeleteProduct(string Title)
        {

            try
            {
                var DataList = _dBContext.Products.Where(x => x.Title == Title).ToList();
                foreach (var item in DataList)
                {
                    Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        //Update
        public void Update(Product model)
        {
            _dBContext.Products.Update(model);
            _dBContext.SaveChanges();
        }

        //Update Person Details  
        public bool UpdateProduct(Product product)
        {
            try
            {
                var DataList = _dBContext.Products.ToList();
                foreach (var item in DataList)
                {
                    Update(item);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    

    public List<Product> YEdekGetProductList()
        {
            var productList = new List<Product> {
                    new Product
                    {
                        Id = 1,
                        Title = "Product1",
                        ImagePath = "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png"
                    },
                    new Product
                    {
                        Id = 2,
                        Title = "Product2",
                        ImagePath = "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png"
                    }
            };

            return productList;
        }


    }
}
