using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyDiary.CQRS.Configuration;
using MyDiary.CQRS.Commands;
using MyDiary.CQRS.Reporting;

namespace MyDiary.CQRS.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var items = ServiceLocator.ReportDatabase.GetItems();
            return View(items);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(DiaryItemDto item)
        {
            ServiceLocator.CommanBus.Send(new CreateItemCommand(Guid.NewGuid() ,item.Title,item.Description,item.Version,item.From,item.To));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Guid Id)
        {
            var item = ServiceLocator.ReportDatabase.GetById(Id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Guid Id,DiaryItemDto item)
        {
            ServiceLocator.CommanBus.Send(new ChangeItemCommand(Id,item.Title,item.Description,item.Version,item.From,item.To));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid Id)
        {
            var item=ServiceLocator.ReportDatabase.GetById(Id);

            ServiceLocator.CommanBus.Send(new DeleteItemCommand(Id,item.Version));
            return RedirectToAction("Index");
        }
    }
}