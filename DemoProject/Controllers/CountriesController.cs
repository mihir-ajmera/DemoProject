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
    public class CountriesController : Controller
    {
        private EntityContext db = new EntityContext();

        // GET: Countries
        public ActionResult Index(string keyword)
        {
            ViewBag.Keyword = keyword;
            var list = db.CountryDB.ToList();
            var auto = AutoMapper.Mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(list);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                auto = auto.Where(f => f.CountryName.Contains(keyword)).ToList();
            }

            return View(auto);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

       //POST: Countries/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create(CountryDto country)
        {
            if (ModelState.IsValid)
            {
                var create = AutoMapper.Mapper.Map<CountryDto, Country>(country);
                if(db.CountryDB.Any(o => o.CountryName == country.CountryName))
                {
                    ModelState.AddModelError("", "Country Already Exists");
                }
                else
                {
                    db.CountryDB.Add(create);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(country);
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.CountryDB.Find(id);
            var edit = AutoMapper.Mapper.Map<Country, CountryDto>(country);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(edit);
        }

        // POST: Countries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CountryDto country)
        {
            if (ModelState.IsValid)
            {
                var edit = AutoMapper.Mapper.Map<CountryDto, Country>(country);
                db.Entry(edit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.CountryDB.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            db.CountryDB.Remove(country);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Countries/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Country country = db.Users.Find(id);
        //    db.Users.Remove(country);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
