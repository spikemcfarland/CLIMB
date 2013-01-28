using System;
using System.Linq;
using System.Web.Mvc;
using CLIMB.Models;
using CLIMB.DataAccess;

namespace CLIMB.Controllers
{
    public class MaterialController : Controller
    {
        //
        // GET: /Material/

        public ActionResult Index()
        {
            var materialDB = new MaterialDB();
            return View(materialDB.GetMaterials());
        }
        public ActionResult Create()
        {
            try
            {
                var cvDB = new CvDB();
                ViewBag._MaterialType_key = new SelectList(cvDB.GetMaterialTypes(), "_MaterialType_key", "MaterialType");
                return View();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return View() ;
            }
        }

        //
        // POST: /Material/Create
        [HttpPost]
        public ActionResult Create(MaterialModel material)
        {
            try
            {
                var materialDB = new MaterialDB();
                var cvDB=new CvDB();
                material.MaterialTypeSelectList = new SelectList(cvDB.GetMaterialTypes(),"_MaterialType_key", "MaterialType");
                materialDB.Create(material);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int key)
        {              
                int materialKey = (int)key;
                var materialDB = new MaterialDB();
                var cvDB = new CvDB();
                MaterialModel material = materialDB.GetMaterialByKey(materialKey);
                material.MaterialTypeSelectList = new SelectList(cvDB.GetMaterialTypes(), "_MaterialType_key", "MaterialType");
                return View(material);
        }

        //
        // POST: /Material/Edit/ 
        [HttpPost]
        public ActionResult Edit(MaterialModel material)
        {
            try
            {
                // TODO: Add update logic here
                var materialDB = new MaterialDB();
                materialDB.Update(material);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int key)
        {
            var materialDB = new MaterialDB();
            materialDB.Delete(key);
            return RedirectToAction("Index");
        }
       
    }
}
