using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DAL
    {
        static ApiDBEntities DbContext;

        static DAL()
        {
            DbContext = new ApiDBEntities();
        }
        public static List<Product> GetAllProducts()
        {
            return DbContext.Products.ToList();
        }
        public static Product GetProduct(int productId) {
            return DbContext.Products.Where(p => p.ProductId == productId).FirstOrDefault();
        }
        public static bool InsertProduct(Product product)
        {
            bool status;

            try
            {
                DbContext.Products.Add(product);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool UpdateProduct(Product product)
        {
            bool status;

            try
            {
                Product prodItem = DbContext.Products.Where(p => p.ProductId == product.ProductId).FirstOrDefault();
                if (prodItem != null)
                {
                    prodItem.ProductName = product.ProductName;
                    prodItem.Quantity = product.Quantity;
                    prodItem.Price = product.Price;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public static bool DeleteProduct(int id)
        {
            bool status;
            try
            {
                Product product = DbContext.Products.Where(p => p.ProductId == id).FirstOrDefault();

                if (product != null)
                {
                    DbContext.Products.Remove(product);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
