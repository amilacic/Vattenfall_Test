using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vattenfall_IT_test.Data;
using Vattenfall_IT_test.Models;

namespace Vattenfall_IT_test.Controllers
{
    public class FooController : Controller
    {
        // GET: Foo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListFoos()
        {
            return PartialView();
        }

        public ActionResult ManageFoo()
        {
            return PartialView();
        }

        // Get data
        [HttpPost]
        public ActionResult GetFooData()
        {
            return Json(new { FooList = new DBFooLogic().GetFoos() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetFooDataById([Bind(Include ="Id")] Guid Id)
        {
            return Json(new { Foo = new DBFooLogic().GetFoo(Id) }, JsonRequestBehavior.AllowGet);
        }

        // Save data
        [HttpPost]
        public ActionResult SaveFooData([Bind(Prefix ="model")] FooModels model)
        {
            return Json(new { Foo = new DBFooLogic().SaveFoo(model) }, JsonRequestBehavior.AllowGet);
        }

        // Edit data
        [HttpPost]
        public ActionResult EditFooData([Bind(Prefix = "model")] FooModels model)
        {
            return Json(new { Foo = new DBFooLogic().EditFoo(model) }, JsonRequestBehavior.AllowGet);
        }

        // Delete data
        [HttpPost]
        public ActionResult DeleteFooData([Bind(Prefix = "model")] FooModels model)
        {
            return Json(new { Foo = new DBFooLogic().DeleteFoo(model) }, JsonRequestBehavior.AllowGet);
        }

    }
}