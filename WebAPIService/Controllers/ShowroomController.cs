using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPIService.Repository;

namespace WebAPIService.Controllers
{
    public class ShowroomController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.Product>> GetAllProducts()
        {
            EntityMapper<DataAccessLayer.Product, Models.Product> mapObj = new EntityMapper<Product, Models.Product>();
            List<DataAccessLayer.Product> prodList = DAL.GetAllProducts();
            List<Models.Product> products = new List<Models.Product>();
            foreach (var item in prodList)
            {
                products.Add(mapObj.Translate(item));
            }
            return Json<List<Models.Product>>(products);
        }

        [HttpGet]
        public JsonResult<Models.Product> GetProduct(int id)
        {
            EntityMapper<DataAccessLayer.Product, Models.Product> mapObj = new EntityMapper<Product, Models.Product>();
            DataAccessLayer.Product dalProduct = DAL.GetProduct(id);
            Models.Product products = new Models.Product();
            products = mapObj.Translate(dalProduct);
            return Json<Models.Product>(products);
        }

        [HttpPost]
        public bool InsertProducts(Models.Product product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<Models.Product, DataAccessLayer.Product> mapObj = new EntityMapper<Models.Product, Product>();
                DataAccessLayer.Product productObj = new DataAccessLayer.Product();
                productObj = mapObj.Translate(product);
                status = DAL.InsertProduct(productObj);
            }
            return status;
        }
        [HttpPut]
        public bool UpdateProduct(Models.Product product)
        {
            EntityMapper<Models.Product, DataAccessLayer.Product> mapObj = new EntityMapper<Models.Product, DataAccessLayer.Product>();
            DataAccessLayer.Product productObj = new DataAccessLayer.Product();
            productObj = mapObj.Translate(product);
            var status = DAL.UpdateProduct(productObj);
            return status;
        }
        [HttpDelete]
        public bool DeleteProduct(int id)
        {
            var status = DAL.DeleteProduct(id);
            return status;
        }
    }
}
