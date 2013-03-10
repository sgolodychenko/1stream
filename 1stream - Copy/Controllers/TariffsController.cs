using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _1stream.Models;

namespace _1stream.Controllers
{   
    public class TariffsController : Controller
    {
		private readonly ITariffRepository tariffRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public TariffsController() : this(new TariffRepository())
        {
        }

        public TariffsController(ITariffRepository tariffRepository)
        {
			this.tariffRepository = tariffRepository;
        }

        //
        // GET: /Tariffs/

        public ViewResult Index()
        {
            return View(tariffRepository.All);
        }

        //
        // GET: /Tariffs/Details/5

        public ViewResult Details(int id)
        {
            return View(tariffRepository.Find(id));
        }

        //
        // GET: /Tariffs/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Tariffs/Create

        [HttpPost]
        public ActionResult Create(Tariff tariff)
        {
            if (ModelState.IsValid) {
                tariffRepository.InsertOrUpdate(tariff);
                tariffRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Tariffs/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(tariffRepository.Find(id));
        }

        //
        // POST: /Tariffs/Edit/5

        [HttpPost]
        public ActionResult Edit(Tariff tariff)
        {
            if (ModelState.IsValid) {
                tariffRepository.InsertOrUpdate(tariff);
                tariffRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Tariffs/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(tariffRepository.Find(id));
        }

        //
        // POST: /Tariffs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            tariffRepository.Delete(id);
            tariffRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                tariffRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

