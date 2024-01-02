using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Project.Controllers
{
    public class GetProductController : Controller
    {
        // GET: GetProduct
        public ActionResult GetProduct()
        {
            GetProductDB db = new GetProductDB();
            List<GetProduct> obj = db.getProducts();

            return View(obj);
        }

        public ActionResult AddProduct()
        {


            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(GetProduct prr)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    GetProductDB contex = new GetProductDB();
                    bool check = contex.AddProduct(prr);
                    if (check)
                    {
                        TempData["InsertMessage"] = "Data has been inserted sucessfully";
                        ModelState.Clear();
                        return RedirectToAction("GetProduct");
                    }
                    else
                    {
                        TempData["InsertMessage"] = "ID is already Existed";
                        
                        return View("AddProduct");
                    }
                }
            }
            catch 
            {
                TempData["InsertMessage"] = "ID is too long it should be 3 digits long.";
                return View();
            }



            return View();
        }




        public ActionResult Edit(string ID)
        {
            GetProductDB obj = new GetProductDB();
            var row = obj.getProducts().Find(model => model.fb_ID == ID);

            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(string ID , GetProduct prr)
        {
            if (ModelState.IsValid == true)
            {
                GetProductDB contex = new GetProductDB();
                bool check = contex.UpdateProduct(prr);
                if (check)
                {
                    TempData["UpdateMessage"] = "Data has been updated sucessfully";
                    ModelState.Clear();
                    return RedirectToAction("GetProduct");
                }
                else
                {
                    TempData["UpdateMessage"] = "ID is already Existed";

                    return View("GetProduct");
                }
            }

            return View();
        }





        public ActionResult Delete(string ID)
        {
            GetProductDB obj = new GetProductDB();
            var row = obj.getProducts().Find(model => model.fb_ID == ID);

            return View(row);
        }


        [HttpPost]
        public ActionResult Delete(string ID, GetProduct prr)
        {
           
                GetProductDB contex = new GetProductDB();
                bool check = contex.DeleteProduct(ID); 
                if (check)
                {
                    TempData["DeleteMessage"] = "Data has been deleted sucessfully";
                    
                    return RedirectToAction("GetProduct");
                }
                else
                {
                    TempData["DeleteMessage"] = "ID is already Existed";

                    return View("Delete");
                }
            

            return View();
        }
    }
}