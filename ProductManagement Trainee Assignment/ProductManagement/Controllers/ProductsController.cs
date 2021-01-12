using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ProductManagement.ViewModels;
using ProductManagement.Dtos;
using System.Data.Entity.Validation;
using System.IO;
using log4net;

namespace ProductManagement.Controllers
{
    public class ProductsController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ProductsController));
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Products
        [Authorize]
        public ActionResult Index()
        {
            try
            {

                //request Products data From API
                IEnumerable<Product> Products;
                HttpResponseMessage response = GlobalVariables.WebApiClient
                  .GetAsync("Products").Result;

                Products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;

                var ProductListViewModel = new ProductListViewModel
                {
                    Products = Products
                };

                return View("List", ProductListViewModel);

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                TempData["ErrorMessage"] = "There was some problem in processing your request .Pleasetry again later";
                return View("error");
            }
        }


        [Authorize]
        public ActionResult New()
        {
            //Get Categories
            HttpResponseMessage response = GlobalVariables.WebApiClient
             .GetAsync("Categories").Result;


            var ProductFormViewModel = new ProductFormViewModel
            {
                Title = "New Product",
                Categories = response.Content.ReadAsAsync<IEnumerable<Category>>().Result,
                Product = new Product()
            };

            return View("ProductForm", ProductFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Save(Product product, HttpPostedFileBase SmallImage, HttpPostedFileBase LargeImage)
        {
            HttpResponseMessage response;

            //return if model is invalid or no small product image is recieved
            if (!ModelState.IsValid || (SmallImage == null && String.IsNullOrEmpty(product.SmallImage)))
            {
                response = GlobalVariables.WebApiClient
                                               .GetAsync("Categories").Result;
                var viewModel = new ProductFormViewModel
                {
                    Product = product,
                    Categories = response.Content.ReadAsAsync<IEnumerable<Category>>().Result,
                    Title = "New Product"
                };

                TempData["ErrorMessage"] = "Please Verify Data and Also Provide Small Image for Product";

                return View("ProductForm", viewModel);
            }

            //For New Product
            if (product.Id == 0)
            {
                product.SmallImage = SaveImage(SmallImage);
                product.LargeImage = SaveImage(LargeImage);

                response = GlobalVariables.WebApiClient.PostAsJsonAsync("Products", product).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                //For updating existing product

                if (SmallImage != null)
                {
                    DeleteImage(product.SmallImage);
                    product.SmallImage = SaveImage(SmallImage);
                }

                if (LargeImage != null)
                {
                    DeleteImage(product.LargeImage);
                    product.LargeImage = SaveImage(LargeImage);
                }

                response = GlobalVariables.WebApiClient.PutAsJsonAsync("Products/" + product.Id, product).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index", "Products");
        }

        [Authorize]
        public ActionResult edit(int id)
        {
            //Request for Product and categories
            HttpResponseMessage productResponse = GlobalVariables.WebApiClient.GetAsync("Products/" + id).Result;
            HttpResponseMessage categoryResponse = GlobalVariables.WebApiClient.GetAsync("Categories").Result;

            //Extract Response Data
            Product product = productResponse.Content.ReadAsAsync<Product>().Result;
            IEnumerable<Category> categories = categoryResponse.Content.ReadAsAsync<IEnumerable<Category>>().Result;

            if (product == null)
                return View("Error");

            var viewModel = new ProductFormViewModel
            {
                Product = product,
                Categories = categories,
                Title = "Edit Product Details"
            };
            return View("ProductForm", viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult DeleteMultiple(FormCollection formCollection)
        {
            //verify if id has some value
            if (formCollection["ID"] == null)
            {
                TempData["ErrorMessage"] = "No Records Selected for Deletion";
                return RedirectToAction("index");
            }

            string[] ids = formCollection["ID"].Split(new char[] { ',' });
            HttpResponseMessage ProductResponse;

            //send delete request and delete images side by side
            foreach (string id in ids)
            {
                ProductResponse = GlobalVariables.WebApiClient.DeleteAsync("products/" + id).Result;
                if (ProductResponse.IsSuccessStatusCode)
                {
                    var Product = ProductResponse.Content.ReadAsAsync<Product>().Result;
                    DeleteImage(Product.SmallImage);
                    DeleteImage(Product.LargeImage);

                }

            }
            TempData["SuccessMessage"] = "Successfully Deleted " + ids.Count().ToString() + " product";

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            try
            {

                //get record
                Product product;
                HttpResponseMessage productResponse = GlobalVariables.WebApiClient.GetAsync("Products/" + id).Result;

                if (productResponse.IsSuccessStatusCode)
                {
                    //extract product details
                    product = productResponse.Content.ReadAsAsync<Product>().Result;

                    //delete record and then images
                    HttpResponseMessage productDeleteResponse = GlobalVariables.WebApiClient.DeleteAsync("Products/" + id).Result;

                    if (productDeleteResponse.IsSuccessStatusCode)
                    {
                        DeleteImage(product.SmallImage);
                        DeleteImage(product.LargeImage);
                        TempData["SuccessMessage"] = "Deleted Successfully";
                        //log this
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Operation Failed";
                        //log this

                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid Product Id";
                }
                return RedirectToAction("index");



            }
            catch (Exception ex)
            {

                Log.Error(ex.Message, ex);
                TempData["ErrorMessage"] = "There was some problem in processing your request .Pleasetry again later";
                return View("error");
            }



        }


        [Authorize]
        public ActionResult Details(int id)
        {
            HttpResponseMessage productResponse = GlobalVariables.WebApiClient.GetAsync("Products/" + id).Result;
            var Product = productResponse.Content.ReadAsAsync<Product>().Result;
            if (Product == null)
            {
                TempData["ErrorMessage"] = "Product Not Found";
                return View("Error");
            }
            return View(Product);
        }

        private string SaveImage(HttpPostedFileBase Image)
        {
            try
            {


                if (Image == null) return "Not Available";

                //check image Availablity

                string path = Server.MapPath("~/ProductImages/");

                //verify destination path
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //generate dynamic name and path for image and save finally
                string imagePath = "";
                string fileName = Path.GetFileNameWithoutExtension(Image.FileName);
                string fileExtension = Path.GetExtension(Image.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtension;
                imagePath = "~/ProductImages/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/ProductImages/"), fileName);
                Image.SaveAs(fileName);

                return imagePath;
            }
            catch (Exception ex)
            {

                Log.Error(ex.Message, ex);
                TempData["ErrorMessage"] = "There was some problem in processing your request .Pleasetry again later";
                return "";
            }

        }

        private void DeleteImage(string path)
        {
            try
            {
                if (path == null)
                    return;

                string imagePathOnServer = Request.MapPath(path);

                if (System.IO.File.Exists(imagePathOnServer))
                {
                    System.IO.File.Delete(imagePathOnServer);
                }

            }
            catch (Exception ex)
            {

                Log.Error(ex.Message, ex);
                TempData["ErrorMessage"] = "There was some problem in processing your request .Pleasetry again later";
            }

        }
    }
}