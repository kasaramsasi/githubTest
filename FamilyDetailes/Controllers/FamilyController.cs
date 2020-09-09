using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace FamilyDetailes.Controllers
{
    public class FamilyController : Controller
    {
      
        public ActionResult Index()
        {

            FamilyBusinessLayer family = new FamilyBusinessLayer();
            List<FamilyMember> fmb = family.FamilyMembers.ToList();
            //FamilyBusinessLayer familyBusinessLayer = new FamilyBusinessLayer();
            //List<FamilyMember> familyMembers = new List<FamilyMember>();

            return View(fmb);

            //if (searchBy == "Gender")
            //{
            //    return View(family.FamilyMembers.Where(x => x.Gender == search || search == null).ToList());
            //}
            //else
            //{
            //    return View(family.FamilyMembers.Where(x => x.Name.StartsWith(search) || search == null).ToList());
            //}
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            FamilyBusinessLayer familyBusinessLayer = new FamilyBusinessLayer();
            FamilyMember fm = familyBusinessLayer.FamilyMembers.Single(fam => fam.id == id);
            return View(fm);
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
         
            //FamilyMember fm = new FamilyMember();
            //fm.Name = Name;
            //fm.Gender = Gender;
            //fm.City = City;
            //fm.Mobileno = Mobileno;
            //fm.DateoOfBirth = Convert.ToDateTime(DateOfBirth);
            if(ModelState.IsValid)
            {
                FamilyMember fm = new FamilyMember();
                UpdateModel(fm);
                FamilyBusinessLayer familyBusinessLayer = new FamilyBusinessLayer();
                familyBusinessLayer.AddFamilyMember(fm);

                return RedirectToAction("Index");
            }
            return View();
            

        }
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    //foreach(String key in formCollection.AllKeys)
        //    //{
        //    //    Response.Write(key);
        //    //    Response.Write(formCollection[key]);
        //    //    Response.Write("<br/>");
        //    //}

        //    FamilyMember fm = new FamilyMember();
        //    fm.Name = formCollection["Name"];
        //    fm.Gender = formCollection["Gender"];
        //    fm.City = formCollection["City"];
        //    fm.Mobileno = formCollection["Mobileno"];
        //    fm.DateoOfBirth = Convert.ToDateTime(formCollection["DateoOfBirth"]);

        //    FamilyBusinessLayer familyBusinessLayer = new FamilyBusinessLayer();
        //    familyBusinessLayer.AddFamilyMember(fm);

        //    return RedirectToAction("Index")

        //    return View();
        //}
        [HttpPost]
        public ActionResult Edit(FamilyMember fmes)
        {
            if (ModelState.IsValid)
            {
                FamilyBusinessLayer familyBusinessLayer = new FamilyBusinessLayer();
               familyBusinessLayer.EditFamily(fmes);

                return RedirectToAction("Index");
            }
           return View();
        }
        [HttpPost]
       public ActionResult Delete(int id)
        {
            if(ModelState.IsValid)
            {
                FamilyBusinessLayer familyBusinessLayer = new FamilyBusinessLayer();
                familyBusinessLayer.DeleteFamily(id);
                return RedirectToAction("Index");
            }
            
            return View();
        }

        public PartialViewResult SideNavBar()
        {
            return PartialView();
        }
    }

    
}