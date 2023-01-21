using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Teacher model)
        {

            // To open a connection to the database
            using (var context = new TeacherDBEntities())
            {
                // Add data to the particular table
                context.Teachers.Add(model);

                // save the changes
                context.SaveChanges();
            }
            string message = "Created the record successfully";

            // To display the message on the screen
            // after the record is created successfully
            ViewBag.Message = message;

            // write @Viewbag.Message in the created
            // view at the place where you want to
            // display the message
            return View();
        }
        
            [HttpGet] // Set the attribute to Read
            public ActionResult
                Read()
            {
                using (var context = new TeacherDBEntities())
                {

                    // Return the list of data from the database
                    var data = context.Teachers.ToList();
                    return View(data);
                }
            }
        //public ActionResult Update(int id)
        //{
        //    using (var context = new TeacherDBEntities())
        //    {
        //        var data = context.Teachers.Where(x => x.ID == id).SingleOrDefault();
        //        return View(data);
        //    }
        //}

        //// To specify that this will be
        //// invoked when post method is called
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Update(int id, Teacher model)
        //{
        //    using (var context = new TeacherDBEntities())
        //    {

        //        // Use of lambda expression to access
        //        // particular record from a database
        //        var data = context.Teachers.FirstOrDefault(x => x.ID == id);

        //        // Checking if any such record exist
        //        if (data != null)
        //        {
        //           
        //            context.SaveChanges();

        //            // It will redirect to
        //            // the Read method
        //            return RedirectToAction("Read");
        //        }
        //        else
        //            return View();
        //    }
        //}
        public ActionResult Update(int id)
        {
            using (var context = new TeacherDBEntities())
            {
                var data = context.Teachers.Where(x => x.ID == id).SingleOrDefault();
                return View(data);
            }
        }

        // To specify that this will be
        // invoked when post method is called
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, Teacher model)
        {
            using (var context = new TeacherDBEntities())
            {

                // Use of lambda expression to access
                // particular record from a database
                var data = context.Teachers.FirstOrDefault(x => x.ID == id);

                // Checking if any such record exist
                if (data != null)
                {
                    data.FirstName = model.FirstName;
                    data.MiddleName = model.MiddleName;
                    data.LastName = model.LastName;
                    data.CNIC = model.CNIC;
                    data.Address = model.Address;
                    data.ContactNo = model.ContactNo;
                    data.Email = model.Email;
                    data.Department = model.Department;
                    data.Designation = model.Designation;
                    context.SaveChanges();

                    // It will redirect to
                    // the Read method
                    return RedirectToAction("Read");
                }
                else
                    return View();
            }
        }
    }
}