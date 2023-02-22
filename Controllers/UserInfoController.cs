using Registration.DB;
using Registration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class UserInfoController : Controller
    {

        //DB Connection
        MyDBEntities db = new MyDBEntities();


        // GET: UserInfo
        public ActionResult List()
        {
            var gg = db.NewUserregistrations.ToList();

            return View(gg);
        }



        public ActionResult Create()
        {
            var model = new UserRegistrationvalid();


            //Gender List Radiobutton-(Model)
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Male", Value = "M" });
            items.Add(new SelectListItem { Text = "Femal", Value = "F" });
            items.Add(new SelectListItem { Text = "Other", Value = "O" });
            model.GenderItems = items;
            //ViewBag.GenderItems = items;





            //Qualification List-(ViewBag)
            List<SelectListItem> Qualificationitems = new List<SelectListItem>();
            Qualificationitems.Add(new SelectListItem { Text = "PG", Value = "PG" });
            Qualificationitems.Add(new SelectListItem { Text = "UG", Value = "UG" });
            Qualificationitems.Add(new SelectListItem { Text = "Diploma", Value = "Diploma" });
            //Assgin to ViewBag
            ViewBag.Items = Qualificationitems;


            //Course List-(Model)
            List <SelectListItem> Courseitems = new List<SelectListItem>();
            Courseitems.Add(new SelectListItem { Text = "Bcom", Value = "Bcom" });
            Courseitems.Add(new SelectListItem { Text = "BA", Value = "BA" });
            Courseitems.Add(new SelectListItem { Text = "Diploma", Value = "Diploma" });
            //Assgin to Model
            model.CourseItems = Courseitems;


            //Get Countries from Database
            ViewBag.country = new SelectList(db.Countries.ToList(), "CID", "CountryName");


            //Get State from Database
            ViewBag.state = new SelectList(db.States.ToList(), "SID","StateName");

            return View(model);
        }



        [HttpPost]
        public ActionResult Create(UserRegistrationvalid usr)
        {
            if(ModelState.IsValid)
            {
                NewUserregistration user = new NewUserregistration();

                user.FirstName = usr.FirstName;
                user.LastName = usr.LastName;
                user.DOB = usr.DOB;
                user.Gender = usr.Gender;
                user.MarriageStatus = usr.MarriageStatus;

                user.Qualification = usr.Qualification;
                user.Course = usr.Course;
                user.Language = usr.Language;
                user.Country = usr.Country;
                user.State = usr.State;
                user.Address = usr.Address;
                user.Mobile = usr.Mobile;
                user.Email = usr.Email;
                user.Password = usr.Password;

                user.Status = true;
                db.NewUserregistrations.Add(user);
                db.SaveChanges();

            }
            return View("Create");
        }




        [HttpPost]
        public JsonResult IsAlreadySigned(string Email)
        {

            var RegEmailId = (from u in db.NewUserregistrations
                              where u.Email.ToUpper() == Email.ToUpper()
                              select new { Email }).FirstOrDefault();

            bool status;
            if (RegEmailId != null)
            {
                //Already registered  
                status = false;
            }
            else
            {
                //Available to use  
                status = true;
            }

            return Json(status);

        }


    

    }
}