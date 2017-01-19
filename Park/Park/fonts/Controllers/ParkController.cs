using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Park.Controllers
{
    public class ParkController : Controller
    {
        // GET: Park
        public ActionResult PHome()
        {
            Service.DatabaseService db = new Service.DatabaseService();
            var list = db.LoadAllPark();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            Service.areaService db = new Service.areaService();
            var list = db.GETAll();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in list)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value=item.Name.ToString(),
                });
            }
            ViewBag.Map_area = items;
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult Create(Models.Park newPark)
        {
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                var File = Request.Files[0];
                string dir = string.Format("~/Content/Image/");
                var TrueDir = System.Web.Hosting.HostingEnvironment.MapPath(dir);
                if (!System.IO.Directory.Exists(TrueDir))
                {
                    System.IO.Directory.CreateDirectory(TrueDir);
                }
                var SaveDir = System.IO.Path.Combine(TrueDir, File.FileName);

                File.SaveAs(SaveDir);

                newPark.Map = this.Url.Content(System.IO.Path.Combine(dir, File.FileName));

                //System.Drawing.Image image = System.Drawing.Image.FromStream(File.InputStream);

            }


            Service.DatabaseService db = new Service.DatabaseService();
            //newPark.Manager = Guid.NewGuid().ToString();
            db.CreatePark(newPark);
            return RedirectToAction("ok");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            Service.DatabaseService db = new Service.DatabaseService();
            Service.areaService db1 = new Service.areaService();
            var model = db.GetParkByID(id);
            var list = db1.GETAll();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in list)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Name.ToString(),
                });
            }
            ViewBag.Map_area = items;




            return View(model);
        }
        [HttpPost]
        public RedirectToRouteResult Update(Models.Park newPark)
        {
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                var File = Request.Files[0];
                string dir = string.Format("~/Content/Image/");
                var TrueDir = System.Web.Hosting.HostingEnvironment.MapPath(dir);
                if (!System.IO.Directory.Exists(TrueDir))
                {
                    System.IO.Directory.CreateDirectory(TrueDir);
                }
                var SaveDir = System.IO.Path.Combine(TrueDir, File.FileName);

                File.SaveAs(SaveDir);

                newPark.Map = this.Url.Content(System.IO.Path.Combine(dir, File.FileName));

                //System.Drawing.Image image = System.Drawing.Image.FromStream(File.InputStream);


            }


            Service.DatabaseService db = new Service.DatabaseService();
            db.UpdatePark(newPark);
            return RedirectToAction("ok");
        }

        public ActionResult Delete(string id)
        {
            Service.DatabaseService db = new Service.DatabaseService();
            db.DeletePark(id);
            return RedirectToAction("PHome");
        }
        public ActionResult ok()
        {
            return View();
        }

    }
}