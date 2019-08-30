using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoProject.DAL;
using DemoProject.DataContexts;
using DemoProject.DTO;


namespace DemoProject.Controllers
{
    public class CitiesController : Controller
    {
        private EntityContext db = new EntityContext();

        // GET: Cities
        public ActionResult Index(string keyword)
        {
            ViewBag.Keyword = keyword;
            var list = db.CityDB.ToList();
            var auto = AutoMapper.Mapper.Map<IEnumerable<City>, IEnumerable<CityDto>>(list);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                auto = auto.Where(f => f.CityName.Contains(keyword)).ToList();
            }

            return View(auto);
        }

        // GET: States/Create
        public ActionResult Create()
        {

            var list = db.StateDB.ToList();
            var auto = AutoMapper.Mapper.Map<IEnumerable<State>, IEnumerable<StateDto>>(list);
            ViewBag.StateList = new SelectList(auto, "Id", "StateName");

            return View();
        }

        // POST: Cities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CityDto city)
        {
            var list = db.StateDB.ToList();
            var auto = AutoMapper.Mapper.Map<IEnumerable<State>, IEnumerable<StateDto>>(list);
            ViewBag.StateList = new SelectList(auto, "Id", "StateName");

            if (ModelState.IsValid)
            {
                var create = AutoMapper.Mapper.Map<CityDto, City>(city);
                if (db.CityDB.Any(o => o.CityName == city.CityName && o.StateID == city.StateID))
                {
                    ModelState.AddModelError("", "City Already Exists");
                }
                else
                {
                    db.CityDB.Add(create);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(city);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.CityDB.Find(id);
            var edit = AutoMapper.Mapper.Map<City, CityDto>(city);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(edit);
        }

        // POST: Cities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CityDto city)
        {
            if (ModelState.IsValid)
            {
                var edit = AutoMapper.Mapper.Map<CityDto, City>(city);
                db.Entry(edit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(city);
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.CityDB.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            db.CityDB.Remove(city);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}