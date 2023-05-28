using ConnectDBWEB.Models;
using DBcon;
using DBcon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Immutable;
using System.Data;

namespace ConnectDBWEB.Controllers
{
    public class ProductController : Controller
    {
        public List<Product> products { get; set; }
        //DB_Context
        DB_Context _dbContext;
        public ProductController()
        {
            _dbContext = new DB_Context(@"Data Source=RAHUL\SQLEXPRESS;Initial Catalog=MVCSQL;User ID=Ajay;Password=Ajay");
        }

        // GET: ProductController
        public ActionResult Index()
        {
            //products = MyProduct();
            int id = 0;
            List<ProductM> products = _dbContext.GetProduct(id);
            List<Product> productList = products.Select(p => new Product
            {
                ProId = p.ID,
                ProName = p.Name,
                ProDetail = p.Description
                // Assign values to other properties as needed
            }).ToList();

            return View(productList);
        }
        public List<Product> MyProduct()
        {
            products = new List<Product>()
            {
                new Product{ProId=1,ProName="TV",ProDetail="TV Details"},
                new Product{ProId=2,ProName="Ac",ProDetail="AC Details"},
                new Product{ProId=3,ProName="Mobile",ProDetail="Mobile Details"}
            };
            return products;
        }


        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            Product p = new Product();
            List<ProductM> product = new List<ProductM>();
            product = _dbContext.GetProduct(id);
            //valueList.FirstOrDefault(x => x.Name == nameToFind)?.Value;
            foreach (var pro in product)
            {
                p.ProId= pro.ID; p.ProName= pro.Name;p.ProDetail = pro.Description;
            }

            return View(p);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            string Labelerror = null;
            try
            {
                products = MyProduct();

                ProductM productsAdd = new ProductM()
                {
                   // ID= Convert.ToInt32(collection["ProId"]),
                    Name =collection["ProName"],
                    Description=collection["ProDetail"]
                };
                int inserted =  _dbContext.AddProduct(productsAdd);

                //return RedirectToAction(nameof(Index));
                if (inserted > 0)
                {
                    return RedirectToAction("Index");
                }
                else {
                    Labelerror = "Error faced";
                    return View();
                }
            }
            catch
            {
                Labelerror = "Error faced";
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            Product p = new Product();
            List<ProductM> product = new List<ProductM>();
            product = _dbContext.GetProduct(id);
            //valueList.FirstOrDefault(x => x.Name == nameToFind)?.Value;
            foreach (var pro in product)
            {
                p.ProId = pro.ID; p.ProName = pro.Name; p.ProDetail = pro.Description;
            }

            return View(p);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                //products.Where(p => p.ProId == id).ToList().ForEach(p =>
                //{
                //    p.ProName = collection["ProName"];
                //    p.ProDetail = collection["ProDetail"];
                //});
                ProductM productsEdit = new ProductM()
                {
                    ID= Convert.ToInt32(collection["ProId"]),
                    Name = collection["ProName"],
                    Description = collection["ProDetail"]
                };
                int inserted = _dbContext.EditProduct(productsEdit);

                //return RedirectToAction(nameof(Index));
                if (inserted > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                   // Labelerror = "Error faced";
                    return View();
                }


                Product p = new Product();
                List<ProductM> product = new List<ProductM>();
                product = _dbContext.GetProduct(id);
                foreach (var pro in product)
                {
                    p.ProId = pro.ID; p.ProName = pro.Name; p.ProDetail = pro.Description;
                }

                return View(p);

               // return View("Index", products);
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
