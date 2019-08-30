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
    public class StatesController : Controller
    {
        private EntityContext db = new EntityContext();

        // GET: States
        public ActionResult Index(string keyword)
        {

            ViewBag.Keyword = keyword;
            var list = db.StateDB.ToList();
            var auto = AutoMapper.Mapper.Map<IEnumerable<State>, IEnumerable<StateDto>>(list);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                auto = auto.Where(f => f.StateName.Contains(keyword)).ToList();
            }

            return View(auto);
        }

        // GET: States/Create
        public ActionResult Create()
        {

            var list = db.CountryDB.ToList();
            var auto = AutoMapper.Mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(list);
            ViewBag.CountryList = new SelectList(auto, "Id", "CountryName");

            return View();
        }

        // POST: States/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StateDto state)
        {
            var list = db.CountryDB.ToList();
            var auto = AutoMapper.Mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(list);
            ViewBag.CountryList = new SelectList(auto, "Id", "CountryName");

            if (ModelState.IsValid)
            {
                var create = AutoMapper.Mapper.Map<StateDto, State>(state);
                if (db.StateDB.Any(o => o.StateName == state.StateName && o.CountryId == state.CountryId))
                {
                    ModelState.AddModelError("", "State Already Exists");
                }
                else
                {
                    db.StateDB.Add(create);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }            
            }

            return View(state);
        }

        // GET: States/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = db.StateDB.Find(id);
            var edit = AutoMapper.Mapper.Map<State, StateDto>(state);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(edit);
        }

        // POST: States/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StateDto state)
        {
            if (ModelState.IsValid)
            {
                var edit = AutoMapper.Mapper.Map<StateDto, State>(state);
                db.Entry(edit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(state);
        }

        // GET: States/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = db.StateDB.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            db.StateDB.Remove(state);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}